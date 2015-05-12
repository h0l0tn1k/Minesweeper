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
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Field[,] Map { get { return map; }}
        public Level(int width,int height)
        {
            Width = width;
            Height = height;
        }
    }

    public class Level1 : Level
    {
        public Level1()
            :base(10,10)
        {
            map = new Field[10, 10] 
            {
                {Field.Empty,   Field.Empty,    Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Stone,    Field.Nothing,  Field.Hearth,  Field.Nothing},
                {Field.Empty,   Field.Nothing,  Field.Nothing,  Field.Bomb,     Field.Nothing,  Field.Nothing,  Field.Stone,    Field.Nothing,  Field.Nothing,  Field.Gold},
                {Field.Nothing, Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Stone,    Field.Nothing,  Field.Nothing,  Field.Bomb},
                {Field.Nothing, Field.Gold,     Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Stone,    Field.Nothing,  Field.Nothing,  Field.Nothing},
                {Field.Bomb,    Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Bomb,     Field.Nothing,  Field.Nothing,  Field.Nothing},
                {Field.Bomb,    Field.Nothing,  Field.Nothing,  Field.Bomb,     Field.Nothing,  Field.Hearth,   Field.Nothing,  Field.Bomb,     Field.Nothing,  Field.Nothing},
                {Field.Nothing, Field.Hearth,   Field.Nothing,  Field.Bomb,     Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing},
                {Field.Nothing, Field.Nothing,  Field.Bomb,     Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing},
                {Field.Stone,   Field.Bomb,     Field.Bomb,     Field.Nothing,  Field.Nothing,  Field.Stone,    Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Bomb},
                {Field.Gold,    Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Gold,     Field.Stone,    Field.Nothing,  Field.Nothing,  Field.Bomb,  Field.Finish}            
            };
        }
    }

    class Level2 : Level
    {
        public Level2()
            :base(10,10)
        {
            map = new Field[10, 10] { 
                {Field.Stone,   Field.Gold,     Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Hearth,   Field.Nothing},
                {Field.Empty,   Field.Stone,    Field.Bomb,     Field.Bomb,     Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Gold},
                {Field.Hearth,  Field.Nothing,  Field.Stone,    Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Stone,    Field.Bomb},
                {Field.Bomb,    Field.Gold,     Field.Nothing,  Field.Stone,    Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Stone,    Field.Nothing},
                {Field.Bomb,    Field.Nothing,  Field.Stone,    Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Bomb,     Field.Nothing,  Field.Stone,    Field.Gold},
                {Field.Bomb,    Field.Stone,    Field.Bomb,     Field.Bomb,     Field.Nothing,  Field.Hearth,   Field.Nothing,  Field.Bomb,     Field.Stone,    Field.Gold},
                {Field.Nothing, Field.Hearth,   Field.Nothing,  Field.Gold,     Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Stone,    Field.Gold},
                {Field.Nothing, Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Stone,    Field.Nothing},
                {Field.Bomb,    Field.Bomb,     Field.Bomb,     Field.Nothing,  Field.Nothing,  Field.Stone,    Field.Nothing,  Field.Gold,     Field.Stone,    Field.Bomb},
                {Field.Bomb,    Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Gold,     Field.Stone,    Field.Nothing,  Field.Nothing,  Field.Bomb,     Field.Nothing}            
            
            };
        }
    }

    class Level3 : Level
    {
        public Level3()
            : base(10, 10)
        {
            map = new Field[10, 10] { 
                {Field.Stone,   Field.Gold,     Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Hearth,   Field.Nothing},
                {Field.Empty,   Field.Stone,    Field.Bomb,     Field.Bomb,     Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Gold},
                {Field.Hearth,  Field.Nothing,  Field.Stone,    Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Stone,    Field.Bomb},
                {Field.Bomb,    Field.Gold,     Field.Nothing,  Field.Stone,    Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Stone,    Field.Nothing},
                {Field.Bomb,    Field.Nothing,  Field.Stone,    Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Bomb,     Field.Nothing,  Field.Stone,    Field.Gold},
                {Field.Bomb,    Field.Stone,    Field.Bomb,     Field.Bomb,     Field.Nothing,  Field.Hearth,   Field.Nothing,  Field.Bomb,     Field.Stone,    Field.Gold},
                {Field.Nothing, Field.Hearth,   Field.Nothing,  Field.Gold,     Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Stone,    Field.Gold},
                {Field.Nothing, Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Stone,    Field.Nothing},
                {Field.Bomb,    Field.Bomb,     Field.Bomb,     Field.Nothing,  Field.Nothing,  Field.Stone,    Field.Nothing,  Field.Gold,     Field.Stone,    Field.Bomb},
                {Field.Bomb,    Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Gold,     Field.Stone,    Field.Nothing,  Field.Nothing,  Field.Bomb,     Field.Nothing}            
            
            };
        }
        
    }
}
