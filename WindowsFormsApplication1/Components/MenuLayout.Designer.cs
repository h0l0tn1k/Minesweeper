namespace Minesweeper
{
    partial class MenuLayout
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.btnStats = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnNewGame);
            this.flowLayoutPanel1.Controls.Add(this.btnStats);
            this.flowLayoutPanel1.Controls.Add(this.btnExit);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(484, 310);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnNewGame
            // 
            this.btnNewGame.BackColor = System.Drawing.Color.Transparent;
            this.btnNewGame.BackgroundImage = global::Minesweeper.Properties.Resources.NewGame;
            this.btnNewGame.FlatAppearance.BorderSize = 0;
            this.btnNewGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewGame.Location = new System.Drawing.Point(3, 3);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(478, 92);
            this.btnNewGame.TabIndex = 0;
            this.btnNewGame.UseVisualStyleBackColor = false;
            // 
            // btnStats
            // 
            this.btnStats.BackColor = System.Drawing.Color.Transparent;
            this.btnStats.BackgroundImage = global::Minesweeper.Properties.Resources.Stats;
            this.btnStats.FlatAppearance.BorderSize = 0;
            this.btnStats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStats.Location = new System.Drawing.Point(3, 101);
            this.btnStats.Name = "btnStats";
            this.btnStats.Size = new System.Drawing.Size(230, 84);
            this.btnStats.TabIndex = 2;
            this.btnStats.UseVisualStyleBackColor = false;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BackgroundImage = global::Minesweeper.Properties.Resources.Exit;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(3, 191);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(230, 103);
            this.btnExit.TabIndex = 4;
            this.btnExit.UseVisualStyleBackColor = false;
            // 
            // MenuLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.flowLayoutPanel1);
            this.DoubleBuffered = true;
            this.Name = "MenuLayout";
            this.Size = new System.Drawing.Size(484, 500);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Button btnStats;
        private System.Windows.Forms.Button btnExit;
    }
}
