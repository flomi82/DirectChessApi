using System.Collections.Generic;

namespace DirectChessApi.Models.Response
{
    public class GameResponse
    {
        public string GameKey { get; set; }
        public string Player1Name { get; set; }
        public string Player2Name { get; set; }
        public int WhitePlayer { get; set; }
        public List<MoveResponse> Moves { get; set; }
    }
}
