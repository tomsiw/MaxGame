namespace MaxGame.Views
{
    partial class GameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gameAreaView = new MaxGame.Views.GameAreaView();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gameAreaView
            // 
            this.gameAreaView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.gameAreaView.GridSize = 12;
            this.gameAreaView.HeaderFont = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gameAreaView.HeaderSize = 100;
            this.gameAreaView.HeaderTextColor = System.Drawing.Color.Green;
            this.gameAreaView.Location = new System.Drawing.Point(12, 12);
            this.gameAreaView.MarkedCellColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.gameAreaView.Name = "gameAreaView";
            this.gameAreaView.SeparatorLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gameAreaView.Size = new System.Drawing.Size(430, 425);
            this.gameAreaView.TabIndex = 0;
            this.gameAreaView.UnmarkedCellColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gameAreaView.CellClicked += new System.EventHandler<System.Windows.Forms.MouseEventArgs>(this.gameAreaView_CellClicked);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(448, 401);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(124, 36);
            this.exitButton.TabIndex = 2;
            this.exitButton.Text = "Quit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 451);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.gameAreaView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Guess the pattern";
            this.ResumeLayout(false);

        }

        #endregion

        private GameAreaView gameAreaView;
        private System.Windows.Forms.Button exitButton;
    }
}