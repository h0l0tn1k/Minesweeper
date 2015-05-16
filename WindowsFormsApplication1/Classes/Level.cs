
namespace Minesweeper
{
    /// <summary>
    /// Abstract representation of each level
    /// </summary>
    public abstract class Level
    {
        /// <summary>
        /// 2D array of cells
        /// </summary>
        protected Field[,] map;
        /// <summary>
        /// Width of field
        /// </summary>
        public int Width { get; private set; }
        /// <summary>
        /// Height of field
        /// </summary>
        public int Height { get; private set; }
        /// <summary>
        /// public property to access map
        /// </summary>
        public Field[,] Map { get { return map; }}
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
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
                {Field.Empty,   Field.Empty,    Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Stone,    Field.Nothing,  Field.Hearth,   Field.Nothing},
                {Field.Empty,   Field.Nothing,  Field.Nothing,  Field.Bomb,     Field.Nothing,  Field.Nothing,  Field.Stone,    Field.Nothing,  Field.Nothing,  Field.Gold},
                {Field.Nothing, Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Stone,    Field.Nothing,  Field.Nothing,  Field.Bomb},
                {Field.Nothing, Field.Gold,     Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Stone,    Field.Nothing,  Field.Nothing,  Field.Nothing},
                {Field.Bomb,    Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Bomb,     Field.Nothing,  Field.Nothing,  Field.Nothing},
                {Field.Bomb,    Field.Nothing,  Field.Nothing,  Field.Bomb,     Field.Nothing,  Field.Hearth,   Field.Nothing,  Field.Bomb,     Field.Nothing,  Field.Nothing},
                {Field.Nothing, Field.Hearth,   Field.Nothing,  Field.Bomb,     Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing},
                {Field.Nothing, Field.Nothing,  Field.Bomb,     Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing},
                {Field.Stone,   Field.Bomb,     Field.Bomb,     Field.Nothing,  Field.Nothing,  Field.Stone,    Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Bomb},
                {Field.Gold,    Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Gold,     Field.Stone,    Field.Nothing,  Field.Nothing,  Field.Bomb,     Field.Gold}            
            };
        }
    }

    public class Level2 : Level
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

    public class Level3 : Level
    {
        public Level3()
            : base(10, 10)
        {
            map = new Field[10, 10] { 
                {Field.Bomb,    Field.Stone,    Field.Gold,     Field.Stone,    Field.Empty,    Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Empty,    Field.Nothing},
                {Field.Hearth,  Field.Gold,     Field.Bomb,     Field.Stone,    Field.Nothing,  Field.Empty,    Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Gold},
                {Field.Empty,   Field.Empty,    Field.Bomb,     Field.Stone,    Field.Bomb,     Field.Hearth,   Field.Bomb,     Field.Nothing,  Field.Bomb,     Field.Bomb},
                {Field.Nothing, Field.Bomb,     Field.Stone,    Field.Nothing,  Field.Nothing,  Field.Empty,    Field.Bomb,     Field.Nothing,  Field.Nothing,  Field.Gold},
                {Field.Nothing, Field.Stone,    Field.Bomb,     Field.Empty,    Field.Nothing,  Field.Gold,     Field.Stone,    Field.Nothing,  Field.Hearth,   Field.Nothing},
                {Field.Stone,   Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Empty,    Field.Stone,    Field.Bomb,     Field.Bomb,     Field.Nothing,  Field.Gold},
                {Field.Nothing, Field.Stone,    Field.Stone,    Field.Bomb,     Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Gold},
                {Field.Bomb,    Field.Stone,    Field.Bomb,     Field.Bomb,     Field.Bomb,     Field.Nothing,  Field.Stone,    Field.Nothing,  Field.Stone,    Field.Nothing},
                {Field.Gold,    Field.Stone,    Field.Stone,    Field.Bomb,     Field.Gold,     Field.Nothing,  Field.Bomb,     Field.Gold,     Field.Gold,     Field.Bomb},
                {Field.Gold,    Field.Stone,    Field.Stone,    Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Stone,    Field.Stone,    Field.Empty,    Field.Stone}            
            
            };
        }
        
    }

    public class Level4 : Level
    {
        public Level4()
            : base(10, 10)
        {
            map = new Field[10, 10] { 
               
                {Field.Stone,   Field.Gold,     Field.Nothing,  Field.Stone,    Field.Empty,    Field.Empty,    Field.Stone,    Field.Stone,    Field.Stone,    Field.Stone},
                {Field.Empty,   Field.Stone,    Field.Bomb,     Field.Stone,    Field.Nothing,  Field.Empty,    Field.Nothing,  Field.Gold,     Field.Bomb,     Field.Bomb},
                {Field.Hearth,  Field.Nothing,  Field.Stone,    Field.Stone,    Field.Nothing,  Field.Hearth,   Field.Bomb,     Field.Gold,     Field.Bomb,     Field.Bomb},
                {Field.Bomb,    Field.Gold,     Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Empty,    Field.Bomb,     Field.Nothing,  Field.Nothing,  Field.Gold},
                {Field.Bomb,    Field.Gold,     Field.Stone,    Field.Empty,    Field.Nothing,  Field.Gold,     Field.Stone,    Field.Nothing,  Field.Hearth,   Field.Stone},
                {Field.Nothing, Field.Nothing,  Field.Bomb,     Field.Nothing,  Field.Empty,    Field.Stone,    Field.Bomb,     Field.Bomb,     Field.Nothing,  Field.Stone},
                {Field.Nothing, Field.Hearth,   Field.Nothing,  Field.Bomb,     Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Stone},
                {Field.Stone,   Field.Stone,    Field.Stone,    Field.Stone,    Field.Bomb,     Field.Nothing,  Field.Stone,    Field.Nothing,  Field.Nothing,  Field.Nothing},
                {Field.Gold,    Field.Bomb,     Field.Gold,     Field.Bomb,     Field.Gold,     Field.Bomb,     Field.Nothing,  Field.Gold,     Field.Bomb,     Field.Bomb},
                {Field.Gold,    Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Stone,    Field.Stone,    Field.Bomb,     Field.Stone}            
            
            };
        }

    }

    public class Level5 : Level
    {
        public Level5()
            :base(10,10)
        {
            map = new Field[10, 10] 
            {
                {Field.Bomb,    Field.Bomb,     Field.Bomb,     Field.Nothing,  Field.Stone,    Field.Nothing,  Field.Gold,     Field.Stone,    Field.Stone,    Field.Gold},
                {Field.Bomb,    Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Stone,    Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Gold},
                {Field.Bomb,    Field.Stone,    Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Stone,    Field.Nothing,  Field.Bomb,     Field.Nothing,  Field.Gold},
                {Field.Nothing, Field.Stone,    Field.Nothing,  Field.Gold,     Field.Nothing,  Field.Stone,    Field.Nothing,  Field.Nothing,  Field.Bomb,     Field.Nothing},
                {Field.Nothing, Field.Nothing,  Field.Bomb,     Field.Gold,     Field.Stone,    Field.Bomb,     Field.Stone,    Field.Bomb,     Field.Nothing,  Field.Nothing},
                {Field.Nothing, Field.Stone,    Field.Gold,     Field.Gold,     Field.Stone,    Field.Bomb,     Field.Stone,    Field.Nothing,  Field.Bomb,     Field.Bomb},
                {Field.Bomb,    Field.Bomb,     Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Bomb,     Field.Nothing,  Field.Nothing},
                {Field.Nothing, Field.Nothing,  Field.Hearth,   Field.Nothing,  Field.Nothing,  Field.Stone,    Field.Nothing,  Field.Nothing,  Field.Bomb,     Field.Nothing},
                {Field.Nothing, Field.Nothing,  Field.Nothing,  Field.Bomb,     Field.Nothing,  Field.Nothing,  Field.Gold,     Field.Bomb,     Field.Nothing,  Field.Gold},
                {Field.Gold,    Field.Gold,     Field.Bomb,     Field.Bomb,     Field.Bomb,     Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Hearth,   Field.Gold}
            };
        }
    }

    public class Level6 : Level
    {
        public Level6()
            :base(10,10)
        {
            map = new Field[10, 10] 
            {
                {Field.Nothing, Field.Nothing,   Field.Bomb,    Field.Nothing,  Field.Nothing,  Field.Bomb,     Field.Bomb,     Field.Nothing,  Field.Bomb,     Field.Nothing},
                {Field.Bomb,    Field.Nothing,   Field.Bomb,    Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Bomb,     Field.Nothing},
                {Field.Bomb,    Field.Nothing,   Field.Nothing, Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Bomb,     Field.Nothing,  Field.Nothing,  Field.Bomb},
                {Field.Bomb,    Field.Nothing,   Field.Nothing, Field.Nothing,  Field.Gold,     Field.Nothing,  Field.Bomb,     Field.Gold,     Field.Nothing,  Field.Bomb},
                {Field.Nothing, Field.Nothing,   Field.Nothing, Field.Nothing,  Field.Hearth,   Field.Nothing,  Field.Bomb,     Field.Gold,     Field.Nothing,  Field.Bomb},
                {Field.Nothing, Field.Stone,     Field.Stone,   Field.Stone,    Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Bomb,     Field.Nothing},
                {Field.Nothing, Field.Nothing,   Field.Bomb,    Field.Bomb,     Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Bomb,     Field.Nothing,  Field.Nothing},
                {Field.Nothing, Field.Bomb,      Field.Bomb,    Field.Bomb,     Field.Bomb,     Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Bomb,     Field.Hearth},
                {Field.Nothing, Field.Nothing,   Field.Nothing, Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Bomb,     Field.Gold},
                {Field.Gold,    Field.Nothing,   Field.Gold,    Field.Gold,     Field.Nothing,  Field.Stone,    Field.Stone,    Field.Stone,    Field.Nothing,  Field.Gold}
            };
        }
    }

    public class Level7 : Level
    {
        public Level7()
            : base(10, 10)
        {
            map = new Field[10, 10] 
            {
                {Field.Bomb,    Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Bomb,     Field.Nothing,  Field.Bomb,     Field.Gold},
                {Field.Nothing, Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Bomb,     Field.Nothing,  Field.Nothing,  Field.Bomb,     Field.Gold},
                {Field.Bomb,    Field.Bomb,     Field.Hearth,   Field.Bomb,     Field.Bomb,     Field.Nothing,  Field.Bomb,     Field.Nothing,  Field.Nothing,  Field.Empty},
                {Field.Nothing, Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Gold,     Field.Nothing,  Field.Nothing,  Field.Gold,     Field.Nothing,  Field.Empty},
                {Field.Bomb,    Field.Empty,    Field.Nothing,  Field.Nothing,  Field.Hearth,   Field.Nothing,  Field.Nothing,  Field.Bomb,     Field.Nothing,  Field.Nothing},
                {Field.Bomb,    Field.Gold,     Field.Bomb,     Field.Bomb,     Field.Nothing,  Field.Gold,     Field.Nothing,  Field.Bomb,     Field.Nothing,  Field.Nothing},
                {Field.Nothing, Field.Gold,     Field.Nothing,  Field.Bomb,     Field.Nothing,  Field.Gold,     Field.Nothing,  Field.Bomb,     Field.Nothing,  Field.Gold},
                {Field.Nothing, Field.Gold,     Field.Nothing,  Field.Bomb,     Field.Bomb,     Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Bomb,     Field.Nothing},
                {Field.Nothing, Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Bomb,     Field.Nothing,  Field.Nothing,  Field.Nothing},
                {Field.Gold,    Field.Bomb,     Field.Gold,     Field.Gold,     Field.Empty,    Field.Stone,    Field.Bomb,     Field.Stone,    Field.Nothing,  Field.Bomb}
            };
        }
    }
<<<<<<< HEAD
    public class Level8 : Level
    {
        public Level8()
            : base(10, 10)
        {
            map = new Field[10, 10] 
            {                                             
                {Field.Hearth,      Field.Bomb,     Field.Nothing,  Field.Nothing,  Field.Bomb,     Field.Nothing,  Field.Bomb,     Field.Nothing,  Field.Nothing,  Field.Bomb},
                {Field.Nothing,     Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Bomb,     Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Gold},
                {Field.Nothing,     Field.Nothing,  Field.Nothing,  Field.Bomb,     Field.Nothing,  Field.Bomb,     Field.Bomb,     Field.Bomb,     Field.Nothing,  Field.Nothing},
                {Field.Nothing,     Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Gold,     Field.Nothing,  Field.Gold},
                {Field.Nothing,     Field.Gold,     Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Gold,     Field.Nothing,  Field.Bomb,     Field.Nothing},
                {Field.Gold,        Field.Bomb,     Field.Nothing,  Field.Gold,     Field.Bomb,     Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing},
                {Field.Nothing,     Field.Nothing,  Field.Bomb,     Field.Nothing,  Field.Bomb,     Field.Nothing,  Field.Bomb,     Field.Bomb,     Field.Bomb,     Field.Bomb},
                {Field.Bomb,        Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Bomb,     Field.Nothing},
                {Field.Nothing,     Field.Bomb,     Field.Nothing,  Field.Bomb,     Field.Nothing,  Field.Bomb,     Field.Bomb,     Field.Nothing,  Field.Nothing,  Field.Bomb},
                {Field.Gold,        Field.Nothing,  Field.Gold,     Field.Bomb,     Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Bomb,     Field.Bomb}
            };
        }
    }

    public class Level9 : Level
    {
        public Level9()
            : base(10, 10)
        {
            map = new Field[10, 10] 
            {                                             
                {Field.Bomb,        Field.Bomb,     Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Gold,     Field.Gold,     Field.Nothing,  Field.Bomb},
                {Field.Gold,        Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Bomb,     Field.Hearth,   Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing},
                {Field.Bomb,        Field.Nothing,  Field.Bomb,     Field.Gold,     Field.Nothing,  Field.Hearth,   Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Bomb},
                {Field.Gold,        Field.Nothing,  Field.Nothing,  Field.Gold,     Field.Nothing,  Field.Nothing,  Field.Gold,     Field.Bomb,     Field.Nothing,  Field.Bomb},
                {Field.Nothing,     Field.Bomb,     Field.Bomb,     Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Gold,     Field.Nothing,  Field.Bomb,     Field.Nothing},
                {Field.Empty,       Field.Gold,     Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Bomb,     Field.Gold,     Field.Nothing,  Field.Bomb,     Field.Nothing},
                {Field.Empty,       Field.Nothing,  Field.Bomb,     Field.Bomb,     Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Bomb,     Field.Nothing},
                {Field.Nothing,     Field.Nothing,  Field.Bomb,     Field.Bomb,     Field.Nothing,  Field.Bomb,     Field.Nothing,  Field.Nothing,  Field.Bomb,     Field.Nothing},
                {Field.Nothing,     Field.Nothing,  Field.Nothing,  Field.Bomb,     Field.Bomb,     Field.Nothing,  Field.Bomb,     Field.Nothing,  Field.Nothing,  Field.Bomb},
                {Field.Bomb,        Field.Gold,     Field.Bomb,     Field.Bomb,     Field.Bomb,     Field.Nothing,  Field.Nothing,  Field.Bomb,     Field.Nothing,  Field.Nothing}
            };
        }
    }

    public class Level10 : Level
    {
        public Level10()
            : base(10, 10)
        {
            map = new Field[10, 10] 
            {                                             
                {Field.Nothing,     Field.Nothing,  Field.Nothing,  Field.Bomb,     Field.Nothing,  Field.Bomb,     Field.Nothing,  Field.Nothing,  Field.Bomb,     Field.Bomb},
                {Field.Nothing,     Field.Nothing,  Field.Nothing,  Field.Bomb,     Field.Bomb,     Field.Bomb,     Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing},
                {Field.Nothing,     Field.Nothing,  Field.Bomb,     Field.Nothing,  Field.Bomb,     Field.Nothing,  Field.Bomb,     Field.Nothing,  Field.Bomb,     Field.Bomb},
                {Field.Nothing,     Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Bomb,     Field.Bomb,     Field.Nothing,  Field.Nothing},
                {Field.Nothing,     Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Bomb,     Field.Nothing,  Field.Nothing},
                {Field.Bomb,        Field.Bomb,     Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing},
                {Field.Nothing,     Field.Bomb,     Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Bomb,     Field.Bomb,     Field.Bomb,     Field.Bomb},
                {Field.Nothing,     Field.Nothing,  Field.Bomb,     Field.Bomb,     Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Bomb,     Field.Bomb},
                {Field.Nothing,     Field.Bomb,     Field.Nothing,  Field.Bomb,     Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing},
                {Field.Bomb,        Field.Bomb,     Field.Bomb,     Field.Nothing,  Field.Nothing,  Field.Bomb,     Field.Nothing,  Field.Nothing,  Field.Nothing,  Field.Nothing}
            };
        }
    }
=======
>>>>>>> origin/master


}
