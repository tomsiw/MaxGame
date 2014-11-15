using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxGame.Models
{
    public class Dimension
    {
        private GameArea area;
        private int index;
        private int dimension;

        public Dimension(GameArea _area, int _index, int _dimension)
        {
            area = _area;
            index = _index;
            dimension = _dimension;
            if (area == null || area.Fields == null || area.Fields.Rank != 2)
                throw new ApplicationException("Incorrect game area - row can not be created");
            if (area.Fields.Rank <= dimension)
                throw new ApplicationException("Expected too high dimension for given game area");
            var length = area.Fields.GetLength(dimension);
            if (length <= index)
                throw new ApplicationException("Expected too high index for given dimention of game area");
        }

        public bool[] Projection
        {
            get 
            {
                var length = area.Fields.GetLength(dimension);
                var proj = new bool[length];
                for (var i = 0; i < length; i++)
                    proj[i] = dimension == 0 ? area.Fields[index, i].Enabled : area.Fields[i, index].Enabled;
                return proj;
            }
        }

        public override string ToString()
        {
            var result = "";
            var val = 0;
            foreach (var field in Projection)
                if (field)
                    val += 1;
                else
                {
                    if (val > 0) result += val.ToString() + ",";
                    val = 0;
                }
            if (val > 0) result += val;
            return result.Trim(',');
        }
    }

    public class Row : Dimension
    {
        public Row(GameArea _area, int _row) : base(_area, _row, 0) { }
    }

    public class Column : Dimension
    {
        public Column(GameArea _area, int _row) : base(_area, _row, 1) { }
    }
}
