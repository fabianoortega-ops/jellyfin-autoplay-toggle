# =============================================================================
# build-release.ps1
# Compila, empacota, atualiza o manifest e publica via GitHub Releases.
# Os zips ficam na aba Releases do GitHub — não na árvore do repositório.
#
# Uso: .\build-release.ps1
#      .\build-release.ps1 -Version "0.3.0.0"
# =============================================================================
param(
    [string]$GitHubUser = "fabianoortega-ops",
    [string]$Version    = "0.2.5.0"
)

$ErrorActionPreference = "Stop"
Set-Location -Path $PSScriptRoot

$PluginName  = "JellyfinAutoPlayToggle"
$RepoSlug    = "jellyfin-autoplay-toggle"
$DllPath     = "bin\Release\net9.0\$PluginName.dll"
$ZipName     = "${PluginName}_${Version}.zip"
$ZipDest     = "$env:TEMP\$ZipName"   # zip fica só no temp, NÃO no repo
$RepoUrl     = "https://$GitHubUser.github.io/$RepoSlug"
$TagName     = "v$Version"
# Releases do GitHub — URL de download direto (não usa GitHub Pages)
$SourceUrl   = "https://github.com/$GitHubUser/$RepoSlug/releases/download/$TagName/$ZipName"

Write-Host ""
Write-Host "=== AutoPlay Toggle — Build & Release ===" -ForegroundColor Cyan
Write-Host "    Usuário : $GitHubUser  |  Versão: $Version"
Write-Host ""

# ── 1. Compilar ──────────────────────────────────────────────────────────────
Write-Host "[1/6] Compilando..." -ForegroundColor Yellow
dotnet build --configuration Release --nologo -v q /p:Version=$Version /p:AssemblyVersion=$Version /p:FileVersion=$Version
if ($LASTEXITCODE -ne 0) { Write-Error "Falha na compilação."; exit 1 }
Write-Host "      OK"

# ── 2. Empacotar .dll (no temp, fora do repo) ────────────────────────────────
Write-Host "[2/6] Empacotando $ZipName..." -ForegroundColor Yellow
if (Test-Path $ZipDest) { Remove-Item $ZipDest -Force }
Compress-Archive -Path $DllPath -DestinationPath $ZipDest -Force
Write-Host "      OK ($ZipDest)"

# ── 3. Calcular MD5 e gerar manifest.json ────────────────────────────────────
Write-Host "[3/6] Gerando manifest.json..." -ForegroundColor Yellow
$checksum  = (Get-FileHash $ZipDest -Algorithm MD5).Hash.ToLower()
$timestamp = (Get-Date).ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ")

$pluginObj = [ordered]@{
    guid        = "036768e6-cd63-49c0-9661-2677d3ccef72"
    name        = "AutoPlay Toggle"
    description = "Adiciona um botão para ligar/desligar o autoplay do próximo episódio diretamente pelo Dashboard."
    overview    = "Controle o autoplay do próximo episódio sem sair do Dashboard do Jellyfin."
    owner       = $GitHubUser
    category    = "General"
    imageUrl    = "$RepoUrl/logo.svg"
    versions    = @([ordered]@{
        version   = $Version
        changelog = "## $Version`n`n- AutoPlay Toggle v$Version"
        targetAbi = "10.11.0.0"
        sourceUrl = $SourceUrl
        checksum  = $checksum
        timestamp = $timestamp
    })
}
$manifestJson = "[" + ($pluginObj | ConvertTo-Json -Depth 10) + "]"
Set-Content -Path "manifest.json" -Value $manifestJson -Encoding UTF8
Write-Host "      MD5: $checksum  |  OK"

# ── 4. Commit e push do código/manifest ──────────────────────────────────────
Write-Host "[4/6] Commitando..." -ForegroundColor Yellow
git add .
# Remove bin/ e obj/ do índice mesmo que .gitignore falhe
git rm -r --cached bin/ obj/ releases/ 2>&1 | Out-Null

$status = git status --porcelain 2>&1
if ($status) {
    git commit -m "release: $TagName" 2>&1 | ForEach-Object { Write-Host "      $_" }
} else {
    Write-Host "      Nada novo para commitar."
}

Write-Host "[5/6] Sincronizando com GitHub..." -ForegroundColor Yellow
git pull --rebase origin main 2>&1 | ForEach-Object { Write-Host "      $_" }
if ($LASTEXITCODE -ne 0) { Write-Error "Falha no pull."; exit 1 }
git push origin main 2>&1 | ForEach-Object { Write-Host "      $_" }
if ($LASTEXITCODE -ne 0) { Write-Error "Falha no push."; exit 1 }

# ── 5. Criar GitHub Release e fazer upload do zip via API ───────────────────
Write-Host "[6/6] Criando GitHub Release $TagName..." -ForegroundColor Yellow

# Lê o token do git credential store
$tokenProcess = git credential fill 2>&1
$GitHubToken  = ($env:GITHUB_TOKEN)

if (-not $GitHubToken) {
    # Tenta buscar do credential helper
    $credInput  = "protocol=https`nhost=github.com`n"
    $credOutput = $credInput | git credential fill 2>&1
    $GitHubToken = ($credOutput | Select-String "password=(.+)").Matches.Groups[1].Value
}

if (-not $GitHubToken) {
    Write-Warning "Token do GitHub não encontrado. Defina a variável de ambiente GITHUB_TOKEN."
    Write-Warning "Exemplo: `$env:GITHUB_TOKEN = 'ghp_...'"
    Write-Host ""
    Write-Host "Após definir o token, rode o script novamente ou crie o release manualmente:"
    Write-Host "  https://github.com/$GitHubUser/$RepoSlug/releases/new"
    Write-Host "  Tag: $TagName  |  Arquivo: $ZipDest"
} else {
    $headers = @{
        "Authorization" = "Bearer $GitHubToken"
        "Accept"        = "application/vnd.github+json"
        "X-GitHub-Api-Version" = "2022-11-28"
    }

    # Criar release
    $releaseBody = @{ tag_name = $TagName; name = "AutoPlay Toggle $TagName"; body = "AutoPlay Toggle $Version"; draft = $false; prerelease = $false } | ConvertTo-Json
    try {
        $release    = Invoke-RestMethod -Uri "https://api.github.com/repos/$GitHubUser/$RepoSlug/releases" -Method POST -Headers $headers -Body $releaseBody -ContentType "application/json"
        $uploadUrl  = $release.upload_url -replace '\{.*\}', "?name=$ZipName"

        # Upload do zip
        $zipBytes   = [System.IO.File]::ReadAllBytes($ZipDest)
        Invoke-RestMethod -Uri $uploadUrl -Method POST -Headers $headers -Body $zipBytes -ContentType "application/octet-stream" | Out-Null
        Write-Host "      Release $TagName criado com sucesso!"
    } catch {
        Write-Warning "Erro ao criar release via API: $_"
        Write-Host "Crie manualmente em: https://github.com/$GitHubUser/$RepoSlug/releases/new"
    }
}

Write-Host ""
Write-Host "=== Pronto! ===" -ForegroundColor Green
Write-Host ""
Write-Host "Repositório Jellyfin:" -ForegroundColor Cyan
Write-Host "  $RepoUrl/manifest.json" -ForegroundColor Green
Write-Host ""
