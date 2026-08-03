<div align="center">

<img src="banner.svg" alt="AutoPlay Toggle" width="100%">

<br/>
<br/>

[![Jellyfin](https://img.shields.io/badge/Jellyfin-10.11.x-00a4dc?style=flat-square&logo=jellyfin&logoColor=white)](https://jellyfin.org)
[![License](https://img.shields.io/badge/license-MIT-green?style=flat-square)](LICENSE)
[![Languages](https://img.shields.io/badge/idiomas-25-brightgreen?style=flat-square)](#-idiomas)
[![JavaScript Injector](https://img.shields.io/badge/requiere-JavaScript%20Injector-orange?style=flat-square)](https://github.com/n00bcodr/Jellyfin-JavaScript-Injector)

<br/>

**[🌐 Sitio](https://fabianoortega-ops.github.io/jellyfin-autoplay-toggle) · [📦 Instalar](#installation) · [🌍 Idiomas](#languages) · [🐛 Problemas](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/issues)**

<br/>

---

### 🌍 Traducciones
[🇬🇧 English](../README.md) · [🇧🇷 Português](README.pt.md) · [🇩🇪 Deutsch](README.de.md) · [🇫🇷 Français](README.fr.md) · [🇮🇹 Italiano](README.it.md) · [🇷🇺 Русский](README.ru.md) · [🇨🇳 中文](README.zh.md) · [🇯🇵 日本語](README.ja.md) · [🇰🇷 한국어](README.ko.md) · [🇵🇱 Polski](README.pl.md)  
*¿Quieres añadir tu idioma? [¡Abre un PR!](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/pulls)*

---

</div>

## 🎯 Qué hace

AutoPlay Toggle añade un **botón 🔁** entre el botón de favoritos y el de subtítulos en el reproductor de vídeo de Jellyfin. Un clic activa o desactiva la reproducción automática del siguiente episodio — sin menús, sin páginas de configuración.

```
  ♥  🔁  CC  🎵  ─────────  ⚙  ⛶
       ↑
  AutoPlay Toggle
```

- **Icono brillante** → autoplay siguiente episodio **activado**
- **Icono oscuro** → autoplay siguiente episodio **desactivado**
- Los cambios son instantáneos y persisten en todas las sesiones

---

## ✨ Características

| Característica | Descripción |
|---|---|
| 🎮 **Botón en el reproductor** | Entre ♥ y CC — justo donde lo necesitas |
| ⚡ **Cambio instantáneo** | Los cambios se aplican inmediatamente, sin recargar |
| 🌍 **25 Idiomas** | Detecta automáticamente el idioma de tu navegador |

---

## 📦 Instalación

### Paso 1 — Instalar JavaScript Injector (dependencia requerida)

AutoPlay Toggle requiere el plugin [JavaScript Injector](https://github.com/n00bcodr/Jellyfin-JavaScript-Injector) de n00bcodr para inyectar el botón en el reproductor.

Ve a **Dashboard → Plugins → Repositories → +** y añade:

```
https://raw.githubusercontent.com/n00bcodr/jellyfin-plugins/main/10.11/manifest.json
```

> Para Jellyfin 10.10.x usa: `https://raw.githubusercontent.com/n00bcodr/jellyfin-plugins/main/10.10/manifest.json`

Ve a **Catalog**, encuentra **JavaScript Injector** y haz clic en **Install**. Reinicia Jellyfin.

> **Usuarios Docker / TrueNAS:** si ves `Access to the path '/usr/share/jellyfin/web/index.html' is denied` en los logs, instala también [File Transformation](https://github.com/IAmParadox27/jellyfin-plugin-file-transformation) (v2.2.1.0+).

---

### Paso 2 — Instalar AutoPlay Toggle

Ve a **Dashboard → Plugins → Repositories → +** y añade:

```
https://fabianoortega-ops.github.io/jellyfin-autoplay-toggle/manifest.json
```

Ve a **Catalog**, encuentra **AutoPlay Toggle** y haz clic en **Install**.

---

### Paso 3 — Reiniciar Jellyfin

Reinicia una vez para cargar ambos plugins. El botón 🔁 aparecerá automáticamente entre ♥ y CC en el reproductor.

---

## 🌍 Idiomas soportados

La información del botón se muestra automáticamente en el idioma de tu navegador.

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

¿Falta tu idioma? [Abre un issue](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/issues) o envía un PR.

---

## 💬 Comunidad

Únete a la comunidad Jellyfin:

| Platform | Link |
|---|---|
| 💬 Discord (Official) | [discord.gg/zHBxVSXdBV](https://discord.gg/zHBxVSXdBV) |
| 💬 Discord (Community) | [discord.gg/N3M99fNxbK](https://discord.gg/N3M99fNxbK) |
| 🌐 Forum | [forum.jellyfin.org](https://forum.jellyfin.org) |
| 🟠 Reddit | [r/jellyfin](https://www.reddit.com/r/jellyfin) · [r/JellyfinCommunity](https://www.reddit.com/r/JellyfinCommunity) |

---

## 🔗 Relacionados

- [JavaScript Injector](https://github.com/n00bcodr/Jellyfin-JavaScript-Injector) — Dependencia requerida. Inyecta JavaScript en la interfaz de Jellyfin.
- [File Transformation](https://github.com/IAmParadox27/jellyfin-plugin-file-transformation) — Resuelve problemas de permisos en Docker/TrueNAS. Necesario si JavaScript Injector muestra errores de acceso.
- [Jellyfin Enhanced](https://github.com/MakD/jellyfin-enhanced) — Añade valoraciones, badges, mejoras OSD y mucho más.
- [Intro Skipper](https://github.com/intro-skipper/intro-skipper) — Detecta y salta automáticamente intros, créditos y recaps.
- [awesome-jellyfin](https://github.com/awesome-jellyfin/awesome-jellyfin) — Una lista curada de plugins, temas y herramientas de Jellyfin.
- [Jellyfin](https://github.com/jellyfin/jellyfin) — El sistema multimedia libre para el que se creó este plugin.

---

## 🤝 Contribuir

- 🌍 **Traducir** — añade un `README.xx.md` para tu idioma
- 🐛 **Reportar errores** — [abre un issue](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/issues)
- 💡 **Sugerir funcionalidades** — las ideas son bienvenidas
- ⭐ **Dar una estrella** — ayuda a otros a descubrir el plugin

---

<div align="center">

Hecho con ♥ para la comunidad [Jellyfin](https://jellyfin.org)

[Licencia MIT](LICENSE) · [Sitio](https://fabianoortega-ops.github.io/jellyfin-autoplay-toggle) · [Releases](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/releases)

</div>


