using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MaxGame.Properties;
using MaxGame.Views;
using MaxGame.Controllers;

namespace MaxGame
{
    public partial class GameEditorForm : Form
    {
        private Controllers.EditorController editController;

        public GameEditorForm() 
        {
            InitializeComponent();
        }

        public GameEditorForm(Controllers.EditorController editController)
            : this()
        {
            this.editController = editController;
        }

        private void gameAreaView_CellClicked(object sender, MouseEventArgs e)
        {
            if (editController == null)
                return;
            ApplyChanges(editController.CellClicked(e.Y, e.X));
        }

        private void ApplyChanges(List<Controllers.AreaChange> changes)
        {
            foreach (var pt in changes)
            {
                gameAreaView.SetCell(pt.Row, pt.Col, pt.Value);
                gameAreaView.SetColumnHeader(pt.Col, pt.ColumnHeader);
                gameAreaView.SetRowHeader(pt.Row, pt.RowHeader);
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            var file = GameAreaStorage.SelectFileToLoad();
            if (file == null)
                return;

            var result = editController.LoadGame(file);
            if (result == null)
            {
                MessageBox.Show(Settings.Default.FailToLoad, Settings.Default.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ApplyChanges(result);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var file = GameAreaStorage.SelectFileToSave();
            if (file == null)
                return;
            if (!editController.SaveGame(file))
                MessageBox.Show(Settings.Default.FailToSave, Settings.Default.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Settings.Default.ClearMessage, Settings.Default.Question, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
                return;
            ApplyChanges(editController.Clear());
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            using (var game = new GameForm(editController.Area))
            {
                Hide();
                game.ShowDialog();
                Show();
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Settings.Default.QuitMessage, Settings.Default.Question, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
                return;
            Close();
        }
    }
}
