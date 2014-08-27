namespace AuroraTranslationTool
{
    sealed partial class Main
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
            this.components = new System.ComponentModel.Container();
            this.loadorigbtn = new System.Windows.Forms.Button();
            this.loadtransbtn = new System.Windows.Forms.Button();
            this.compilebtn = new System.Windows.Forms.Button();
            this.savetransbtn = new System.Windows.Forms.Button();
            this.origgbox = new System.Windows.Forms.GroupBox();
            this.origbox = new System.Windows.Forms.TextBox();
            this.hidenumbox = new System.Windows.Forms.CheckBox();
            this.listview = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.savecurlinebtn = new System.Windows.Forms.Button();
            this.copybtn = new System.Windows.Forms.Button();
            this.hideemptybox = new System.Windows.Forms.CheckBox();
            this.clearbtn = new System.Windows.Forms.Button();
            this.transbox = new System.Windows.Forms.TextBox();
            this.transgbox = new System.Windows.Forms.GroupBox();
            this.hidefinishedbox = new System.Windows.Forms.CheckBox();
            this.listviewContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.setFinishedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setSimilarFinishedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statslabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbllabel1 = new System.Windows.Forms.Label();
            this.sections = new System.Windows.Forms.ComboBox();
            this.keepsavepathbox = new System.Windows.Forms.CheckBox();
            this.copyNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.origgbox.SuspendLayout();
            this.transgbox.SuspendLayout();
            this.listviewContext.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // loadorigbtn
            // 
            this.loadorigbtn.Location = new System.Drawing.Point(16, 15);
            this.loadorigbtn.Margin = new System.Windows.Forms.Padding(4);
            this.loadorigbtn.Name = "loadorigbtn";
            this.loadorigbtn.Size = new System.Drawing.Size(144, 28);
            this.loadorigbtn.TabIndex = 0;
            this.loadorigbtn.Text = "Load Original";
            this.loadorigbtn.UseVisualStyleBackColor = true;
            this.loadorigbtn.Click += new System.EventHandler(this.loadorigbtn_Click);
            // 
            // loadtransbtn
            // 
            this.loadtransbtn.Location = new System.Drawing.Point(169, 15);
            this.loadtransbtn.Margin = new System.Windows.Forms.Padding(4);
            this.loadtransbtn.Name = "loadtransbtn";
            this.loadtransbtn.Size = new System.Drawing.Size(144, 28);
            this.loadtransbtn.TabIndex = 1;
            this.loadtransbtn.Text = "Load Translation";
            this.loadtransbtn.UseVisualStyleBackColor = true;
            this.loadtransbtn.Click += new System.EventHandler(this.loadtransbtn_Click);
            // 
            // compilebtn
            // 
            this.compilebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.compilebtn.Location = new System.Drawing.Point(473, 15);
            this.compilebtn.Margin = new System.Windows.Forms.Padding(4);
            this.compilebtn.Name = "compilebtn";
            this.compilebtn.Size = new System.Drawing.Size(183, 28);
            this.compilebtn.TabIndex = 2;
            this.compilebtn.Text = "Compile Translation";
            this.compilebtn.UseVisualStyleBackColor = true;
            this.compilebtn.Click += new System.EventHandler(this.compilebtn_Click);
            // 
            // savetransbtn
            // 
            this.savetransbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.savetransbtn.Enabled = false;
            this.savetransbtn.Location = new System.Drawing.Point(664, 15);
            this.savetransbtn.Margin = new System.Windows.Forms.Padding(4);
            this.savetransbtn.Name = "savetransbtn";
            this.savetransbtn.Size = new System.Drawing.Size(171, 28);
            this.savetransbtn.TabIndex = 2;
            this.savetransbtn.Text = "Save Translation";
            this.savetransbtn.UseVisualStyleBackColor = true;
            this.savetransbtn.Click += new System.EventHandler(this.savetransbtn_Click);
            // 
            // origgbox
            // 
            this.origgbox.Controls.Add(this.origbox);
            this.origgbox.Location = new System.Drawing.Point(16, 50);
            this.origgbox.Margin = new System.Windows.Forms.Padding(4);
            this.origgbox.Name = "origgbox";
            this.origgbox.Padding = new System.Windows.Forms.Padding(4);
            this.origgbox.Size = new System.Drawing.Size(405, 123);
            this.origgbox.TabIndex = 3;
            this.origgbox.TabStop = false;
            this.origgbox.Text = "Original";
            // 
            // origbox
            // 
            this.origbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.origbox.Location = new System.Drawing.Point(4, 19);
            this.origbox.Margin = new System.Windows.Forms.Padding(4);
            this.origbox.Multiline = true;
            this.origbox.Name = "origbox";
            this.origbox.ReadOnly = true;
            this.origbox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.origbox.Size = new System.Drawing.Size(397, 100);
            this.origbox.TabIndex = 0;
            // 
            // hidenumbox
            // 
            this.hidenumbox.AutoSize = true;
            this.hidenumbox.Checked = true;
            this.hidenumbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hidenumbox.Location = new System.Drawing.Point(16, 181);
            this.hidenumbox.Margin = new System.Windows.Forms.Padding(4);
            this.hidenumbox.Name = "hidenumbox";
            this.hidenumbox.Size = new System.Drawing.Size(171, 21);
            this.hidenumbox.TabIndex = 4;
            this.hidenumbox.Text = "Hide Numerical values";
            this.hidenumbox.UseVisualStyleBackColor = true;
            this.hidenumbox.CheckedChanged += new System.EventHandler(this.FilterChanged);
            // 
            // listview
            // 
            this.listview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listview.FullRowSelect = true;
            this.listview.GridLines = true;
            this.listview.Location = new System.Drawing.Point(16, 242);
            this.listview.Margin = new System.Windows.Forms.Padding(4);
            this.listview.Name = "listview";
            this.listview.Size = new System.Drawing.Size(817, 218);
            this.listview.TabIndex = 5;
            this.listview.UseCompatibleStateImageBehavior = false;
            this.listview.View = System.Windows.Forms.View.Details;
            this.listview.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listview_ColumnClick);
            this.listview.DoubleClick += new System.EventHandler(this.listview_DoubleClick);
            this.listview.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listview_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Original";
            this.columnHeader2.Width = 184;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Translation";
            this.columnHeader3.Width = 188;
            // 
            // savecurlinebtn
            // 
            this.savecurlinebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.savecurlinebtn.Enabled = false;
            this.savecurlinebtn.Location = new System.Drawing.Point(664, 181);
            this.savecurlinebtn.Margin = new System.Windows.Forms.Padding(4);
            this.savecurlinebtn.Name = "savecurlinebtn";
            this.savecurlinebtn.Size = new System.Drawing.Size(171, 28);
            this.savecurlinebtn.TabIndex = 6;
            this.savecurlinebtn.Text = "Save Current Line";
            this.savecurlinebtn.UseVisualStyleBackColor = true;
            this.savecurlinebtn.Click += new System.EventHandler(this.savecurlinebtn_Click);
            // 
            // copybtn
            // 
            this.copybtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.copybtn.Enabled = false;
            this.copybtn.Location = new System.Drawing.Point(445, 181);
            this.copybtn.Margin = new System.Windows.Forms.Padding(4);
            this.copybtn.Name = "copybtn";
            this.copybtn.Size = new System.Drawing.Size(211, 28);
            this.copybtn.TabIndex = 6;
            this.copybtn.Text = "Copy Original to Translation";
            this.copybtn.UseVisualStyleBackColor = true;
            this.copybtn.Click += new System.EventHandler(this.copybtn_Click);
            // 
            // hideemptybox
            // 
            this.hideemptybox.AutoSize = true;
            this.hideemptybox.Checked = true;
            this.hideemptybox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hideemptybox.Location = new System.Drawing.Point(200, 181);
            this.hideemptybox.Margin = new System.Windows.Forms.Padding(4);
            this.hideemptybox.Name = "hideemptybox";
            this.hideemptybox.Size = new System.Drawing.Size(102, 21);
            this.hideemptybox.TabIndex = 4;
            this.hideemptybox.Text = "Hide Empty";
            this.hideemptybox.UseVisualStyleBackColor = true;
            this.hideemptybox.CheckedChanged += new System.EventHandler(this.FilterChanged);
            // 
            // clearbtn
            // 
            this.clearbtn.Enabled = false;
            this.clearbtn.Location = new System.Drawing.Point(321, 15);
            this.clearbtn.Margin = new System.Windows.Forms.Padding(4);
            this.clearbtn.Name = "clearbtn";
            this.clearbtn.Size = new System.Drawing.Size(100, 28);
            this.clearbtn.TabIndex = 1;
            this.clearbtn.Text = "Clear All";
            this.clearbtn.UseVisualStyleBackColor = true;
            this.clearbtn.Click += new System.EventHandler(this.clearbtn_Click);
            // 
            // transbox
            // 
            this.transbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transbox.Location = new System.Drawing.Point(4, 19);
            this.transbox.Margin = new System.Windows.Forms.Padding(4);
            this.transbox.Multiline = true;
            this.transbox.Name = "transbox";
            this.transbox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.transbox.Size = new System.Drawing.Size(397, 100);
            this.transbox.TabIndex = 0;
            this.transbox.TextChanged += new System.EventHandler(this.transbox_TextChanged);
            // 
            // transgbox
            // 
            this.transgbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.transgbox.Controls.Add(this.transbox);
            this.transgbox.Location = new System.Drawing.Point(429, 50);
            this.transgbox.Margin = new System.Windows.Forms.Padding(4);
            this.transgbox.Name = "transgbox";
            this.transgbox.Padding = new System.Windows.Forms.Padding(4);
            this.transgbox.Size = new System.Drawing.Size(405, 123);
            this.transgbox.TabIndex = 3;
            this.transgbox.TabStop = false;
            this.transgbox.Text = "Translation";
            // 
            // hidefinishedbox
            // 
            this.hidefinishedbox.AutoSize = true;
            this.hidefinishedbox.Checked = true;
            this.hidefinishedbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hidefinishedbox.Location = new System.Drawing.Point(315, 181);
            this.hidefinishedbox.Margin = new System.Windows.Forms.Padding(4);
            this.hidefinishedbox.Name = "hidefinishedbox";
            this.hidefinishedbox.Size = new System.Drawing.Size(116, 21);
            this.hidefinishedbox.TabIndex = 4;
            this.hidefinishedbox.Text = "Hide Finished";
            this.hidefinishedbox.UseVisualStyleBackColor = true;
            this.hidefinishedbox.CheckedChanged += new System.EventHandler(this.FilterChanged);
            // 
            // listviewContext
            // 
            this.listviewContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setFinishedToolStripMenuItem,
            this.setSimilarFinishedToolStripMenuItem,
            this.resetToolStripMenuItem,
            this.copyNameToolStripMenuItem});
            this.listviewContext.Name = "listviewContext";
            this.listviewContext.Size = new System.Drawing.Size(208, 128);
            // 
            // setFinishedToolStripMenuItem
            // 
            this.setFinishedToolStripMenuItem.Name = "setFinishedToolStripMenuItem";
            this.setFinishedToolStripMenuItem.Size = new System.Drawing.Size(207, 24);
            this.setFinishedToolStripMenuItem.Text = "Set Finished";
            this.setFinishedToolStripMenuItem.Click += new System.EventHandler(this.setFinishedToolStripMenuItem_Click);
            // 
            // setSimilarFinishedToolStripMenuItem
            // 
            this.setSimilarFinishedToolStripMenuItem.Name = "setSimilarFinishedToolStripMenuItem";
            this.setSimilarFinishedToolStripMenuItem.Size = new System.Drawing.Size(207, 24);
            this.setSimilarFinishedToolStripMenuItem.Text = "Set Similar Finished";
            this.setSimilarFinishedToolStripMenuItem.Click += new System.EventHandler(this.setSimilarFinishedToolStripMenuItem_Click);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(207, 24);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.statslabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 467);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(851, 25);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(44, 20);
            this.toolStripStatusLabel1.Text = "Stats:";
            // 
            // statslabel
            // 
            this.statslabel.Name = "statslabel";
            this.statslabel.Size = new System.Drawing.Size(39, 20);
            this.statslabel.Text = "stats";
            // 
            // lbllabel1
            // 
            this.lbllabel1.AutoSize = true;
            this.lbllabel1.Location = new System.Drawing.Point(12, 213);
            this.lbllabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbllabel1.Name = "lbllabel1";
            this.lbllabel1.Size = new System.Drawing.Size(94, 17);
            this.lbllabel1.TabIndex = 8;
            this.lbllabel1.Text = "Section Filter:";
            // 
            // sections
            // 
            this.sections.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sections.FormattingEnabled = true;
            this.sections.Location = new System.Drawing.Point(115, 209);
            this.sections.Margin = new System.Windows.Forms.Padding(4);
            this.sections.Name = "sections";
            this.sections.Size = new System.Drawing.Size(319, 24);
            this.sections.TabIndex = 9;
            this.sections.SelectedIndexChanged += new System.EventHandler(this.sections_SelectedIndexChanged);
            // 
            // keepsavepathbox
            // 
            this.keepsavepathbox.AutoSize = true;
            this.keepsavepathbox.Location = new System.Drawing.Point(445, 214);
            this.keepsavepathbox.Margin = new System.Windows.Forms.Padding(4);
            this.keepsavepathbox.Name = "keepsavepathbox";
            this.keepsavepathbox.Size = new System.Drawing.Size(279, 21);
            this.keepsavepathbox.TabIndex = 10;
            this.keepsavepathbox.Text = "Keep filename for last saved translation";
            this.keepsavepathbox.UseVisualStyleBackColor = true;
            this.keepsavepathbox.CheckedChanged += new System.EventHandler(this.keepsavepathbox_CheckedChanged);
            // 
            // copyNameToolStripMenuItem
            // 
            this.copyNameToolStripMenuItem.Name = "copyNameToolStripMenuItem";
            this.copyNameToolStripMenuItem.Size = new System.Drawing.Size(207, 24);
            this.copyNameToolStripMenuItem.Text = "Copy Name";
            this.copyNameToolStripMenuItem.Click += new System.EventHandler(this.copyNameToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 492);
            this.Controls.Add(this.keepsavepathbox);
            this.Controls.Add(this.sections);
            this.Controls.Add(this.lbllabel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.copybtn);
            this.Controls.Add(this.savecurlinebtn);
            this.Controls.Add(this.listview);
            this.Controls.Add(this.hidefinishedbox);
            this.Controls.Add(this.hideemptybox);
            this.Controls.Add(this.hidenumbox);
            this.Controls.Add(this.transgbox);
            this.Controls.Add(this.origgbox);
            this.Controls.Add(this.savetransbtn);
            this.Controls.Add(this.compilebtn);
            this.Controls.Add(this.clearbtn);
            this.Controls.Add(this.loadtransbtn);
            this.Controls.Add(this.loadorigbtn);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(866, 470);
            this.Name = "Main";
            this.Text = "Aurora Translation Tool v{0}.{1} Build: {2}";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.SizeChanged += new System.EventHandler(this.Main_SizeChanged);
            this.origgbox.ResumeLayout(false);
            this.origgbox.PerformLayout();
            this.transgbox.ResumeLayout(false);
            this.transgbox.PerformLayout();
            this.listviewContext.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loadorigbtn;
        private System.Windows.Forms.Button loadtransbtn;
        private System.Windows.Forms.Button compilebtn;
        private System.Windows.Forms.Button savetransbtn;
        private System.Windows.Forms.GroupBox origgbox;
        private System.Windows.Forms.TextBox origbox;
        private System.Windows.Forms.CheckBox hidenumbox;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button savecurlinebtn;
        private System.Windows.Forms.Button copybtn;
        private System.Windows.Forms.CheckBox hideemptybox;
        private System.Windows.Forms.Button clearbtn;
        private System.Windows.Forms.TextBox transbox;
        private System.Windows.Forms.GroupBox transgbox;
        private System.Windows.Forms.CheckBox hidefinishedbox;
        private System.Windows.Forms.ContextMenuStrip listviewContext;
        private System.Windows.Forms.ToolStripMenuItem setFinishedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel statslabel;
        private System.Windows.Forms.Label lbllabel1;
        private System.Windows.Forms.ComboBox sections;
        private System.Windows.Forms.CheckBox keepsavepathbox;
        internal System.Windows.Forms.ListView listview;
        private System.Windows.Forms.ToolStripMenuItem setSimilarFinishedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyNameToolStripMenuItem;
    }
}

