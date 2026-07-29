# AutoPlay Toggle — Plugin para Jellyfin

Adiciona um botão no Dashboard do Jellyfin para ligar/desligar o autoplay do
próximo episódio **sem precisar ir nas configurações do usuário**.

---

## Estrutura do projeto

```
JellyfinAutoPlayToggle/
├── JellyfinAutoPlayToggle.csproj   ← definição do projeto .NET
├── Plugin.cs                       ← classe principal (nome, ID, página)
├── PluginConfiguration.cs          ← configurações persistentes (futuro)
├── AutoPlayController.cs           ← endpoints da API REST
├── Configuration/
│   └── config.html                 ← interface do Dashboard (HTML + JS)
├── build.sh                        ← script de compilação/instalação
└── README.md
```

---

## Pré-requisitos

| Item | Versão mínima |
|------|--------------|
| .NET SDK | 8.0 |
| Jellyfin Server | 10.9.x |

Baixe o SDK em: https://dotnet.microsoft.com/download

---

## Como compilar

```bash
# Entrar na pasta do projeto
cd JellyfinAutoPlayToggle

# Restaurar dependências e compilar
dotnet build --configuration Release
```

O arquivo gerado será:
```
bin/Release/net8.0/JellyfinAutoPlayToggle.dll
```

---

## Como instalar

### Passo 1 — Localizar a pasta de plugins do Jellyfin

| Instalação | Caminho típico |
|------------|----------------|
| TrueNAS Scale | `/mnt/<pool>/ix-applications/releases/jellyfin/volumes/<hash>/config/plugins/` |
| Docker | volume mapeado + `/config/plugins/` |
| Linux nativo | `/var/lib/jellyfin/plugins/` |
| Windows | `%APPDATA%\Jellyfin\Server\plugins\` |

### Passo 2 — Copiar o .dll

```bash
# Crie a subpasta do plugin
mkdir -p /caminho/plugins/AutoPlayToggle

# Copie o arquivo compilado
cp bin/Release/net8.0/JellyfinAutoPlayToggle.dll /caminho/plugins/AutoPlayToggle/
```

Ou use o script pronto:
```bash
chmod +x build.sh
./build.sh /caminho/plugins/jellyfin
```

### Passo 3 — Reiniciar o Jellyfin

- **TrueNAS Scale**: Apps → Jellyfin → Stop → Start
- **Docker**: `docker restart jellyfin`
- **Linux**: `sudo systemctl restart jellyfin`

---

## Como usar

1. Acesse o **Dashboard** do Jellyfin
2. No menu lateral, clique em **AutoPlay Toggle**
3. Use o switch para ligar/desligar — a mudança é imediata

---

## Endpoints da API

| Método | URL | Descrição |
|--------|-----|-----------|
| `GET`  | `/AutoPlay/Status/{userId}` | Retorna o estado atual |
| `POST` | `/AutoPlay/Toggle` | Altera o estado |

### Exemplo de chamada manual (curl)

```bash
# Consultar status
curl -H "Authorization: MediaBrowser Token=SEU_TOKEN" \
     http://localhost:8096/AutoPlay/Status/SEU_USER_ID

# Ligar autoplay
curl -X POST \
     -H "Authorization: MediaBrowser Token=SEU_TOKEN" \
     -H "Content-Type: application/json" \
     -d '{"UserId":"SEU_USER_ID","Enable":true}' \
     http://localhost:8096/AutoPlay/Toggle
```

---

## Solução de problemas

**Plugin não aparece na lista de plugins**
- Confirme que o `.dll` está dentro de uma *subpasta* em `plugins/`
- Verifique os logs em Dashboard → Logs e procure por `AutoPlayToggle`

**Erro 401 Unauthorized ao chamar a API**
- O endpoint exige autenticação. Certifique-se de que `ApiClient` está logado

**Switch não muda de estado**
- Abra o console do navegador (F12 → Console) e procure por `[AutoPlayToggle]`
- Confirme que o Jellyfin está na versão 10.9.x

---

## GUID do plugin

`036768e6-cd63-49c0-9661-2677d3ccef72`

> ⚠️ Não altere este valor após instalar o plugin. O Jellyfin usa o GUID
> para identificar e gerenciar o plugin entre reinicializações.
