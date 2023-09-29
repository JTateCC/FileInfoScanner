namespace FileInfoScanner
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.browseFileBtn = new System.Windows.Forms.Button();
            this.fileListBox = new System.Windows.Forms.CheckedListBox();
            this.removeFilesBtn = new System.Windows.Forms.Button();
            this.selectAllBtn = new System.Windows.Forms.Button();
            this.clearSelectBtn = new System.Windows.Forms.Button();
            this.outputListView = new System.Windows.Forms.ListView();
            this.idHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fileNameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fileSizeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.createdDateHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.modifiedDateHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fileExtHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // browseFileBtn
            // 
            this.browseFileBtn.Location = new System.Drawing.Point(982, 82);
            this.browseFileBtn.Name = "browseFileBtn";
            this.browseFileBtn.Size = new System.Drawing.Size(199, 59);
            this.browseFileBtn.TabIndex = 0;
            this.browseFileBtn.Text = "Add File(s)";
            this.browseFileBtn.UseVisualStyleBackColor = true;
            this.browseFileBtn.Click += new System.EventHandler(this.browseFileBtn_Click);
            // 
            // fileListBox
            // 
            this.fileListBox.FormattingEnabled = true;
            this.fileListBox.Location = new System.Drawing.Point(42, 82);
            this.fileListBox.MultiColumn = true;
            this.fileListBox.Name = "fileListBox";
            this.fileListBox.Size = new System.Drawing.Size(839, 464);
            this.fileListBox.TabIndex = 5;
            this.fileListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.fileListBox_ItemCheck);
            // 
            // removeFilesBtn
            // 
            this.removeFilesBtn.Location = new System.Drawing.Point(982, 193);
            this.removeFilesBtn.Name = "removeFilesBtn";
            this.removeFilesBtn.Size = new System.Drawing.Size(199, 59);
            this.removeFilesBtn.TabIndex = 6;
            this.removeFilesBtn.Text = "Remove Selected";
            this.removeFilesBtn.UseVisualStyleBackColor = true;
            this.removeFilesBtn.Click += new System.EventHandler(this.removeFilesBtn_Click);
            // 
            // selectAllBtn
            // 
            this.selectAllBtn.Location = new System.Drawing.Point(982, 391);
            this.selectAllBtn.Name = "selectAllBtn";
            this.selectAllBtn.Size = new System.Drawing.Size(199, 59);
            this.selectAllBtn.TabIndex = 7;
            this.selectAllBtn.Text = "Select All";
            this.selectAllBtn.UseVisualStyleBackColor = true;
            this.selectAllBtn.Click += new System.EventHandler(this.selectAllBtn_Click);
            // 
            // clearSelectBtn
            // 
            this.clearSelectBtn.Location = new System.Drawing.Point(992, 487);
            this.clearSelectBtn.Name = "clearSelectBtn";
            this.clearSelectBtn.Size = new System.Drawing.Size(199, 59);
            this.clearSelectBtn.TabIndex = 8;
            this.clearSelectBtn.Text = "Clear Selection";
            this.clearSelectBtn.UseVisualStyleBackColor = true;
            this.clearSelectBtn.Click += new System.EventHandler(this.clearSelectBtn_Click);
            // 
            // outputListView
            // 
            this.outputListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.idHeader,
            this.fileNameHeader,
            this.fileExtHeader,
            this.fileSizeHeader,
            this.createdDateHeader,
            this.modifiedDateHeader});
            this.outputListView.HideSelection = false;
            this.outputListView.Location = new System.Drawing.Point(42, 726);
            this.outputListView.MaximumSize = new System.Drawing.Size(1500, 600);
            this.outputListView.MinimumSize = new System.Drawing.Size(1150, 450);
            this.outputListView.Name = "outputListView";
            this.outputListView.Size = new System.Drawing.Size(1500, 450);
            this.outputListView.TabIndex = 9;
            this.outputListView.UseCompatibleStateImageBehavior = false;
            this.outputListView.View = System.Windows.Forms.View.Details;
            // 
            // idHeader
            // 
            this.idHeader.Text = "ID";
            this.idHeader.Width = 75;
            // 
            // fileNameHeader
            // 
            this.fileNameHeader.Text = "File Name";
            this.fileNameHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fileNameHeader.Width = 300;
            // 
            // fileSizeHeader
            // 
            this.fileSizeHeader.Text = "Size (bytes)";
            this.fileSizeHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fileSizeHeader.Width = 150;
            // 
            // createdDateHeader
            // 
            this.createdDateHeader.Text = "Date Created";
            this.createdDateHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.createdDateHeader.Width = 150;
            // 
            // modifiedDateHeader
            // 
            this.modifiedDateHeader.Text = "Last Modified";
            this.modifiedDateHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.modifiedDateHeader.Width = 150;
            // 
            // fileExtHeader
            // 
            this.fileExtHeader.Text = "Extension";
            this.fileExtHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fileExtHeader.Width = 150;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1850, 1450);
            this.Controls.Add(this.outputListView);
            this.Controls.Add(this.clearSelectBtn);
            this.Controls.Add(this.selectAllBtn);
            this.Controls.Add(this.removeFilesBtn);
            this.Controls.Add(this.fileListBox);
            this.Controls.Add(this.browseFileBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button browseFileBtn;
        private System.Windows.Forms.CheckedListBox fileListBox;
        private System.Windows.Forms.Button removeFilesBtn;
        private System.Windows.Forms.Button selectAllBtn;
        private System.Windows.Forms.Button clearSelectBtn;
        private System.Windows.Forms.ListView outputListView;
        private System.Windows.Forms.ColumnHeader idHeader;
        private System.Windows.Forms.ColumnHeader fileNameHeader;
        private System.Windows.Forms.ColumnHeader fileSizeHeader;
        private System.Windows.Forms.ColumnHeader createdDateHeader;
        private System.Windows.Forms.ColumnHeader modifiedDateHeader;
        private System.Windows.Forms.ColumnHeader fileExtHeader;
    }
}

