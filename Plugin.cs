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

    // ── i18n: detecta o idioma do browser e usa o texto correto ─────────────
    var i18n = (function () {
        var full = (navigator.language || 'en').toLowerCase();
        var lang = full.split('-')[0];

        var map = {
            'en': { on: 'Next episode: On',              off: 'Next episode: Off',              loading: 'Next episode: loading…'          },
            'pt': { on: 'Próximo episódio: Ligado',       off: 'Próximo episódio: Desligado',    loading: 'Próximo episódio: aguardando…'   },
            'de': { on: 'Nächste Folge: Ein',             off: 'Nächste Folge: Aus',             loading: 'Nächste Folge: lädt…'            },
            'fr': { on: 'Épisode suivant: Activé',        off: 'Épisode suivant: Désactivé',     loading: 'Épisode suivant: chargement…'    },
            'es': { on: 'Siguiente episodio: Activado',   off: 'Siguiente episodio: Desactivado',loading: 'Siguiente episodio: cargando…'   },
            'it': { on: 'Episodio successivo: Attivo',    off: 'Episodio successivo: Inattivo',  loading: 'Episodio successivo: caricamento…'},
            'nl': { on: 'Volgend aflevering: Aan',        off: 'Volgend aflevering: Uit',        loading: 'Volgend aflevering: laden…'      },
            'ru': { on: 'Следующий эпизод: Вкл',          off: 'Следующий эпизод: Выкл',         loading: 'Следующий эпизод: загрузка…'     },
            'zh': { on: '下一集：开启',                     off: '下一集：关闭',                    loading: '下一集：加载中…'                  },
            'ja': { on: '次のエピソード: オン',              off: '次のエピソード: オフ',             loading: '次のエピソード: 読み込み中…'      },
            'ko': { on: '다음 에피소드: 켜짐',               off: '다음 에피소드: 꺼짐',              loading: '다음 에피소드: 로딩 중…'          },
            'pl': { on: 'Następny odcinek: Włączone',     off: 'Następny odcinek: Wyłączone',    loading: 'Następny odcinek: ładowanie…'    },
            'sv': { on: 'Nästa avsnitt: På',              off: 'Nästa avsnitt: Av',              loading: 'Nästa avsnitt: laddar…'          },
            'nb': { on: 'Neste episode: På',              off: 'Neste episode: Av',              loading: 'Neste episode: laster…'          },
            'da': { on: 'Næste afsnit: Til',              off: 'Næste afsnit: Fra',              loading: 'Næste afsnit: indlæser…'         },
            'fi': { on: 'Seuraava jakso: Päällä',         off: 'Seuraava jakso: Pois',           loading: 'Seuraava jakso: ladataan…'       },
            'cs': { on: 'Další epizoda: Zapnuto',         off: 'Další epizoda: Vypnuto',         loading: 'Další epizoda: načítání…'        },
            'sk': { on: 'Ďalšia epizóda: Zapnuté',        off: 'Ďalšia epizóda: Vypnuté',       loading: 'Ďalšia epizóda: načítavanie…'   },
            'hu': { on: 'Következő rész: Be',             off: 'Következő rész: Ki',             loading: 'Következő rész: betöltés…'       },
            'ro': { on: 'Episodul următor: Activat',      off: 'Episodul următor: Dezactivat',   loading: 'Episodul următor: se încarcă…'   },
            'tr': { on: 'Sonraki bölüm: Açık',            off: 'Sonraki bölüm: Kapalı',          loading: 'Sonraki bölüm: yükleniyor…'      },
            'ar': { on: 'الحلقة التالية: تشغيل',          off: 'الحلقة التالية: إيقاف',          loading: 'الحلقة التالية: جار التحميل…'   },
            'uk': { on: 'Наступний епізод: Увімк',        off: 'Наступний епізод: Вимк',         loading: 'Наступний епізод: завантаження…' },
            'el': { on: 'Επόμενο επεισόδιο: Ενεργό',     off: 'Επόμενο επεισόδιο: Ανενεργό',   loading: 'Επόμενο επεισόδιο: φόρτωση…'    },
            'ca': { on: 'Episodi següent: Activat',       off: 'Episodi següent: Desactivat',    loading: 'Episodi següent: carregant…'     }
        };

        return map[full] || map[lang] || map['en'];
    }());

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
        btn.title   = enabled ? i18n.on : i18n.off;
        btn.style.opacity = enabled ? '1' : '0.4';
    }

    function createButton() {
        var btn = document.createElement('button');
        btn.id = BTN_ID;
        btn.type = 'button';
        btn.className = 'paper-icon-button-light';
        btn.style.cssText = 'vertical-align:middle;margin:0 2px;padding:0;background:none;border:none;cursor:pointer;color:inherit;opacity:0.4;';
        btn.innerHTML = '<span class=""material-icons"" style=""font-size:22px"">repeat</span>';
        btn.title = i18n.loading;

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
                    console.log('[AutoPlayToggle] ' + (d.enableNextEpisodeAutoPlay ? i18n.on : i18n.off));
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

        var ref = document.querySelector('.btnSubtitles') ||
                  document.querySelector('.btnFullscreen');

        if (!ref) return;

        var btn = createButton();
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
