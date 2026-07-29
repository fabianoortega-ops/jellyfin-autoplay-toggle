<div align="center">

<img src="banner.svg" alt="AutoPlay Toggle" width="100%">

<br/>
<br/>

[![Jellyfin](https://img.shields.io/badge/Jellyfin-10.11.x-00a4dc?style=flat-square&logo=jellyfin&logoColor=white)](https://jellyfin.org)
[![License](https://img.shields.io/badge/license-MIT-green?style=flat-square)](LICENSE)
[![Languages](https://img.shields.io/badge/languages-25-brightgreen?style=flat-square)](#supported-languages)
[![JavaScript Injector](https://img.shields.io/badge/requires-JavaScript%20Injector-orange?style=flat-square)](https://github.com/n00bcodr/Jellyfin-JavaScript-Injector)

<br/>

**[🌐 Strona](https://fabianoortega-ops.github.io/jellyfin-autoplay-toggle) · [📦 Zainstaluj](#installation) · [🌍 Języki](#supported-languages) · [🐛 Problemy](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/issues)**

<br/>

---

### 🌍 Tłumaczenia
[🇬🇧 English](../README.md) · [🇧🇷 Português](README.pt.md) · [🇩🇪 Deutsch](README.de.md) · [🇫🇷 Français](README.fr.md) · [🇪🇸 Español](README.es.md) · [🇮🇹 Italiano](README.it.md) · [🇷🇺 Русский](README.ru.md) · [🇨🇳 中文](README.zh.md) · [🇯🇵 日本語](README.ja.md) · [🇰🇷 한국어](README.ko.md)  
*Chcesz dodać swój język? [Otwórz PR!](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/pulls)*

---

</div>

## 🎯 Co robi

AutoPlay Toggle dodaje **przycisk 🔁** między przyciskiem ulubionych a napisami w odtwarzaczu wideo Jellyfin. Jedno kliknięcie włącza lub wyłącza automatyczne odtwarzanie następnego odcinka.

```
  ♥  🔁  CC  🎵  ─────────  ⚙  ⛶
       ↑
  AutoPlay Toggle
```

- **Jasna ikona** → autoplay następnego odcinka **włączone**
- **Ciemna ikona** → autoplay następnego odcinka **wyłączone**
- Zmiany są natychmiastowe i utrzymują się we wszystkich sesjach

---

## ✨ Funkcje

| Funkcja | Opis |
|---|---|
| 🎮 **Przycisk w odtwarzaczu** | Między ♥ a CC — dokładnie tam, gdzie potrzebujesz |
| ⚡ **Natychmiastowe przełączanie** | Zmiany stosowane natychmiast, bez przeładowania |
| 🌍 **25 języków** | Automatycznie wykrywa język przeglądarki |

---

## 📦 Instalacja

### Krok 1 — Zainstaluj JavaScript Injector (wymagana zależność)

AutoPlay Toggle wymaga wtyczki [JavaScript Injector](https://github.com/n00bcodr/Jellyfin-JavaScript-Injector) od n00bcodr, aby wstrzyknąć przycisk do odtwarzacza.

Przejdź do **Dashboard → Plugins → Repositories → +** i dodaj:

```
https://raw.githubusercontent.com/n00bcodr/jellyfin-plugins/main/10.11/manifest.json
```

> Dla Jellyfin 10.10.x użyj: `https://raw.githubusercontent.com/n00bcodr/jellyfin-plugins/main/10.10/manifest.json`

Przejdź do **Catalog**, znajdź **JavaScript Injector** i kliknij **Install**. Uruchom ponownie Jellyfin.

> **Użytkownicy Docker / TrueNAS:** jeśli widzisz `Access to the path '/usr/share/jellyfin/web/index.html' is denied` w logach, zainstaluj również [File Transformation](https://github.com/IAmParadox27/jellyfin-plugin-file-transformation) (v2.2.1.0+).

---

### Krok 2 — Zainstaluj AutoPlay Toggle

Przejdź do **Dashboard → Plugins → Repositories → +** i dodaj:

```
https://fabianoortega-ops.github.io/jellyfin-autoplay-toggle/manifest.json
```

Przejdź do **Catalog**, znajdź **AutoPlay Toggle** i kliknij **Install**.

---

### Krok 3 — Uruchom ponownie Jellyfin

Uruchom ponownie raz, aby załadować oba wtyczki. Przycisk 🔁 pojawi się automatycznie między ♥ a CC w odtwarzaczu.

---

## 🌍 Obsługiwane języki

Podpowiedź przycisku jest automatycznie wyświetlana w języku przeglądarki.

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

Brakuje Twojego języka? [Otwórz issue](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/issues) lub wyślij PR.

---

## 💬 Społeczność

Dołącz do społeczności Jellyfin:

| Platform | Link |
|---|---|
| 💬 Discord (Official) | [discord.gg/zHBxVSXdBV](https://discord.gg/zHBxVSXdBV) |
| 💬 Discord (Community) | [discord.gg/N3M99fNxbK](https://discord.gg/N3M99fNxbK) |
| 🌐 Forum | [forum.jellyfin.org](https://forum.jellyfin.org) |
| 🔷 Matrix | [#jellyfin:matrix.org](https://matrix.to/#/#jellyfin:matrix.org) |
| 🟠 Reddit | [r/jellyfin](https://www.reddit.com/r/jellyfin) · [r/JellyfinCommunity](https://www.reddit.com/r/JellyfinCommunity) |

---

## 🔗 Powiązane projekty

- [JavaScript Injector](https://github.com/n00bcodr/Jellyfin-JavaScript-Injector) — Wymagana zależność. Wstrzykuje JavaScript do interfejsu Jellyfin.
- [Jellyfin Enhanced](https://github.com/MakD/jellyfin-enhanced) — Dodaje oceny, odznaki, ulepszenia OSD i wiele więcej.
- [Intro Skipper](https://github.com/intro-skipper/intro-skipper) — Automatycznie wykrywa i pomija intro, napisy końcowe i podsumowania.
- [awesome-jellyfin](https://github.com/awesome-jellyfin/awesome-jellyfin) — Wyselekcjonowana lista wtyczek, motywów i narzędzi Jellyfin.
- [Jellyfin](https://github.com/jellyfin/jellyfin) — Wolny system multimedialny, dla którego stworzono tę wtyczkę.

---

## 🤝 Współpraca

- 🌍 **Tłumaczenie** — dodaj `README.xx.md` dla swojego języka
- 🐛 **Zgłaszanie błędów** — [otwórz issue](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/issues)
- 💡 **Sugerowanie funkcji** — pomysły są mile widziane
- ⭐ **Dodaj gwiazdkę** — pomaga innym odkryć wtyczkę

---

<div align="center">

Stworzone z ♥ dla społeczności [Jellyfin](https://jellyfin.org)

[Licencja MIT](LICENSE) · [Strona](https://fabianoortega-ops.github.io/jellyfin-autoplay-toggle) · [Wydania](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/releases)

</div>
