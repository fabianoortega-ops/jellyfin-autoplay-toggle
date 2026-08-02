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
$ZipDest     = "$env:TEMP\$ZipName"
$RepoUrl     = "https://$GitHubUser.github.io/$RepoSlug"
$TagName     = "v$Version"
$SourceUrl   = "https://github.com/$GitHubUser/$RepoSlug/releases/download/$TagName/$ZipName"
Write-Host ""
Write-Host "=== AutoPlay Toggle — Build & Release ===" -ForegroundColor Cyan
Write-Host "    Usuário : $GitHubUser  |  Versão: $Version"
Write-Host ""
Write-Host "[1/6] Compilando..." -ForegroundColor Yellow
dotnet build --configuration Release --nologo -v q /p:Version=$Version /p:AssemblyVersion=$Version /p:FileVersion=$Version
if ($LASTEXITCODE -ne 0) { Write-Error "Falha na compilação."; exit 1 }
Write-Host "      OK"
Write-Host "[2/6] Empacotando $ZipName..." -ForegroundColor Yellow
if (Test-Path $ZipDest) { Remove-Item $ZipDest -Force }
Compress-Archive -Path $DllPath -DestinationPath $ZipDest -Force
Write-Host "      OK ($ZipDest)"
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
Write-Host "[4/6] Commitando..." -ForegroundColor Yellow
git add .
git rm -r --cached bin/ obj/ releases/ 2>&1 | Out-Null
$status = git status --porcelain 2>&1
if ($status) {
    git commit -m "chore: publish" 2>&1 | ForEach-Object { Write-Host "      $_" }
} else {
    Write-Host "      Nada novo para commitar."
}
Write-Host "[5/6] Sincronizando com GitHub..." -ForegroundColor Yellow
git pull --rebase origin main 2>&1 | ForEach-Object { Write-Host "      $_" }
if ($LASTEXITCODE -ne 0) { Write-Error "Falha no pull."; exit 1 }
git push origin main 2>&1 | ForEach-Object { Write-Host "      $_" }
if ($LASTEXITCODE -ne 0) { Write-Error "Falha no push."; exit 1 }
Write-Host "[6/6] Criando GitHub Release $TagName..." -ForegroundColor Yellow
$GitHubToken  = ($env:GITHUB_TOKEN)
if (-not $GitHubToken) {
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
    $releaseBody = @{ tag_name = $TagName; name = "AutoPlay Toggle $TagName"; body = "AutoPlay Toggle $Version"; draft = $false; prerelease = $false } | ConvertTo-Json
    try {
        $release    = Invoke-RestMethod -Uri "https://api.github.com/repos/$GitHubUser/$RepoSlug/releases" -Method POST -Headers $headers -Body $releaseBody -ContentType "application/json"
        $uploadUrl  = $release.upload_url -replace '\{.*\}', "?name=$ZipName"
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
