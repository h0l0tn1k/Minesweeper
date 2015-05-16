namespace Minesweeper
{
    partial class StatsForm
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
            this.pictureBoxLocal = new System.Windows.Forms.PictureBox();
<<<<<<< HEAD
=======
            this.pictureBoxGlobal = new System.Windows.Forms.PictureBox();
            this.pictureBoxSplitter = new System.Windows.Forms.PictureBox();
>>>>>>> origin/master
            this.lblStatsLocal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLocal)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxLocal
            // 
            this.pictureBoxLocal.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxLocal.Image = global::Minesweeper.Pictures.local;
            this.pictureBoxLocal.Location = new System.Drawing.Point(313, 71);
            this.pictureBoxLocal.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.pictureBoxLocal.Name = "pictureBoxLocal";
            this.pictureBoxLocal.Size = new System.Drawing.Size(244, 87);
            this.pictureBoxLocal.TabIndex = 5;
            this.pictureBoxLocal.TabStop = false;
            // 
            // lblStatsLocal
            // 
            this.lblStatsLocal.AutoSize = true;
            this.lblStatsLocal.BackColor = System.Drawing.Color.Transparent;
            this.lblStatsLocal.Font = new System.Drawing.Font("Eras Bold ITC", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatsLocal.Location = new System.Drawing.Point(202, 186);
            this.lblStatsLocal.Name = "lblStatsLocal";
            this.lblStatsLocal.Size = new System.Drawing.Size(0, 28);
            this.lblStatsLocal.TabIndex = 10;
            // 
            // lblStatsLocal
            // 
            this.lblStatsLocal.AutoSize = true;
            this.lblStatsLocal.BackColor = System.Drawing.Color.Transparent;
            this.lblStatsLocal.Font = new System.Drawing.Font("Eras Bold ITC", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatsLocal.Location = new System.Drawing.Point(127, 208);
            this.lblStatsLocal.Name = "lblStatsLocal";
            this.lblStatsLocal.Size = new System.Drawing.Size(0, 28);
            this.lblStatsLocal.TabIndex = 10;
            // 
            // StatsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Minesweeper.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
<<<<<<< HEAD
            this.ClientSize = new System.Drawing.Size(880, 607);
            this.Controls.Add(this.lblStatsLocal);
=======
            this.ClientSize = new System.Drawing.Size(1180, 608);
            this.Controls.Add(this.lblStatsLocal);
            this.Controls.Add(this.pictureBoxSplitter);
            this.Controls.Add(this.pictureBoxGlobal);
>>>>>>> origin/master
            this.Controls.Add(this.pictureBoxLocal);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "StatsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Statistics";
            this.TopMost = true;
<<<<<<< HEAD
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.exitForm);
=======
>>>>>>> origin/master
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLocal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxLocal;
<<<<<<< HEAD
=======
        private System.Windows.Forms.PictureBox pictureBoxGlobal;
        private System.Windows.Forms.PictureBox pictureBoxSplitter;
>>>>>>> origin/master
        private System.Windows.Forms.Label lblStatsLocal;
    }
}