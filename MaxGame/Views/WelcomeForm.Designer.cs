namespace MaxGame.Views
{
    partial class WelcomeForm
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
            this.playRandomGameButton = new System.Windows.Forms.Button();
            this.playSelectedGameButton = new System.Windows.Forms.Button();
            this.editorButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // playRandomGameButton
            // 
            this.playRandomGameButton.Location = new System.Drawing.Point(58, 35);
            this.playRandomGameButton.Name = "playRandomGameButton";
            this.playRandomGameButton.Size = new System.Drawing.Size(248, 37);
            this.playRandomGameButton.TabIndex = 0;
            this.playRandomGameButton.Text = "Play Random Game";
            this.playRandomGameButton.UseVisualStyleBackColor = true;
            this.playRandomGameButton.Click += new System.EventHandler(this.playRandomGameButton_Click);
            // 
            // playSelectedGameButton
            // 
            this.playSelectedGameButton.Location = new System.Drawing.Point(58, 78);
            this.playSelectedGameButton.Name = "playSelectedGameButton";
            this.playSelectedGameButton.Size = new System.Drawing.Size(248, 37);
            this.playSelectedGameButton.TabIndex = 0;
            this.playSelectedGameButton.Text = "Play Selected Game";
            this.playSelectedGameButton.UseVisualStyleBackColor = true;
            this.playSelectedGameButton.Click += new System.EventHandler(this.playSelectedGameButton_Click);
            // 
            // editorButton
            // 
            this.editorButton.Location = new System.Drawing.Point(58, 121);
            this.editorButton.Name = "editorButton";
            this.editorButton.Size = new System.Drawing.Size(248, 37);
            this.editorButton.TabIndex = 0;
            this.editorButton.Text = "Game Editor";
            this.editorButton.UseVisualStyleBackColor = true;
            this.editorButton.Click += new System.EventHandler(this.editorButton_Click);
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(58, 208);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(248, 37);
            this.quitButton.TabIndex = 0;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // WelcomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 281);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.editorButton);
            this.Controls.Add(this.playSelectedGameButton);
            this.Controls.Add(this.playRandomGameButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WelcomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hanjie";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button playRandomGameButton;
        private System.Windows.Forms.Button playSelectedGameButton;
        private System.Windows.Forms.Button editorButton;
        private System.Windows.Forms.Button quitButton;
    }
}