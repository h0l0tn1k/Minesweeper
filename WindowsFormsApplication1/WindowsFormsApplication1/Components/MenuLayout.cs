using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class MenuLayout : UserControl
    {
           
        public MenuLayout()
        {
            InitializeComponent();
            btnExit.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnExit.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnNewGame.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnNewGame.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnStats.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnStats.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }

        public Button NewGame { get { return btnNewGame; } set { NewGame = value; } }
        public Button Stats { get { return btnStats; } set { btnStats = value; } }
        public Button Exit { get { return btnExit; } set { btnExit = value; } }
    }
}
