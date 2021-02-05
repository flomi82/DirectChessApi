using DirectChessApi.Enums;
using System;

namespace DirectChessApi.Models
{
    public class Field
    {
        public Column Column { get; set; }
        public Row Row { get; set; }

        public Field(string field)
        {
            var column = field.Substring(0, 1);
            var row = "_" + field.Substring(1);
            Column = (Column)Enum.Parse(typeof(Column), column);
            Row = (Row)Enum.Parse(typeof(Row), row);
        }

        public override string ToString()
        {
            return Column.ToString() + Row.ToString().Substring(1);
        }
    }
}
