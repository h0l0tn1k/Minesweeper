using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class Player
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Life { get; set; }
        public int Coins { get; set; }

        public Player(int x, int y, int life)
        {
            X = x;
            Y = y;
            Life = life;
        }
    }
}
