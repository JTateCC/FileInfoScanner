using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography; // learning abut this new module.
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvHelper;
using CsvHelper.Configuration;

namespace FileInfoScanner
{
    public partial class Form1 : Form
    {


        private List<FileWithID> fileList = new List<FileWithID>();// useful to keep this list rather than working with the listbox.
        public Form1()
        {
            InitializeComponent();
            fileCountLabel.Text = $"Total Files: 0";
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
                            ListViewItem item = new ListViewItem(newFile.ID);
                            item.SubItems.Add(newFile.formatFileNameString());
                            item.SubItems.Add(newFile.fileExt);
                            item.SubItems.Add(newFile.fileSize.ToString());
                            item.SubItems.Add(newFile.creationDate.ToString());
                            item.SubItems.Add(newFile.modifiedDate.ToString());
                            item.Tag = newFile;
                            outputListView.Items.Add(item);
                        }
                        else
                        {
                            DialogResult err;
                            err = MessageBox.Show("Some Duplicate Files Not Added");
                        }
                    }
                }
            }
            updateFileCountLabel();

        }



        

        // remove any selected files from the listbox and list
        private void removeFilesBtn_Click(object sender, EventArgs e)
        {


            List<ListViewItem> itemsToRemove = new List<ListViewItem>();

            // Iterate through the ListView items
            foreach (ListViewItem item in outputListView.Items)
            {
                // Check if the item's checkbox is checked
                if (item.Checked)
                {
                    // Add the checked item to the list
                    itemsToRemove.Add(item);
                    if (item.Tag is FileWithID fileToRemove)
                    {
                        fileList.Remove(fileToRemove); 
                    }
                }
            }

            // Remove the checked items from the ListView
            foreach (ListViewItem itemToRemove in itemsToRemove)
            {
                outputListView.Items.Remove(itemToRemove);



            }
            updateFileCountLabel();
        }

    
        // simple loop to select all
        private void selectAllBtn_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in outputListView.Items)
            {
                item.Checked = true; // Set the checkbox of each item to checked
            }
        }

        private void clearSelectBtn_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in outputListView.Items)
            {
                item.Checked = false; // Set the checkbox of each item to checked
            }

        }


        // function to wrtie to cvsv. rewritten usng the classmap to improve headers.
        private void ExportToCsv(string saveFilePath, List<FileWithID> fileList)
        {
            try { 
            using (var writer = new StreamWriter(saveFilePath))
            using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csv.Context.RegisterClassMap<FileWithIDMap>();
                csv.WriteRecords(fileList);
            }
                MessageBox.Show($"CSV file exported successfully to {saveFilePath}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Display an error message
                MessageBox.Show($"Error exporting CSV file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        // initiate function on btn click
        private void exportCsvBtn_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV Files|*.csv";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var selectedFiles = fileList.ToList();
                    ExportToCsv(saveFileDialog.FileName, selectedFiles);
                }
            }
        }


        private void updateFileCountLabel()
        {
            int numFiles = fileList.Count;
            fileCountLabel.Text = $"Total Files: {numFiles}";
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

        public string fileExt { get; set; }
        public long fileSize { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime modifiedDate { get; set; }

        public int inputIndex { get; set; }
        public int outputIndex { get; set; }

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
            return $"{filePath}";
        }


        // if filename too long then truncates it
       public string formatFileNameString()
        {
            string fnameString = fileName;
            if (fileName.Length > 50)
            {
                fnameString = fileName.Substring(0, 50) + "...";
            }

        
          return fnameString;
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

            fileExt = fileInfo.Extension;

            // Capture file size
            fileSize = fileInfo.Length;

            // Capture creation date
            creationDate = fileInfo.CreationTime;

            // Capture modified date
            modifiedDate = fileInfo.LastWriteTime;

            // TODO Capture author (if available)
        }





    }

    // this class allows the file with id to mpa proper column names when outputtng to csv
    public sealed class FileWithIDMap : ClassMap<FileWithID>
    {
        public FileWithIDMap()
        {
            Map(m => m.ID).Name("ID"); 
            Map(m => m.fileName).Name("File Name"); 
            Map(m => m.fileSize).Name("File Size (bytes)");
            Map(m => m.fileExt).Name("File Extension");
            Map(m => m.creationDate).Name("Date Created");
            Map(m => m.modifiedDate).Name("Date Modified");
        }
    }
}