using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{

    public enum Field
    {
        Bomb,
        Nothing,
        Gold,
        Player,
        Hearth,
        Stone,
        Finish,
        Flag,
        Number,
        Empty
    }



    class BattleField
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public  Player Player { get; set; }

        /// <summary>
        ///             10 X 10
        /// </summary>
        public Field[,] Field { get; set; }

        public BattleField(int width,int height,Field[,] field)
        {
            Player = new Player(0, 0, 3);
            Field = field;
        }

    }
}
