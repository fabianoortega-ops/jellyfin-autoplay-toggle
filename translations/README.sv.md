<div align="center">

<img src="banner.svg" alt="AutoPlay Toggle" width="100%">

<br/><br/>

[![Jellyfin](https://img.shields.io/badge/Jellyfin-10.11.x-00a4dc?style=flat-square&logo=jellyfin&logoColor=white)](https://jellyfin.org)
[![License](https://img.shields.io/github/license/fabianoortega-ops/jellyfin-autoplay-toggle?style=flat-square&color=green)](LICENSE)
[![Languages](https://img.shields.io/badge/languages-25-brightgreen?style=flat-square)](#supported-languages)
[![JavaScript Injector](https://img.shields.io/badge/requires-JavaScript%20Injector-orange?style=flat-square)](https://github.com/n00bcodr/Jellyfin-JavaScript-Injector)

<br/>

**[🌐 Webbplats](https://fabianoortega-ops.github.io/jellyfin-autoplay-toggle) · [📦 Installera](#installation) · [🌍 Språk](#supported-languages) · [🐛 Problem](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/issues)**

<br/>

---

### 🌍 Översättningar
[🇬🇧 English](../README.md) · [🇧🇷 Português](README.pt.md) · [🇩🇪 Deutsch](README.de.md) · [🇫🇷 Français](README.fr.md) · [🇪🇸 Español](README.es.md) · [🇮🇹 Italiano](README.it.md) · [🇷🇺 Русский](README.ru.md) · [🇨🇳 中文](README.zh.md) · [🇯🇵 日本語](README.ja.md) · [🇰🇷 한국어](README.ko.md) · [🇵🇱 Polski](README.pl.md)  
*Vill du lägga till ditt språk? [Öppna en PR!](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/pulls)*

---

</div>

## 🎯 Vad det gör

AutoPlay Toggle lägger till en **🔁 knapp** mellan favorit- och undertextknappen i Jellyfin-videospelaren. Ett klick aktiverar eller inaktiverar autouppspelning av nästa avsnitt — inga menyer, inga inställningssidor.

```
  ♥  🔁  CC  🎵  ─────────  ⚙  ⛶
       ↑
  AutoPlay Toggle
```

- **Ljus ikon** → autoplay nästa avsnitt **på**
- **Mörk ikon** → autoplay nästa avsnitt **av**
- Ändringar tillämpas omedelbart och behålls i alla sessioner

---

## ✨ Funktioner

| Funktion | Beskrivning |
|---|---|
| 🎮 **Knapp i spelaren** | Mellan ♥ och CC — precis där du behöver den |
| ⚡ **Omedelbar växling** | Ändringar tillämpas direkt, ingen omladdning |
| 🌍 **25 språk** | Identifierar automatiskt webbläsarens språk |
| 🔧 **REST API** | `GET /AutoPlay/Status` · `POST /AutoPlay/Toggle` |
| 📊 **Instrumentpanel** | Tillgänglig också från Jellyfinss sidofält |
| 🚀 **Hot Reload** | UI-uppdateringar via `git push` — ingen serveromstart behövs |

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

## 🌍 Stödda språk

| Language | Code | On | Off |
|---|---|---|---|
| English | `en` | Next episode: On | Next episode: Off |
| Português | `pt` | Próximo episódio: Ligado | Próximo episódio: Desligado |
| Deutsch | `de` | Nächste Folge: Ein | Nächste Folge: Aus |
| Français | `fr` | Épisode suivant: Activé | Épisode suivant: Désactivé |
| Español | `es` | Siguiente episodio: Activado | Siguiente episodio: Desactivado |
| Svenska | `sv` | Nästa avsnitt: På | Nästa avsnitt: Av |

---

## 💬 Gemenskap

| Platform | Länk |
|---|---|
| 💬 Discord (Officiell) | [discord.gg/zHBxVSXdBV](https://discord.gg/zHBxVSXdBV) |
| 🌐 Forum | [forum.jellyfin.org](https://forum.jellyfin.org) |
| 🟠 Reddit | [r/jellyfin](https://www.reddit.com/r/jellyfin) |

---

## 🤝 Bidra

- 🌍 **Översätt** — lägg till en `README.xx.md` för ditt språk
- 🐛 **Rapportera buggar** — [öppna ett ärende](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/issues)
- ⭐ **Stjärnmärk repot** — hjälper andra att hitta pluginet

---

<div align="center">

Gjord med ♥ för [Jellyfin](https://jellyfin.org)-gemenskapen

[MIT-licens](LICENSE) · [Webbplats](https://fabianoortega-ops.github.io/jellyfin-autoplay-toggle) · [Utgåvor](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/releases)

</div>
