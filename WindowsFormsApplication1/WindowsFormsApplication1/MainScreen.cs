using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Minesweeper
{
    public partial class MainScreen : Form
    {
        internal static Rectangle UserScreen = Screen.PrimaryScreen.Bounds;
        private Level[] lvl = new Level[] { new Level1(), new Level2(), new Level3() };
        Player pl = new Player(3);
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
            startGame(0);
        }

        private void startGame(int i)
        {
            Gameplay game = new Gameplay(lvl[i].Map, lvl[i].Width, lvl[i].Height, ref pl,i);
            game.Parent = this;
            game.NextLevel = new Finishgame(startGame);
            game.QuitGame = new Finishgame(playerDead);

            this.Hide();
            game.Show();
        }

        private void stats(object sender, EventArgs e)
        {
            StatsForm stats = new StatsForm(this);
            this.Hide();
            stats.Show();
        }

        private void playerDead(int z)
        { 
            ///Update Database
        }


        private void setButtons()
        {
            menuLayout1.NewGame.Click += new System.EventHandler(this.newgame);
            menuLayout1.Exit.Click += new System.EventHandler(CloseForm);
            menuLayout1.Stats.Click += new System.EventHandler(stats);
        }

    }
}
