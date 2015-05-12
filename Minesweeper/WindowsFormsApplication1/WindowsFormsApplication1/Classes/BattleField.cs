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



    public class BattleField
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public  Player Player { get; set; }
        public Field[,] Field { get; set; }

        public BattleField(int width,int height,Field[,] field)
        {
            Field = field;
            Width = width;
            Height = height;
        }

    }
}
