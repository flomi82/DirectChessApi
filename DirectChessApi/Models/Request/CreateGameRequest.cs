﻿using DirectChessApi.Enums;

namespace DirectChessApi.Models.Request
{
    public class CreateGameRequest
    {
        public string Player1Name { get; set; }
        public string Player2Name { get; set; }
        public int? WhitePlayer { get; set; }
    }
}
