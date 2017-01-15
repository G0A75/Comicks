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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        #region Variables

        private const string SupportedFileTypes = @"CBZ Files|*.cbz|CBR Files|*.cbr|CBT Files|*.cbt|CBA Files|*.cba|All Files|*.*";

        #endregion

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {      
            try
            {
                // Construct the OpenFileDialog
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Title = @"Open a file";
                    ofd.Filter = SupportedFileTypes;

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        // To do
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Unable to open file." + Environment.NewLine + ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}