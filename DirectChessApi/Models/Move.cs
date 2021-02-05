using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirectChessApi.Models
{
    public class Move
    {
        public Guid GameId { get; set; }
        public string PlayerKey { get; set; }
        public string FromField { get; set; }
        public string ToField { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
