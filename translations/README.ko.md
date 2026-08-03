<div align="center">

<img src="banner.svg" alt="AutoPlay Toggle" width="100%">

<br/>
<br/>

[![Jellyfin](https://img.shields.io/badge/Jellyfin-10.11.x-00a4dc?style=flat-square&logo=jellyfin&logoColor=white)](https://jellyfin.org)
[![License](https://img.shields.io/badge/license-MIT-green?style=flat-square)](LICENSE)
[![Languages](https://img.shields.io/badge/languages-25-brightgreen?style=flat-square)](#supported-languages)
[![JavaScript Injector](https://img.shields.io/badge/requires-JavaScript%20Injector-orange?style=flat-square)](https://github.com/n00bcodr/Jellyfin-JavaScript-Injector)

<br/>

**[🌐 웹사이트](https://fabianoortega-ops.github.io/jellyfin-autoplay-toggle) · [📦 설치](#installation) · [🌍 언어](#supported-languages) · [🐛 문제](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/issues)**

<br/>

---

### 🌍 번역
[🇬🇧 English](../README.md) · [🇧🇷 Português](README.pt.md) · [🇩🇪 Deutsch](README.de.md) · [🇫🇷 Français](README.fr.md) · [🇪🇸 Español](README.es.md) · [🇮🇹 Italiano](README.it.md) · [🇷🇺 Русский](README.ru.md) · [🇨🇳 中文](README.zh.md) · [🇯🇵 日本語](README.ja.md) · [🇵🇱 Polski](README.pl.md)  
*언어를 추가하시겠습니까? [PR을 열어주세요!](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/pulls)*

---

</div>

## 🎯 기능 소개

AutoPlay Toggle은 Jellyfin 비디오 플레이어의 즐겨찾기와 자막 버튼 사이에 **🔁 버튼**을 추가합니다. 클릭 한 번으로 다음 에피소드 자동 재생을 켜거나 끌 수 있습니다.

```
  ♥  🔁  CC  🎵  ─────────  ⚙  ⛶
       ↑
  AutoPlay Toggle
```

- **밝은 아이콘** → 다음 에피소드 자동 재생 **켜짐**
- **어두운 아이콘** → 다음 에피소드 자동 재생 **꺼짐**
- 변경 사항은 즉시 적용되며 모든 세션에서 유지됩니다

---

## ✨ 기능

| 기능 | 설명 |
|---|---|
| 🎮 **플레이어 내 버튼** | ♥와 CC 사이 — 필요한 곳에 정확히 위치 |
| ⚡ **즉시 전환** | 변경 사항이 즉시 적용, 새로고침 불필요 |
| 🌍 **25개 언어** | 브라우저 언어를 자동으로 감지 |

---

## 📦 설치

### 1단계 — JavaScript Injector 설치 (필수 의존성)

AutoPlay Toggle은 플레이어에 버튼을 주입하기 위해 n00bcodr의 [JavaScript Injector](https://github.com/n00bcodr/Jellyfin-JavaScript-Injector) 플러그인이 필요합니다.

**Dashboard → Plugins → Repositories → +** 로 이동하여 추가:

```
https://raw.githubusercontent.com/n00bcodr/jellyfin-plugins/main/10.11/manifest.json
```

> Jellyfin 10.10.x의 경우: `https://raw.githubusercontent.com/n00bcodr/jellyfin-plugins/main/10.10/manifest.json`

**Catalog** 로 이동하여 **JavaScript Injector** 를 찾아 **Install** 을 클릭하세요. Jellyfin을 재시작하세요.

> **Docker / TrueNAS 사용자:** 로그에 `Access to the path '/usr/share/jellyfin/web/index.html' is denied` 가 나타나면 [File Transformation](https://github.com/IAmParadox27/jellyfin-plugin-file-transformation) (v2.2.1.0+)도 설치하세요.

---

### 2단계 — AutoPlay Toggle 설치

**Dashboard → Plugins → Repositories → +** 로 이동하여 추가:

```
https://fabianoortega-ops.github.io/jellyfin-autoplay-toggle/manifest.json
```

**Catalog** 로 이동하여 **AutoPlay Toggle** 을 찾아 **Install** 을 클릭하세요.

---

### 3단계 — Jellyfin 재시작

두 플러그인을 로드하기 위해 한 번 재시작하세요. 🔁 버튼이 플레이어의 ♥ 와 CC 사이에 자동으로 나타납니다.

---

## 🌍 지원 언어

버튼 툴팁은 브라우저 언어로 자동 표시됩니다.

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

언어가 없나요? [이슈 열기](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/issues) 또는 PR을 보내주세요.

---

## 💬 커뮤니티

Jellyfin 커뮤니티에 참여하세요:

| Platform | Link |
|---|---|
| 💬 Discord (Official) | [discord.gg/zHBxVSXdBV](https://discord.gg/zHBxVSXdBV) |
| 💬 Discord (Community) | [discord.gg/N3M99fNxbK](https://discord.gg/N3M99fNxbK) |
| 🌐 Forum | [forum.jellyfin.org](https://forum.jellyfin.org) |
| 🟠 Reddit | [r/jellyfin](https://www.reddit.com/r/jellyfin) · [r/JellyfinCommunity](https://www.reddit.com/r/JellyfinCommunity) |

---

## 🔗 관련 프로젝트

- [JavaScript Injector](https://github.com/n00bcodr/Jellyfin-JavaScript-Injector) — 필수 의존성. Jellyfin 인터페이스에 JavaScript를 주입합니다.
- [File Transformation](https://github.com/IAmParadox27/jellyfin-plugin-file-transformation) — Docker/TrueNAS 권한 문제 해결. JavaScript Injector 액세스 거부 오류 시 필요.
- [Jellyfin Enhanced](https://github.com/MakD/jellyfin-enhanced) — 평점, 태그 배지, OSD 개선 등을 추가합니다.
- [Intro Skipper](https://github.com/intro-skipper/intro-skipper) — 인트로, 크레딧, 리캡을 자동으로 감지하고 건너뜁니다.
- [awesome-jellyfin](https://github.com/awesome-jellyfin/awesome-jellyfin) — Jellyfin 플러그인, 테마, 도구의 큐레이션 목록.
- [Jellyfin](https://github.com/jellyfin/jellyfin) — 이 플러그인이 만들어진 자유 미디어 시스템.

---

## 🤝 기여

- 🌍 **번역** — 언어용 `README.xx.md` 추가
- 🐛 **버그 신고** — [이슈 열기](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/issues)
- 💡 **기능 제안** — 아이디어 환영
- ⭐ **별표 달기** — 다른 사람들이 플러그인을 발견하는 데 도움

---

<div align="center">

[Jellyfin](https://jellyfin.org) 커뮤니티를 위해 ♥로 만들었습니다

[MIT 라이선스](LICENSE) · [웹사이트](https://fabianoortega-ops.github.io/jellyfin-autoplay-toggle) · [릴리스](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/releases)

</div>


