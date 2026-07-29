/**
 * AutoPlay Toggle — Jellyfin Player Button
 * Servido via GitHub Pages. Atualizar + git push = sem reiniciar o Jellyfin.
 */
(function () {
    'use strict';
    var BTN_ID = 'apt-player-btn';
    var _state = null;

    // ── i18n ─────────────────────────────────────────────────────────────────
    var i18n = (function () {
        var full = (navigator.language || 'en').toLowerCase();
        var lang = full.split('-')[0];
        var map = {
            'en': { on: 'Next episode: On',              off: 'Next episode: Off',              loading: 'Next episode: loading\u2026'          },
            'pt': { on: 'Próximo episódio: Ligado',       off: 'Próximo episódio: Desligado',    loading: 'Próximo episódio: aguardando\u2026'   },
            'de': { on: 'N\u00e4chste Folge: Ein',        off: 'N\u00e4chste Folge: Aus',        loading: 'N\u00e4chste Folge: l\u00e4dt\u2026' },
            'fr': { on: '\u00c9pisode suivant: Activ\u00e9', off: '\u00c9pisode suivant: D\u00e9sactiv\u00e9', loading: '\u00c9pisode suivant: chargement\u2026' },
            'es': { on: 'Siguiente episodio: Activado',   off: 'Siguiente episodio: Desactivado',loading: 'Siguiente episodio: cargando\u2026'   },
            'it': { on: 'Episodio successivo: Attivo',    off: 'Episodio successivo: Inattivo',  loading: 'Episodio successivo: caricamento\u2026'},
            'nl': { on: 'Volgend aflevering: Aan',        off: 'Volgend aflevering: Uit',        loading: 'Volgend aflevering: laden\u2026'      },
            'ru': { on: '\u0421\u043b\u0435\u0434. \u044d\u043f\u0438\u0437\u043e\u0434: \u0412\u043a\u043b', off: '\u0421\u043b\u0435\u0434. \u044d\u043f\u0438\u0437\u043e\u0434: \u0412\u044b\u043a\u043b', loading: '\u0421\u043b\u0435\u0434. \u044d\u043f\u0438\u0437\u043e\u0434: \u2026' },
            'zh': { on: '\u4e0b\u4e00\u96c6\uff1a\u5f00\u542f', off: '\u4e0b\u4e00\u96c6\uff1a\u5173\u95ed', loading: '\u4e0b\u4e00\u96c6\uff1a\u52a0\u8f7d\u4e2d\u2026' },
            'ja': { on: '\u6b21\u306e\u30a8\u30d4: \u30aa\u30f3', off: '\u6b21\u306e\u30a8\u30d4: \u30aa\u30d5', loading: '\u6b21\u306e\u30a8\u30d4: \u8aad\u307f\u8fbc\u307f\u4e2d\u2026' },
            'ko': { on: '\ub2e4\uc74c \uc5d0\ud53c: \ucf1c\uc9d1', off: '\ub2e4\uc74c \uc5d0\ud53c: \uaebc\uc9d1', loading: '\ub2e4\uc74c \uc5d0\ud53c: \ub85c\ub529 \uc911\u2026' },
            'pl': { on: 'Nast. odcinek: W\u0142\u0105czone', off: 'Nast. odcinek: Wy\u0142\u0105czone', loading: 'Nast. odcinek: \u0142adowanie\u2026' },
            'sv': { on: 'N\u00e4sta avsnitt: P\u00e5', off: 'N\u00e4sta avsnitt: Av', loading: 'N\u00e4sta avsnitt: laddar\u2026' },
            'nb': { on: 'Neste episode: P\u00e5', off: 'Neste episode: Av', loading: 'Neste episode: laster\u2026' },
            'da': { on: 'N\u00e6ste afsnit: Til', off: 'N\u00e6ste afsnit: Fra', loading: 'N\u00e6ste afsnit: indl\u00e6ser\u2026' },
            'fi': { on: 'Seuraava jakso: P\u00e4\u00e4ll\u00e4', off: 'Seuraava jakso: Pois', loading: 'Seuraava jakso: ladataan\u2026' },
            'cs': { on: 'Dal\u0161\u00ed epizoda: Zapnuto', off: 'Dal\u0161\u00ed epizoda: Vypnuto', loading: 'Dal\u0161\u00ed epizoda: na\u010d\u00edt\u00e1n\u00ed\u2026' },
            'sk': { on: '\u010fal\u0161ia epiz.: Zapnut\u00e9', off: '\u010fal\u0161ia epiz.: Vypnut\u00e9', loading: '\u010fal\u0161ia epiz.: na\u010d\u00edtavanie\u2026' },
            'hu': { on: 'K\u00f6v. r\u00e9sz: Be', off: 'K\u00f6v. r\u00e9sz: Ki', loading: 'K\u00f6v. r\u00e9sz: bet\u00f6lt\u00e9s\u2026' },
            'ro': { on: 'Ep. urm\u0103tor: Activat', off: 'Ep. urm\u0103tor: Dezactivat', loading: 'Ep. urm\u0103tor: se \u00eancarc\u0103\u2026' },
            'tr': { on: 'Sonraki b\u00f6l\u00fcm: A\u00e7\u0131k', off: 'Sonraki b\u00f6l\u00fcm: Kapal\u0131', loading: 'Sonraki b\u00f6l\u00fcm: y\u00fckleniyor\u2026' },
            'ar': { on: '\u0627\u0644\u062d\u0644\u0642\u0629 \u0627\u0644\u062a\u0627\u0644\u064a\u0629: \u062a\u0634\u063a\u064a\u0644', off: '\u0627\u0644\u062d\u0644\u0642\u0629 \u0627\u0644\u062a\u0627\u0644\u064a\u0629: \u0625\u064a\u0642\u0627\u0641', loading: '\u062c\u0627\u0631 \u0627\u0644\u062a\u062d\u0645\u064a\u0644\u2026' },
            'uk': { on: '\u041d\u0430\u0441\u0442. \u0435\u043f\u0456\u0437\u043e\u0434: \u0423\u0432\u0456\u043c\u043a', off: '\u041d\u0430\u0441\u0442. \u0435\u043f\u0456\u0437\u043e\u0434: \u0412\u0438\u043c\u043a', loading: '\u041d\u0430\u0441\u0442. \u0435\u043f\u0456\u0437\u043e\u0434: \u0437\u0430\u0432\u0430\u043d\u0442\u0430\u0436\u0435\u043d\u043d\u044f\u2026' },
            'el': { on: '\u0395\u03c0\u03cc\u03bc. \u03b5\u03c0\u03b5\u03b9\u03c3.: \u0395\u03bd\u03b5\u03c1\u03b3\u03cc', off: '\u0395\u03c0\u03cc\u03bc. \u03b5\u03c0\u03b5\u03b9\u03c3.: \u0391\u03bd\u03b5\u03bd\u03b5\u03c1\u03b3\u03cc', loading: '\u03c6\u03cc\u03c1\u03c4\u03c9\u03c3\u03b7\u2026' },
            'ca': { on: 'Ep. seg\u00fcent: Activat', off: 'Ep. seg\u00fcent: Desactivat', loading: 'Ep. seg\u00fcent: carregant\u2026' }
        };
        return map[full] || map[lang] || map['en'];
    }());

    // ── API ───────────────────────────────────────────────────────────────────
    function getToken() {
        try { var ac = window.ApiClient; if (!ac) return ''; return (typeof ac.accessToken === 'function' ? ac.accessToken() : ac.accessToken) || ''; } catch(e) { return ''; }
    }
    function getUserId() {
        try { var ac = window.ApiClient; if (!ac) return ''; return (typeof ac.getCurrentUserId === 'function' ? ac.getCurrentUserId() : ac.currentUserId) || ''; } catch(e) { return ''; }
    }
    function api(method, path, body) {
        return fetch(window.location.origin + '/' + path, {
            method: method,
            headers: { 'Authorization': 'MediaBrowser Token="' + getToken() + '"', 'Content-Type': 'application/json' },
            body: body ? JSON.stringify(body) : undefined
        }).then(function(r) { return r.json(); });
    }

    // ── Botão ─────────────────────────────────────────────────────────────────
    function applyState(btn, enabled) {
        _state = enabled;
        btn.title = enabled ? i18n.on : i18n.off;
        btn.style.opacity = enabled ? '1' : '0.4';
    }

    function createButton() {
        var btn = document.createElement('button');
        btn.id = BTN_ID;
        btn.type = 'button';
        btn.className = 'paper-icon-button-light';
        btn.style.cssText = 'vertical-align:middle;margin:0 2px;padding:0;background:none;border:none;cursor:pointer;color:inherit;opacity:0.4;';
        btn.innerHTML = '<span class="material-icons" style="font-size:22px">repeat</span>';
        btn.title = i18n.loading;
        var uid = getUserId();
        if (uid) api('GET', 'AutoPlay/Status/' + uid).then(function(d) { applyState(btn, d.enableNextEpisodeAutoPlay); }).catch(function(){});
        btn.addEventListener('click', function(e) {
            e.stopPropagation();
            var uid = getUserId(); if (!uid) return;
            btn.disabled = true;
            api('POST', 'AutoPlay/Toggle', { UserId: uid, Enable: !_state })
                .then(function(d) { applyState(btn, d.enableNextEpisodeAutoPlay); btn.disabled = false; })
                .catch(function() { btn.disabled = false; });
        });
        return btn;
    }

    // ── Injeção robusta ──────────────────────────────────────────────────────
    // MutationObserver sempre ativo — detect() é O(1) (getElementById).
    // Sem setInterval. O observer dispara na mudança de DOM e re-injeta
    // o botão se o Jellyfin Enhanced ou o player reconstruir os controles.

    function inject() {
        if (document.getElementById(BTN_ID)) return;
        var ref = document.querySelector('.btnSubtitles') || document.querySelector('.btnFullscreen');
        if (!ref) return;
        ref.parentNode.insertBefore(createButton(), ref);
        console.log('[AutoPlayToggle] Botão injetado.');
    }

    // Quando o vídeo começa a tocar o OSD aparece automaticamente —
    // injetamos logo após. Evento no capture phase é leve e preciso.
    document.addEventListener('play', function(e) {
        if (e.target && e.target.tagName === 'VIDEO') {
            setTimeout(inject, 600); // aguarda OSD renderizar
        }
    }, true);

    // Mousemove: OSD aparece com movimento — debounce curto para resposta rápida
    var _t = null;
    document.addEventListener('mousemove', function() {
        clearTimeout(_t);
        _t = setTimeout(inject, 60);
    }, { passive: true });

    // Safety net de baixíssimo custo
    setInterval(inject, 4000);
    console.log('[AutoPlayToggle] Script carregado.');
}());
