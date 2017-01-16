using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comicks
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = ofd.Filter = "CBZ Files(*.cbz)|*.cbz|CBR Files(*.cbr)|*.cbr|" +
               "CBT Files(*.cbt)|*.cbt|CBA Files(*.cba)|*.cba|All Files|*.*";
            ofd.ShowDialog();
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
