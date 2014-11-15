using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MaxGame.Models
{
    [Serializable]
    public struct Field
    {
        public bool Enabled { get; set; }
        public void Toggle() { Enabled = !Enabled; }
    }

    [Serializable]
    public class GameArea
    {
        private int size;
        public Field[,] Fields { get; set; }

        public GameArea() : this(12) { }
        public GameArea(int _size)
        {
            size = _size;
            Fields = new Field[size, size];
        }

        public override string ToString()
        {
            var result = "";
            for (var r = 0; r < size; r++ )
            {
                for (var c = 0; c < size; c++)
                    result += string.Format("{0,3}", Fields[r, c].Enabled ? 1 : 0);
                result += Environment.NewLine;
            }
            return result;
        }

        public bool FromString(string text)
        {
            var lines = text.Replace("\r", "").Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            if (lines == null || lines.Length < 1)
                return false;
            var size = lines.Length;
            var result = new Field[size, size];
            for (var r = 0; r < size; r++)
            {
                var elts = lines[r].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (elts.Length != size)
                    return false;
                for (var c = 0; c < size; c++)
                    result[r, c] = new Field { Enabled = elts[c] == "1" };
            }
            this.size = size;
            Fields = result;
            return true;
        }
    }
}
