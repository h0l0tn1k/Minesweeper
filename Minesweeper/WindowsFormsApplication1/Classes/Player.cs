using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    /// <summary>
    /// Class for representing player
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Number of lives
        /// </summary>
        public int Life { get; set; }
        /// <summary>
        /// Coins that player has
        /// </summary>
        public int Coins { get; set; }
<<<<<<< HEAD
        /// <summary>
        /// Score of player
        /// </summary>
        public int Score { get; set; }
        /// <summary>
        /// Username of player
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// His highest achieved level
        /// </summary>
        public int Level { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="username">Player's username</param>
        /// <param name="life">Life of player</param>
        public Player(string username,int life = 3)
=======
        public int Score { get; set; }
        public string Username { get; set; }
        public int Level { get; set; }
        public Player(string username,int life)
>>>>>>> origin/master
        {
            Level = 1;
            Username = username;
            Life = life;
        }
    }
}
