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
                user.EnableNextEpisodeAutoPlay = request.Enable;
                await _userManager.UpdateUserAsync(user).ConfigureAwait(false);
                _logger.LogInformation(
                    "[AutoPlayToggle] Usuário {UserId}: EnableNextEpisodeAutoPlay → {Value}",
                    user.Id, request.Enable);
                return Ok(new
                {
                    success = true,
                    userId  = user.Id,
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
                enableNextEpisodeAutoPlay = user.EnableNextEpisodeAutoPlay
            });
        }
    }
    public class ToggleRequest
    {
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public bool Enable { get; set; }
    }
}
