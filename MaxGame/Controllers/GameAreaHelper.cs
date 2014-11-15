using MaxGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxGame.Controllers
{
    public class AreaChange
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public bool Value { get; set; }
        public string ColumnHeader { get; set; }
        public string RowHeader { get; set; }
    }

    public class GameAreaHelper
    {
        public static List<AreaChange> FindDiffs(GameArea area1, GameArea area2)
        {
            var result = new List<AreaChange>();
            for (var row = 0; row < area1.Fields.GetLength(0); row++)
                for (var col = 0; col < area1.Fields.GetLength(1); col++)
                    if (area2.Fields[row, col].Enabled != area1.Fields[row, col].Enabled)
                    {
                        var rowProj = new MaxGame.Models.Row(area2, row);
                        var colProj = new MaxGame.Models.Column(area2, col);
                        result.Add(new AreaChange { Row = row, Col = col, Value = area2.Fields[row, col].Enabled, RowHeader = rowProj.ToString(), ColumnHeader = colProj.ToString() });
                    }
            return result;
        }

        public static List<AreaChange> GetHeaders(GameArea area)
        {
            var result = new List<AreaChange>();
            for (var index = 0; index < area.Fields.GetLength(0); index++)
            {
                var rowProj = new MaxGame.Models.Row(area, index);
                var colProj = new MaxGame.Models.Column(area, index);
                result.Add(new AreaChange { Row = index, Col = index, Value = false, RowHeader = rowProj.ToString(), ColumnHeader = colProj.ToString() });
            }
            return result;
        }
    }
}
