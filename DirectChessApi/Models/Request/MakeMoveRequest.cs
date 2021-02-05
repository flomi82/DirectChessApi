namespace DirectChessApi.Models.Request
{
    public class MakeMoveRequest
    {
        public string PlayerKey { get; set; }
        public string FromField { get; set; }
        public string ToField { get; set; }
    }
}
