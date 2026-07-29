using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using MediaBrowser.Controller.Library;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JellyfinAutoPlayToggle
{
    /// <summary>
    /// Expõe dois endpoints REST:
    ///   POST /AutoPlay/Toggle        — altera o autoplay do usuário
    ///   GET  /AutoPlay/Status/{id}   — consulta o estado atual
    ///
    /// NOTA JELLYFIN 10.10+:
    ///   A classe User foi reestruturada. As propriedades que antes ficavam em
    ///   user.Configuration.X foram movidas para diretamente em user.X.
    ///   Portanto: user.Configuration.EnableNextEpisodeAutoPlay
    ///         →   user.EnableNextEpisodeAutoPlay
    ///   E para salvar: _userManager.UpdateUserAsync(user)
    ///   (o método UpdateConfigurationAsync foi removido)
    /// </summary>
    [ApiController]
    [Route("AutoPlay")]
    [Authorize]
    public class AutoPlayController : ControllerBase
    {
        private readonly IUserManager _userManager;
        private readonly ILogger<AutoPlayController> _logger;

        public AutoPlayController(
            IUserManager userManager,
            ILogger<AutoPlayController> logger)
        {
            _userManager = userManager;
            _logger      = logger;
        }

        // ------------------------------------------------------------------ //
        //  POST /AutoPlay/Toggle                                               //
        //  Body JSON: { "userId": "<guid>", "enable": true|false }            //
        // ------------------------------------------------------------------ //
        [HttpPost("Toggle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ToggleAutoPlay([FromBody] ToggleRequest request)
        {
            try
            {
                var user = _userManager.GetUserById(request.UserId);
                if (user is null)
                {
                    return NotFound(new { error = $"Usuário '{request.UserId}' não encontrado." });
                }

                // Jellyfin 10.10+: propriedade direta no objeto User
                user.EnableNextEpisodeAutoPlay = request.Enable;

                // Salva via UpdateUserAsync (UpdateConfigurationAsync foi removido no 10.10)
                await _userManager.UpdateUserAsync(user).ConfigureAwait(false);

                _logger.LogInformation(
                    "[AutoPlayToggle] Usuário {UserId}: EnableNextEpisodeAutoPlay → {Value}",
                    user.Id, request.Enable);

                return Ok(new
                {
                    success = true,
                    userId  = user.Id,
                    // Lê de volta para confirmar o valor persistido
                    enableNextEpisodeAutoPlay = user.EnableNextEpisodeAutoPlay
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[AutoPlayToggle] Erro ao alterar configuração.");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { error = "Erro interno ao alterar configuração.", detail = ex.Message });
            }
        }

        // ------------------------------------------------------------------ //
        //  GET /AutoPlay/Status/{userId}                                       //
        // ------------------------------------------------------------------ //
        [HttpGet("Status/{userId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetStatus([FromRoute] Guid userId)
        {
            var user = _userManager.GetUserById(userId);
            if (user is null)
            {
                return NotFound(new { error = $"Usuário '{userId}' não encontrado." });
            }

            return Ok(new
            {
                userId  = user.Id,
                // Jellyfin 10.10+: propriedade direta no objeto User
                enableNextEpisodeAutoPlay = user.EnableNextEpisodeAutoPlay
            });
        }
    }

    // ----------------------------------------------------------------------- //
    //  DTO para o corpo do POST /AutoPlay/Toggle                               //
    // ----------------------------------------------------------------------- //
    public class ToggleRequest
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public bool Enable { get; set; }
    }
}

