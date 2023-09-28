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
            this.outputListBox = new System.Windows.Forms.ListBox();
            this.fileListBox = new System.Windows.Forms.CheckedListBox();
            this.removeFilesBtn = new System.Windows.Forms.Button();
            this.selectAllBtn = new System.Windows.Forms.Button();
            this.clearSelectBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // browseFileBtn
            // 
            this.browseFileBtn.Location = new System.Drawing.Point(781, 71);
            this.browseFileBtn.Name = "browseFileBtn";
            this.browseFileBtn.Size = new System.Drawing.Size(199, 59);
            this.browseFileBtn.TabIndex = 0;
            this.browseFileBtn.Text = "Add File(s)";
            this.browseFileBtn.UseVisualStyleBackColor = true;
            this.browseFileBtn.Click += new System.EventHandler(this.browseFileBtn_Click);
            // 
            // outputListBox
            // 
            this.outputListBox.FormattingEnabled = true;
            this.outputListBox.ItemHeight = 20;
            this.outputListBox.Location = new System.Drawing.Point(207, 689);
            this.outputListBox.MultiColumn = true;
            this.outputListBox.Name = "outputListBox";
            this.outputListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.outputListBox.Size = new System.Drawing.Size(1044, 444);
            this.outputListBox.TabIndex = 4;
            // 
            // fileListBox
            // 
            this.fileListBox.FormattingEnabled = true;
            this.fileListBox.Location = new System.Drawing.Point(207, 71);
            this.fileListBox.MultiColumn = true;
            this.fileListBox.Name = "fileListBox";
            this.fileListBox.Size = new System.Drawing.Size(519, 464);
            this.fileListBox.TabIndex = 5;
            // 
            // removeFilesBtn
            // 
            this.removeFilesBtn.Location = new System.Drawing.Point(781, 170);
            this.removeFilesBtn.Name = "removeFilesBtn";
            this.removeFilesBtn.Size = new System.Drawing.Size(199, 59);
            this.removeFilesBtn.TabIndex = 6;
            this.removeFilesBtn.Text = "Remove Selected";
            this.removeFilesBtn.UseVisualStyleBackColor = true;
            this.removeFilesBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // selectAllBtn
            // 
            this.selectAllBtn.Location = new System.Drawing.Point(781, 378);
            this.selectAllBtn.Name = "selectAllBtn";
            this.selectAllBtn.Size = new System.Drawing.Size(199, 59);
            this.selectAllBtn.TabIndex = 7;
            this.selectAllBtn.Text = "Select All";
            this.selectAllBtn.UseVisualStyleBackColor = true;
            this.selectAllBtn.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // clearSelectBtn
            // 
            this.clearSelectBtn.Location = new System.Drawing.Point(781, 476);
            this.clearSelectBtn.Name = "clearSelectBtn";
            this.clearSelectBtn.Size = new System.Drawing.Size(199, 59);
            this.clearSelectBtn.TabIndex = 8;
            this.clearSelectBtn.Text = "Clear Selection";
            this.clearSelectBtn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1345, 1450);
            this.Controls.Add(this.clearSelectBtn);
            this.Controls.Add(this.selectAllBtn);
            this.Controls.Add(this.removeFilesBtn);
            this.Controls.Add(this.fileListBox);
            this.Controls.Add(this.outputListBox);
            this.Controls.Add(this.browseFileBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button browseFileBtn;
        private System.Windows.Forms.ListBox outputListBox;
        private System.Windows.Forms.CheckedListBox fileListBox;
        private System.Windows.Forms.Button removeFilesBtn;
        private System.Windows.Forms.Button selectAllBtn;
        private System.Windows.Forms.Button clearSelectBtn;
    }
}

