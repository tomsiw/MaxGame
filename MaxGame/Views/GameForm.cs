using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MaxGame.Controllers;
using MaxGame.Models;
using MaxGame.Properties;

namespace MaxGame.Views
{
    public partial class GameForm : Form
    {
        private GameController controller;
        
        public GameForm() : this(null) { }

        private void InitGameView()
        {
            if (controller == null)
                return;
            var diffs = controller.GetInitialState();
            ApplyChanges(diffs);
        }

        public GameForm(GameArea _area)
        {
            controller = new GameController(_area);
            InitializeComponent();
            InitGameView();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gameAreaView_CellClicked(object sender, MouseEventArgs e)
        {
            var change = controller.CellClicked(e.Y, e.X);
            var diff = controller.IsDifference();
            ApplyChanges(change);

            if (!diff)
                MessageBox.Show(Settings.Default.CongratulationMsg, Settings.Default.Success, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ApplyChanges(List<AreaChange> changes)
        {
            foreach (var pt in changes)
            {
                gameAreaView.SetCell(pt.Row, pt.Col, pt.Value);
                gameAreaView.SetColumnHeader(pt.Col, pt.ColumnHeader);
                gameAreaView.SetRowHeader(pt.Row, pt.RowHeader);
            }
        }
    }
}
