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
    public partial class MainScreen : Form
    {
        internal static Rectangle UserScreen = Screen.PrimaryScreen.Bounds;
        public MainScreen()
        {
            InitializeComponent();
            setButtons();
        }

        private void CloseForm(object sender, EventArgs e)
        {
            Close();
        }

        private void MinimalizeForm(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void newgame(object sender, EventArgs e)
        {
            startGame();
        }

        private void startGame()
        {
            Level lvl = new Level1();
            Player pl = new Player(0, 0, 3);
            Gameplay game = new Gameplay(lvl.Map,pl);
            this.Hide();
            game.Show();
        }

        private void stats(object sender, EventArgs e)
        {
            StatsForm stats = new StatsForm(this);
            this.Hide();
            stats.Show();
        }

        private void setButtons()
        {
            menuLayout1.NewGame.Click += new System.EventHandler(this.newgame);
            menuLayout1.Exit.Click += new System.EventHandler(CloseForm);
            menuLayout1.Stats.Click += new System.EventHandler(stats);
            this.menuLayout1.Location = new System.Drawing.Point((UserScreen.Width / 2) - (menuLayout1.Width / 2), (UserScreen.Height / 2) - (menuLayout1.Height / 2));
            this.btnCloseApp.Location = new System.Drawing.Point(UserScreen.Width - 5 - btnCloseApp.Width, 0);
            this.btnMinApp.Location = new System.Drawing.Point(UserScreen.Width - btnCloseApp.Width - btnMinApp.Width - 8, -5);
            this.pictureBoxGoldCoinSack.Location = new System.Drawing.Point(UserScreen.Width - pictureBoxGoldCoinSack.Width ,UserScreen.Height - pictureBoxGoldCoinSack.Height -50);
            this.pictureBox5.Location = new System.Drawing.Point((UserScreen.Width-btnCloseApp.Width-btnMinApp.Width - pictureBox5.Width- 10),10);
            btnCloseApp.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnCloseApp.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnMinApp.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnMinApp.FlatAppearance.MouseOverBackColor = Color.Transparent;
        }

    }
}
