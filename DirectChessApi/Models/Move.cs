using System;

namespace DirectChessApi.Models
{
    public class Move
    {
        public Guid GameId { get; set; }
        public Guid PlayerKey { get; set; }
        public Field FromField { get; set; }
        public Field ToField { get; set; }
    }
}
