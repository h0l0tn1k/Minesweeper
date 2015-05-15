using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{

    /// <summary>
    /// This class is used for loading data from file(Database)
    /// </summary>
    public class PlayersData
    {
        /// <summary>
        /// username of player
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// maximum Level he achieved
        /// </summary>
        public int MaxLevel{get;set;}
        /// <summary>
        /// His maximum score
        /// </summary>
        public int Score { get; set; }
        /// <summary>
        /// Position in Table
        /// </summary>
        public int Position { get; set; }
        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public PlayersData()
        {

        }
        /// <summary>
        /// To string overload
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}. {1}, Score: {2} Level: {3}", Position, Username, Score, MaxLevel);
        }
    }
}
