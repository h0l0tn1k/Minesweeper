using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

namespace Minesweeper
{
    /// <summary>
    /// Public delegate for handling end of the game
    /// </summary>
    /// <param name="x"></param>
    public delegate void Finishgame(int x);




    /// <summary>
    /// Class that draws battlefield, resolves user's input (mouse click) etc.
    /// Need to set up NextLevel & QuitGame Properties/Delegates
    /// </summary>
    public partial class Gameplay : Form
    {
        /// <summary>
        /// Delegate for a function that gives another level
        /// </summary>
        public Finishgame NextLevel { get; set; }
        /// <summary>
        /// Delegate for a function that ends current game & level
        /// </summary>
        public Finishgame QuitGame { get; set; }
        /// <summary>
        /// Parent (Window that called this form, MainWindow)
        /// </summary>
        public MainScreen ParentWindow { get; set; }
        /// <summary>
        /// Determines if game has just ended
        /// </summary>
        private bool endOfGame = false;
        /// <summary>
        /// Calls resolver_Tick every 500ms
        /// </summary>
        private System.Windows.Forms.Timer tim;
        /// <summary>
        /// Timer, counts elapsed time
        /// </summary>
        private Stopwatch timer;
        /// <summary>
        /// Is used to set initial values
        /// </summary>
        private bool init;
        /// <summary>
        /// how many bombs are located at current battlefield
        /// </summary>
        private int bombsCount;
        /// <summary>
        /// Current battlefield (current level)
        /// </summary>
        private BattleField battlefield;
        /// <summary>
        /// Which cells has been visited
        /// </summary>
        private bool[,] visitedRectangles;
        /// <summary>
        /// Images Array (Ground,Stone,Empty,Nothing,...)
        /// Array indexer is Field ENUM
        /// Images[(int)Field.bomb] == Picture of a bomb
        /// </summary>
        private Image[] Images = new Image[10];
        /// <summary>
        /// Which objects have to be hidden
        /// </summary>
        private List<Field> hidden = new List<Field> { Field.Bomb, Field.Gold,Field.Hearth};
        /// <summary>
        /// Numbers around bombs
        /// </summary>
        private int[,] numbersBomb;
        /// <summary>
        /// List of flagged bombs
        /// </summary>
        private List<Point> flags;
        /// <summary>
        /// Current level
        /// </summary>
        private int level;
        /// <summary>
        /// battlefield Public property
        /// </summary>
        public BattleField Battlefield { get { return battlefield; }}

        /// <summary>
        /// Constructor
        /// Initializes Images
        /// </summary>
        /// <param name="field">Battlefield of current level</param>
        /// <param name="width">Width of current battlefield</param>
        /// <param name="height">height of current battlefield</param>
        /// <param name="pl">Players that plays this level</param>
        /// <param name="lvl">Current level</param>
        public Gameplay(Field[,] field,int width,int height,ref Player pl,int lvl)
        {
            InitializeComponent();
            level = lvl;
            lblLevelNumber.Text = "Level " + (level + 1).ToString();
            this.Text = "Level " + (level + 1).ToString();

            Images[(int)Field.Bomb] = Pictures.bomb;
            Images[(int)Field.Nothing] = Pictures.ground;
            Images[(int)Field.Hearth] = Pictures.hearth;
            Images[(int)Field.Stone] = Pictures.stone;
            Images[(int)Field.Empty] = Pictures.empteyyy;
            Images[(int)Field.Gold] = Pictures.coin;
            Images[(int)Field.Flag] = Pictures.flag;
            
            battlefield = new BattleField(width,height, field);
            numbersBomb = new int[height,width];
            visitedRectangles = new bool[height,width];
            timer = new Stopwatch();
            tim = new System.Windows.Forms.Timer();
            flags = new List<Point>();
            
            tim.Tick += resolver_Tick;
            tim.Interval = 500;
            battlefield.Player = pl;
            bombsCount = 0;
            init = true;
            pl.Coins = 0;
            setBombNumbers();
            tim.Start();
        }

        /// <summary>
        /// Tick event every 500ms
        /// Updates elapsed time in lblTime
        /// Finishes game == calls QuitGame function
        /// Calls NextLevel function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void resolver_Tick(object sender, EventArgs e)
        {
            if (!endOfGame)
                lblTime.Text = "Time : " + timer.Elapsed.ToString("mm\\:ss");
            else
                timer.Stop();

            if (battlefield.Player.Life <= 0)
            {
                tim.Tick -= resolver_Tick;
                battlefield.Player.Level = level;
                CustomMessageBox mbox = new CustomMessageBox();
                mbox.BackColor = Color.Red;
                mbox.Label1 = "Your are dead!";
                mbox.Label2 = "Total score: " + battlefield.Player.Score;
                mbox.ShowDialog();
                ParentWindow.Player.PlayLooping();
                QuitGame(0);
                this.Close();
                return;
            }
            if (endOfGame)
            {
                tim.Tick -= resolver_Tick;
                ///bonus for time
                
                battlefield.Player.Score += (int)Math.Max(0, 60 - (timer.ElapsedMilliseconds / 1000));
                CustomMessageBox mbox = new CustomMessageBox();
                mbox.Label1 = "You won!!";
                mbox.Label2 = "Elapsed time: " + timer.Elapsed.ToString("mm\\:ss");
                mbox.Label3 = "Time bonus: " + (int)Math.Max(0, 60 - (timer.ElapsedMilliseconds / 1000)) + "\nTotal score: " + battlefield.Player.Score;
                mbox.ShowDialog();
                //MessageBox.Show("You WON!!\n" + "Elapsed time: " + timer.Elapsed.ToString("mm\\:ss") + "\nTime bonus: " + (int)Math.Max(0, 60 - (timer.ElapsedMilliseconds / 1000)) + "\nTotal score: " + battlefield.Player.Score);
                this.Close();
                NextLevel(++level);
            }
        }

        /// <summary>
        /// On closing event, hides this window, shows parent, and disposes resources
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(CancelEventArgs e)
        {
            ParentWindow.Show();
            this.Dispose();
            base.OnClosing(e);
        }

        /// <summary>
        /// Counts numbers around bombs
        /// </summary>
        private void setBombNumbers()
        {
            for (int i = 0; i < battlefield.Height; i++)
            {
                for (int x = 0; x < battlefield.Width; x++)
                {
                    numbersBomb[i, x] = 0;
                }
            }

            for (int i = 0; i < battlefield.Height; i++)
            {
                for (int x = 0; x < battlefield.Width; x++)
                {
                    if (battlefield.Field[i, x] == Field.Bomb)
                    {
                        bombsCount++;
                        addToSurroundings(x, i);
                    }
                    if (battlefield.Field[i, x] == Field.Empty)
                        visitedRectangles[i, x] = true;
                }

            }
        }

        /// <summary>
        /// Adds numbers to surroundings of bomb
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        private void addToSurroundings(int x,int y)
        {
            bool[] arr = new bool[9];
            for (int i = 0; i < 9; i++)
            {
                arr[i] = true;
            }
            arr[4] = false;


            if (x == 0)
            {
                arr[0] = arr[3] = arr[6] = false;
            }

            if (y == 0)
            {
                arr[0] = arr[1] = arr[2] = false;
            }

            if (x == 9)
            {
                arr[2] = arr[5] = arr[8] = false;
            }

            if (y == 9)
            {
                arr[6] = arr[7] = arr[8] = false;
            }


            for (int i = 0; i < 9; i++)
            {
                if (arr[i])
                {
                    switch (i)
                    {
                        case 0:
                            if (battlefield.Field[y - 1, x - 1] == Field.Bomb)
                                break;
                            numbersBomb[y - 1, x - 1]++;
                            break;
                        case 1:
                            if (battlefield.Field[y - 1, x] == Field.Bomb)
                                break;
                            numbersBomb[y - 1, x]++;
                            break;
                        case 2:
                            if (battlefield.Field[y - 1, x + 1] == Field.Bomb)
                                break;
                            numbersBomb[y - 1, x + 1]++;
                            break;
                        case 3:
                            if (battlefield.Field[y, x - 1] == Field.Bomb)
                                break;
                            numbersBomb[y, x - 1]++;
                            break;
                        case 5:
                            if (battlefield.Field[y, x + 1] == Field.Bomb)
                                break;
                            numbersBomb[y, x + 1]++;
                            break;
                        case 6:
                            if (battlefield.Field[y + 1, x - 1] == Field.Bomb)
                                break;
                            numbersBomb[y + 1, x - 1]++;
                            break;
                        case 7:
                            if (battlefield.Field[y + 1, x] == Field.Bomb)
                                break;
                            numbersBomb[y + 1, x]++;
                            break;
                        case 8:
                            if (battlefield.Field[y + 1, x + 1] == Field.Bomb)
                                break;
                            numbersBomb[y + 1, x + 1]++;
                            break;
                        default:
                            break;
                    }
                }
            }


        }

        /// <summary>
        /// Draws battlefield in window
        /// </summary>
        /// <param name="e">paint drawing event argument</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            /// use other thread
            Invoke(new Action(() => {
                e.Graphics.DrawString("Life : " + (Math.Max(0, battlefield.Player.Life)).ToString() + "/3", new Font(FontFamily.GenericSansSerif, 15), Brushes.Gray, new Point(30, 100));
                e.Graphics.DrawString("Coins: " + battlefield.Player.Coins, new Font(FontFamily.GenericSansSerif, 15), Brushes.Gray, new Point(30, 130));
                e.Graphics.DrawString("Bombs: " + (Math.Max(0, bombsCount)).ToString(), new Font(FontFamily.GenericSansSerif, 15), Brushes.Gray, new Point(30, 160));
                e.Graphics.DrawString("Score: " + (battlefield.Player.Score).ToString(), new Font(FontFamily.GenericSansSerif, 15), Brushes.Gray, new Point(30, 220));
                e.Graphics.DrawImage(Pictures.battlefield, 157, 37, 550, 550);
            }));

            ///Draw first half on other thread 
            Invoke(new Action(() => {
                for (int y = battlefield.Height/2; y < battlefield.Height; y++)
                {
                    for (int x = 0; x < battlefield.Width; x++)
                    {
                        Point p = new Point(221 + x * 43, 93 + y * 43);

                        if (visitedRectangles[y, x] && numbersBomb[y, x] > 0 && battlefield.Field[y, x] != Field.Gold && battlefield.Field[y, x] != Field.Hearth && battlefield.Field[y, x] != Field.Finish
                            && battlefield.Field[y, x] != Field.Stone)
                        {
                            ///Draw Numbers
                            e.Graphics.DrawString(numbersBomb[y, x].ToString(), new Font(FontFamily.GenericSansSerif, 20), Brushes.Black, new Point(p.X + 10, p.Y + 8));
                            continue;
                        }

                        ///if flaged, draw flag
                        if (flags.Contains(new Point(x, y)))
                        {
                            e.Graphics.DrawImage(Images[(int)Field.Flag], p.X, p.Y, 43, 43);
                        }
                        else
                        {
                            if (hidden.Any(z => z == battlefield.Field[y, x]) && !visitedRectangles[y, x])
                            {
                                /// cover
                                e.Graphics.DrawImage(Images[(int)Field.Nothing], p.X, p.Y, 43, 43);

                                ///DEBUG
                                //e.Graphics.DrawImage(Images[(int)battlefield.Field[y, x]],p.X,p.Y, 43, 43);
                            }
                            else
                            {
                                if (visitedRectangles[y, x] && battlefield.Field[y, x] == Field.Nothing)
                                    e.Graphics.DrawImage(Images[(int)Field.Empty], p.X, p.Y, 43, 43);
                                else
                                    e.Graphics.DrawImage(Images[(int)battlefield.Field[y, x]], p.X, p.Y, 43, 43);
                            }
                        }
                    }
                }
            
            }));

            ///draw other half of battlefield
            for (int y = 0; y < battlefield.Height/2; y++)
            {
                for (int x = 0; x < battlefield.Width; x++)
                {
                    Point p = new Point(221+ x*43,93+y*43);

                    if (visitedRectangles[y, x] && numbersBomb[y, x] > 0 && battlefield.Field[y, x] != Field.Gold && battlefield.Field[y, x] != Field.Hearth && battlefield.Field[y, x] != Field.Finish
                        && battlefield.Field[y, x] != Field.Stone)
                    {
                        ///Draw Numbers
                        e.Graphics.DrawString(numbersBomb[y, x].ToString(), new Font(FontFamily.GenericSansSerif, 20), Brushes.Black, new Point(p.X+10, p.Y+8));
                        continue;
                    }

                    ///if flaged, draw flag
                    if (flags.Contains(new Point(x,y)))
                    {
                        e.Graphics.DrawImage(Images[(int)Field.Flag], p.X, p.Y, 43, 43);
                    }
                    else
                    {
                        if (hidden.Any(z => z == battlefield.Field[y, x]) && !visitedRectangles[y, x])
                        {
                            /// cover
                            e.Graphics.DrawImage(Images[(int)Field.Nothing], p.X, p.Y, 43, 43);

                            ///DEBUG
                            //e.Graphics.DrawImage(Images[(int)battlefield.Field[y, x]], p.X, p.Y, 43, 43);
                        }
                        else
                        {
                            if (visitedRectangles[y, x] && battlefield.Field[y, x] == Field.Nothing)
                                e.Graphics.DrawImage(Images[(int)Field.Empty], p.X, p.Y, 43, 43);
                            else
                                e.Graphics.DrawImage(Images[(int)battlefield.Field[y, x]], p.X, p.Y, 43, 43);
                        }
                    }
                }
            }
            
            ///Init settings
            ///Launch timer
            if (init)
            {
                tim.Enabled = true;
                timer.Start();
                init = false;
            }
        }

        /// <summary>
        /// Clicked event, places flags, handles bomb, gold, heart clicks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clicked(object sender, EventArgs e)
        {
            //MessageBox.Show("Position: [" + ((MouseEventArgs)e).Y + "," + ((MouseEventArgs)e).X + "]");
            int x = ((MouseEventArgs)e).X - 221;
            int y = ((MouseEventArgs)e).Y - 90;
            
            ///determines if user clicked in desired area
            if (x > 43*battlefield.Width || x < 0)
                return;
            if (y > 43*battlefield.Height || y < 0)
                return;
            int cX = (int)x / 43;
            int cY = (int)y / 43;
            if(cX >= battlefield.Width || cY >= battlefield.Height || cX < 0 || cY < 0)
            {
                return;
            }
            Point p = new Point(cX, cY);

            ///IF Left Mouse button
            if(((MouseEventArgs)e).Button == System.Windows.Forms.MouseButtons.Left )
            {
                if (flags.Contains(p))
                    return;

                if (battlefield.Field[cY, cX] == Field.Hearth && battlefield.Player.Life < 3 )
                {
                    battlefield.Field[cY, cX] = Field.Empty;
                    battlefield.Player.Life++;
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(Sounds.health);
                    player.Play();
                }
                if (battlefield.Field[cY, cX] == Field.Gold)
                {
                    battlefield.Field[cY, cX] = Field.Empty;
                    battlefield.Player.Coins++;
                    battlefield.Player.Score += 10;
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(Sounds.coin);
                    player.Play();
                }
                if (battlefield.Field[cY, cX] == Field.Bomb && !visitedRectangles[cY, cX])
                {
                    visitedRectangles[cY, cX] = true;
                    battlefield.Player.Life--;
                    bombsCount--;
                    battlefield.Player.Score -= 10;
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(Sounds.bomb);
                    player.Play();
                    resolver_Tick(this, EventArgs.Empty);
                }
                else
                {
                    visitedRectangles[cY, cX] = reveal(cX, cY);
                }
            }

            ///If Right Mouse Button
            if (((MouseEventArgs)e).Button == System.Windows.Forms.MouseButtons.Right)
            {
                if ( (battlefield.Field[cY, cX] == Field.Stone || battlefield.Field[cY, cX] == Field.Empty) 
                    ||( visitedRectangles[cY,cX]))
                { 
                    //do not flag other objects
                }
                else if(flags.Contains(p)){
                    //remove flag
                    flags.Remove(p);
                    bombsCount++;
                }
                else
                {
                    ///place flag
                    bombsCount--;
                    flags.Add(new Point(cX, cY));
                }
            }
            //Is game finished?
            endOfGame = isFinishedd();

            ///Redraw window
            Invalidate();
        }

        /// <summary>
        /// Reveals cells that are empty or hold only number
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <returns>if [x,y] is visible</returns>
        private bool reveal(int x,int y)
        {
            if (x < 0 || y < 0 || x > 9 || y > 9)
                return false;
            
            if (visitedRectangles[y, x])
                return true;
            if (numbersBomb[y, x] > 0)
            {
                visitedRectangles[y, x] = true;
                return true;
            }

            if (battlefield.Field[y, x] == Field.Nothing || battlefield.Field[y,x] == Field.Hearth
                || battlefield.Field[y, x] == Field.Gold || battlefield.Field[y,x] == Field.Empty)
            {
                visitedRectangles[y, x] = true;
            }
            else
                return false;
            ///run horizontal and vertical scan on other thread
            Invoke(new Action(() => {
                reveal(x - 1, y);
                reveal(x + 1, y);
                reveal(x, y - 1);
                reveal(x, y + 1);
            }));

            ///Diagonal scan on other thread as well
            Invoke(new Action(() =>
            {
                ///diagonaly
                reveal(x + 1, y - 1);
                reveal(x + 1, y - 1);
                reveal(x - 1, y + 1);
                reveal(x - 1, y + 1);
            }));

            return true;
        }


        /// <summary>
        /// Scans field and finds out if game is finished, all fields that does not contain bomb are visited
        /// </summary>
        /// <returns>true if game is finished</returns>
        private bool isFinishedd()
        {
            
            for (int yy = 0; yy < battlefield.Height; yy++)
            {
                for (int xx = 0; xx < battlefield.Width; xx++)
                {
                    if (   battlefield.Field[yy, xx] == Field.Empty 
                        || battlefield.Field[yy, xx] == Field.Nothing 
                        || battlefield.Field[yy,xx]  == Field.Gold)
                    {
                        if (!visitedRectangles[yy, xx])
                            return false;
                    }
                }
            }
            return true;
        }

    }
}
