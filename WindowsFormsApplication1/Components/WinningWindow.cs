using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    /// <summary>
    /// Form for displaying Winning whole game
    /// </summary>
    public partial class WinningWindow : Form
    {
        /// <summary>
        /// public property to set up score 
        /// </summary>
        public string LblScore { set { label1.Text = value; } }
        /// <summary>
        /// Parent window to show after 
        /// </summary>
        public MainScreen ParentWindow { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        public WinningWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// On closing show parent
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            ParentWindow.Show();
        }
    }
}
