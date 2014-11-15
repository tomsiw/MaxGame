using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaxGame.Views
{
    public partial class GameAreaView : UserControl
    {
        [Category("Game Area Properties")]
        public Color BackgroundColor { get; set; }
        [Category("Game Area Properties")]
        public Color MarkedCellColor { get; set; }
        [Category("Game Area Properties")]
        public Color UnmarkedCellColor { get; set; }
        [Category("Game Area Properties")]
        public Color SeparatorLineColor { get; set; }
        [Category("Game Area Properties")]
        public int HeaderSize { get; set; }
        private int gridSize;
        [Category("Game Area Properties")]
        public int GridSize { get { return gridSize; } set { gridSize = Math.Max(2, value); } }
        private Font headerFont = new Font("Verdana", 10);
        [Category("Game Area Properties")]
        public Font HeaderFont { get { return headerFont; } set { headerFont = value; } }
        [Category("Game Area Properties")]
        public Color HeaderTextColor { get; set; }

        private Dictionary<Point, bool> cells = new Dictionary<Point, bool>();
        private Dictionary<int, string> columnHeaders = new Dictionary<int, string>();
        private Dictionary<int, string> rowHeaders = new Dictionary<int, string>();

        [Category("Game Area Events")]
        public event EventHandler<MouseEventArgs> CellClicked;

        public GameAreaView()
        {
            InitializeComponent();
        }

        public void SetCell(int x, int y, bool value)
        { 
            var coord = new Point(x, y);
            if (cells.ContainsKey(coord))
                cells[coord] = value;
            else
                cells.Add(coord, value);
            Invalidate();
        }

        public void SetRowHeader(int index, string value)
        {
            if (rowHeaders.ContainsKey(index))
                rowHeaders[index] = value;
            else
                rowHeaders.Add(index, value);
            Invalidate();
        }

        public void SetColumnHeader(int index, string value)
        {
            if (columnHeaders.ContainsKey(index))
                columnHeaders[index] = value;
            else
                columnHeaders.Add(index, value);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var gr = e.Graphics;

            DrawBackground(gr);
            DrawRowHeaders(gr);
            DrawColumnHeaders(gr);
            DrawCells(gr);
            DrawGrid(gr);
        }

        private void DrawCells(Graphics gr)
        {
            var markedCellBrush = new SolidBrush(MarkedCellColor);
            var unmarkedCellBrush = new SolidBrush(UnmarkedCellColor);
            var startX = HeaderSize;
            var startY = HeaderSize;
            var stepX = ((double)(Width - HeaderSize) / (double)GridSize);
            var stepY = ((double)(Height - HeaderSize) / (double)GridSize);
            for (var rowId = 0; rowId < GridSize; rowId++)
            {
                double y = startY + (rowId * stepY);
                for (var colId = 0; colId < GridSize; colId++)
                {
                    double x = startX + (colId * stepX);
                    var cellBrush = IsCellMarked(rowId, colId) ? markedCellBrush : unmarkedCellBrush;
                    gr.FillRectangle(cellBrush, new Rectangle((int)(x+1.0), (int)(y+1.0), (int)(stepX), (int)(stepY)));
                }
            }

            unmarkedCellBrush.Dispose();
            markedCellBrush.Dispose();
        }

        private bool IsCellMarked(int rowId, int colId)
        {
            var coord = new Point(rowId, colId);
            if (cells.ContainsKey(coord))
                return cells[coord];
            return false;
        }

        private void DrawGrid(Graphics gr)
        {
            var sepLinePen = new Pen(SeparatorLineColor);
            var startX = HeaderSize;
            var startY = HeaderSize;
            var stepX = ((double)(Width - HeaderSize) / (double)GridSize);
            var stepY = ((double)(Height - HeaderSize) / (double)GridSize);

            for (var rowId = 0; rowId < GridSize; rowId++)
            {
                double y = startY + (rowId * stepY);
                gr.DrawLine(sepLinePen, new Point(startX, (int)y), new Point(Width-1, (int)y));
            }

            for (var colId = 0; colId < GridSize; colId++)
            {
                double x = startX + (colId * stepX);
                gr.DrawLine(sepLinePen, new Point((int)x, HeaderSize), new Point((int)x, Height-1));
            }
            sepLinePen.Dispose();
        }

        private void DrawRowHeaders(Graphics gr)
        {
            var sepLinePen = new Pen(SeparatorLineColor);
            var textBrush = new SolidBrush(HeaderTextColor);
            var startY = HeaderSize;
            var step = ((double)(Height - HeaderSize) / (double)GridSize);
            for (var rowId = 0; rowId < GridSize; rowId++)
            {
                double y = startY + (rowId * step);
                gr.DrawLine(sepLinePen, new Point(0, (int)y), new Point(HeaderSize, (int)y));
                gr.DrawString(GetRowText(rowId), HeaderFont, textBrush, 5, (int)((y+step/2)-HeaderFont.Size/2));
            }
            textBrush.Dispose();
            sepLinePen.Dispose();
        }

        private void DrawColumnHeaders(Graphics gr)
        {
            var sepLinePen = new Pen(SeparatorLineColor);
            var textBrush = new SolidBrush(HeaderTextColor);
            var startX = HeaderSize;
            var step = ((double)(Width - HeaderSize) / (double)GridSize);
            for (var colId=0; colId<GridSize; colId++)
            {
                double x = startX + (colId * step);
                gr.DrawLine(sepLinePen, new Point((int)x, 0), new Point((int)x, HeaderSize));
                gr.TranslateTransform((int)((x+step/2)+HeaderFont.Size/2), 5);
                gr.RotateTransform(90);
                gr.DrawString(GetColumnText(colId), HeaderFont, textBrush, 0, 0);
                gr.ResetTransform();
            }
            textBrush.Dispose();
            sepLinePen.Dispose();
        }

        private string GetColumnText(int colId)
        {
            if (columnHeaders.ContainsKey(colId))
                return columnHeaders[colId];
            return "";
        }

        private string GetRowText(int colId)
        {
            if (rowHeaders.ContainsKey(colId))
                return rowHeaders[colId];
            return "";
        }

        private void DrawBackground(Graphics gr)
        {
            var bkgBrush = new SolidBrush(BackgroundColor);
            gr.FillRectangle(bkgBrush, new Rectangle(0, 0, Width, Height));
            bkgBrush.Dispose();
        }

        private void GameAreaView_MouseClick(object sender, MouseEventArgs e)
        {
            if (CellClicked == null)
                return;
            var startX = HeaderSize;
            var startY = HeaderSize;
            var stepX = ((double)(Width - HeaderSize) / (double)GridSize);
            var stepY = ((double)(Height - HeaderSize) / (double)GridSize);
            for (var rowId = 0; rowId < GridSize; rowId++)
            {
                double y = startY + (rowId * stepY);
                for (var colId = 0; colId < GridSize; colId++)
                {
                    double x = startX + (colId * stepX);
                    var rect = new Rectangle((int)x, (int)y, (int)stepX, (int)stepY);
                    if (rect.Contains(e.Location))
                        CellClicked(this, new MouseEventArgs(e.Button, e.Clicks, colId, rowId, 0));
                }
            }
        }
    }
}
