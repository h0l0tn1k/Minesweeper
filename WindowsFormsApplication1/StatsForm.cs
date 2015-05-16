﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Minesweeper
{

<<<<<<< HEAD
    /// <summary>
    /// Stats form
    /// </summary>
    public partial class StatsForm : Form
    {
        /// <summary>
        /// Data about players
        /// </summary>
        private List<PlayersData> data;
        /// <summary>
        /// Parent window to show after closing
        /// </summary>
        public MainScreen ParentWindow;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="database">players data</param>
=======
    public partial class StatsForm : Form
    {
        private List<PlayersData> data;
        public MainScreen ParentWindow;
>>>>>>> origin/master
        public StatsForm(List<PlayersData> database)
        {
            InitializeComponent();
            lblStatsLocal.ForeColor = Color.White;
            data = database;

            ///GET TOP TEN PLAYERS
            IEnumerable<PlayersData> topTen = data.Take<PlayersData>(10);
            foreach (PlayersData item in topTen)
            {
                lblStatsLocal.Text += item.ToString() + "\n";
            }
            lblStatsLocal.Text.TrimEnd('\n');
        }

<<<<<<< HEAD
        /// <summary>
        /// On closing show parent
        /// </summary>
        /// <param name="e"></param>
=======
>>>>>>> origin/master
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            ///Show parent Main Window
            ParentWindow.Show();
        }
<<<<<<< HEAD

        /// <summary>
        /// Exit form if esc or enter rpessed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitForm(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Enter)
                this.Close();
        }
=======
>>>>>>> origin/master
    }
}