using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class Player
    {
        public int Life { get; set; }
        public int Coins { get; set; }

        public Player(int life)
        {
            Life = life;
        }
    }
}
