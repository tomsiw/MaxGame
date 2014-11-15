using MaxGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxGame.Controllers
{
    public class GameController
    {
        private GameArea orgArea;
        private GameArea area;

        public GameController(GameArea _area)
        { 
            orgArea = _area;
            area = new GameArea(orgArea.Fields.GetLength(0));
        }

        public List<AreaChange> CellClicked(int row, int col)
        {
            area.Fields[row, col].Toggle();
            var headers = GameAreaHelper.GetHeaders(orgArea);
            var orgRowProj = new Row(orgArea, row).Projection;
            var rowProj = new Row(area, row).Projection;

            var orgColProj = new Column(orgArea, col).Projection;
            var colProj = new Column(area, col).Projection;

            var rowDiff = !Same(orgRowProj, rowProj);
            var colDiff = !Same(orgColProj, colProj);

            var rowHeader = headers[row].RowHeader + (rowDiff ? " *" : "");
            var colHeader = headers[col].ColumnHeader + (colDiff ? " *" : "");

            var val = area.Fields[row, col].Enabled;

            return new List<AreaChange> { new AreaChange{ Row = row, Col = col, Value = val, RowHeader = rowHeader, ColumnHeader = colHeader } };
        }

        private bool Same(bool[] proj1, bool[] proj2)
        {
            if (proj1.Length != proj2.Length)
                return false;
            for (var index = 0; index < proj1.Length; index++)
                if (proj1[index] != proj2[index])
                    return false;
            return true;
        }

        public List<AreaChange> GetInitialState()
        {
            return GameAreaHelper.GetHeaders(orgArea).Select(a => MarkChanges(a)).ToList();
        }

        private AreaChange MarkChanges(AreaChange org)
        {
            if (!string.IsNullOrEmpty(org.RowHeader))
                org.RowHeader += " *";
            if (!string.IsNullOrEmpty(org.ColumnHeader))
                org.ColumnHeader += " *";
            return org;
        }

        public bool IsDifference()
        {
            return GameAreaHelper.FindDiffs(orgArea, area).Count > 0;
        }
    }
}
