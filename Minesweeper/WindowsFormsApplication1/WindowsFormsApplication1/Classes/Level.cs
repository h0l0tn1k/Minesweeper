using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public abstract class Level
    {
        protected Field[,] map;
        public Field[,] Map { get { return map; }}
    }

    public class Level1 : Level
    {
        public Level1()
        {
            map = new Field[10, 10] 
            {
                {Field.Empty,   Field.Empty,    Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Stone,    Field.Nothing,  Field.Nothing,  Field.Nothing},
                {Field.Empty,   Field.Nothing,  Field.Nothing,  Field.Bomb,     Field.Nothing,  Field.Nothing,  Field.Stone,    Field.Nothing,  Field.Nothing,  Field.Nothing},
                {Field.Nothing, Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Stone,    Field.Nothing,  Field.Nothing,  Field.Nothing},
                {Field.Nothing, Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Stone,    Field.Nothing,  Field.Nothing,  Field.Nothing},
                {Field.Nothing, Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Bomb,     Field.Nothing,  Field.Nothing,  Field.Nothing},
                {Field.Nothing, Field.Nothing,  Field.Nothing,  Field.Bomb,     Field.Nothing,  Field.Hearth,   Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing},
                {Field.Nothing, Field.Hearth,   Field.Nothing,  Field.Bomb,     Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing},
                {Field.Nothing, Field.Nothing,  Field.Bomb,     Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing},
                {Field.Stone,   Field.Bomb,     Field.Bomb,     Field.Nothing,  Field.Nothing,  Field.Stone,    Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing},
                {Field.Gold,    Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Gold,     Field.Stone,    Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Finish}            
            };
        }
    }
}
