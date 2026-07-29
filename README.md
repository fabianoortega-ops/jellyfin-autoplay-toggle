# AutoPlay Toggle — Jellyfin Plugin

Adiciona um botão **repeat** diretamente nos controles do player para ligar ou desligar o autoplay do próximo episódio — sem precisar abrir configurações.

> **Compatível com Jellyfin 10.11.x**  
> **Requer:** [JavaScript Injector](https://github.com/n00bcodr/Jellyfin-JavaScript-Injector) (n00bcodr)

---

## Instalação

1. Adicione o repositório em **Dashboard → Plugins → Repositories → +**
   - **Name:** `AutoPlay Toggle`
   - **URL:** `https://fabianoortega-ops.github.io/jellyfin-autoplay-toggle/manifest.json`
2. Vá em **Catalog**, encontre **AutoPlay Toggle** e clique em **Install**
3. Reinicie o Jellyfin
4. O botão aparece automaticamente nos controles do player

---

## Como usar

O botão **⟳** aparece entre o botão de favoritos e o de legendas na barra de controles do player.

- **Ícone brilhante** → autoplay do próximo episódio **ligado**
- **Ícone opaco** → autoplay do próximo episódio **desligado**
- **Clique** → alterna o estado instantaneamente

A alteração também pode ser verificada em **Configurações → Reprodução → Reproduzir automaticamente o próximo episódio**.

---

## Idiomas suportados

O botão detecta automaticamente o idioma do browser.

| Idioma | Código | Ligado | Desligado |
|--------|--------|--------|-----------|
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

Idioma não listado? Fique à vontade para abrir um PR ou issue.

---

## API REST

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| `GET` | `/AutoPlay/Status/{userId}` | Retorna o estado atual |
| `POST` | `/AutoPlay/Toggle` | Alterna o estado |

---

## Publicar nova versão

```powershell
.\build-release.ps1 -Version "0.x.x.0"
```

---

## Estrutura

```
├── AutoPlayController.cs     API REST
├── Plugin.cs                 Registro + injeção do script via JavaScript Injector
├── PluginConfiguration.cs    Configurações persistentes
├── JellyfinAutoPlayToggle.csproj
├── Configuration/config.html Página no Dashboard (alternativa ao botão no player)
├── releases/                 .zip gerado pelo script de release
├── manifest.json             Índice do repositório Jellyfin
└── build-release.ps1         Script de release (Windows/PowerShell)
```

---

## GUID

`036768e6-cd63-49c0-9661-2677d3ccef72`
