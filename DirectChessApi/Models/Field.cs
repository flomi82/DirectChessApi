using DirectChessApi.Enums;

namespace DirectChessApi.Models
{
    public class Field
    {
        public Column Column { get; set; }
        public Row Row { get; set; }

        public override string ToString()
        {
            return Column.ToString() + Row.ToString();
        }
    }
}
