using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Minesweeper
{
    public partial class Gameplay : Form
    {
        private Timer tim;
        private Stopwatch timer;
        private bool init;
        private int bombsCount;
        private BattleField battlefield;
        private bool[,] visitedRectangles;
        private Image[] Images = new Image[10];
        private List<Field> hidden = new List<Field> { Field.Bomb, Field.Gold,Field.Hearth};
        private int[,] numbersBomb;
        private List<Point> flags;

        public Gameplay(Field[,] field,Player pl)
        {
            InitializeComponent();
            battlefield = new BattleField(433, 433, field);
            numbersBomb = new int[10, 10];
            flags = new List<Point>();
            battlefield.Player = pl;
            bombsCount = 0;
            visitedRectangles = new bool[10, 10];
            visitedRectangles[pl.Y, pl.X] = true;
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
            timer = new Stopwatch();
            tim = new Timer();
            tim.Tick += tim_Tick;
            tim.Interval = 1000;
            lblTime.Text = "Time : 00:00";
            init = true;
        }

        void tim_Tick(object sender, EventArgs e)
        {
            lblTime.Text = "Time : " + timer.Elapsed.ToString("mm\\:ss");
        }

        private void setBombNumbers()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int x = 0; x < 10; x++)
                {
                    numbersBomb[i, x] = 0;
                }
            }

            for (int i = 0; i < 10; i++)
            {
                for (int x = 0; x < 10; x++)
                {
                    if (battlefield.Field[i, x] == Field.Bomb)
                    {
                        bombsCount++;
                        addToSurroundings(x, i);
                    }
                }

            }
        }

        private void addToSurroundings(int x,int y)
        {
            bool[] arr = new bool[10];
            for (int i = 0; i < 10; i++)
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


            for (int i = 0; i < 10; i++)
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


            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    Point p = new Point(221+ x*43,93+y*43);
                    if (x == battlefield.Player.X && y == battlefield.Player.Y) { 
                        e.Graphics.DrawImage(Images[(int)Field.Player], p.X, p.Y, 43, 43);
                        continue;
                    }

                    if (visitedRectangles[y, x] && numbersBomb[y, x] > 0 && battlefield.Field[y, x] != Field.Gold && battlefield.Field[y, x] != Field.Hearth && battlefield.Field[y, x] != Field.Finish
                        && battlefield.Field[y, x] != Field.Stone)
                    {
                        e.Graphics.DrawString(numbersBomb[y, x].ToString(), new Font(FontFamily.GenericSansSerif, 20), Brushes.Black, new Point(p.X+10, p.Y+8));
                        continue;
                    }

                    if (flags.Contains(new Point(x,y)))
                    {
                        e.Graphics.DrawImage(Images[(int)Field.Flag], p.X, p.Y, 43, 43);
                    }
                    else
                    {
                        if (hidden.Any(z => z == battlefield.Field[y, x]) && !visitedRectangles[y, x])
                        {
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
            
            if (x > 430 || x < 0)
                return;
            if (y > 430 || y < 0)
                return;
            int cX = (int)x / 43;
            int cY = (int)y / 43;
            Point p = new Point(cX, cY);

            if(((MouseEventArgs)e).Button == System.Windows.Forms.MouseButtons.Left )
            {
                if (flags.Contains(p))
                    return;
                if (battlefield.Field[cY, cX] == Field.Bomb && !visitedRectangles[cY, cX]) { 
                    battlefield.Player.Life--;
                    bombsCount--;
                }
                if (battlefield.Field[cY, cX] == Field.Hearth && battlefield.Player.Life < 3 && !visitedRectangles[cY,cX])
                    battlefield.Player.Life++;
                if (battlefield.Field[cY, cX] == Field.Gold && !visitedRectangles[cY, cX])
                    battlefield.Player.Coins++;
                visitedRectangles[cY, cX] = true;
            }
            if (((MouseEventArgs)e).Button == System.Windows.Forms.MouseButtons.Right)
            {
                if ( (battlefield.Field[cY, cX] == Field.Stone || battlefield.Field[cY, cX] == Field.Empty) 
                    ||( visitedRectangles[cY,cX]))
                { 
                
                }
                else if(flags.Contains(p)){
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
        
    }
}
