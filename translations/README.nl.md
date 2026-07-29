<div align="center">

<img src="banner.svg" alt="AutoPlay Toggle" width="100%">

<br/>
<br/>

[![Jellyfin](https://img.shields.io/badge/Jellyfin-10.11.x-00a4dc?style=flat-square&logo=jellyfin&logoColor=white)](https://jellyfin.org)
[![License](https://img.shields.io/badge/license-MIT-green?style=flat-square)](LICENSE)
[![Languages](https://img.shields.io/badge/languages-25-brightgreen?style=flat-square)](#supported-languages)
[![JavaScript Injector](https://img.shields.io/badge/requires-JavaScript%20Injector-orange?style=flat-square)](https://github.com/n00bcodr/Jellyfin-JavaScript-Injector)

<br/>

**[🌐 Website](https://fabianoortega-ops.github.io/jellyfin-autoplay-toggle) · [📦 Installeren](#installation) · [🌍 Talen](#supported-languages) · [🐛 Problemen](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/issues)**

<br/>

---

### 🌍 Vertalingen
[🇬🇧 English](../README.md) · [🇧🇷 Português](README.pt.md) · [🇩🇪 Deutsch](README.de.md) · [🇫🇷 Français](README.fr.md) · [🇪🇸 Español](README.es.md) · [🇮🇹 Italiano](README.it.md) · [🇷🇺 Русский](README.ru.md) · [🇨🇳 中文](README.zh.md) · [🇯🇵 日本語](README.ja.md) · [🇰🇷 한국어](README.ko.md) · [🇵🇱 Polski](README.pl.md)  
*Wil je jouw taal toevoegen? [Open een PR!](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/pulls)*

---

</div>

## 🎯 Wat het doet

AutoPlay Toggle voegt een **🔁 knop** toe tussen de favoriet- en ondertitelknop in de Jellyfin videospeler. Één klik schakelt automatisch afspelen van de volgende aflevering in of uit — geen menu's, geen instellingenpagina's.

```
  ♥  🔁  CC  🎵  ─────────  ⚙  ⛶
       ↑
  AutoPlay Toggle
```

- **Helder icoon** → autoplay volgende aflevering **aan**
- **Dim icoon** → autoplay volgende aflevering **uit**
- Wijzigingen zijn direct en blijven behouden in alle sessies

---

## ✨ Functies

| Functie | Beschrijving |
|---|---|
| 🎮 **In-speler knop** | Tussen ♥ en CC — precies waar je het nodig hebt |
| ⚡ **Direct schakelen** | Wijzigingen worden direct toegepast, geen herladen |
| 🌍 **25 Talen** | Detecteert automatisch de browsertaal |
| 📊 **Dashboard paneel** | Ook toegankelijk via de Jellyfin zijbalk |

---

## 📦 Installatie

### Stap 1 — JavaScript Injector installeren (vereiste afhankelijkheid)

AutoPlay Toggle vereist het [JavaScript Injector](https://github.com/n00bcodr/Jellyfin-JavaScript-Injector) plugin van n00bcodr om de knop in de speler te injecteren.

Ga naar **Dashboard → Plugins → Repositories → +** en voeg toe:

```
https://raw.githubusercontent.com/n00bcodr/jellyfin-plugins/main/10.11/manifest.json
```

> Voor Jellyfin 10.10.x gebruik: `https://raw.githubusercontent.com/n00bcodr/jellyfin-plugins/main/10.10/manifest.json`

Ga naar **Catalog**, vind **JavaScript Injector** en klik **Install**. Herstart Jellyfin.

> **Docker / TrueNAS gebruikers:** als je `Access to the path '/usr/share/jellyfin/web/index.html' is denied` in de logs ziet, installeer ook [File Transformation](https://github.com/IAmParadox27/jellyfin-plugin-file-transformation) (v2.2.1.0+).

---

### Stap 2 — AutoPlay Toggle installeren

Ga naar **Dashboard → Plugins → Repositories → +** en voeg toe:

```
https://fabianoortega-ops.github.io/jellyfin-autoplay-toggle/manifest.json
```

Ga naar **Catalog**, vind **AutoPlay Toggle** en klik **Install**.

---

### Stap 3 — Jellyfin herstarten

Herstart eenmalig om beide plugins te laden. De 🔁 knop verschijnt automatisch tussen ♥ en CC in de speler.
---

## 🌍 Ondersteunde talen

De knopinfo wordt automatisch weergegeven in de browsertaal.

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

Ontbreekt jouw taal? [Open een issue](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/issues) of stuur een PR.

---

## 💬 Community

Sluit je aan bij de Jellyfin community:

| Platform | Link |
|---|---|
| 💬 Discord (Official) | [discord.gg/zHBxVSXdBV](https://discord.gg/zHBxVSXdBV) |
| 💬 Discord (Community) | [discord.gg/N3M99fNxbK](https://discord.gg/N3M99fNxbK) |
| 🌐 Forum | [forum.jellyfin.org](https://forum.jellyfin.org) |
| 🔷 Matrix | [#jellyfin:matrix.org](https://matrix.to/#/#jellyfin:matrix.org) |
| 🟠 Reddit | [r/jellyfin](https://www.reddit.com/r/jellyfin) · [r/JellyfinCommunity](https://www.reddit.com/r/JellyfinCommunity) |

---

## 🔗 Gerelateerd

- [JavaScript Injector](https://github.com/n00bcodr/Jellyfin-JavaScript-Injector) — Vereiste afhankelijkheid. Injecteert JavaScript in de Jellyfin interface.
- [Jellyfin Enhanced](https://github.com/MakD/jellyfin-enhanced) — Voegt beoordelingen, badges, OSD-verbeteringen en meer toe.
- [Intro Skipper](https://github.com/intro-skipper/intro-skipper) — Detecteert en slaat automatisch intro's, aftitelingen en samenvattingen over.
- [awesome-jellyfin](https://github.com/awesome-jellyfin/awesome-jellyfin) — Een gecureerde lijst van Jellyfin plugins, thema's en tools.
- [Jellyfin](https://github.com/jellyfin/jellyfin) — Het vrije mediasysteem waarvoor deze plugin is gemaakt.

---

## 🤝 Bijdragen

- 🌍 **Vertalen** — voeg een `README.xx.md` toe voor jouw taal
- 🐛 **Bugs melden** — [open een issue](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/issues)
- 💡 **Functies voorstellen** — ideeën zijn welkom
- ⭐ **Ster geven** — helpt anderen de plugin te ontdekken

---

<div align="center">

Gemaakt met ♥ voor de [Jellyfin](https://jellyfin.org) community

[MIT Licentie](LICENSE) · [Website](https://fabianoortega-ops.github.io/jellyfin-autoplay-toggle) · [Releases](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/releases)

</div>
