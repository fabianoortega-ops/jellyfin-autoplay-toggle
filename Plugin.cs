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
        private void RegisterWithJavaScriptInjector()
        {
            _ = Task.Run(async () =>
            {
                const int maxAttempts = 10;
                for (int attempt = 1; attempt <= maxAttempts; attempt++)
                {
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
        private string BuildPlayerScript() => $@"
(function () {{
    var s = document.createElement('script');
    s.src = 'https:
    s.onerror = function() {{ console.warn('[AutoPlayToggle] Falha ao carregar script remoto.'); }};
    document.head.appendChild(s);
}}());
";
        public IEnumerable<PluginPageInfo> GetPages() => new[]
        {
            new PluginPageInfo
            {
                Name                 = "AutoPlayToggle",
                EmbeddedResourcePath = $"{GetType().Namespace}.Configuration.config.html",
                EnableInMainMenu     = false,
                DisplayName          = "AutoPlay Toggle",
                MenuIcon             = "play_arrow",
                MenuSection          = "server"
            }
        };
    }
}
