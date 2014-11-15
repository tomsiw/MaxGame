using MaxGame.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxGame.Controllers
{
    public class EditorController
    {
        private GameArea area;
        public GameArea Area { get { return area; } }

        public EditorController(GameArea _area)
        {
            area = _area;
        }

        public List<AreaChange> CellClicked(int row, int col)
        {
            area.Fields[row, col].Toggle();
            var rowProj = new MaxGame.Models.Row(area, row);
            var colProj = new MaxGame.Models.Column(area, col);
            return new List<AreaChange> { new AreaChange { Row = row, Col = col, Value = area.Fields[row, col].Enabled, RowHeader = rowProj.ToString(), ColumnHeader = colProj.ToString() } };
        }

        public List<AreaChange> Clear()
        {
            var newArea = new GameArea(area.Fields.GetLength(0));
            var diffs = GameAreaHelper.FindDiffs(area, newArea);
            area = newArea;
            return diffs;
        }

        public List<AreaChange> LoadGame(string file)
        {
            var loadedArea = LoadArea(file);
            if (loadedArea == null)
                return null;
            var result = GameAreaHelper.FindDiffs(area, loadedArea);
            area = loadedArea;
            return result;
        }

        protected virtual GameArea LoadArea(string file)
        {
            var loader = new GameAreaStorage();
            return loader.Load(file);
        }

        public bool SaveGame(string file)
        {
            var saver = new GameAreaStorage();
            return saver.Save(area, file);
        }
    }
}
