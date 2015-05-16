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
           
        /// <summary>
        /// Main screen menu layout
        /// </summary>
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

        /// <summary>
        /// New game button
        /// </summary>
        public Button NewGame { get { return btnNewGame; } set { NewGame = value; } }
        /// <summary>
        /// Stats button
        /// </summary>
        public Button Stats { get { return btnStats; } set { btnStats = value; } }
        /// <summary>
        /// Exit button
        /// </summary>
        public Button Exit { get { return btnExit; } set { btnExit = value; } }
    }
}
