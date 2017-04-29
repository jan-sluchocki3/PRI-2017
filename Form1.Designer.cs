namespace PRI_KATALOGOWANIE_PLIKÓW
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Plik", System.Windows.Forms.HorizontalAlignment.Left);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkExcludeMetadata = new System.Windows.Forms.CheckBox();
            this.chkMetadata = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.chkUseEquality = new System.Windows.Forms.CheckBox();
            this.chkUseCreteRule = new System.Windows.Forms.CheckBox();
            this.lbExampleCommand = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.bnCatalogue = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.listView1 = new System.Windows.Forms.ListView();
            this.File = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Label = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Metadate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DownloadedFrom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LastModified = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ArithmMean = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Median = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Mode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Q1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Q2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Q3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.QDeviation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.State = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Durance = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(599, 488);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Kryteria katalogowania";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.chkExcludeMetadata);
            this.groupBox2.Controls.Add(this.chkMetadata);
            this.groupBox2.Location = new System.Drawing.Point(7, 219);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(579, 266);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Metadane";
            // 
            // chkExcludeMetadata
            // 
            this.chkExcludeMetadata.AutoSize = true;
            this.chkExcludeMetadata.Location = new System.Drawing.Point(8, 31);
            this.chkExcludeMetadata.Margin = new System.Windows.Forms.Padding(4);
            this.chkExcludeMetadata.Name = "chkExcludeMetadata";
            this.chkExcludeMetadata.Size = new System.Drawing.Size(349, 29);
            this.chkExcludeMetadata.TabIndex = 3;
            this.chkExcludeMetadata.Text = "Wy&klucz niektóre metadane z plików";
            this.chkExcludeMetadata.UseVisualStyleBackColor = true;
            this.chkExcludeMetadata.CheckedChanged += new System.EventHandler(this.chkExcludeMetadata_CheckedChanged);
            // 
            // chkMetadata
            // 
            this.chkMetadata.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkMetadata.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkMetadata.Enabled = false;
            this.chkMetadata.FormattingEnabled = true;
            this.chkMetadata.Location = new System.Drawing.Point(8, 59);
            this.chkMetadata.Margin = new System.Windows.Forms.Padding(4);
            this.chkMetadata.Name = "chkMetadata";
            this.chkMetadata.Size = new System.Drawing.Size(563, 200);
            this.chkMetadata.TabIndex = 2;
            this.chkMetadata.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkMetadata_ItemCheck);
            this.chkMetadata.SelectedIndexChanged += new System.EventHandler(this.chkMetadata_SelectedIndexChanged);
            this.chkMetadata.DoubleClick += new System.EventHandler(this.chkMetadata_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.chkUseEquality);
            this.groupBox1.Controls.Add(this.chkUseCreteRule);
            this.groupBox1.Controls.Add(this.lbExampleCommand);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtCommand);
            this.groupBox1.Location = new System.Drawing.Point(3, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(584, 210);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Użyj polecenia";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(399, 182);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 28);
            this.button3.TabIndex = 5;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(399, 133);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // chkUseEquality
            // 
            this.chkUseEquality.AutoSize = true;
            this.chkUseEquality.Enabled = false;
            this.chkUseEquality.Location = new System.Drawing.Point(28, 170);
            this.chkUseEquality.Margin = new System.Windows.Forms.Padding(4);
            this.chkUseEquality.Name = "chkUseEquality";
            this.chkUseEquality.Size = new System.Drawing.Size(243, 29);
            this.chkUseEquality.TabIndex = 5;
            this.chkUseEquality.Text = "Użyj znaku &równości (=)";
            this.chkUseEquality.UseVisualStyleBackColor = true;
            this.chkUseEquality.CheckedChanged += new System.EventHandler(this.chkUseEquality_CheckedChanged);
            // 
            // chkUseCreteRule
            // 
            this.chkUseCreteRule.AutoSize = true;
            this.chkUseCreteRule.Location = new System.Drawing.Point(28, 133);
            this.chkUseCreteRule.Margin = new System.Windows.Forms.Padding(4);
            this.chkUseCreteRule.Name = "chkUseCreteRule";
            this.chkUseCreteRule.Size = new System.Drawing.Size(260, 29);
            this.chkUseCreteRule.TabIndex = 3;
            this.chkUseCreteRule.Text = "&Użyj reguły typu \"create...\"";
            this.chkUseCreteRule.UseVisualStyleBackColor = true;
            this.chkUseCreteRule.CheckedChanged += new System.EventHandler(this.chkUseCreteRule_CheckedChanged);
            // 
            // lbExampleCommand
            // 
            this.lbExampleCommand.AutoSize = true;
            this.lbExampleCommand.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbExampleCommand.Location = new System.Drawing.Point(23, 89);
            this.lbExampleCommand.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbExampleCommand.Name = "lbExampleCommand";
            this.lbExampleCommand.Size = new System.Drawing.Size(53, 25);
            this.lbExampleCommand.TabIndex = 4;
            this.lbExampleCommand.Text = "Np.: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Polecenie:";
            // 
            // txtCommand
            // 
            this.txtCommand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCommand.Location = new System.Drawing.Point(133, 39);
            this.txtCommand.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(427, 30);
            this.txtCommand.TabIndex = 0;
            this.txtCommand.TextChanged += new System.EventHandler(this.txtCommand_TextChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(607, 526);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.bnCatalogue);
            this.tabPage2.Controls.Add(this.listView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(599, 488);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Praca";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(445, 443);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(147, 36);
            this.button2.TabIndex = 4;
            this.button2.Text = "W&yślij";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // bnCatalogue
            // 
            this.bnCatalogue.ContextMenuStrip = this.contextMenuStrip1;
            this.bnCatalogue.Location = new System.Drawing.Point(13, 341);
            this.bnCatalogue.Margin = new System.Windows.Forms.Padding(4);
            this.bnCatalogue.Name = "bnCatalogue";
            this.bnCatalogue.Size = new System.Drawing.Size(572, 44);
            this.bnCatalogue.TabIndex = 3;
            this.bnCatalogue.Text = "&Kataloguj";
            this.bnCatalogue.UseVisualStyleBackColor = true;
            this.bnCatalogue.Click += new System.EventHandler(this.bnCatalogue_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(482, 56);
            this.contextMenuStrip1.Text = "Uwzględnij w nazwie folderu datę i godzinę  katalogowania";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(481, 26);
            this.toolStripMenuItem1.Text = "Uwzględnij w nazwie folderu datę i godzinę  katalogowania";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(481, 26);
            this.toolStripMenuItem2.Text = "Zapisz raport katgalogowania";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.File,
            this.Label,
            this.Metadate,
            this.DownloadedFrom,
            this.LastModified,
            this.ArithmMean,
            this.Median,
            this.Mode,
            this.Q1,
            this.Q2,
            this.Q3,
            this.QDeviation,
            this.State,
            this.Durance});
            listViewGroup3.Header = "Plik";
            listViewGroup3.Name = "listViewGroup1";
            this.listView1.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup3});
            this.listView1.Location = new System.Drawing.Point(13, 6);
            this.listView1.Margin = new System.Windows.Forms.Padding(4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(571, 326);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // File
            // 
            this.File.Text = "Plik";
            // 
            // Label
            // 
            this.Label.Text = "Etykieta";
            // 
            // Metadate
            // 
            this.Metadate.Text = "Metadane";
            // 
            // DownloadedFrom
            // 
            this.DownloadedFrom.Text = "Strona web pobierania";
            // 
            // LastModified
            // 
            this.LastModified.Text = "Ostatnia mofyfikacja";
            // 
            // ArithmMean
            // 
            this.ArithmMean.Text = "Średnia arytmetyczna";
            // 
            // Median
            // 
            this.Median.Text = "Mediana";
            // 
            // Mode
            // 
            this.Mode.Text = "Moda";
            // 
            // Q1
            // 
            this.Q1.Text = "Kwartyl 1.";
            // 
            // Q2
            // 
            this.Q2.Text = "Kwartyl 2.";
            // 
            // Q3
            // 
            this.Q3.Text = "Kwartyl 3.";
            // 
            // QDeviation
            // 
            this.QDeviation.Text = "Odchylenie kwartylne";
            // 
            // State
            // 
            this.State.Text = "Stan";
            // 
            // Durance
            // 
            this.Durance.Text = "Czas trwania";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 526);
            this.Controls.Add(this.tabControl1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCommand;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lbExampleCommand;
        private System.Windows.Forms.CheckBox chkUseCreteRule;
        private System.Windows.Forms.CheckBox chkUseEquality;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox chkMetadata;
        private System.Windows.Forms.CheckBox chkExcludeMetadata;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button bnCatalogue;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader File;
        private System.Windows.Forms.ColumnHeader Label;
        private System.Windows.Forms.ColumnHeader Metadate;
        private System.Windows.Forms.ColumnHeader DownloadedFrom;
        private System.Windows.Forms.ColumnHeader LastModified;
        private System.Windows.Forms.ColumnHeader ArithmMean;
        private System.Windows.Forms.ColumnHeader Median;
        private System.Windows.Forms.ColumnHeader Mode;
        private System.Windows.Forms.ColumnHeader Q1;
        private System.Windows.Forms.ColumnHeader Q2;
        private System.Windows.Forms.ColumnHeader Q3;
        private System.Windows.Forms.ColumnHeader QDeviation;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ColumnHeader State;
        private System.Windows.Forms.ColumnHeader Durance;
    }
}

