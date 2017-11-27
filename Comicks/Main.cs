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
        private const string TempFolder = @"C:\Comixtemp";
        private Image imgOriginal;
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
                        ExtractComic(ofd.FileName);
                    
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Unable to open file." + Environment.NewLine + ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Extract comic selected by user
        /// </summary>
        /// <param name="comicPath">file path of file selected by user</param>
        private void ExtractComic(string comicPath)
        {
            try
            {
                using (Stream stream = File.OpenRead(comicPath))
                {
                    var reader = ReaderFactory.Open(stream);
                    while (reader.MoveToNextEntry())
                    {
                        if (!reader.Entry.IsDirectory)
                        {
                            Console.WriteLine(reader.Entry.Key);
                            reader.WriteEntryToDirectory(@"C:\Comixtemp", new ExtractionOptions() { ExtractFullPath = true, Overwrite = true });
                            ShowComic();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(@"Unable to open file."+ Environment.NewLine + ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowComic()
        {
            string comicDirectory;
            string[] comicFiles;
            string[] directory;

            directory = Directory.GetDirectories(TempFolder);
            comicDirectory = directory[0];

            comicFiles = Directory.GetFiles(comicDirectory);
            imgOriginal = Image.FromFile(comicFiles[0]);
            objImageViewer1.Image = imgOriginal;


            
            
            

            

        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            objImageViewer1.Zoom += (float)0.1;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            objImageViewer1.Zoom -= (float)0.1;
        }
       
        
    }
}