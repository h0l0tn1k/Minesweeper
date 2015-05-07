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
            this.SuspendLayout();
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblTime.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblTime.Location = new System.Drawing.Point(30, 190);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(67, 25);
            this.lblTime.TabIndex = 0;
            this.lblTime.Text = "Time :";
            // 
            // Gameplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Minesweeper.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(914, 621);
            this.Controls.Add(this.lblTime);
            this.Name = "Gameplay";
            this.Text = "Gameplay";
            this.Click += new System.EventHandler(this.clicked);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTime;


    }
}