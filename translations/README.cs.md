<div align="center">

<img src="banner.svg" alt="AutoPlay Toggle" width="100%">

<br/><br/>

[![Jellyfin](https://img.shields.io/badge/Jellyfin-10.11.x-00a4dc?style=flat-square&logo=jellyfin&logoColor=white)](https://jellyfin.org)
[![License](https://img.shields.io/badge/license-MIT-green?style=flat-square)](LICENSE)
[![Languages](https://img.shields.io/badge/languages-25-brightgreen?style=flat-square)](#supported-languages)
[![JavaScript Injector](https://img.shields.io/badge/requires-JavaScript%20Injector-orange?style=flat-square)](https://github.com/n00bcodr/Jellyfin-JavaScript-Injector)

<br/>

**[🌐 Webová stránka](https://fabianoortega-ops.github.io/jellyfin-autoplay-toggle) · [📦 Instalovat](#installation) · [🌍 Jazyky](#supported-languages) · [🐛 Problémy](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/issues)**

<br/>

---

### 🌍 Překlady
[🇬🇧 English](../README.md) · [🇧🇷 Português](README.pt.md) · [🇩🇪 Deutsch](README.de.md) · [🇫🇷 Français](README.fr.md) · [🇪🇸 Español](README.es.md) · [🇮🇹 Italiano](README.it.md) · [🇷🇺 Русский](README.ru.md) · [🇨🇳 中文](README.zh.md) · [🇯🇵 日本語](README.ja.md) · [🇰🇷 한국어](README.ko.md) · [🇵🇱 Polski](README.pl.md)  
*Chcete přidat svůj jazyk? [Otevřete PR!](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/pulls)*

---

</div>

## 🎯 Co to dělá

AutoPlay Toggle přidá **tlačítko 🔁** mezi tlačítko oblíbených a titulků v přehrávači videa Jellyfin.

```
  ♥  🔁  CC  🎵  ─────────  ⚙  ⛶
       ↑
  AutoPlay Toggle
```

- **Světlá ikona** → automatické přehrávání další epizody **zapnuto**
- **Tmavá ikona** → automatické přehrávání další epizody **vypnuto**
- Změny se projeví okamžitě a zachovají se ve všech relacích

---

## ✨ Features

| Feature | Description |
|---|---|
| 🎮 **In-Player Button** | Sits between ♥ and CC — right where you need it |
| ⚡ **Instant Toggle** | Changes apply immediately, no page reload |
| 🌍 **25 Languages** | Auto-detects your browser language |

---

## 📦 Installation

### Step 1 — Install JavaScript Injector (required dependency)

AutoPlay Toggle requires the [JavaScript Injector](https://github.com/n00bcodr/Jellyfin-JavaScript-Injector) plugin by n00bcodr to inject the button into the player.

Go to **Dashboard → Plugins → Repositories → +** and add:

```
https://raw.githubusercontent.com/n00bcodr/jellyfin-plugins/main/10.11/manifest.json
```

> For Jellyfin 10.10.x use: `https://raw.githubusercontent.com/n00bcodr/jellyfin-plugins/main/10.10/manifest.json`

Go to **Catalog**, find **JavaScript Injector** and click **Install**. Restart Jellyfin.

> **Docker / TrueNAS users:** if you see `Access to the path '/usr/share/jellyfin/web/index.html' is denied` in the logs, also install [File Transformation](https://github.com/IAmParadox27/jellyfin-plugin-file-transformation) (v2.2.1.0+). It resolves permission issues on containerized installs.

---

### Step 2 — Install AutoPlay Toggle

Go to **Dashboard → Plugins → Repositories → +** and add:

```
https://fabianoortega-ops.github.io/jellyfin-autoplay-toggle/manifest.json
```

Go to **Catalog**, find **AutoPlay Toggle** and click **Install**.

---

### Step 3 — Restart Jellyfin

Restart once to load both plugins. The 🔁 button will appear automatically between ♥ and CC in the player.
---

## 🌍 Supported Languages

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

---

## 💬 Community

| Platform | Link |
|---|---|
| 💬 Discord (Official) | [discord.gg/zHBxVSXdBV](https://discord.gg/zHBxVSXdBV) |
| 💬 Discord (Community) | [discord.gg/N3M99fNxbK](https://discord.gg/N3M99fNxbK) |
| 🌐 Forum | [forum.jellyfin.org](https://forum.jellyfin.org) |
| 🔷 Matrix | [#jellyfin:matrix.org](https://matrix.to/#/#jellyfin:matrix.org) |
| 🟠 Reddit | [r/jellyfin](https://www.reddit.com/r/jellyfin) · [r/JellyfinCommunity](https://www.reddit.com/r/JellyfinCommunity) |

---

## 🔗 Related

- [JavaScript Injector](https://github.com/n00bcodr/Jellyfin-JavaScript-Injector) — Required dependency.
- [Jellyfin Enhanced](https://github.com/MakD/jellyfin-enhanced) — Adds ratings, badges, OSD improvements and more.
- [Intro Skipper](https://github.com/intro-skipper/intro-skipper) — Automatically skips intros and credits.
- [awesome-jellyfin](https://github.com/awesome-jellyfin/awesome-jellyfin) — A curated list of Jellyfin plugins and tools.
- [Jellyfin](https://github.com/jellyfin/jellyfin) — The free media system this plugin is built for.

---

## 🤝 Contributing

- 🌍 **Translate** — add a `README.xx.md` for your language
- 🐛 **Report bugs** — [open an issue](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/issues)
- 💡 **Suggest features** — ideas are welcome
- ⭐ **Star the repo** — helps others discover it

---

<div align="center">

Made with ♥ for the [Jellyfin](https://jellyfin.org) community

[MIT License](LICENSE) · [Website](https://fabianoortega-ops.github.io/jellyfin-autoplay-toggle) · [Releases](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/releases)

</div>
