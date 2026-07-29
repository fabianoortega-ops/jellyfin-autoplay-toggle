<div align="center">

<img src="banner.svg" alt="AutoPlay Toggle" width="100%">

<br/>
<br/>

[![Jellyfin](https://img.shields.io/badge/Jellyfin-10.11.x-00a4dc?style=flat-square&logo=jellyfin&logoColor=white)](https://jellyfin.org)
[![License](https://img.shields.io/badge/license-MIT-green?style=flat-square)](LICENSE)
[![Languages](https://img.shields.io/badge/languages-25-brightgreen?style=flat-square)](#supported-languages)
[![JavaScript Injector](https://img.shields.io/badge/requires-JavaScript%20Injector-orange?style=flat-square)](https://github.com/n00bcodr/Jellyfin-JavaScript-Injector)

<br/>

**[🌐 网站](https://fabianoortega-ops.github.io/jellyfin-autoplay-toggle) · [📦 安装](#installation) · [🌍 语言](#supported-languages) · [🐛 问题](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/issues)**

<br/>

---

### 🌍 翻译
[🇬🇧 English](../README.md) · [🇧🇷 Português](README.pt.md) · [🇩🇪 Deutsch](README.de.md) · [🇫🇷 Français](README.fr.md) · [🇪🇸 Español](README.es.md) · [🇮🇹 Italiano](README.it.md) · [🇷🇺 Русский](README.ru.md) · [🇯🇵 日本語](README.ja.md) · [🇰🇷 한국어](README.ko.md) · [🇵🇱 Polski](README.pl.md)  
*想添加您的语言？ [提交 PR！](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/pulls)*

---

</div>

## 🎯 功能介绍

AutoPlay Toggle 在 Jellyfin 视频播放器的收藏和字幕按钮之间添加了一个 **🔁 按钮**。单击即可启用或禁用下一集的自动播放——无需菜单，无需设置页面。

```
  ♥  🔁  CC  🎵  ─────────  ⚙  ⛶
       ↑
  AutoPlay Toggle
```

- **亮图标** → 下一集自动播放**开启**
- **暗图标** → 下一集自动播放**关闭**
- 更改立即生效并在所有会话中保持

---

## ✨ 功能

| 功能 | 描述 |
|---|---|
| 🎮 **播放器内按钮** | 位于 ♥ 和 CC 之间——正好在需要的地方 |
| ⚡ **即时切换** | 更改立即应用，无需重新加载 |
| 🌍 **25种语言** | 自动检测浏览器语言 |

---

## 📦 安装

### 第一步 — 安装 JavaScript Injector（必需依赖）

AutoPlay Toggle 需要 n00bcodr 的 [JavaScript Injector](https://github.com/n00bcodr/Jellyfin-JavaScript-Injector) 插件来将按钮注入播放器。

前往 **Dashboard → Plugins → Repositories → +** 并添加：

```
https://raw.githubusercontent.com/n00bcodr/jellyfin-plugins/main/10.11/manifest.json
```

> Jellyfin 10.10.x 请使用：`https://raw.githubusercontent.com/n00bcodr/jellyfin-plugins/main/10.10/manifest.json`

前往 **Catalog**，找到 **JavaScript Injector** 并点击 **Install**。重启 Jellyfin。

> **Docker / TrueNAS 用户：** 如果日志中出现 `Access to the path '/usr/share/jellyfin/web/index.html' is denied`，还需安装 [File Transformation](https://github.com/IAmParadox27/jellyfin-plugin-file-transformation) (v2.2.1.0+)。

---

### 第二步 — 安装 AutoPlay Toggle

前往 **Dashboard → Plugins → Repositories → +** 并添加：

```
https://fabianoortega-ops.github.io/jellyfin-autoplay-toggle/manifest.json
```

前往 **Catalog**，找到 **AutoPlay Toggle** 并点击 **Install**。

---

### 第三步 — 重启 Jellyfin

重启一次以加载两个插件。🔁 按钮将自动出现在播放器的 ♥ 和 CC 之间。

---

## 🌍 支持的语言

按钮提示自动以浏览器语言显示。

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

缺少您的语言？[提交 issue](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/issues) 或发送 PR。

---

## 💬 社区

加入 Jellyfin 社区：

| Platform | Link |
|---|---|
| 💬 Discord (Official) | [discord.gg/zHBxVSXdBV](https://discord.gg/zHBxVSXdBV) |
| 💬 Discord (Community) | [discord.gg/N3M99fNxbK](https://discord.gg/N3M99fNxbK) |
| 🌐 Forum | [forum.jellyfin.org](https://forum.jellyfin.org) |
| 🟠 Reddit | [r/jellyfin](https://www.reddit.com/r/jellyfin) · [r/JellyfinCommunity](https://www.reddit.com/r/JellyfinCommunity) |

---

## 🔗 相关项目

- [JavaScript Injector](https://github.com/n00bcodr/Jellyfin-JavaScript-Injector) — 必需依赖。向 Jellyfin 界面注入 JavaScript。
- [File Transformation](https://github.com/IAmParadox27/jellyfin-plugin-file-transformation) — 解决 Docker/TrueNAS 权限问题。若 JavaScript Injector 显示访问被拒绝则需要。
- [Jellyfin Enhanced](https://github.com/MakD/jellyfin-enhanced) — 添加评分、标签徽章、OSD 改进等更多功能。
- [Intro Skipper](https://github.com/intro-skipper/intro-skipper) — 自动检测并跳过片头、字幕和回顾。
- [awesome-jellyfin](https://github.com/awesome-jellyfin/awesome-jellyfin) — 精选的 Jellyfin 插件、主题和工具列表。
- [Jellyfin](https://github.com/jellyfin/jellyfin) — 此插件为之构建的免费媒体系统。

---

## 🤝 贡献

- 🌍 **翻译** — 为您的语言添加 `README.xx.md`
- 🐛 **报告错误** — [提交 issue](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/issues)
- 💡 **建议功能** — 欢迎提出想法
- ⭐ **给仓库加星** — 帮助他人发现此插件

---

<div align="center">

用 ♥ 为 [Jellyfin](https://jellyfin.org) 社区制作

[MIT 许可证](LICENSE) · [网站](https://fabianoortega-ops.github.io/jellyfin-autoplay-toggle) · [发布](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/releases)

</div>
