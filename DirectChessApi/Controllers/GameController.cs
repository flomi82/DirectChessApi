using DirectChessApi.Models.Request;
using DirectChessApi.Models.Response;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DirectChessApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        /// <summary>
        /// Create a new chess game
        /// </summary>
        /// <param name="createGameRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateGame(CreateGameRequest createGameRequest)
        {
            var response = new CreateGameResponse();
            return Ok(response);
        }

        /// <summary>
        /// Get a chess game
        /// </summary>
        /// <param name="gameKey"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetGame(string gameKey)
        {
            var response = new GameResponse(); // ... get game with key from repository
            return Ok(response);
        }
    }
}