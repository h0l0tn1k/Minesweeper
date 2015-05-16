namespace Minesweeper
{
    partial class Gameplay
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
            this.lblTime = new System.Windows.Forms.Label();
            this.lblLevelNumber = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblTime.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblTime.Location = new System.Drawing.Point(28, 190);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(122, 25);
            this.lblTime.TabIndex = 0;
            this.lblTime.Text = "Time : 00:00";
            // 
            // lblLevelNumber
            // 
            this.lblLevelNumber.AutoSize = true;
            this.lblLevelNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblLevelNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.lblLevelNumber.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblLevelNumber.Location = new System.Drawing.Point(26, 40);
            this.lblLevelNumber.Name = "lblLevelNumber";
            this.lblLevelNumber.Size = new System.Drawing.Size(0, 39);
            this.lblLevelNumber.TabIndex = 2;
            // 
            // Gameplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
<<<<<<< HEAD
            this.BackgroundImage = global::Minesweeper.Pictures.medBackground;
=======
            this.BackgroundImage = global::Minesweeper.Properties.Resources.background;
>>>>>>> origin/master
            this.ClientSize = new System.Drawing.Size(884, 612);
            this.Controls.Add(this.lblLevelNumber);
            this.Controls.Add(this.lblTime);
            this.DoubleBuffered = true;
            this.Name = "Gameplay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Click += new System.EventHandler(this.clicked);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Gameplay_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblLevelNumber;


    }
}