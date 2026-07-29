# =============================================================================
# build-release.ps1
# Compila o plugin, empacota o .dll para o repositório Jellyfin e
# atualiza o manifest.json com o checksum correto.
#
# Uso (no PowerShell, dentro da pasta do projeto):
#   .\build-release.ps1 -GitHubUser SEU-USUARIO
# =============================================================================
param(
    [Parameter(Mandatory=$true)]
    [string]$GitHubUser
)

$ErrorActionPreference = "Stop"

# Garante que o script sempre roda a partir da sua própria pasta,
# independente de onde o PowerShell foi aberto.
Set-Location -Path $PSScriptRoot

$PluginName  = "JellyfinAutoPlayToggle"
$Version     = "1.0.0.0"
$DllPath     = "bin\Release\net9.0\$PluginName.dll"
$ZipName     = "${PluginName}_${Version}.zip"
$ZipDest     = "releases\$ZipName"
$RepoUrl     = "https://$GitHubUser.github.io/jellyfin-autoplay-toggle"
$SourceUrl   = "$RepoUrl/releases/$ZipName"
$ManifestOut = "manifest.json"

Write-Host ""
Write-Host "=== AutoPlay Toggle — Build de Release ===" -ForegroundColor Cyan

# 1. Compilar
Write-Host "`n[1/4] Compilando..." -ForegroundColor Yellow
dotnet build --configuration Release
if ($LASTEXITCODE -ne 0) { Write-Error "Falha na compilação."; exit 1 }

# 2. Empacotar só o .dll num zip limpo
Write-Host "[2/4] Empacotando $ZipDest..." -ForegroundColor Yellow
if (!(Test-Path "releases")) { New-Item -ItemType Directory -Path "releases" | Out-Null }
if (Test-Path $ZipDest) { Remove-Item $ZipDest -Force }
Compress-Archive -Path $DllPath -DestinationPath $ZipDest -Force
Write-Host "      Zip criado: $ZipDest"

# 3. Calcular MD5 do zip
Write-Host "[3/4] Calculando checksum MD5..." -ForegroundColor Yellow
$md5      = Get-FileHash $ZipDest -Algorithm MD5
$checksum = $md5.Hash.ToLower()
Write-Host "      MD5: $checksum"

# 4. Gerar manifest.json
Write-Host "[4/4] Gerando $ManifestOut..." -ForegroundColor Yellow
$timestamp = (Get-Date).ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ")

$manifest = @(
    @{
        guid        = "036768e6-cd63-49c0-9661-2677d3ccef72"
        name        = "AutoPlay Toggle"
        description = "Adiciona um botão para ligar/desligar o autoplay do próximo episódio diretamente pelo Dashboard."
        overview    = "Controle o autoplay do próximo episódio sem sair do Dashboard do Jellyfin."
        owner       = $GitHubUser
        category    = "General"
        versions    = @(
            @{
                version    = $Version
                changelog  = "## 1.0.0.0`n`n- Versão inicial`n- Switch para ligar/desligar autoplay do próximo episódio`n- Compatível com Jellyfin 10.11.x"
                targetAbi  = "10.11.0.0"
                sourceUrl  = $SourceUrl
                checksum   = $checksum
                timestamp  = $timestamp
            }
        )
    }
) | ConvertTo-Json -Depth 10

Set-Content -Path $ManifestOut -Value $manifest -Encoding UTF8
Write-Host "      manifest.json gerado com URL: $SourceUrl"

Write-Host ""
Write-Host "=== Tudo pronto! ===" -ForegroundColor Green
Write-Host ""
Write-Host "Proximos passos:" -ForegroundColor Cyan
Write-Host "  1. git add releases\$ZipName manifest.json"
Write-Host "  2. git commit -m `"release: v$Version`""
Write-Host "  3. git push"
Write-Host "  4. Ativar GitHub Pages (veja README)"
Write-Host ""
Write-Host "URL do repositório no Jellyfin:"
Write-Host "  $RepoUrl/manifest.json" -ForegroundColor Green
Write-Host ""
