<div align="center">

<img src="banner.svg" alt="AutoPlay Toggle — Plugin Jellyfin" width="100%">

<br/>
<br/>

[![Jellyfin](https://img.shields.io/badge/Jellyfin-10.11.x-00a4dc?style=flat-square&logo=jellyfin&logoColor=white)](https://jellyfin.org)
[![Licença](https://img.shields.io/github/license/fabianoortega-ops/jellyfin-autoplay-toggle?style=flat-square&color=green)](LICENSE)
[![Idiomas](https://img.shields.io/badge/idiomas-25-brightgreen?style=flat-square)](#-idiomas-suportados)
[![JavaScript Injector](https://img.shields.io/badge/requer-JavaScript%20Injector-orange?style=flat-square)](https://github.com/n00bcodr/Jellyfin-JavaScript-Injector)

<br/>

**[🌐 Site](https://fabianoortega-ops.github.io/jellyfin-autoplay-toggle) · [📦 Instalar](#-instalação) · [🌍 Idiomas](#-idiomas-suportados) · [🐛 Problemas](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/issues)**

<br/>

---

### 🌍 Traduções
[🇬🇧 English](../README.md) · [🇩🇪 Deutsch](README.de.md) · [🇫🇷 Français](README.fr.md) · [🇪🇸 Español](README.es.md) · [🇮🇹 Italiano](README.it.md) · [🇷🇺 Русский](README.ru.md) · [🇨🇳 中文](README.zh.md) · [🇯🇵 日本語](README.ja.md) · [🇰🇷 한국어](README.ko.md) · [🇵🇱 Polski](README.pl.md)  
*Quer adicionar seu idioma? [Abra um PR!](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/pulls)*

---

</div>

## 🎯 O que faz

AutoPlay Toggle adiciona um **botão 🔁** entre o botão de favoritos e o de legendas no player de vídeo do Jellyfin. Um clique ativa ou desativa o autoplay do próximo episódio — sem menus, sem configurações, sem interrupções.

```
  ♥  🔁  CC  🎵  ─────────  ⚙  ⛶
       ↑
  AutoPlay Toggle
```

- **Ícone brilhante** → autoplay do próximo episódio **ligado**
- **Ícone opaco** → autoplay do próximo episódio **desligado**
- As alterações são instantâneas e persistem em todas as sessões

---

## ✨ Funcionalidades

| Funcionalidade | Descrição |
|---|---|
| 🎮 **Botão no Player** | Fica entre ♥ e CC — exatamente onde você precisa |
| ⚡ **Toggle Instantâneo** | Mudanças aplicadas imediatamente, sem recarregar a página |
| 🌍 **25 Idiomas** | Detecta automaticamente o idioma do browser |

---

## 📦 Instalação

### Passo 1 — Instalar o JavaScript Injector (dependência obrigatória)

O AutoPlay Toggle requer o plugin [JavaScript Injector](https://github.com/n00bcodr/Jellyfin-JavaScript-Injector) de n00bcodr para injetar o botão no player.

Vá em **Dashboard → Plugins → Repositories → +** e adicione:

```
https://raw.githubusercontent.com/n00bcodr/jellyfin-plugins/main/10.11/manifest.json
```

> Para Jellyfin 10.10.x use: `https://raw.githubusercontent.com/n00bcodr/jellyfin-plugins/main/10.10/manifest.json`

Vá em **Catalog**, encontre **JavaScript Injector** e clique em **Install**. Reinicie o Jellyfin.

> **Usuários Docker / TrueNAS:** se aparecer `Access to the path '/usr/share/jellyfin/web/index.html' is denied` nos logs, instale também o [File Transformation](https://github.com/IAmParadox27/jellyfin-plugin-file-transformation) (v2.2.1.0+). Resolve problemas de permissão em instalações em contêiner.

---

### Passo 2 — Instalar o AutoPlay Toggle

Vá em **Dashboard → Plugins → Repositories → +** e adicione:

```
https://fabianoortega-ops.github.io/jellyfin-autoplay-toggle/manifest.json
```

Vá em **Catalog**, encontre **AutoPlay Toggle** e clique em **Install**.

---

### Passo 3 — Reiniciar o Jellyfin

Reinicie uma vez para carregar os dois plugins. O botão 🔁 aparecerá automaticamente entre ♥ e CC no player.

---

## 🌍 Idiomas Suportados

| Idioma | Código | Ligado | Desligado |
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

Falta o seu idioma? [Abra um issue](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/issues) ou envie um PR.

---

## 💬 Comunidade

Junte-se à comunidade Jellyfin para obter ajuda, compartilhar feedback ou apenas conversar:

| Plataforma | Link |
|---|---|
| 💬 Discord (Oficial) | [discord.gg/zHBxVSXdBV](https://discord.gg/zHBxVSXdBV) |
| 💬 Discord (Comunidade) | [discord.gg/N3M99fNxbK](https://discord.gg/N3M99fNxbK) |
| 🌐 Fórum | [forum.jellyfin.org](https://forum.jellyfin.org) |
| 🟠 Reddit | [r/jellyfin](https://www.reddit.com/r/jellyfin) · [r/JellyfinCommunity](https://www.reddit.com/r/JellyfinCommunity) |

---

## 🔗 Relacionados

Outros plugins e ferramentas do Jellyfin que você pode achar úteis:

- [JavaScript Injector](https://github.com/n00bcodr/Jellyfin-JavaScript-Injector) — Dependência obrigatória. Injeta JavaScript personalizado na interface do Jellyfin.
- [File Transformation](https://github.com/IAmParadox27/jellyfin-plugin-file-transformation) — Resolve problemas de permissão no Docker/TrueNAS. Necessário se o JavaScript Injector apresentar erros de acesso negado.
- [Jellyfin Enhanced](https://github.com/MakD/jellyfin-enhanced) — Adiciona avaliações, badges, melhorias no OSD e muito mais.
- [Intro Skipper](https://github.com/intro-skipper/intro-skipper) — Detecta e pula automaticamente intros, créditos e recaps.
- [awesome-jellyfin](https://github.com/awesome-jellyfin/awesome-jellyfin) — Lista curada de plugins, temas e ferramentas para o Jellyfin.
- [Jellyfin](https://github.com/jellyfin/jellyfin) — O sistema de mídia gratuito para o qual este plugin foi criado.

---

## 🤝 Contribuindo

Contribuições são bem-vindas! Você pode ajudar:

- 🌍 **Traduzindo** — adicione um `README.xx.md` para o seu idioma
- 🐛 **Reportando bugs** — [abra um issue](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/issues)
- 💡 **Sugerindo funcionalidades** — ideias são bem-vindas
- ⭐ **Dando uma estrela** — ajuda outros a descobrir o plugin

---

<div align="center">

Feito com ♥ para a comunidade [Jellyfin](https://jellyfin.org)

[Licença MIT](LICENSE) · [Site](https://fabianoortega-ops.github.io/jellyfin-autoplay-toggle) · [Releases](https://github.com/fabianoortega-ops/jellyfin-autoplay-toggle/releases)

</div>


