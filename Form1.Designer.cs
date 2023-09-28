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
            this.fileListBox = new System.Windows.Forms.ListBox();
            this.addFileBtn = new System.Windows.Forms.Button();
            this.filePathTb = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // browseFileBtn
            // 
            this.browseFileBtn.Location = new System.Drawing.Point(660, 586);
            this.browseFileBtn.Name = "browseFileBtn";
            this.browseFileBtn.Size = new System.Drawing.Size(59, 59);
            this.browseFileBtn.TabIndex = 0;
            this.browseFileBtn.Text = "...";
            this.browseFileBtn.UseVisualStyleBackColor = true;
            this.browseFileBtn.Click += new System.EventHandler(this.browseFileBtn_Click);
            // 
            // fileListBox
            // 
            this.fileListBox.FormattingEnabled = true;
            this.fileListBox.ItemHeight = 20;
            this.fileListBox.Location = new System.Drawing.Point(207, 116);
            this.fileListBox.Name = "fileListBox";
            this.fileListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.fileListBox.Size = new System.Drawing.Size(512, 444);
            this.fileListBox.TabIndex = 1;
            // 
            // addFileBtn
            // 
            this.addFileBtn.Location = new System.Drawing.Point(564, 586);
            this.addFileBtn.Name = "addFileBtn";
            this.addFileBtn.Size = new System.Drawing.Size(58, 59);
            this.addFileBtn.TabIndex = 2;
            this.addFileBtn.Text = "+";
            this.addFileBtn.UseVisualStyleBackColor = true;
            this.addFileBtn.Click += new System.EventHandler(this.addFileBtn_Click);
            // 
            // filePathTb
            // 
            this.filePathTb.Location = new System.Drawing.Point(207, 586);
            this.filePathTb.MinimumSize = new System.Drawing.Size(0, 2);
            this.filePathTb.Multiline = true;
            this.filePathTb.Name = "filePathTb";
            this.filePathTb.Size = new System.Drawing.Size(323, 59);
            this.filePathTb.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1956, 1450);
            this.Controls.Add(this.filePathTb);
            this.Controls.Add(this.addFileBtn);
            this.Controls.Add(this.fileListBox);
            this.Controls.Add(this.browseFileBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button browseFileBtn;
        private System.Windows.Forms.ListBox fileListBox;
        private System.Windows.Forms.Button addFileBtn;
        private System.Windows.Forms.TextBox filePathTb;
    }
}

