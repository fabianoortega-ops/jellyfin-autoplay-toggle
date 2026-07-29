# AutoPlay Toggle — Plugin para Jellyfin

Adiciona um switch no Dashboard do Jellyfin para ligar/desligar o autoplay do
próximo episódio **sem precisar entrar nas configurações do usuário**.

**Compatível com Jellyfin 10.11.x**

---

## Instalar via repositório (recomendado)

1. No Jellyfin, vá em **Dashboard → Plugins → Repositories**
2. Clique em **+** e adicione:
   - **Name:** AutoPlay Toggle
   - **URL:** `https://SEU-USUARIO.github.io/jellyfin-autoplay-toggle/manifest.json`
3. Vá em **Catalog**, encontre **AutoPlay Toggle** e clique em **Install**
4. Reinicie o Jellyfin
5. O plugin aparece no menu lateral

---

## Configurar o GitHub Pages (para publicar o repositório)

1. Acesse o repositório no GitHub
2. Vá em **Settings → Pages**
3. Em **Source**, selecione **Deploy from a branch**
4. Branch: `main` | Folder: `/ (root)`
5. Clique **Save**

Após alguns minutos, a URL estará disponível em:
`https://SEU-USUARIO.github.io/jellyfin-autoplay-toggle/`

---

## Publicar uma nova versão

```powershell
# No PowerShell, dentro da pasta do projeto:
.\build-release.ps1 -GitHubUser SEU-USUARIO
git add releases/ manifest.json
git commit -m "release: v1.0.0.0"
git push
```

O script faz tudo automaticamente: compila, empacota o `.dll`, calcula o MD5
e atualiza o `manifest.json`.

---

## Estrutura do repositório

```
jellyfin-autoplay-toggle/
├── AutoPlayController.cs       ← lógica da API
├── Plugin.cs                   ← classe principal
├── PluginConfiguration.cs      ← configurações
├── JellyfinAutoPlayToggle.csproj
├── Configuration/
│   └── config.html             ← interface do Dashboard
├── releases/
│   └── JellyfinAutoPlayToggle_1.0.0.0.zip  ← .dll empacotado
├── manifest.json               ← índice do repositório Jellyfin
├── build-release.ps1           ← script de release
└── .nojekyll                   ← necessário para o GitHub Pages
```

---

## GUID do plugin

`036768e6-cd63-49c0-9661-2677d3ccef72`
