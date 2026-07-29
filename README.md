<div align="center">

<img src="banner.svg" alt="AutoPlay Toggle — Jellyfin Plugin" width="100%">

<br/>
<br/>

[![Jellyfin](https://img.shields.io/badge/Jellyfin-10.11.x-00a4dc?style=flat-square&logo=jellyfin&logoColor=white)](https://jellyfin.org)
[![License](https://img.shields.io/github/license/fabianoortega-ops/jellyfin-autoplay-toggle?style=flat-square&color=green)](LICENSE)
[![Languages](https://img.shields.io/badge/languages-25-brightgreen?style=flat-square)](#-supported-languages)
[![JavaScript Injector](https://img.shields.io/badge/requires-JavaScript%20Injector-orange?style=flat-square)](https://github.com/n00bcodr/Jellyfin-JavaScript-Injector)

<br/>

**[🌐 Website](https://fabianoortega-ops.github.io/jellyfin-autoplay-toggle) · [📦 Install](#-installation) · [🌍 Languages](#-supported-languages) · [🐛 Issues](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/issues)**

<br/>

---

### 🌍 Translations
[🇧🇷 Português](README.pt.md) · [🇩🇪 Deutsch](README.de.md) · [🇫🇷 Français](README.fr.md) · [🇪🇸 Español](README.es.md) · [🇮🇹 Italiano](README.it.md) · [🇷🇺 Русский](README.ru.md) · [🇨🇳 中文](README.zh.md) · [🇯🇵 日本語](README.ja.md) · [🇰🇷 한국어](README.ko.md) · [🇵🇱 Polski](README.pl.md)  
*Want to add your language? [Open a PR!](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/pulls)*

---

</div>

## 🎯 What it does

AutoPlay Toggle adds a **🔁 button** between the favorite and subtitle buttons in the Jellyfin video player. One click enables or disables autoplay for the next episode — no menus, no settings pages, no interruptions.

```
  ♥  🔁  CC  🎵  ─────────  ⚙  ⛶
       ↑
  AutoPlay Toggle
```

- **Bright icon** → next episode autoplay is **on**
- **Dim icon** → next episode autoplay is **off**
- Changes are instant and persist across all your sessions

---

## ✨ Features

| Feature | Description |
|---|---|
| 🎮 **In-Player Button** | Sits between ♥ and CC — right where you need it |
| ⚡ **Instant Toggle** | Changes apply immediately, no page reload |
| 🌍 **25 Languages** | Auto-detects your browser language |
| 🔧 **REST API** | `GET /AutoPlay/Status` · `POST /AutoPlay/Toggle` |
| 📊 **Dashboard Panel** | Also accessible from the Jellyfin sidebar |
| 🚀 **Hot Reload** | UI updates via `git push` — no server restart needed |

---

## 📦 Installation

> **Requires** the [JavaScript Injector](https://github.com/n00bcodr/Jellyfin-JavaScript-Injector) plugin by n00bcodr. Install it from the Jellyfin Catalog first.

**1. Add the repository**

Go to **Dashboard → Plugins → Repositories → +** and add:

```
https://fabianoortega-ops.github.io/jellyfin-autoplay-toggle/manifest.json
```

**2. Install the plugin**

Go to **Catalog**, find **AutoPlay Toggle** and click **Install**.

**3. Restart Jellyfin**

Restart once to load the plugin. The 🔁 button will appear automatically in the player.

---

## 🌍 Supported Languages

The button tooltip is automatically shown in your browser's language.

| Language | Code | On | Off |
|---|---|---|---|
| English | `en` | Next episode: On | Next episode: Off |
| Português | `pt` | Próximo episódio: Ligado | Próximo episódio: Desligado |
| Deutsch | `de` | Nächste Folge: Ein | Nächste Folge: Aus |
| Français | `fr` | Épisode suivant: Activé | Épisode suivant: Désactivé |
| Español | `es` | Siguiente episodio: Activado | Siguiente episodio: Desactivado |
| Italiano | `it` | Episodio successivo: Attivo | Episodio successivo: Inattivo |
| Nederlands | `nl` | Volgend aflevering: Aan | Volgend aflevering: Uit |
| Русский | `ru` | Следующий эпизод: Вкл | Следующий эпизод: Выкл |
| 中文 | `zh` | 下一集：开启 | 下一集：关闭 |
| 日本語 | `ja` | 次のエピソード: オン | 次のエピソード: オフ |
| 한국어 | `ko` | 다음 에피소드: 켜짐 | 다음 에피소드: 꺼짐 |
| Polski | `pl` | Następny odcinek: Włączone | Następny odcinek: Wyłączone |
| Svenska | `sv` | Nästa avsnitt: På | Nästa avsnitt: Av |
| Norsk | `nb` | Neste episode: På | Neste episode: Av |
| Dansk | `da` | Næste afsnit: Til | Næste afsnit: Fra |
| Suomi | `fi` | Seuraava jakso: Päällä | Seuraava jakso: Pois |
| Čeština | `cs` | Další epizoda: Zapnuto | Další epizoda: Vypnuto |
| Slovenčina | `sk` | Ďalšia epizóda: Zapnuté | Ďalšia epizóda: Vypnuté |
| Magyar | `hu` | Következő rész: Be | Következő rész: Ki |
| Română | `ro` | Episodul următor: Activat | Episodul următor: Dezactivat |
| Türkçe | `tr` | Sonraki bölüm: Açık | Sonraki bölüm: Kapalı |
| العربية | `ar` | الحلقة التالية: تشغيل | الحلقة التالية: إيقاف |
| Українська | `uk` | Наступний епізод: Увімк | Наступний епізод: Вимк |
| Ελληνικά | `el` | Επόμενο επεισόδιο: Ενεργό | Επόμενο επεισόδιο: Ανενεργό |
| Català | `ca` | Episodi següent: Activat | Episodi següent: Desactivat |

Missing your language? [Open an issue](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/issues) or submit a PR.

---

## 💬 Community

Join the Jellyfin community to get help, share feedback, or just hang out:

| Platform | Link |
|---|---|
| 💬 Discord (Official) | [discord.gg/zHBxVSXdBV](https://discord.gg/zHBxVSXdBV) |
| 💬 Discord (Community) | [discord.gg/N3M99fNxbK](https://discord.gg/N3M99fNxbK) |
| 🌐 Forum | [forum.jellyfin.org](https://forum.jellyfin.org) |
| 🔷 Matrix | [#jellyfin:matrix.org](https://matrix.to/#/#jellyfin:matrix.org) |
| 🟠 Reddit | [r/jellyfin](https://www.reddit.com/r/jellyfin) · [r/JellyfinCommunity](https://www.reddit.com/r/JellyfinCommunity) |

---


---

## 🔗 Related

Other Jellyfin plugins and tools you might find useful:

- [JavaScript Injector](https://github.com/n00bcodr/Jellyfin-JavaScript-Injector) — Required dependency. Inject custom JavaScript into the Jellyfin interface.
- [Jellyfin Enhanced](https://github.com/MakD/jellyfin-enhanced) — Adds ratings, tag badges, OSD improvements, and much more to Jellyfin.
- [Intro Skipper](https://github.com/intro-skipper/intro-skipper) — Automatically detects and skips intros, credits, and recaps.
- [awesome-jellyfin](https://github.com/awesome-jellyfin/awesome-jellyfin) — A curated list of awesome Jellyfin plugins, themes, and tools.
- [Jellyfin](https://github.com/jellyfin/jellyfin) — The free software media system this plugin is built for.

## 🤝 Contributing

Contributions are welcome! You can help by:

- 🌍 **Translating** — add a `README.xx.md` for your language
- 🐛 **Reporting bugs** — [open an issue](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/issues)
- 💡 **Suggesting features** — ideas are welcome
- ⭐ **Starring the repo** — helps others discover it

---

<div align="center">

Made with ♥ for the [Jellyfin](https://jellyfin.org) community

[MIT License](LICENSE) · [Website](https://fabianoortega-ops.github.io/jellyfin-autoplay-toggle) · [Releases](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/releases)

</div>
