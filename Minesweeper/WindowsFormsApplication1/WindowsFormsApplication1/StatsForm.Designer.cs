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
            this.pictureBoxGlobal = new System.Windows.Forms.PictureBox();
            this.pictureBoxSplitter = new System.Windows.Forms.PictureBox();
            this.lblStatsLocal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLocal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGlobal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitter)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxLocal
            // 
            this.pictureBoxLocal.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxLocal.Image = global::Minesweeper.Pictures.local;
            this.pictureBoxLocal.Location = new System.Drawing.Point(165, 76);
            this.pictureBoxLocal.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.pictureBoxLocal.Name = "pictureBoxLocal";
            this.pictureBoxLocal.Size = new System.Drawing.Size(244, 87);
            this.pictureBoxLocal.TabIndex = 5;
            this.pictureBoxLocal.TabStop = false;
            // 
            // pictureBoxGlobal
            // 
            this.pictureBoxGlobal.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxGlobal.Image = global::Minesweeper.Pictures.Global;
            this.pictureBoxGlobal.Location = new System.Drawing.Point(764, 76);
            this.pictureBoxGlobal.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.pictureBoxGlobal.Name = "pictureBoxGlobal";
            this.pictureBoxGlobal.Size = new System.Drawing.Size(305, 87);
            this.pictureBoxGlobal.TabIndex = 6;
            this.pictureBoxGlobal.TabStop = false;
            // 
            // pictureBoxSplitter
            // 
            this.pictureBoxSplitter.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxSplitter.BackgroundImage = global::Minesweeper.Pictures.splitter;
            this.pictureBoxSplitter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBoxSplitter.Location = new System.Drawing.Point(522, 76);
            this.pictureBoxSplitter.Name = "pictureBoxSplitter";
            this.pictureBoxSplitter.Size = new System.Drawing.Size(100, 371);
            this.pictureBoxSplitter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxSplitter.TabIndex = 7;
            this.pictureBoxSplitter.TabStop = false;
            this.pictureBoxSplitter.WaitOnLoad = true;
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
            this.ClientSize = new System.Drawing.Size(1180, 608);
            this.Controls.Add(this.lblStatsLocal);
            this.Controls.Add(this.pictureBoxSplitter);
            this.Controls.Add(this.pictureBoxGlobal);
            this.Controls.Add(this.pictureBoxLocal);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "StatsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Statistics";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLocal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGlobal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxLocal;
        private System.Windows.Forms.PictureBox pictureBoxGlobal;
        private System.Windows.Forms.PictureBox pictureBoxSplitter;
        private System.Windows.Forms.Label lblStatsLocal;
    }
}