using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography; // learning abut this new module.
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileInfoScanner
{
    public partial class Form1 : Form
    {

        private List<FileWithID> fileList = new List<FileWithID>();// useful to keep this list rather than working with the listbox.
        public Form1()
        {
            InitializeComponent();
        }

        // moved outside of the class as better to check if a duplicate exists before creating the new object.
        private byte[] GenerateDigitalSignature(string filepath) // researched this pattern on generating the signature. from the path
        {

            using (var sha256 = SHA256.Create())
            {
                using (var stream = File.OpenRead(filepath))
                {
                    // Compute the digital signature of the file
                    return sha256.ComputeHash(stream);
                }
            }
        }

        // this method takes in a digita sig and compares it to digital sigs of other fileItems in the list.
        private bool DigitalSignatureExists(byte[] digitalSignature)
        {
            foreach (var item in fileList)
            {
                bool match = true;
                for (int i = 0; i < digitalSignature.Length; i++)
                {
                    if (item.digitalSignature[i] != digitalSignature[i]) // improves performance by breaking if any part of the signature doesnt match.
                    {
                        match = false;
                        break;
                    }
                }
                if (match)
                    return true;
            }
            return false;
        }


        // Opens File Dialog and allows user to pick file, and filter by extension.
        private void browseFileBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog(); // new file dialog object
            openFileDialog.Title = "Select a File";
            openFileDialog.Filter = "All Files (*.*)|*.*";
            openFileDialog.Filter += "|SolidWorks Files|*.SLDPRT;*.SLDASM;*.SLDDRW";// allowing for extension filtering
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


                        byte[] digitalSignature = GenerateDigitalSignature(selectedFile);
                        if (!DigitalSignatureExists(digitalSignature))
                        {

                            FileWithID newFile = new FileWithID(selectedFile, digitalSignature);
                            fileList.Add(newFile);
                            fileListBox.Items.Add(newFile);
                        }
                        else
                        {
                            DialogResult err;
                            err = MessageBox.Show("Some Duplicate Files Not Added");
                        }
                    }
                }
            }


        }



        // when checked the output list populates data
        private void fileListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                FileWithID checkedItem = fileList[e.Index];
                outputListBox.Items.Add(checkedItem.formatOutputString());
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                FileWithID uncheckedItem = fileList[e.Index];
                outputListBox.Items.Remove(uncheckedItem.formatOutputString());
            }
        }

        // remove any selected files from the listbox and list
        private void removeFilesBtn_Click(object sender, EventArgs e)
        {

        }

        private void selectAllBtn_Click(object sender, EventArgs e)
        {

        }

        private void clearSelectBtn_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string header = $"{ "ID",-50} | { "Name",-150} | { "Size (bytes)",-30} | { "Date Created",-30} | { "Last Modified",-30}";
            outputListBox.Items.Insert(0, header);
        }
    }

    // keep an oop approach and havin a custom class for files with id;s
    public class FileWithID
    {
        public string ID { get; set; }
        public string filePath { get; set; }
        public byte[] digitalSignature { get; set; } // digital sig is captured from the path and then stored to avoid duplicates.

        // pertinent file data for capture and display.

        public string fileName { get; set; }
        public long fileSize { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime modifiedDate { get; set; }

        // public string author { get; set; } TODO: set this method up if time available.


        public FileWithID(string filepath, byte[] digitialsignature)
        {
            ID = generateUniqueId();
            filePath = filepath;
            digitalSignature = digitialsignature;
            getFileProperties();
        }

        public override string ToString()
        {
            return $"{filePath} (ID: {ID})";
        }


        // researching best way to display the output in seperate clumns
        public string formatOutputString()
        {
            string fnameString = fileName;
            if (fileName.Length > 50)
            {
                fnameString = fileName.Substring(0, 50) + "...";
            }

        
          return $"{ID,-50} | {fnameString,-150} | {fileSize,-30} | {creationDate,-30} | {modifiedDate,-30}";
        }

        // Generate a unique ID using te Guid module.
        private string generateUniqueId()
        {
            return Guid.NewGuid().ToString();
        }

        private void getFileProperties() // master function to get all properties including author which is more complex
        {
            FileInfo fileInfo = new FileInfo(filePath);

            // Capture file name
            fileName = fileInfo.Name;

            // Capture file size
            fileSize = fileInfo.Length;

            // Capture creation date
            creationDate = fileInfo.CreationTime;

            // Capture modified date
            modifiedDate = fileInfo.LastWriteTime;

            // TODO Capture author (if available)
        }





    }
}