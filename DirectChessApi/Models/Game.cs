using DirectChessApi.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirectChessApi.Models
{
    public class Game
    {
        public Guid GameId { get; set; }
        public string GameKey { get; set; }
        public string Player1Key { get; set; }
        public string Player1Name { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public Color Player1Color { get; set; }
        public string Player2Key { get; set; }
        public string Player2Name { get; set; }

        public ICollection<Move> Moves { get; set; }

    }
}
