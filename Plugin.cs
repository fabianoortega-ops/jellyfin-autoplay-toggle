using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Threading.Tasks;
using MediaBrowser.Common.Configuration;
using MediaBrowser.Common.Plugins;
using MediaBrowser.Model.Plugins;
using MediaBrowser.Model.Serialization;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace JellyfinAutoPlayToggle
{
    public class Plugin : BasePlugin<PluginConfiguration>, IHasWebPages
    {
        public static Plugin? Instance { get; private set; }
        private readonly ILogger<Plugin> _logger;

        public Plugin(
            IApplicationPaths applicationPaths,
            IXmlSerializer xmlSerializer,
            ILogger<Plugin> logger)
            : base(applicationPaths, xmlSerializer)
        {
            Instance = this;
            _logger  = logger;
            RegisterWithJavaScriptInjector();
        }

        public override string Name        => "AutoPlay Toggle";
        public override string Description => "Botão no player para ligar/desligar o autoplay do próximo episódio.";
        public override Guid   Id          => Guid.Parse("036768e6-cd63-49c0-9661-2677d3ccef72");

        // Roda em background com retry — o Injector pode ainda não estar pronto
        // quando nosso plugin é carregado pelo Jellyfin.
        private void RegisterWithJavaScriptInjector()
        {
            _ = Task.Run(async () =>
            {
                const int maxAttempts = 10;
                for (int attempt = 1; attempt <= maxAttempts; attempt++)
                {
                    // Aguarda crescentemente: 3s, 6s, 9s … até 30s
                    await Task.Delay(TimeSpan.FromSeconds(attempt * 3)).ConfigureAwait(false);

                    try
                    {
                        var injectorAssembly = FindAssembly("Jellyfin.Plugin.JavaScriptInjector");
                        if (injectorAssembly == null)
                        {
                            _logger.LogInformation("[AutoPlayToggle] JavaScript Injector não encontrado.");
                            return;
                        }

                        var iface = injectorAssembly.GetType("Jellyfin.Plugin.JavaScriptInjector.PluginInterface");
                        if (iface == null)
                        {
                            _logger.LogWarning("[AutoPlayToggle] PluginInterface não encontrado.");
                            return;
                        }

                        var payload = new JObject
                        {
                            { "id",                     $"{Id}-player-btn"       },
                            { "name",                   "AutoPlay Toggle Button" },
                            { "script",                 BuildPlayerScript()      },
                            { "enabled",                true                     },
                            { "requiresAuthentication", true                     },
                            { "pluginId",               Id.ToString()            },
                            { "pluginName",             Name                     },
                            { "pluginVersion",          Version.ToString()       }
                        };

                        var result = iface.GetMethod("RegisterScript")?.Invoke(null, new object[] { payload });
                        if (result is bool ok && ok)
                        {
                            _logger.LogInformation("[AutoPlayToggle] Script registrado no JavaScript Injector (tentativa {A}).", attempt);
                            return;
                        }

                        _logger.LogWarning("[AutoPlayToggle] RegisterScript retornou falso (tentativa {A}/{M}).", attempt, maxAttempts);
                    }
                    catch (TargetInvocationException ex)
                        when (ex.InnerException is InvalidOperationException)
                    {
                        _logger.LogDebug("[AutoPlayToggle] Injector ainda não pronto (tentativa {A}/{M}), aguardando…", attempt, maxAttempts);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "[AutoPlayToggle] Erro inesperado ao registrar (tentativa {A}).", attempt);
                        return;
                    }
                }

                _logger.LogWarning("[AutoPlayToggle] Não foi possível registrar após {M} tentativas.", maxAttempts);
            });
        }

        private static Assembly? FindAssembly(string name) =>
            AssemblyLoadContext.All
                .SelectMany(ctx => ctx.Assemblies)
                .FirstOrDefault(a => a.FullName?.Contains(name) ?? false);

        private static string BuildPlayerScript() => @"
(function () {
    'use strict';
    var BTN_ID = 'apt-player-btn';
    var _state = null;

    function getToken() {
        try {
            var ac = window.ApiClient;
            if (!ac) return '';
            return (typeof ac.accessToken === 'function' ? ac.accessToken() : ac.accessToken) || '';
        } catch(e) { return ''; }
    }

    function getUserId() {
        try {
            var ac = window.ApiClient;
            if (!ac) return '';
            return (typeof ac.getCurrentUserId === 'function' ? ac.getCurrentUserId() : ac.currentUserId) || '';
        } catch(e) { return ''; }
    }

    function api(method, path, body) {
        return fetch(window.location.origin + '/' + path, {
            method: method,
            headers: {
                'Authorization': 'MediaBrowser Token=""' + getToken() + '""',
                'Content-Type':  'application/json'
            },
            body: body ? JSON.stringify(body) : undefined
        }).then(function(r) { return r.json(); });
    }

    function applyState(btn, enabled) {
        _state = enabled;
        btn.title = enabled ? 'Autoplay: Ligado (clique para desligar)' : 'Autoplay: Desligado (clique para ligar)';
        btn.style.opacity = enabled ? '1' : '0.4';
    }

    function createButton() {
        var btn = document.createElement('button');
        btn.id = BTN_ID;
        btn.type = 'button';
        btn.className = 'paper-icon-button-light';
        btn.style.cssText = 'vertical-align:middle;margin:0 2px;padding:0;background:none;border:none;cursor:pointer;color:inherit;opacity:0.4;';
        btn.innerHTML = '<span class=""material-icons"" style=""font-size:22px"">repeat</span>';
        btn.title = 'Autoplay';

        var uid = getUserId();
        if (uid) {
            api('GET', 'AutoPlay/Status/' + uid)
                .then(function(d) { applyState(btn, d.enableNextEpisodeAutoPlay); })
                .catch(function(e) { console.warn('[AutoPlayToggle] Erro ao carregar estado:', e); });
        }

        btn.addEventListener('click', function(e) {
            e.stopPropagation();
            var uid = getUserId();
            if (!uid) return;
            btn.disabled = true;
            api('POST', 'AutoPlay/Toggle', { UserId: uid, Enable: !_state })
                .then(function(d) {
                    applyState(btn, d.enableNextEpisodeAutoPlay);
                    btn.disabled = false;
                    console.log('[AutoPlayToggle] Autoplay: ' + (d.enableNextEpisodeAutoPlay ? 'Ligado' : 'Desligado'));
                })
                .catch(function(e) {
                    console.error('[AutoPlayToggle] Erro ao alternar:', e);
                    btn.disabled = false;
                });
        });

        return btn;
    }

    function inject() {
        if (document.getElementById(BTN_ID)) return;

        var ref = document.querySelector('.btnFullscreen') ||
                  document.querySelector('.btnPip') ||
                  document.querySelector('.btnVideoOsdSettings');

        if (!ref) return;

        var btn = createButton();
        // Usa ref.parentNode para garantir que o insert é sempre válido
        ref.parentNode.insertBefore(btn, ref);

        console.log('[AutoPlayToggle] Botão injetado no player.');
    }

    new MutationObserver(inject).observe(document.body, { childList: true, subtree: true });
    setInterval(inject, 1000);
    console.log('[AutoPlayToggle] Player script carregado.');
}());
";

        public IEnumerable<PluginPageInfo> GetPages() => new[]
        {
            new PluginPageInfo
            {
                Name                 = "AutoPlayToggle",
                EmbeddedResourcePath = $"{GetType().Namespace}.Configuration.config.html",
                EnableInMainMenu     = true,
                DisplayName          = "AutoPlay Toggle",
                MenuIcon             = "play_arrow",
                MenuSection          = "server"
            }
        };
    }
}
