namespace DirectChessApi.Models.Response
{
    public class CreateGameResponse
    {
        public string GameKey { get; set; }
        public string Player1Name { get; set; }
        public string Player1Key { get; set; }
        public string Player2Name { get; set; }
        public string Player2Key { get; set; }
        public int WhitePlayer { get; set; }
    }
}
