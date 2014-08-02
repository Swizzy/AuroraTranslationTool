namespace AuroraTranslationTool
{
    partial class SearchForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.searchtermbox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.searchtransbox = new System.Windows.Forms.CheckBox();
            this.searchorigbox = new System.Windows.Forms.CheckBox();
            this.searchnamebox = new System.Windows.Forms.CheckBox();
            this.endswithbox = new System.Windows.Forms.RadioButton();
            this.equalsbox = new System.Windows.Forms.RadioButton();
            this.containsbox = new System.Windows.Forms.RadioButton();
            this.startswithbox = new System.Windows.Forms.RadioButton();
            this.okbtn = new System.Windows.Forms.Button();
            this.abortbtn = new System.Windows.Forms.Button();
            this.ignorecasebox = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.searchtermbox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(6, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(506, 48);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Searchterm";
            // 
            // searchtermbox
            // 
            this.searchtermbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchtermbox.Location = new System.Drawing.Point(3, 18);
            this.searchtermbox.Name = "searchtermbox";
            this.searchtermbox.Size = new System.Drawing.Size(500, 22);
            this.searchtermbox.TabIndex = 0;
            this.searchtermbox.TextChanged += new System.EventHandler(this.searchtermbox_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ignorecasebox);
            this.groupBox2.Controls.Add(this.searchtransbox);
            this.groupBox2.Controls.Add(this.searchorigbox);
            this.groupBox2.Controls.Add(this.searchnamebox);
            this.groupBox2.Controls.Add(this.endswithbox);
            this.groupBox2.Controls.Add(this.equalsbox);
            this.groupBox2.Controls.Add(this.containsbox);
            this.groupBox2.Controls.Add(this.startswithbox);
            this.groupBox2.Location = new System.Drawing.Point(6, 54);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(506, 75);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search Options";
            // 
            // searchtransbox
            // 
            this.searchtransbox.AutoSize = true;
            this.searchtransbox.Checked = true;
            this.searchtransbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.searchtransbox.Location = new System.Drawing.Point(196, 48);
            this.searchtransbox.Name = "searchtransbox";
            this.searchtransbox.Size = new System.Drawing.Size(165, 21);
            this.searchtransbox.TabIndex = 1;
            this.searchtransbox.Text = "Search in Translation";
            this.searchtransbox.UseVisualStyleBackColor = true;
            // 
            // searchorigbox
            // 
            this.searchorigbox.AutoSize = true;
            this.searchorigbox.Checked = true;
            this.searchorigbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.searchorigbox.Location = new System.Drawing.Point(196, 21);
            this.searchorigbox.Name = "searchorigbox";
            this.searchorigbox.Size = new System.Drawing.Size(143, 21);
            this.searchorigbox.TabIndex = 1;
            this.searchorigbox.Text = "Search in Original";
            this.searchorigbox.UseVisualStyleBackColor = true;
            // 
            // searchnamebox
            // 
            this.searchnamebox.AutoSize = true;
            this.searchnamebox.Checked = true;
            this.searchnamebox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.searchnamebox.Location = new System.Drawing.Point(367, 48);
            this.searchnamebox.Name = "searchnamebox";
            this.searchnamebox.Size = new System.Drawing.Size(131, 21);
            this.searchnamebox.TabIndex = 1;
            this.searchnamebox.Text = "Search in Name";
            this.searchnamebox.UseVisualStyleBackColor = true;
            // 
            // endswithbox
            // 
            this.endswithbox.AutoSize = true;
            this.endswithbox.Location = new System.Drawing.Point(6, 48);
            this.endswithbox.Name = "endswithbox";
            this.endswithbox.Size = new System.Drawing.Size(89, 21);
            this.endswithbox.TabIndex = 0;
            this.endswithbox.Text = "Ends with";
            this.endswithbox.UseVisualStyleBackColor = true;
            // 
            // equalsbox
            // 
            this.equalsbox.AutoSize = true;
            this.equalsbox.Location = new System.Drawing.Point(106, 48);
            this.equalsbox.Name = "equalsbox";
            this.equalsbox.Size = new System.Drawing.Size(72, 21);
            this.equalsbox.TabIndex = 0;
            this.equalsbox.Text = "Equals";
            this.equalsbox.UseVisualStyleBackColor = true;
            // 
            // containsbox
            // 
            this.containsbox.AutoSize = true;
            this.containsbox.Checked = true;
            this.containsbox.Location = new System.Drawing.Point(106, 21);
            this.containsbox.Name = "containsbox";
            this.containsbox.Size = new System.Drawing.Size(84, 21);
            this.containsbox.TabIndex = 0;
            this.containsbox.TabStop = true;
            this.containsbox.Text = "Contains";
            this.containsbox.UseVisualStyleBackColor = true;
            // 
            // startswithbox
            // 
            this.startswithbox.AutoSize = true;
            this.startswithbox.Location = new System.Drawing.Point(6, 21);
            this.startswithbox.Name = "startswithbox";
            this.startswithbox.Size = new System.Drawing.Size(94, 21);
            this.startswithbox.TabIndex = 0;
            this.startswithbox.Text = "Starts with";
            this.startswithbox.UseVisualStyleBackColor = true;
            // 
            // okbtn
            // 
            this.okbtn.Enabled = false;
            this.okbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okbtn.Location = new System.Drawing.Point(323, 135);
            this.okbtn.Name = "okbtn";
            this.okbtn.Size = new System.Drawing.Size(189, 41);
            this.okbtn.TabIndex = 2;
            this.okbtn.Text = "OK";
            this.okbtn.UseVisualStyleBackColor = true;
            this.okbtn.Click += new System.EventHandler(this.OkbtnClick);
            // 
            // abortbtn
            // 
            this.abortbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.abortbtn.Location = new System.Drawing.Point(6, 135);
            this.abortbtn.Name = "abortbtn";
            this.abortbtn.Size = new System.Drawing.Size(189, 41);
            this.abortbtn.TabIndex = 2;
            this.abortbtn.Text = "Cancel";
            this.abortbtn.UseVisualStyleBackColor = true;
            this.abortbtn.Click += new System.EventHandler(this.abortbtn_Click);
            // 
            // ignorecasebox
            // 
            this.ignorecasebox.AutoSize = true;
            this.ignorecasebox.Checked = true;
            this.ignorecasebox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ignorecasebox.Location = new System.Drawing.Point(367, 22);
            this.ignorecasebox.Name = "ignorecasebox";
            this.ignorecasebox.Size = new System.Drawing.Size(104, 21);
            this.ignorecasebox.TabIndex = 2;
            this.ignorecasebox.Text = "Ignore case";
            this.ignorecasebox.UseVisualStyleBackColor = true;
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 179);
            this.Controls.Add(this.abortbtn);
            this.Controls.Add(this.okbtn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SearchForm";
            this.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Text = "SearchForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox searchtermbox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton startswithbox;
        private System.Windows.Forms.RadioButton endswithbox;
        private System.Windows.Forms.RadioButton equalsbox;
        private System.Windows.Forms.RadioButton containsbox;
        private System.Windows.Forms.CheckBox searchnamebox;
        private System.Windows.Forms.CheckBox searchorigbox;
        private System.Windows.Forms.CheckBox searchtransbox;
        private System.Windows.Forms.Button okbtn;
        private System.Windows.Forms.Button abortbtn;
        private System.Windows.Forms.CheckBox ignorecasebox;
    }
}