using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
<<<<<<< HEAD
using System.Media;
=======
>>>>>>> origin/master


namespace Minesweeper
{
    public partial class MainScreen : Form
    {
        /// <summary>
        /// Path to local database of best players
        /// </summary>
        private string pathToDatabase = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\localMinesweeper.csv";
        /// <summary>
        /// Levels array
        /// </summary>
<<<<<<< HEAD
        private Level[] lvl = new Level[] { new Level1(), new Level2(), new Level3(), new Level4(), new Level5(), new Level6(),new Level7(),new Level8() ,new Level9(),new Level10()};
=======
        private Level[] lvl = new Level[] { new Level1(), new Level2(), new Level3(), new Level4(), new Level5(), new Level6() };
>>>>>>> origin/master
        /// <summary>
        /// Current/Signed player
        /// </summary>
        private Player pl;
        /// <summary>
<<<<<<< HEAD
=======
        /// Music player
        /// </summary>
        public System.Media.SoundPlayer Player;
        /// <summary>
>>>>>>> origin/master
        /// Loaded database of players
        /// </summary>
        private List<PlayersData> database;


<<<<<<< HEAD
=======


>>>>>>> origin/master
        /// <summary>
        /// Main screen constructor
        /// </summary>
        public MainScreen()
        {
            InitializeComponent();
            setButtons();
<<<<<<< HEAD
            database = new List<PlayersData>();
            connectDb();

=======
            Player = new System.Media.SoundPlayer(Sounds.Gran_Turismo___PSP___Freeland___Do_You);
            Player.Play();
            database = new List<PlayersData>();
            connectDb();


>>>>>>> origin/master
            if(database.Count > 0)
            {
                foreach (PlayersData item in database)
	            {
                    txtBoxUserName.AutoCompleteCustomSource.Add(item.Username);
	            }
            }
<<<<<<< HEAD
            this.AcceptButton = menuLayout1.NewGame;
=======
>>>>>>> origin/master
        }

        /// <summary>
        /// Closes application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseForm(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Loads data from local database
        /// </summary>
        private void connectDb()
        {
            if (File.Exists(pathToDatabase))
            {
                try
                {
                    database.Clear();
                    TextFileLogStorage db = new TextFileLogStorage(pathToDatabase);
                    CsvLogImporter<PlayersData> import = new CsvLogImporter<PlayersData>(db, new string[] { "Username", "Score", "MaxLevel" }, false, ';', '\"');
                    database = import.Import();

                    #region Sort
                    sortData();
                    #endregion                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Not able to load data from  local database file!\n" + ex.Message);
                    return;
                }
            }
            else
            {
                ///First use
                File.Create(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\localMinesweeper.csv");

            }

        }

        /// <summary>
        /// Sorts players in database by highest score
        /// </summary>
        private void sortData()
        {
            database.Sort(delegate(PlayersData x, PlayersData y)
                    {
                        if (x.Score == y.Score)
                        {
                            if (x.MaxLevel > y.MaxLevel)
                            {
                                return -1;
                            }
                            else
                            {
                                return 1;
                            }
                        }

                        if (x.Score > y.Score)
                            return -1;
                        else
                            return 1;
                    });
            for (int i = 0; i < database.Count; i++)
            {
                database[i].Position = i + 1;
            }
        }

        /// <summary>
        /// Starts new game
        /// Player has to be signed first (in txtBoxUserName)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newgame(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxUserName.Text))
            {
<<<<<<< HEAD
                CustomMessageBox mbox = new CustomMessageBox();
                mbox.Label1 = "Select username";
                mbox.Label2 = "at the bottom of the screen!";
                mbox.BackColor = Color.Red;
                label1.ForeColor = Color.Red;
                txtBoxUserName.Text = "";
                Invalidate();
                mbox.ShowDialog();
=======
                MessageBox.Show("Select username at the bottom of the screen!");
                label1.ForeColor = Color.Red;
                txtBoxUserName.Text = "";
                Invalidate();
>>>>>>> origin/master
                return;
            }
            else {
                label1.ForeColor = Color.Black;
                pl = new Player(txtBoxUserName.Text, 3);
                startGame(0);
            }
        }

        /// <summary>
        /// Creates Windows for new game
        /// </summary>
        /// <param name="i">Level Number</param>
        private void startGame(int i)
        {
<<<<<<< HEAD
            if (i == 10)
            {
                SoundPlayer music = new SoundPlayer(Sounds.finish);
                music.Play();
                WinningWindow wind = new WinningWindow();
                wind.LblScore = "Your score is : " + pl.Score;
                wind.ParentWindow = this;
                wind.ShowDialog();
                playerDead(0);
                sortData();
                return;
            }
            Gameplay game = new Gameplay( lvl[i].Map, lvl[i].Width, lvl[i].Height, ref pl,i);
            ///Parent initialization
            game.ParentWindow = this;
            ///Delegates Initialization
=======
            Gameplay game = new Gameplay(lvl[i].Map, lvl[i].Width, lvl[i].Height, ref pl,i);
            ///Delegates Initialization
            ///Parent initialization
            game.ParentWindow = this;
>>>>>>> origin/master
            game.NextLevel = new Finishgame(startGame);
            game.QuitGame = new Finishgame(playerDead);

            this.Hide();
            Player.Stop();
            game.Show();
        }

        /// <summary>
        /// Shows Stats Window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stats(object sender, EventArgs e)
        {
            StatsForm stats = new StatsForm(database);
            stats.ParentWindow = this;
            this.Hide();
            stats.Show();
        }

        /// <summary>
        /// Function that handles when player is dead
        /// </summary>
        /// <param name="z">Unused variable</param>
        private void playerDead(int z)
        {
            PlayersData tmp = null;
            ///Update Database
            tmp = database.Find(x=> x.Username == pl.Username);
            if (tmp != null) 
            { 
                //update his data
                if (pl.Score > tmp.Score) { 
                    tmp.Score = pl.Score;
<<<<<<< HEAD
                    tmp.MaxLevel = pl.Level+1;
=======
                    tmp.MaxLevel = pl.Level;
>>>>>>> origin/master
                    try
                    {
                        TextFileLogStorage st = new TextFileLogStorage(pathToDatabase);
                        CsvLogExporter<PlayersData> data = new CsvLogExporter<PlayersData>(st, new string[] { "Username", "Score", "MaxLevel" }, false, ';', '\"');
                        data.Export(database);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    sortData();
                }
            }
            else
            {
                ///new player
                try
                {
                    TextFileLogStorage st = new TextFileLogStorage(pathToDatabase);
                    CsvLogExporter<PlayersData> data = new CsvLogExporter<PlayersData>(st, new string[] { "Username", "Score", "MaxLevel" }, false, ';', '\"');
                    PlayersData p = new PlayersData();
                    p.Score = pl.Score;
                    p.Username = pl.Username;
<<<<<<< HEAD
                    p.MaxLevel = pl.Level+1;
=======
                    p.MaxLevel = pl.Level;
>>>>>>> origin/master
                    database.Add(p);
                    data.Export(database);
                    sortData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// Sets Event handlers for pictures
        /// </summary>
        private void setButtons()
        {
            menuLayout1.NewGame.Click += new System.EventHandler(this.newgame);
            menuLayout1.Exit.Click += new System.EventHandler(CloseForm);
            menuLayout1.Stats.Click += new System.EventHandler(stats);
        }


    }
}
