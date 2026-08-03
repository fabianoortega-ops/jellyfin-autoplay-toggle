<div align="center">

<img src="banner.svg" alt="AutoPlay Toggle" width="100%">

<br/>
<br/>

[![Jellyfin](https://img.shields.io/badge/Jellyfin-10.11.x-00a4dc?style=flat-square&logo=jellyfin&logoColor=white)](https://jellyfin.org)
[![License](https://img.shields.io/badge/license-MIT-green?style=flat-square)](LICENSE)
[![Languages](https://img.shields.io/badge/languages-25-brightgreen?style=flat-square)](#supported-languages)
[![JavaScript Injector](https://img.shields.io/badge/requires-JavaScript%20Injector-orange?style=flat-square)](https://github.com/n00bcodr/Jellyfin-JavaScript-Injector)

<br/>

**[🌐 サイト](https://fabianoortega-ops.github.io/jellyfin-autoplay-toggle) · [📦 インストール](#installation) · [🌍 言語](#supported-languages) · [🐛 問題](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/issues)**

<br/>

---

### 🌍 翻訳
[🇬🇧 English](../README.md) · [🇧🇷 Português](README.pt.md) · [🇩🇪 Deutsch](README.de.md) · [🇫🇷 Français](README.fr.md) · [🇪🇸 Español](README.es.md) · [🇮🇹 Italiano](README.it.md) · [🇷🇺 Русский](README.ru.md) · [🇨🇳 中文](README.zh.md) · [🇰🇷 한국어](README.ko.md) · [🇵🇱 Polski](README.pl.md)  
*言語を追加しますか？ [PRを開いてください！](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/pulls)*

---

</div>

## 🎯 機能

AutoPlay Toggleは、Jellyfinビデオプレーヤーのお気に入りボタンと字幕ボタンの間に**🔁ボタン**を追加します。1クリックで次のエピソードの自動再生をオン/オフできます。

```
  ♥  🔁  CC  🎵  ─────────  ⚙  ⛶
       ↑
  AutoPlay Toggle
```

- **明るいアイコン** → 次のエピソードの自動再生**オン**
- **暗いアイコン** → 次のエピソードの自動再生**オフ**
- 変更は即座に適用され、すべてのセッションで保持されます

---

## ✨ 機能

| 機能 | 説明 |
|---|---|
| 🎮 **プレーヤー内ボタン** | ♥とCCの間 — ちょうど必要な場所に |
| ⚡ **即座の切り替え** | 変更はすぐに適用、リロード不要 |
| 🌍 **25言語** | ブラウザの言語を自動検出 |

---

## 📦 インストール

### ステップ 1 — JavaScript Injector をインストール（必須依存関係）

AutoPlay Toggle は、プレーヤーにボタンを注入するために n00bcodr の [JavaScript Injector](https://github.com/n00bcodr/Jellyfin-JavaScript-Injector) プラグインが必要です。

**Dashboard → Plugins → Repositories → +** に移動し、以下を追加：

```
https://raw.githubusercontent.com/n00bcodr/jellyfin-plugins/main/10.11/manifest.json
```

> Jellyfin 10.10.x の場合：`https://raw.githubusercontent.com/n00bcodr/jellyfin-plugins/main/10.10/manifest.json`

**Catalog** に移動し、**JavaScript Injector** を見つけて **Install** をクリック。Jellyfin を再起動。

> **Docker / TrueNAS ユーザー：** ログに `Access to the path '/usr/share/jellyfin/web/index.html' is denied` が表示される場合は、[File Transformation](https://github.com/IAmParadox27/jellyfin-plugin-file-transformation) (v2.2.1.0+) もインストールしてください。

---

### ステップ 2 — AutoPlay Toggle をインストール

**Dashboard → Plugins → Repositories → +** に移動し、以下を追加：

```
https://fabianoortega-ops.github.io/jellyfin-autoplay-toggle/manifest.json
```

**Catalog** に移動し、**AutoPlay Toggle** を見つけて **Install** をクリック。

---

### ステップ 3 — Jellyfin を再起動

両方のプラグインを読み込むために一度再起動します。🔁 ボタンがプレーヤーの ♥ と CC の間に自動的に表示されます。

---

## 🌍 対応言語

ボタンのツールチップはブラウザの言語で自動的に表示されます。

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

言語が見つかりませんか？[issueを開く](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/issues)かPRを送ってください。

---

## 💬 コミュニティ

Jellyfinコミュニティに参加：

| Platform | Link |
|---|---|
| 💬 Discord (Official) | [discord.gg/zHBxVSXdBV](https://discord.gg/zHBxVSXdBV) |
| 💬 Discord (Community) | [discord.gg/N3M99fNxbK](https://discord.gg/N3M99fNxbK) |
| 🌐 Forum | [forum.jellyfin.org](https://forum.jellyfin.org) |
| 🟠 Reddit | [r/jellyfin](https://www.reddit.com/r/jellyfin) · [r/JellyfinCommunity](https://www.reddit.com/r/JellyfinCommunity) |

---

## 🔗 関連プロジェクト

- [JavaScript Injector](https://github.com/n00bcodr/Jellyfin-JavaScript-Injector) — 必須依存関係。JellyfinインターフェースにJavaScriptを注入します。
- [File Transformation](https://github.com/IAmParadox27/jellyfin-plugin-file-transformation) — Docker/TrueNASの権限問題を解決。JavaScript Injectorでアクセス拒否エラーが出る場合に必要。
- [Jellyfin Enhanced](https://github.com/MakD/jellyfin-enhanced) — 評価、タグバッジ、OSD改善などを追加します。
- [Intro Skipper](https://github.com/intro-skipper/intro-skipper) — イントロ、エンドクレジット、リキャップを自動検出してスキップします。
- [awesome-jellyfin](https://github.com/awesome-jellyfin/awesome-jellyfin) — Jellyfinプラグイン、テーマ、ツールのキュレーションリスト。
- [Jellyfin](https://github.com/jellyfin/jellyfin) — このプラグインが作られた自由メディアシステム。

---

## 🤝 貢献

- 🌍 **翻訳** — 言語用の`README.xx.md`を追加してください
- 🐛 **バグ報告** — [issueを開く](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/issues)
- 💡 **機能提案** — アイデアを歓迎します
- ⭐ **スターを付ける** — 他のユーザーがプラグインを発見するのを助けます

---

<div align="center">

[Jellyfin](https://jellyfin.org)コミュニティのために♥で作られました

[MITライセンス](LICENSE) · [サイト](https://fabianoortega-ops.github.io/jellyfin-autoplay-toggle) · [リリース](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/releases)

</div>


