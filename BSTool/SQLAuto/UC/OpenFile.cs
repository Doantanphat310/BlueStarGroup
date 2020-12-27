using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace SQLAuto.UC
{
    public partial class OpenFile : UserControl
    {
        public string FileName
        {
            get { return this.Path_TextBox.Text; }
            set
            {
                this.Path_TextBox.Text = value;
            }
        }

        public string Filter { get; set; } = "XML file(*.xml)|*.xml";

        public OpenFile()
        {
            InitializeComponent();

            Path_TextBox.DragEnter += new DragEventHandler(TextBox_DragEnter);
            Path_TextBox.DragDrop += new DragEventHandler(TextBox_DragDrop);
        }

        private void TextBox_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileNames;

            try
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
                {
                    fileNames = (string[])e.Data.GetData(DataFormats.FileDrop);
                    // handle each file passed as needed
                    foreach (string fileName in fileNames)
                    {
                        if (IsValidFile(fileName))
                        {
                            (sender as TextBox).Text = fileName;
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Error in DragDrop function: " + ex.Message);
            }
        }

        private void TextBox_DragEnter(object sender, DragEventArgs e)
        {
            // for this program, we allow a file to be dropped from Explorer
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private bool IsValidFile(string path)
        {


            return !File.GetAttributes(path).HasFlag(FileAttributes.Directory);
        }

        private void Select_Button_Click(object sender, EventArgs e)
        {
            Path_TextBox.Text = OpenFileDialog(Path_TextBox.Text);
        }

        private string OpenFileDialog(string selectedPath = "")
        {
            string fileName = selectedPath;
            OpenFileDialog open = new OpenFileDialog
            {
                Filter = Filter,
                Multiselect = false
            };

            if (!string.IsNullOrWhiteSpace(selectedPath))
            {
                open.FileName = selectedPath.Trim();
            }

            if (open.ShowDialog() == DialogResult.OK)
            {
                fileName = open.FileName;
            }

            return fileName;
        }
    }
}
