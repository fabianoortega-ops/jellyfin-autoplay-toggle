<div align="center">

<img src="banner.svg" alt="AutoPlay Toggle" width="100%">

<br/>
<br/>

[![Jellyfin](https://img.shields.io/badge/Jellyfin-10.11.x-00a4dc?style=flat-square&logo=jellyfin&logoColor=white)](https://jellyfin.org)
[![License](https://img.shields.io/badge/license-MIT-green?style=flat-square)](LICENSE)
[![Languages](https://img.shields.io/badge/langues-25-brightgreen?style=flat-square)](#-langues)
[![JavaScript Injector](https://img.shields.io/badge/nécessite-JavaScript%20Injector-orange?style=flat-square)](https://github.com/n00bcodr/Jellyfin-JavaScript-Injector)

<br/>

**[🌐 Site](https://fabianoortega-ops.github.io/jellyfin-autoplay-toggle) · [📦 Installer](#installation) · [🌍 Langues](#languages) · [🐛 Problèmes](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/issues)**

<br/>

---

### 🌍 Traductions
[🇬🇧 English](../README.md) · [🇧🇷 Português](README.pt.md) · [🇩🇪 Deutsch](README.de.md) · [🇪🇸 Español](README.es.md) · [🇮🇹 Italiano](README.it.md) · [🇷🇺 Русский](README.ru.md) · [🇨🇳 中文](README.zh.md) · [🇯🇵 日本語](README.ja.md) · [🇰🇷 한국어](README.ko.md) · [🇵🇱 Polski](README.pl.md)  
*Vous voulez ajouter votre langue ? [Ouvrez un PR !](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/pulls)*

---

</div>

## 🎯 Ce que ça fait

AutoPlay Toggle ajoute un **bouton 🔁** entre le bouton favori et le bouton sous-titres dans le lecteur vidéo Jellyfin. Un clic active ou désactive la lecture automatique de l'épisode suivant — sans menus, sans pages de paramètres.

```
  ♥  🔁  CC  🎵  ─────────  ⚙  ⛶
       ↑
  AutoPlay Toggle
```

- **Icône lumineuse** → autoplay épisode suivant **activé**
- **Icône sombre** → autoplay épisode suivant **désactivé**
- Les changements sont instantanés et persistent dans toutes les sessions

---

## ✨ Fonctionnalités

| Fonctionnalité | Description |
|---|---|
| 🎮 **Bouton dans le lecteur** | Entre ♥ et CC — exactement là où vous en avez besoin |
| ⚡ **Bascule instantanée** | Les changements s'appliquent immédiatement, sans rechargement |
| 🌍 **25 Langues** | Détecte automatiquement la langue de votre navigateur |

---

## 📦 Installation

### Étape 1 — Installer JavaScript Injector (dépendance requise)

AutoPlay Toggle nécessite le plugin [JavaScript Injector](https://github.com/n00bcodr/Jellyfin-JavaScript-Injector) de n00bcodr pour injecter le bouton dans le lecteur.

Allez dans **Dashboard → Plugins → Repositories → +** et ajoutez :

```
https://raw.githubusercontent.com/n00bcodr/jellyfin-plugins/main/10.11/manifest.json
```

> Pour Jellyfin 10.10.x utilisez : `https://raw.githubusercontent.com/n00bcodr/jellyfin-plugins/main/10.10/manifest.json`

Allez dans **Catalog**, trouvez **JavaScript Injector** et cliquez **Install**. Redémarrez Jellyfin.

> **Utilisateurs Docker / TrueNAS :** si vous voyez `Access to the path '/usr/share/jellyfin/web/index.html' is denied` dans les logs, installez aussi [File Transformation](https://github.com/IAmParadox27/jellyfin-plugin-file-transformation) (v2.2.1.0+).

---

### Étape 2 — Installer AutoPlay Toggle

Allez dans **Dashboard → Plugins → Repositories → +** et ajoutez :

```
https://fabianoortega-ops.github.io/jellyfin-autoplay-toggle/manifest.json
```

Allez dans **Catalog**, trouvez **AutoPlay Toggle** et cliquez **Install**.

---

### Étape 3 — Redémarrer Jellyfin

Redémarrez une fois pour charger les deux plugins. Le bouton 🔁 apparaîtra automatiquement entre ♥ et CC dans le lecteur.
---

## 🌍 Langues supportées

L'infobulle du bouton s'affiche automatiquement dans la langue de votre navigateur.

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

Votre langue manque ? [Ouvrez un issue](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/issues) ou soumettez un PR.

---

## 💬 Communauté

Rejoignez la communauté Jellyfin :

| Platform | Link |
|---|---|
| 💬 Discord (Official) | [discord.gg/zHBxVSXdBV](https://discord.gg/zHBxVSXdBV) |
| 💬 Discord (Community) | [discord.gg/N3M99fNxbK](https://discord.gg/N3M99fNxbK) |
| 🌐 Forum | [forum.jellyfin.org](https://forum.jellyfin.org) |
| 🟠 Reddit | [r/jellyfin](https://www.reddit.com/r/jellyfin) · [r/JellyfinCommunity](https://www.reddit.com/r/JellyfinCommunity) |

---

## 🔗 Projets liés

- [JavaScript Injector](https://github.com/n00bcodr/Jellyfin-JavaScript-Injector) — Dépendance requise. Injecte du JavaScript dans l'interface Jellyfin.
- [File Transformation](https://github.com/IAmParadox27/jellyfin-plugin-file-transformation) — Résout les problèmes de permissions sur Docker/TrueNAS. Requis en cas d'erreurs d'accès dans JavaScript Injector.
- [Jellyfin Enhanced](https://github.com/MakD/jellyfin-enhanced) — Ajoute des évaluations, badges, améliorations OSD et bien plus.
- [Intro Skipper](https://github.com/intro-skipper/intro-skipper) — Détecte et passe automatiquement les intros, génériques et récaps.
- [awesome-jellyfin](https://github.com/awesome-jellyfin/awesome-jellyfin) — Une liste curée de plugins, thèmes et outils Jellyfin.
- [Jellyfin](https://github.com/jellyfin/jellyfin) — Le système multimédia libre pour lequel ce plugin a été créé.

---

## 🤝 Contribuer

- 🌍 **Traduire** — ajoutez un `README.xx.md` pour votre langue
- 🐛 **Signaler des bugs** — [ouvrez un issue](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/issues)
- 💡 **Suggérer des fonctionnalités** — les idées sont les bienvenues
- ⭐ **Étoiler le dépôt** — aide les autres à découvrir le plugin

---

<div align="center">

Fait avec ♥ pour la communauté [Jellyfin](https://jellyfin.org)

[Licence MIT](LICENSE) · [Site](https://fabianoortega-ops.github.io/jellyfin-autoplay-toggle) · [Releases](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/releases)

</div>


