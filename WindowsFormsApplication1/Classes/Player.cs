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
        public int Score { get; set; }
        public string Username { get; set; }
        public int Level { get; set; }
        public Player(string username,int life)
        {
            Level = 1;
            Username = username;
            Life = life;
        }
    }
}
