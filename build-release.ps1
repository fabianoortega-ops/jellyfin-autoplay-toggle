# =============================================================================
# build-release.ps1
# Uso: .\build-release.ps1
#      .\build-release.ps1 -Version "1.0.1.0"
# =============================================================================
param(
    [string]$GitHubUser = "fabianoortega-ops",
    [string]$Version    = "1.0.0.0"
)

$ErrorActionPreference = "Stop"
Set-Location -Path $PSScriptRoot

$PluginName = "JellyfinAutoPlayToggle"
$DllPath    = "bin\Release\net9.0\$PluginName.dll"
$ZipName    = "${PluginName}_${Version}.zip"
$ZipDest    = "releases\$ZipName"
$RepoUrl    = "https://$GitHubUser.github.io/jellyfin-autoplay-toggle"
$SourceUrl  = "$RepoUrl/releases/$ZipName"

Write-Host ""
Write-Host "=== AutoPlay Toggle — Build & Release ===" -ForegroundColor Cyan
Write-Host "    Usuário : $GitHubUser  |  Versão: $Version"
Write-Host ""

# ── 1. Compilar ──────────────────────────────────────────────────────────────
Write-Host "[1/5] Compilando..." -ForegroundColor Yellow
dotnet build --configuration Release --nologo -v q /p:Version=$Version /p:AssemblyVersion=$Version /p:FileVersion=$Version
if ($LASTEXITCODE -ne 0) { Write-Error "Falha na compilação."; exit 1 }
Write-Host "      OK"

# ── 2. Empacotar .dll ────────────────────────────────────────────────────────
Write-Host "[2/5] Empacotando $ZipName..." -ForegroundColor Yellow
if (!(Test-Path "releases")) { New-Item -ItemType Directory -Path "releases" | Out-Null }
if (Test-Path $ZipDest)      { Remove-Item $ZipDest -Force }
Compress-Archive -Path $DllPath -DestinationPath $ZipDest -Force
Write-Host "      OK"

# ── 3. Calcular MD5 e gerar manifest.json ────────────────────────────────────
Write-Host "[3/5] Gerando manifest.json..." -ForegroundColor Yellow
$checksum  = (Get-FileHash $ZipDest -Algorithm MD5).Hash.ToLower()
$timestamp = (Get-Date).ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ")

$pluginObj = [ordered]@{
    guid        = "036768e6-cd63-49c0-9661-2677d3ccef72"
    name        = "AutoPlay Toggle"
    description = "Adiciona um botão para ligar/desligar o autoplay do próximo episódio diretamente pelo Dashboard."
    overview    = "Controle o autoplay do próximo episódio sem sair do Dashboard do Jellyfin."
    owner       = $GitHubUser
    category    = "General"
    versions    = @([ordered]@{
        version   = $Version
        changelog = "## $Version`n`n- Switch para ligar/desligar autoplay`n- Compatível com Jellyfin 10.11.x"
        targetAbi = "10.11.0.0"
        sourceUrl = $SourceUrl
        checksum  = $checksum
        timestamp = $timestamp
    })
}
$manifestJson = "[" + ($pluginObj | ConvertTo-Json -Depth 10) + "]"
Set-Content -Path "manifest.json" -Value $manifestJson -Encoding UTF8
Write-Host "      MD5: $checksum  |  OK"

# ── 4. Garantir que bin/ e obj/ não estão sendo trackeados ─────────────────
Write-Host "[4/5] Verificando tracking de bin/ e obj/..." -ForegroundColor Yellow
$tracked = git ls-files bin/ obj/ 2>&1
if ($tracked) {
    git rm -r --cached bin/ obj/ 2>&1 | Out-Null
    Write-Host "      bin/ e obj/ removidos do tracking."
}

# ── 5. Commit (git add . funciona pois bin/ e obj/ estão no .gitignore) ──────
Write-Host "[5/5] Commitando..." -ForegroundColor Yellow
git add "releases/$ZipName" manifest.json .gitignore Plugin.cs AutoPlayController.cs PluginConfiguration.cs JellyfinAutoPlayToggle.csproj "Configuration/config.html" build-release.ps1 .nojekyll 2>&1 | Out-Null

$status = git status --porcelain 2>&1
if ($status) {
    git commit -m "release: v$Version" 2>&1 | ForEach-Object { Write-Host "      $_" }
} else {
    Write-Host "      Nada novo para commitar."
}

# ── 5. Pull --rebase + push ───────────────────────────────────────────────────
Write-Host "[6/6] Sincronizando e enviando..." -ForegroundColor Yellow
git pull --rebase origin main 2>&1 | ForEach-Object { Write-Host "      $_" }
if ($LASTEXITCODE -ne 0) { Write-Error "Falha no pull --rebase."; exit 1 }

git push origin main 2>&1 | ForEach-Object { Write-Host "      $_" }
if ($LASTEXITCODE -ne 0) { Write-Error "Falha no push."; exit 1 }

Write-Host ""
Write-Host "=== Pronto! Plugin publicado. ===" -ForegroundColor Green
Write-Host ""
Write-Host "URL do repositório Jellyfin:" -ForegroundColor Cyan
Write-Host "  $RepoUrl/manifest.json" -ForegroundColor Green
Write-Host ""
