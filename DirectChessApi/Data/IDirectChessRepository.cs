using DirectChessApi.Enums;
using DirectChessApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DirectChessApi.Data
{
    public interface IDirectChessRepository
    {
        Game GetGame(Guid gameId);
        Game GetGameByKey(string gameKey);
        Game GetGameByPlayerKey(string playerKey);
        ICollection<Move> GetMovesOfGame(Guid gameId);

        Task<Game> AddGame(string player1Name, string player2Name, int whitePlayer);
        Task MakeMove(Guid gameId, string playerKey, Field fromField, Field toField);
    }
}
