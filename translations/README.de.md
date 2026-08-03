<div align="center">

<img src="banner.svg" alt="AutoPlay Toggle" width="100%">

<br/>
<br/>

[![Jellyfin](https://img.shields.io/badge/Jellyfin-10.11.x-00a4dc?style=flat-square&logo=jellyfin&logoColor=white)](https://jellyfin.org)
[![License](https://img.shields.io/badge/license-MIT-green?style=flat-square)](LICENSE)
[![Languages](https://img.shields.io/badge/Sprachen-25-brightgreen?style=flat-square)](#-unterstutzte)
[![JavaScript Injector](https://img.shields.io/badge/benötigt-JavaScript%20Injector-orange?style=flat-square)](https://github.com/n00bcodr/Jellyfin-JavaScript-Injector)

<br/>

**[🌐 Website](https://fabianoortega-ops.github.io/jellyfin-autoplay-toggle) · [📦 Installieren](#installation) · [🌍 Sprachen](#languages) · [🐛 Probleme](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/issues)**

<br/>

---

### 🌍 Übersetzungen
[🇬🇧 English](../README.md) · [🇧🇷 Português](README.pt.md) · [🇫🇷 Français](README.fr.md) · [🇪🇸 Español](README.es.md) · [🇮🇹 Italiano](README.it.md) · [🇷🇺 Русский](README.ru.md) · [🇨🇳 中文](README.zh.md) · [🇯🇵 日本語](README.ja.md) · [🇰🇷 한국어](README.ko.md) · [🇵🇱 Polski](README.pl.md)  
*Möchtest du deine Sprache hinzufügen? [Öffne einen PR!](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/pulls)*

---

</div>

## 🎯 Was es tut

AutoPlay Toggle fügt eine **🔁 Schaltfläche** zwischen Favoriten- und Untertitelschaltfläche im Jellyfin-Videoplayer ein. Ein Klick aktiviert oder deaktiviert den Autoplay für die nächste Episode — keine Menüs, keine Einstellungsseiten.

```
  ♥  🔁  CC  🎵  ─────────  ⚙  ⛶
       ↑
  AutoPlay Toggle
```

- **Helles Symbol** → Autoplay nächste Episode **an**
- **Dunkles Symbol** → Autoplay nächste Episode **aus**
- Änderungen werden sofort gespeichert und bleiben in allen Sitzungen erhalten

---

## ✨ Funktionen

| Funktion | Beschreibung |
|---|---|
| 🎮 **Im-Player-Schaltfläche** | Sitzt zwischen ♥ und CC — genau dort, wo du sie brauchst |
| ⚡ **Sofortiges Umschalten** | Änderungen werden sofort übernommen, kein Neuladen |
| 🌍 **25 Sprachen** | Erkennt automatisch deine Browser-Sprache |
| 📊 **Dashboard-Panel** | Auch über die Jellyfin-Seitenleiste zugänglich |
| 🚀 **Hot Reload** | UI-Updates via `git push` — kein Serverneustart nötig |

---

## 📦 Installation

### Schritt 1 — JavaScript Injector installieren (erforderliche Abhängigkeit)

AutoPlay Toggle benötigt das Plugin [JavaScript Injector](https://github.com/n00bcodr/Jellyfin-JavaScript-Injector) von n00bcodr, um die Schaltfläche in den Player einzufügen.

Gehe zu **Dashboard → Plugins → Repositories → +** und füge hinzu:

```
https://raw.githubusercontent.com/n00bcodr/jellyfin-plugins/main/10.11/manifest.json
```

> Für Jellyfin 10.10.x verwende: `https://raw.githubusercontent.com/n00bcodr/jellyfin-plugins/main/10.10/manifest.json`

Gehe zu **Catalog**, finde **JavaScript Injector** und klicke **Install**. Starte Jellyfin neu.

> **Docker / TrueNAS-Benutzer:** Wenn du `Access to the path '/usr/share/jellyfin/web/index.html' is denied` in den Logs siehst, installiere auch [File Transformation](https://github.com/IAmParadox27/jellyfin-plugin-file-transformation) (v2.2.1.0+).

---

### Schritt 2 — AutoPlay Toggle installieren

Gehe zu **Dashboard → Plugins → Repositories → +** und füge hinzu:

```
https://fabianoortega-ops.github.io/jellyfin-autoplay-toggle/manifest.json
```

Gehe zu **Catalog**, finde **AutoPlay Toggle** und klicke **Install**.

---

### Schritt 3 — Jellyfin neu starten

Starte einmal neu, um beide Plugins zu laden. Die 🔁 Schaltfläche erscheint automatisch zwischen ♥ und CC im Player.
---

## 🌍 Unterstützte Sprachen

Der Schaltflächen-Tooltip wird automatisch in deiner Browser-Sprache angezeigt.

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

Deine Sprache fehlt? [Öffne einen Issue](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/issues) oder sende einen PR.

---

## 💬 Community

Tritt der Jellyfin-Community bei:

| Platform | Link |
|---|---|
| 💬 Discord (Official) | [discord.gg/zHBxVSXdBV](https://discord.gg/zHBxVSXdBV) |
| 💬 Discord (Community) | [discord.gg/N3M99fNxbK](https://discord.gg/N3M99fNxbK) |
| 🌐 Forum | [forum.jellyfin.org](https://forum.jellyfin.org) |
| 🟠 Reddit | [r/jellyfin](https://www.reddit.com/r/jellyfin) · [r/JellyfinCommunity](https://www.reddit.com/r/JellyfinCommunity) |

---

## 🔗 Verwandte Projekte

- [JavaScript Injector](https://github.com/n00bcodr/Jellyfin-JavaScript-Injector) — Erforderliche Abhängigkeit. Fügt JavaScript in die Jellyfin-Oberfläche ein.
- [File Transformation](https://github.com/IAmParadox27/jellyfin-plugin-file-transformation) — Behebt Berechtigungsprobleme bei Docker/TrueNAS. Erforderlich bei Zugriffsfehlern im JavaScript Injector.
- [Jellyfin Enhanced](https://github.com/MakD/jellyfin-enhanced) — Fügt Bewertungen, Tag-Abzeichen, OSD-Verbesserungen und vieles mehr hinzu.
- [Intro Skipper](https://github.com/intro-skipper/intro-skipper) — Erkennt und überspringt automatisch Intros, Credits und Recaps.
- [awesome-jellyfin](https://github.com/awesome-jellyfin/awesome-jellyfin) — Eine kuratierte Liste großartiger Jellyfin-Plugins, Themes und Tools.
- [Jellyfin](https://github.com/jellyfin/jellyfin) — Das freie Mediensystem, für das dieses Plugin entwickelt wurde.

---

## 🤝 Mitwirken

- 🌍 **Übersetzen** — füge eine `README.xx.md` für deine Sprache hinzu
- 🐛 **Fehler melden** — [öffne einen Issue](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/issues)
- 💡 **Funktionen vorschlagen** — Ideen sind willkommen
- ⭐ **Repo mit Stern versehen** — hilft anderen, das Plugin zu entdecken

---

<div align="center">

Mit ♥ für die [Jellyfin](https://jellyfin.org)-Community erstellt

[MIT-Lizenz](LICENSE) · [Website](https://fabianoortega-ops.github.io/jellyfin-autoplay-toggle) · [Releases](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/releases)

</div>

