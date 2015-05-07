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
            this.btnCloseApp = new System.Windows.Forms.Button();
            this.pictureBoxLocal = new System.Windows.Forms.PictureBox();
            this.pictureBoxGlobal = new System.Windows.Forms.PictureBox();
            this.pictureBoxSplitter = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLocal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGlobal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitter)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCloseApp
            // 
            this.btnCloseApp.BackColor = System.Drawing.Color.Transparent;
            this.btnCloseApp.BackgroundImage = global::Minesweeper.Properties.Resources.Close;
            this.btnCloseApp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCloseApp.FlatAppearance.BorderSize = 0;
            this.btnCloseApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseApp.Location = new System.Drawing.Point(1124, 12);
            this.btnCloseApp.Name = "btnCloseApp";
            this.btnCloseApp.Size = new System.Drawing.Size(43, 46);
            this.btnCloseApp.TabIndex = 4;
            this.btnCloseApp.UseVisualStyleBackColor = false;
            this.btnCloseApp.Click += new System.EventHandler(this.CloseStatsForm);
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
            // StatsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Minesweeper.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1179, 573);
            this.Controls.Add(this.pictureBoxSplitter);
            this.Controls.Add(this.pictureBoxGlobal);
            this.Controls.Add(this.pictureBoxLocal);
            this.Controls.Add(this.btnCloseApp);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StatsForm";
            this.ShowInTaskbar = false;
            this.Text = "StatsForm";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLocal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGlobal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCloseApp;
        private System.Windows.Forms.PictureBox pictureBoxLocal;
        private System.Windows.Forms.PictureBox pictureBoxGlobal;
        private System.Windows.Forms.PictureBox pictureBoxSplitter;
    }
}