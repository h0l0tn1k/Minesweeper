using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Minesweeper
{

    public partial class StatsForm : Form
    {
        private List<PlayersData> data;
        public MainScreen ParentWindow;
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

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            ///Show parent Main Window
            ParentWindow.Show();
        }
    }
}
