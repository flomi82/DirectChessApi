using System;
using System.Collections.Generic;

namespace DirectChessApi.Models
{
    public class Game
    {
        public Guid GameId { get; set; }
        public string GameKey { get; set; }
        public string Player1Key { get; set; }
        public string Player1Name { get; set; }
        public string Player2Key { get; set; }
        public string Player2Name { get; set; }
        public int WhitePlayer { get; set; }
        public DateTime Timestamp { get; set; }

        public ICollection<Move> Moves { get; set; }

    }
}
