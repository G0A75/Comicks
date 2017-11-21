using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpCompress.Readers;
using System.IO;

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
                        ExtractComic("cbr", ofd.FileName);
                    
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Unable to open file." + Environment.NewLine + ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void ExtractComic(string comicFileType, string comicPath)
        {
            using (Stream stream = File.OpenRead(comicPath))
            {
                var reader = ReaderFactory.Open(stream);
                while (reader.MoveToNextEntry())
                {
                    if (!reader.Entry.IsDirectory)
                    {
                        Console.WriteLine(reader.Entry.Key);
                        reader.WriteEntryToDirectory(@"C:\temp", new ExtractionOptions() { ExtractFullPath = true, Overwrite = true });
                    }
                }
            }
          
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}