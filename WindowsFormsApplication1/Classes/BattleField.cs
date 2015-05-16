using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{

    /// <summary>
    /// Cell representation of field
    /// </summary>
    public enum Field
    {
        Bomb,
        Nothing,
        Gold,
        Player, // not used
        Hearth,
        Stone,
        Finish,// not used
        Flag,
        Number,// not used
        Empty
    }



    public class BattleField
    {
        /// <summary>
        /// Width of battlefield
        /// </summary>
        public int Width { get; private set; }
        /// <summary>
        /// Height of battlefield
        /// </summary>
        public int Height { get; private set; }
        /// <summary>
        /// Player that plays on this field
        /// </summary>
        public  Player Player { get; set; }
        /// <summary>
        /// Actual map
        /// </summary>
        public Field[,] Field { get; set; }

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="width">width of field</param>
        /// <param name="height">height of field</param>
        /// <param name="field">Map</param>
        public BattleField(int width,int height,Field[,] field)
        {
            Field = new Minesweeper.Field[height, width];
            Width = width;
            Height = height;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Field[y, x] = field[y, x];
                }
            }
        }

    }
}
