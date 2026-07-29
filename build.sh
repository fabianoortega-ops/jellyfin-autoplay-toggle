#!/usr/bin/env bash
# =============================================================================
# build.sh — Compila e instala o plugin AutoPlay Toggle no Jellyfin
# =============================================================================
# Uso:
#   chmod +x build.sh
#   ./build.sh                          # apenas compila
#   ./build.sh /caminho/plugins/jellyfin  # compila E instala
# =============================================================================
set -e

PLUGIN_NAME="JellyfinAutoPlayToggle"
BUILD_DIR="bin/Release/net8.0"

echo "▶ Compilando $PLUGIN_NAME..."
dotnet build --configuration Release

echo "✔ Compilação concluída: $BUILD_DIR/$PLUGIN_NAME.dll"

# Instalação opcional
if [ -n "$1" ]; then
    PLUGINS_DIR="$1"
    DEST="$PLUGINS_DIR/AutoPlayToggle"

    echo "▶ Instalando em: $DEST"
    mkdir -p "$DEST"
    cp "$BUILD_DIR/$PLUGIN_NAME.dll" "$DEST/"
    echo "✔ Plugin copiado para $DEST"
    echo ""
    echo "⚠  Reinicie o Jellyfin para carregar o plugin."
    echo "   TrueNAS Scale: Apps → Jellyfin → Stop → Start"
fi

echo ""
echo "Feito! 🎉"
