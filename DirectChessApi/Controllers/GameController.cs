using DirectChessApi.Data;
using DirectChessApi.Models.Request;
using DirectChessApi.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using System.Linq;
using DirectChessApi.Models;
using DirectChessApi.Services;
using System.Collections.Generic;

namespace DirectChessApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private IDirectChessRepository _directChessRepository;
        private IRandomService _randomService;

        public GameController(IDirectChessRepository directChessRepository,
            IRandomService randomService)
        {
            _directChessRepository = directChessRepository;
            _randomService = randomService;
        }

        /// <summary>
        /// Create a new chess game
        /// </summary>
        /// <param name="createGameRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(GameResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [SwaggerOperation(Summary = "Create a new chess game")]
        public async Task<IActionResult> CreateGame(CreateGameRequest createGameRequest)
        {
            if (!createGameRequest.WhitePlayer.HasValue)
            {
                createGameRequest.WhitePlayer = (int)_randomService.GetRandomColor();
            }

            var newGame = await _directChessRepository.AddGame(
                createGameRequest.Player1Name,
                createGameRequest.Player2Name,
                createGameRequest.WhitePlayer.Value);

            var response = new CreateGameResponse
            {
                GameKey = newGame.GameKey,
                Player1Name = newGame.Player1Name,
                Player1Key = newGame.Player1Key,
                Player2Name = newGame.Player2Name,
                Player2Key = newGame.Player2Key,
                WhitePlayer = newGame.WhitePlayer
            };

            return Ok(response);
        }

        /// <summary>
        /// Make a move
        /// </summary>
        /// <returns></returns>
        [HttpPost("move")]
        [ProducesResponseType(typeof(GameResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerOperation(Summary = "Create a new chess game")]
        public async Task<IActionResult> MakeMove(MakeMoveRequest makeMoveRequest)
        {
            var game = _directChessRepository.GetGameByPlayerKey(makeMoveRequest.PlayerKey);

            await _directChessRepository.MakeMove(
                game.GameId,
                makeMoveRequest.PlayerKey,
                new Field(makeMoveRequest.FromField),
                new Field(makeMoveRequest.ToField));

            return Ok();
        }

        /// <summary>
        /// Get all moves of an existing chess game
        /// </summary>
        /// <param name="gameKey"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(GameResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Get all moves of an existing chess game")]
        public IActionResult GetMovesOfGame(string gameKey)
        {
            var game = _directChessRepository.GetGameByKey(gameKey);

            var moves = _directChessRepository.GetMovesOfGame(game.GameId).ToList<Move>();
            var moveResponses = new List<MoveResponse>();
            foreach (var move in moves)
            {;
                moveResponses.Add(new MoveResponse
                {
                    FromField = move.FromField,
                    ToField = move.ToField
                });
            }

            var response = new GameResponse
            {
                GameKey = gameKey,
                Player1Name = game.Player1Name,
                Player2Name = game.Player2Name,
                WhitePlayer = game.WhitePlayer,
                Moves = moveResponses
            };

            return Ok(response);
        }
    }
}