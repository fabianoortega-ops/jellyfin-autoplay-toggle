<div align="center">

<img src="banner.svg" alt="AutoPlay Toggle" width="100%">

<br/>
<br/>

[![Jellyfin](https://img.shields.io/badge/Jellyfin-10.11.x-00a4dc?style=flat-square&logo=jellyfin&logoColor=white)](https://jellyfin.org)
[![License](https://img.shields.io/badge/license-MIT-green?style=flat-square)](LICENSE)
[![Languages](https://img.shields.io/badge/languages-25-brightgreen?style=flat-square)](#supported-languages)
[![JavaScript Injector](https://img.shields.io/badge/requires-JavaScript%20Injector-orange?style=flat-square)](https://github.com/n00bcodr/Jellyfin-JavaScript-Injector)

<br/>

**[🌐 Сайт](https://fabianoortega-ops.github.io/jellyfin-autoplay-toggle) · [📦 Установить](#installation) · [🌍 Языки](#supported-languages) · [🐛 Проблемы](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/issues)**

<br/>

---

### 🌍 Переводы
[🇬🇧 English](../README.md) · [🇧🇷 Português](README.pt.md) · [🇩🇪 Deutsch](README.de.md) · [🇫🇷 Français](README.fr.md) · [🇪🇸 Español](README.es.md) · [🇮🇹 Italiano](README.it.md) · [🇨🇳 中文](README.zh.md) · [🇯🇵 日本語](README.ja.md) · [🇰🇷 한국어](README.ko.md) · [🇵🇱 Polski](README.pl.md)  
*Хотите добавить свой язык? [Откройте PR!](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/pulls)*

---

</div>

## 🎯 Что это делает

AutoPlay Toggle добавляет **кнопку 🔁** между кнопками избранного и субтитров в видеоплеере Jellyfin. Один клик включает или отключает автовоспроизведение следующего эпизода — без меню, без страниц настроек.

```
  ♥  🔁  CC  🎵  ─────────  ⚙  ⛶
       ↑
  AutoPlay Toggle
```

- **Яркая иконка** → автовоспроизведение **включено**
- **Тусклая иконка** → автовоспроизведение **выключено**
- Изменения применяются мгновенно и сохраняются во всех сессиях

---

## ✨ Возможности

| Функция | Описание |
|---|---|
| 🎮 **Кнопка в плеере** | Между ♥ и CC — именно там, где нужно |
| ⚡ **Мгновенное переключение** | Изменения применяются сразу, без перезагрузки |
| 🌍 **25 языков** | Автоматически определяет язык браузера |

---

## 📦 Установка

### Шаг 1 — Установить JavaScript Injector (обязательная зависимость)

AutoPlay Toggle требует плагин [JavaScript Injector](https://github.com/n00bcodr/Jellyfin-JavaScript-Injector) от n00bcodr для внедрения кнопки в плеер.

Перейдите в **Dashboard → Plugins → Repositories → +** и добавьте:

```
https://raw.githubusercontent.com/n00bcodr/jellyfin-plugins/main/10.11/manifest.json
```

> Для Jellyfin 10.10.x используйте: `https://raw.githubusercontent.com/n00bcodr/jellyfin-plugins/main/10.10/manifest.json`

Перейдите в **Catalog**, найдите **JavaScript Injector** и нажмите **Install**. Перезапустите Jellyfin.

> **Пользователи Docker / TrueNAS:** если вы видите `Access to the path '/usr/share/jellyfin/web/index.html' is denied` в логах, установите также [File Transformation](https://github.com/IAmParadox27/jellyfin-plugin-file-transformation) (v2.2.1.0+).

---

### Шаг 2 — Установить AutoPlay Toggle

Перейдите в **Dashboard → Plugins → Repositories → +** и добавьте:

```
https://fabianoortega-ops.github.io/jellyfin-autoplay-toggle/manifest.json
```

Перейдите в **Catalog**, найдите **AutoPlay Toggle** и нажмите **Install**.

---

### Шаг 3 — Перезапустить Jellyfin

Перезапустите один раз для загрузки обоих плагинов. Кнопка 🔁 появится автоматически между ♥ и CC в плеере.

---

## 🌍 Поддерживаемые языки

Подсказка кнопки автоматически отображается на языке браузера.

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

Нет вашего языка? [Откройте issue](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/issues) или отправьте PR.

---

## 💬 Сообщество

Присоединяйтесь к сообществу Jellyfin:

| Platform | Link |
|---|---|
| 💬 Discord (Official) | [discord.gg/zHBxVSXdBV](https://discord.gg/zHBxVSXdBV) |
| 💬 Discord (Community) | [discord.gg/N3M99fNxbK](https://discord.gg/N3M99fNxbK) |
| 🌐 Forum | [forum.jellyfin.org](https://forum.jellyfin.org) |
| 🟠 Reddit | [r/jellyfin](https://www.reddit.com/r/jellyfin) · [r/JellyfinCommunity](https://www.reddit.com/r/JellyfinCommunity) |

---

## 🔗 Похожие проекты

- [JavaScript Injector](https://github.com/n00bcodr/Jellyfin-JavaScript-Injector) — Обязательная зависимость. Внедряет JavaScript в интерфейс Jellyfin.
- [File Transformation](https://github.com/IAmParadox27/jellyfin-plugin-file-transformation) — Решает проблемы доступа на Docker/TrueNAS. Необходим при ошибках доступа в JavaScript Injector.
- [Jellyfin Enhanced](https://github.com/MakD/jellyfin-enhanced) — Добавляет рейтинги, значки, улучшения OSD и многое другое.
- [Intro Skipper](https://github.com/intro-skipper/intro-skipper) — Автоматически определяет и пропускает вступления, титры и повторы.
- [awesome-jellyfin](https://github.com/awesome-jellyfin/awesome-jellyfin) — Кураторский список плагинов, тем и инструментов Jellyfin.
- [Jellyfin](https://github.com/jellyfin/jellyfin) — Свободная медиасистема, для которой создан этот плагин.

---

## 🤝 Участие

- 🌍 **Перевод** — добавьте `README.xx.md` для своего языка
- 🐛 **Сообщить об ошибке** — [откройте issue](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/issues)
- 💡 **Предложить функцию** — идеи приветствуются
- ⭐ **Поставить звезду** — помогает другим найти плагин

---

<div align="center">

Сделано с ♥ для сообщества [Jellyfin](https://jellyfin.org)

[Лицензия MIT](LICENSE) · [Сайт](https://fabianoortega-ops.github.io/jellyfin-autoplay-toggle) · [Релизы](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/releases)

</div>


