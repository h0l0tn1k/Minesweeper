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
    /// Custme message box
    /// </summary>
    public partial class CustomMessageBox : Form
    {
        /// <summary>
        /// public property for setting labels 
        /// </summary>
        public string Label1 {set { label1.Text = value; } }

        /// <summary>
        /// public property for setting labels 
        /// </summary>
        public string Label2 { set { label2.Text = value; } }

        /// <summary>
        /// public property for setting labels 
        /// </summary>
        public string Label3 { set { label3.Text = value; } }
        /// <summary>
        /// Constructor
        /// </summary>
        public CustomMessageBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Closes dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseMBox(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// If escape or enter pressed => closes dialog box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomMessageBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Enter)
            {
                this.Close();
            }
        }

    }
}
