using AMS.Server.Services;
using AMS.Shared;
using Microsoft.AspNetCore.Mvc;

namespace AMS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService gameService;
        public GameController(IGameService _gameService)
        {
            gameService = _gameService;
        }

        [HttpPost("AddGame")]
        public async Task<IActionResult> AddGame([FromBody] Game game)
        {
            try
            {
               var results = await gameService.AddGame(game);
                if (results == null)
                    return NotFound();
                else
                    return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("GetGames")]
        public async Task<IActionResult> GetGames()
        {
            try
            {
                return Ok( await gameService.GetAllGames());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
