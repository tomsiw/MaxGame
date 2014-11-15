using MaxGame.Controllers;
using MaxGame.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaxGame.Views
{
    public partial class WelcomeForm : Form
    {
        private GameArea area;
        private EditorController editController;

        public WelcomeForm()
        {
            InitializeComponent();
            InitGameObjects();
            InitButtons();
        }

        private void InitButtons()
        {
            playRandomGameButton.Enabled =  GameAreaStorage.GetGameFilesFromDefaultLocation().Count > 0;
            playSelectedGameButton.Enabled = playRandomGameButton.Enabled;
        }

        private void InitGameObjects()
        {
            area = new GameArea();
            editController = new EditorController(area);
        }

        private void playRandomGameButton_Click(object sender, EventArgs e)
        {
            var files = GameAreaStorage.GetGameFilesFromDefaultLocation();
            var rnd = new Random();
            var file = files.Skip(rnd.Next(files.Count)).First();
            RunGame(file);
        }

        private void RunGame(string file)
        {
            var store = new GameAreaStorage();
            var area = store.Load(file);
            using (var form = new GameForm(area))
            {
                Hide();
                form.ShowDialog();
                Show();
            }
        }

        private void playSelectedGameButton_Click(object sender, EventArgs e)
        {
            var file = GameAreaStorage.SelectFileToLoad();
            if (file == null)
                return;
            RunGame(file);
        }

        private void editorButton_Click(object sender, EventArgs e)
        {
            using (var editor = new GameEditorForm(editController))
            {
                Hide();
                editor.ShowDialog();
                InitButtons();
                Show();
            }
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
