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
    public partial class CustomMessageBox : Form
    {
        public string Label1 {set { label1.Text = value; } }
        public string Label2 { set { label2.Text = value; } }
        public string Label3 { set { label3.Text = value; } }
        public CustomMessageBox()
        {
            InitializeComponent();
        }

        private void CloseMBox(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
