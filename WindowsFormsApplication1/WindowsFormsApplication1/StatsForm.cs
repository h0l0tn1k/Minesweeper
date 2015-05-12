using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class StatsForm : Form
    {
        private static Rectangle UserScreen = Screen.PrimaryScreen.Bounds;
        private Form parent;
        public StatsForm(Form parent)
            :base()
        {
            InitializeComponent();
            btnCloseApp.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnCloseApp.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnCloseApp.Location = new Point(UserScreen.Width - btnCloseApp.Width - 5, 0);
            pictureBoxLocal.Location = new Point(((UserScreen.Width/2)-pictureBoxLocal.Width)/2,100);
            pictureBoxGlobal.Location = new Point(UserScreen.Width/2 + ((UserScreen.Width/2) - pictureBoxGlobal.Width)/2, 100);
            pictureBoxSplitter.Location = new Point((UserScreen.Width/2)-pictureBoxSplitter.Width,100);
            pictureBoxSplitter.Size = new Size(100,UserScreen.Height - 300);
            this.parent = parent;
        }

        private void CloseStatsForm(object sender, EventArgs e)
        {
            this.Close();
            parent.Show();
        }

    }
}
