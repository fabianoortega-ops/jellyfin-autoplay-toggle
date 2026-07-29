using System;
using System.Collections.Generic;
using MediaBrowser.Common.Configuration;
using MediaBrowser.Common.Plugins;
using MediaBrowser.Model.Plugins;
using MediaBrowser.Model.Serialization;

namespace JellyfinAutoPlayToggle
{
    /// <summary>
    /// Plugin principal. Registra o nome, ID e a página de configuração
    /// que aparece no menu lateral do Jellyfin Dashboard.
    /// </summary>
    public class Plugin : BasePlugin<PluginConfiguration>, IHasWebPages
    {
        // Referência estática usada pelo Controller para acessar a instância ativa.
        public static Plugin? Instance { get; private set; }

        public Plugin(IApplicationPaths applicationPaths, IXmlSerializer xmlSerializer)
            : base(applicationPaths, xmlSerializer)
        {
            Instance = this;
        }

        /// <inheritdoc />
        public override string Name => "AutoPlay Toggle";

        /// <inheritdoc />
        public override string Description => "Adiciona um botão para ligar/desligar o autoplay do próximo episódio diretamente pelo Dashboard.";

        /// <inheritdoc />
        // GUID único gerado para este plugin — não altere após instalar,
        // pois o Jellyfin usa este valor para identificar o plugin.
        public override Guid Id => Guid.Parse("036768e6-cd63-49c0-9661-2677d3ccef72");

        /// <inheritdoc />
        // Registra a página HTML embutida no .dll como página do Dashboard.
        public IEnumerable<PluginPageInfo> GetPages()
        {
            return new[]
            {
                new PluginPageInfo
                {
                    Name              = "AutoPlayToggle",
                    EmbeddedResourcePath = $"{GetType().Namespace}.Configuration.config.html",
                    EnableInMainMenu  = true,
                    DisplayName       = "AutoPlay Toggle",
                    MenuIcon          = "play_arrow",
                    MenuSection       = "server"
                }
            };
        }
    }
}
