using DirectChessApi.Enums;

namespace DirectChessApi.Services
{
    public interface IRandomService
    {
        string GetRandomGameKey();
        string GetRandomPlayerKey();
        Color GetRandomColor();
    }
}
