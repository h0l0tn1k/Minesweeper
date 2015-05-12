using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Media;

namespace Minesweeper
{
    public delegate void Finishgame(int x);
    public partial class Gameplay : Form
    {
        public Finishgame NextLevel { get; set; }
        public Finishgame QuitGame { get; set; }
        public Form Parent { get; set; }
        private System.Windows.Forms.Timer tim;
        private Stopwatch timer;
        private bool init;
        private int bombsCount;
        private BattleField battlefield;
        private bool[,] visitedRectangles;
        private Image[] Images = new Image[10];
        private List<Field> hidden = new List<Field> { Field.Bomb, Field.Gold,Field.Hearth};
        private int[,] numbersBomb;
        private List<Point> flags;
        private int level;
        public BattleField Battlefield { get { return battlefield; }  }

        public Gameplay(Field[,] field,int width,int height,ref Player pl,int lvl)
        {
            InitializeComponent();
            level = lvl;
            
            label1.Text = "Level " + (level+1).ToString();
            battlefield = new BattleField(width,height, field);
            numbersBomb = new int[height,width];
            visitedRectangles = new bool[height,width];
            timer = new Stopwatch();
            tim = new System.Windows.Forms.Timer();
            flags = new List<Point>();

            battlefield.Player = pl;
            bombsCount = 0;
            tim.Tick += tim_Tick;
            tim.Tick += resolver_Tick;
            tim.Interval = 500;
            lblTime.Text = "Time : 00:00";
            Images[(int)Field.Bomb] = Pictures.bomb;
            Images[(int)Field.Nothing] = Pictures.ground;
            Images[(int)Field.Hearth] = Pictures.hearth;
            Images[(int)Field.Stone] = Pictures.stone;
            Images[(int)Field.Finish] = Pictures.finish;
            Images[(int)Field.Player] = Pictures.player;
            Images[(int)Field.Empty] = Pictures.empteyyy;
            Images[(int)Field.Gold] = Pictures.coin;
            Images[(int)Field.Flag] = Pictures.flag;

            setBombNumbers();
            init = true;
        }

        void resolver_Tick(object sender, EventArgs e)
        {
            if (battlefield.Player.Life <= 0)
            {
                tim.Tick -= resolver_Tick;
                MessageBox.Show("You are dead!");
                Parent.Show();
                this.Hide();
                QuitGame(0);
                return;
            }
            bool res = isFinishedd();
            lblDebug.Text = "Finished : " + res.ToString();
            if (res)
            {
                tim.Tick -= resolver_Tick;
                MessageBox.Show("You WON!!\n" + "Elapsed time: " + timer.Elapsed.ToString("mm\\:ss"));
                Parent.Show();
                this.Hide();
                NextLevel(++level);
            }

        }

        void tim_Tick(object sender, EventArgs e)
        {
            lblTime.Text = "Time : " + timer.Elapsed.ToString("mm\\:ss");
        }

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

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawString("Life : " + (Math.Max(0,battlefield.Player.Life)).ToString() + "/3",new Font(FontFamily.GenericSansSerif,15),Brushes.Gray,new Point(30,100));
            e.Graphics.DrawString("Coins: " + battlefield.Player.Coins, new Font(FontFamily.GenericSansSerif, 15), Brushes.Gray, new Point(30, 130));
            e.Graphics.DrawString("Bombs: " + (Math.Max(0,bombsCount)).ToString(), new Font(FontFamily.GenericSansSerif, 15), Brushes.Gray, new Point(30, 160));
            e.Graphics.DrawImage(Pictures.battlefield, 157, 37,550,550);


            for (int y = 0; y < battlefield.Height; y++)
            {
                for (int x = 0; x < battlefield.Width; x++)
                {
                    Point p = new Point(221+ x*43,93+y*43);
                    ///Draw Numbers
                    if (visitedRectangles[y, x] && numbersBomb[y, x] > 0 && battlefield.Field[y, x] != Field.Gold && battlefield.Field[y, x] != Field.Hearth && battlefield.Field[y, x] != Field.Finish
                        && battlefield.Field[y, x] != Field.Stone)
                    {
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
                            ///
                            /// DEBUG
                            ///

                            //e.Graphics.DrawImage(Images[(int)battlefield.Field[y, x]], p.X, p.Y, 43, 43);

                            /// cover
                            e.Graphics.DrawImage(Images[(int)Field.Nothing], p.X, p.Y, 43, 43);
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
            
            if (init)
            {
                tim.Enabled = true;
                timer.Start();
                init = false;
            }
        }

        private void clicked(object sender, EventArgs e)
        {
            //MessageBox.Show("Position: [" + ((MouseEventArgs)e).Y + "," + ((MouseEventArgs)e).X + "]");
            int x = ((MouseEventArgs)e).X - 221;
            int y = ((MouseEventArgs)e).Y - 90;
            
            if (x > 43*battlefield.Width || x < 0)
                return;
            if (y > 43*battlefield.Height || y < 0)
                return;
            int cX = (int)x / 43;
            int cY = (int)y / 43;
            Point p = new Point(cX, cY);

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
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(Sounds.coin);
                    player.Play();
                }
                if (battlefield.Field[cY, cX] == Field.Bomb && !visitedRectangles[cY, cX])
                {
                    visitedRectangles[cY, cX] = true;
                    battlefield.Player.Life--;
                    bombsCount--;
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(Sounds.bomb);
                    player.Play();
                    resolver_Tick(this, EventArgs.Empty);
                }
                else
                {
                    visitedRectangles[cY, cX] = reveal(cX, cY);
                }
            }
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
            Invalidate();
        }

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
            reveal(x - 1, y);
            reveal(x + 1, y);
            reveal(x, y - 1);
            reveal(x, y + 1);

            ///diagonaly
            reveal(x + 1, y - 1);
            reveal(x + 1, y - 1);
            reveal(x - 1, y + 1);
            reveal(x - 1, y + 1);
            return true;
        }

        private bool isFinishedd()
        {
            for (int yy = 0; yy < battlefield.Height; yy++)
            {
                for (int xx = 0; xx < battlefield.Width; xx++)
                {
                    if (battlefield.Field[yy, xx] == Field.Empty || battlefield.Field[yy, xx] == Field.Nothing)
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
