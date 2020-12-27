using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace SQLAuto.UC
{
    public partial class OpenFolder : UserControl
    {
        public string FileName
        {
            get { return this.Path_TextBox.Text; }
            set
            {
                this.Path_TextBox.Text = value;
            }
        }

        public OpenFolder()
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
                        (sender as TextBox).Text = GetDirectoryName(fileName);
                        return;
                    }
                }
                //else if (e.Data.GetDataPresent("FileGroupDescriptor"))
                //{
                //    //
                //    // the first step here is to get the filename
                //    // of the attachment and
                //    // build a full-path name so we can store it
                //    // in the temporary folder
                //    //

                //    // set up to obtain the FileGroupDescriptor
                //    // and extract the file name
                //    Stream theStream = (Stream)e.Data.GetData("FileGroupDescriptor");
                //    byte[] fileGroupDescriptor = new byte[512];
                //    theStream.Read(fileGroupDescriptor, 0, 512);
                //    // used to build the filename from the FileGroupDescriptor block
                //    StringBuilder fileName = new StringBuilder("");
                //    // this trick gets the filename of the passed attached file
                //    for (int i = 76; fileGroupDescriptor[i] != 0; i++)
                //    { fileName.Append(Convert.ToChar(fileGroupDescriptor[i])); }
                //    theStream.Close();
                //    string path = Path.GetTempPath();
                //    // put the zip file into the temp directory
                //    string theFile = path + fileName.ToString();
                //    // create the full-path name

                //    //
                //    // Second step:  we have the file name.
                //    // Now we need to get the actual raw
                //    // data for the attached file and copy it to disk so we work on it.
                //    //

                //    // get the actual raw file into memory
                //    MemoryStream ms = (MemoryStream)e.Data.GetData(
                //        "FileContents", true);
                //    // allocate enough bytes to hold the raw data
                //    byte[] fileBytes = new byte[ms.Length];
                //    // set starting position at first byte and read in the raw data
                //    ms.Position = 0;
                //    ms.Read(fileBytes, 0, (int)ms.Length);
                //    // create a file and save the raw zip file to it
                //    FileStream fs = new FileStream(theFile, FileMode.Create);
                //    fs.Write(fileBytes, 0, (int)fileBytes.Length);

                //    fs.Close();  // close the file

                //    FileInfo tempFile = new FileInfo(theFile);

                //    // always good to make sure we actually created the file
                //    if (tempFile.Exists == true)
                //    {
                //        // for now, just delete what we created
                //        tempFile.Delete();
                //    }
                //    else
                //    {
                //        Trace.WriteLine("File was not created!");
                //    }
                //}
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
            ////    or this tells us if it is an Outlook attachment drop
            //else if (e.Data.GetDataPresent("FileGroupDescriptor"))
            //{
            //    e.Effect = DragDropEffects.Move;
            //}
            //    or none of the above
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private string GetDirectoryName(string path)
        {
            if (File.GetAttributes(path).HasFlag(FileAttributes.Directory))
            {
                return path;
            }
            else
            {
                return Path.GetDirectoryName(path);
            }
        }

        private void Select_Button_Click(object sender, EventArgs e)
        {
            Path_TextBox.Text = OpenFolderDialog(Path_TextBox.Text);
        }

        private string OpenFolderDialog(string selectedPath = "")
        {
            string folderPath = selectedPath;
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if (!string.IsNullOrWhiteSpace(selectedPath))
            {
                folderBrowserDialog.SelectedPath = selectedPath.Trim();
            }

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                folderPath = folderBrowserDialog.SelectedPath;
            }

            return folderPath;
        }
    }
}
