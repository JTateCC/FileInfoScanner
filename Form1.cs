using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileInfoScanner
{
    public partial class Form1 : Form
    {

        private List<FileWithID> fileList = new List<FileWithID>();
        public Form1()
        {
            InitializeComponent();
        }


        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
        // Opens File Dialog and allows user to pick file, and filter by extension.
        private void browseFileBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog(); // new file dialog object
            openFileDialog.Title = "Select a File";
            openFileDialog.Filter = "All Files (*.*)|*.*";  // allowing for extension filtering
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.Multiselect = true; // convenient to allow multiple file selection

            // TODO: Add Ability to Select a directory

            if (openFileDialog.ShowDialog() == DialogResult.OK) // validate that user has selected a file
            {
                if (openFileDialog.FileNames.Length > 0)
                {
                    // Add selected files to the ListBox
                    foreach (string selectedFile in openFileDialog.FileNames)
                    {
                        FileWithID newFile = new FileWithID(selectedFile);
                        fileList.Add(newFile);
                        fileListBox.Items.Add(newFile);
                    }
                }
            }


        }
        // allows user to directly enter the path into the text entry and add to the file lit box.
        private void addFileBtn_Click(object sender, EventArgs e)
        {
            if (File.Exists(filePathTb.Text))
            {
                FileWithID newFile = new FileWithID(filePathTb.Text);
                fileList.Add(newFile);
                fileListBox.Items.Add(newFile);
            }
            else
            {
                DialogResult err;
                err = MessageBox.Show("No File Entered or Specified File Does Not Exist");
            }
        }
    }
}

// keep an oop approach and havin a custom class for files with id;s
public class FileWithID
{
    public string ID { get; set; }
    public string filePath { get; set; }


    public FileWithID(string filepath)
    {
        ID = GenerateUniqueId();
        filePath = filepath;
    }

    public override string ToString()
    {
        return $"{filePath} (ID: {ID})";
    }

    // Generate a unique ID using te Guid module.
    private string GenerateUniqueId()
    {   
        return Guid.NewGuid().ToString();
    }
}