using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DirectChessApi.Enums;
using DirectChessApi.Models;
using DirectChessApi.Services;

namespace DirectChessApi.Data
{
    public class DirectChessRepository : IDirectChessRepository
    {
        private DirectChessContext _directChessContext { get; set; }
        private IRandomService _randomService { get; set; }

        public DirectChessRepository(
            DirectChessContext directChessContext,
            IRandomService randomService)
        {
            _directChessContext = directChessContext;
            _randomService = randomService;
        }

        public async Task<Game> AddGame(string player1Name, string player2Name, int whitePlayer)
        {
            var newGame = new Game
            {
                GameId = Guid.NewGuid(),
                GameKey = _randomService.GetRandomGameKey(),
                Player1Name = player1Name,
                Player2Name = player2Name,
                Player1Key = _randomService.GetRandomPlayerKey(),
                Player2Key = _randomService.GetRandomPlayerKey(),
                WhitePlayer = whitePlayer
            };

            await _directChessContext.Games.AddAsync(newGame);
            await _directChessContext.SaveChangesAsync();

            return newGame;
        }

        public Game GetGame(Guid gameId)
        {
            return _directChessContext.Games.SingleOrDefault(g => g.GameId == gameId);
        }

        public Game GetGameByKey(string gameKey)
        {
            return _directChessContext.Games.SingleOrDefault(g => g.GameKey == gameKey);
        }

        public Game GetGameByPlayerKey(string playerKey)
        {
            return _directChessContext.Games.SingleOrDefault(g => g.Player1Key == playerKey || g.Player2Key == playerKey);
        }

        public ICollection<Move> GetMovesOfGame(Guid gameId)
        {
            return _directChessContext.Moves.Where(m => m.GameId == gameId).ToList<Move>();
        }

        public async Task MakeMove(Guid gameId, string playerKey, Field fromField, Field toField)
        {
            var game = _directChessContext.Games.Single(g => g.GameId == gameId);
            _directChessContext.Games.Update(game);

            var newMove = new Move
            {
                GameId = gameId,
                PlayerKey = playerKey,
                FromField = fromField.ToString(),
                ToField = toField.ToString()
            };

            await _directChessContext.Moves.AddAsync(newMove);
            await _directChessContext.SaveChangesAsync();
        }
    }
}
