<div align="center">

<img src="banner.svg" alt="AutoPlay Toggle" width="100%">

<br/>
<br/>

[![Jellyfin](https://img.shields.io/badge/Jellyfin-10.11.x-00a4dc?style=flat-square&logo=jellyfin&logoColor=white)](https://jellyfin.org)
[![License](https://img.shields.io/badge/license-MIT-green?style=flat-square)](LICENSE)
[![Languages](https://img.shields.io/badge/languages-25-brightgreen?style=flat-square)](#supported-languages)
[![JavaScript Injector](https://img.shields.io/badge/requires-JavaScript%20Injector-orange?style=flat-square)](https://github.com/n00bcodr/Jellyfin-JavaScript-Injector)

<br/>

**[🌐 Sito](https://fabianoortega-ops.github.io/jellyfin-autoplay-toggle) · [📦 Installa](#installation) · [🌍 Lingue](#supported-languages) · [🐛 Problemi](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/issues)**

<br/>

---

### 🌍 Traduzioni
[🇬🇧 English](../README.md) · [🇧🇷 Português](README.pt.md) · [🇩🇪 Deutsch](README.de.md) · [🇫🇷 Français](README.fr.md) · [🇪🇸 Español](README.es.md) · [🇷🇺 Русский](README.ru.md) · [🇨🇳 中文](README.zh.md) · [🇯🇵 日本語](README.ja.md) · [🇰🇷 한국어](README.ko.md) · [🇵🇱 Polski](README.pl.md)  
*Vuoi aggiungere la tua lingua? [Apri una PR!](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/pulls)*

---

</div>

## 🎯 Cosa fa

AutoPlay Toggle aggiunge un **pulsante 🔁** tra il pulsante preferiti e quello dei sottotitoli nel player video di Jellyfin. Un clic attiva o disattiva la riproduzione automatica dell'episodio successivo — senza menu, senza pagine di impostazioni.

```
  ♥  🔁  CC  🎵  ─────────  ⚙  ⛶
       ↑
  AutoPlay Toggle
```

- **Icona luminosa** → autoplay episodio successivo **attivo**
- **Icona scura** → autoplay episodio successivo **disattivo**
- Le modifiche sono immediate e persistono in tutte le sessioni

---

## ✨ Funzionalità

| Funzionalità | Descrizione |
|---|---|
| 🎮 **Pulsante nel Player** | Tra ♥ e CC — esattamente dove ne hai bisogno |
| ⚡ **Toggle Istantaneo** | Le modifiche si applicano immediatamente, senza ricaricare |
| 🌍 **25 Lingue** | Rileva automaticamente la lingua del browser |

---

## 📦 Installazione

### Passo 1 — Installare JavaScript Injector (dipendenza richiesta)

AutoPlay Toggle richiede il plugin [JavaScript Injector](https://github.com/n00bcodr/Jellyfin-JavaScript-Injector) di n00bcodr per iniettare il pulsante nel player.

Vai su **Dashboard → Plugins → Repositories → +** e aggiungi:

```
https://raw.githubusercontent.com/n00bcodr/jellyfin-plugins/main/10.11/manifest.json
```

> Per Jellyfin 10.10.x usa: `https://raw.githubusercontent.com/n00bcodr/jellyfin-plugins/main/10.10/manifest.json`

Vai su **Catalog**, trova **JavaScript Injector** e clicca **Install**. Riavvia Jellyfin.

> **Utenti Docker / TrueNAS:** se vedi `Access to the path '/usr/share/jellyfin/web/index.html' is denied` nei log, installa anche [File Transformation](https://github.com/IAmParadox27/jellyfin-plugin-file-transformation) (v2.2.1.0+).

---

### Passo 2 — Installare AutoPlay Toggle

Vai su **Dashboard → Plugins → Repositories → +** e aggiungi:

```
https://fabianoortega-ops.github.io/jellyfin-autoplay-toggle/manifest.json
```

Vai su **Catalog**, trova **AutoPlay Toggle** e clicca **Install**.

---

### Passo 3 — Riavviare Jellyfin

Riavvia una volta per caricare entrambi i plugin. Il pulsante 🔁 apparirà automaticamente tra ♥ e CC nel player.
---

## 🌍 Lingue supportate

Il tooltip del pulsante viene mostrato automaticamente nella lingua del browser.

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

Manca la tua lingua? [Apri un issue](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/issues) o invia una PR.

---

## 💬 Comunità

Unisciti alla comunità Jellyfin:

| Platform | Link |
|---|---|
| 💬 Discord (Official) | [discord.gg/zHBxVSXdBV](https://discord.gg/zHBxVSXdBV) |
| 💬 Discord (Community) | [discord.gg/N3M99fNxbK](https://discord.gg/N3M99fNxbK) |
| 🌐 Forum | [forum.jellyfin.org](https://forum.jellyfin.org) |
| 🟠 Reddit | [r/jellyfin](https://www.reddit.com/r/jellyfin) · [r/JellyfinCommunity](https://www.reddit.com/r/JellyfinCommunity) |

---

## 🔗 Correlati

- [JavaScript Injector](https://github.com/n00bcodr/Jellyfin-JavaScript-Injector) — Dipendenza richiesta. Inietta JavaScript nell'interfaccia Jellyfin.
- [File Transformation](https://github.com/IAmParadox27/jellyfin-plugin-file-transformation) — Risolve problemi di permessi su Docker/TrueNAS. Necessario in caso di errori di accesso in JavaScript Injector.
- [Jellyfin Enhanced](https://github.com/MakD/jellyfin-enhanced) — Aggiunge valutazioni, badge, miglioramenti OSD e molto altro.
- [Intro Skipper](https://github.com/intro-skipper/intro-skipper) — Rileva e salta automaticamente intro, crediti e riepiloghi.
- [awesome-jellyfin](https://github.com/awesome-jellyfin/awesome-jellyfin) — Una lista curata di plugin, temi e strumenti Jellyfin.
- [Jellyfin](https://github.com/jellyfin/jellyfin) — Il sistema multimediale libero per cui è stato creato questo plugin.

---

## 🤝 Contribuire

- 🌍 **Tradurre** — aggiungi un `README.xx.md` per la tua lingua
- 🐛 **Segnalare bug** — [apri un issue](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/issues)
- 💡 **Suggerire funzionalità** — le idee sono benvenute
- ⭐ **Mettere una stella** — aiuta altri a scoprire il plugin

---

<div align="center">

Fatto con ♥ per la comunità [Jellyfin](https://jellyfin.org)

[Licenza MIT](LICENSE) · [Sito](https://fabianoortega-ops.github.io/jellyfin-autoplay-toggle) · [Releases](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/releases)

</div>
