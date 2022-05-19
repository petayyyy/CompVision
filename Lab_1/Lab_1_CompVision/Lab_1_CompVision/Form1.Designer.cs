namespace Lab_1_CompVision
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Generate_but = new System.Windows.Forms.Button();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Open_but = new System.Windows.Forms.Button();
            this.Size_data = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Z = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Save_but = new System.Windows.Forms.Button();
            this.fileFormat = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Len_Claster = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Start_Claster = new System.Windows.Forms.Button();
            this.Line_but = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.Z_size = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox1.Location = new System.Drawing.Point(695, 14);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1000, 1000);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Generate_but
            // 
            this.Generate_but.Location = new System.Drawing.Point(51, 95);
            this.Generate_but.Margin = new System.Windows.Forms.Padding(2);
            this.Generate_but.Name = "Generate_but";
            this.Generate_but.Size = new System.Drawing.Size(144, 79);
            this.Generate_but.TabIndex = 2;
            this.Generate_but.Text = "Generate";
            this.Generate_but.UseVisualStyleBackColor = true;
            this.Generate_but.Click += new System.EventHandler(this.Generate_but_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "CSV|*.csv|TXT|*.txt";
            // 
            // Open_but
            // 
            this.Open_but.Location = new System.Drawing.Point(46, 928);
            this.Open_but.Margin = new System.Windows.Forms.Padding(2);
            this.Open_but.Name = "Open_but";
            this.Open_but.Size = new System.Drawing.Size(144, 79);
            this.Open_but.TabIndex = 3;
            this.Open_but.Text = "Open file";
            this.Open_but.UseVisualStyleBackColor = true;
            this.Open_but.Click += new System.EventHandler(this.Open_but_Click);
            // 
            // Size_data
            // 
            this.Size_data.Location = new System.Drawing.Point(51, 58);
            this.Size_data.Margin = new System.Windows.Forms.Padding(2);
            this.Size_data.Name = "Size_data";
            this.Size_data.Size = new System.Drawing.Size(144, 31);
            this.Size_data.TabIndex = 4;
            this.Size_data.Text = "100";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Size genering data";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.X,
            this.Y,
            this.Z});
            this.dataGridView1.Location = new System.Drawing.Point(252, 12);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 25;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(438, 1000);
            this.dataGridView1.TabIndex = 6;
            // 
            // X
            // 
            this.X.HeaderText = "X";
            this.X.MinimumWidth = 8;
            this.X.Name = "X";
            this.X.Width = 150;
            // 
            // Y
            // 
            this.Y.HeaderText = "Y";
            this.Y.MinimumWidth = 8;
            this.Y.Name = "Y";
            this.Y.Width = 150;
            // 
            // Z
            // 
            this.Z.HeaderText = "Z";
            this.Z.MinimumWidth = 8;
            this.Z.Name = "Z";
            this.Z.Width = 150;
            // 
            // Save_but
            // 
            this.Save_but.Location = new System.Drawing.Point(46, 842);
            this.Save_but.Margin = new System.Windows.Forms.Padding(2);
            this.Save_but.Name = "Save_but";
            this.Save_but.Size = new System.Drawing.Size(144, 79);
            this.Save_but.TabIndex = 7;
            this.Save_but.Text = "Save file";
            this.Save_but.UseVisualStyleBackColor = true;
            this.Save_but.Click += new System.EventHandler(this.Save_but_Click);
            // 
            // fileFormat
            // 
            this.fileFormat.FormattingEnabled = true;
            this.fileFormat.Items.AddRange(new object[] {
            "TXT",
            "CSV"});
            this.fileFormat.Location = new System.Drawing.Point(46, 804);
            this.fileFormat.Margin = new System.Windows.Forms.Padding(2);
            this.fileFormat.Name = "fileFormat";
            this.fileFormat.Size = new System.Drawing.Size(144, 33);
            this.fileFormat.TabIndex = 8;
            this.fileFormat.Text = "TXT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 196);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Length of Cluster";
            // 
            // Len_Claster
            // 
            this.Len_Claster.Location = new System.Drawing.Point(50, 234);
            this.Len_Claster.Margin = new System.Windows.Forms.Padding(2);
            this.Len_Claster.Name = "Len_Claster";
            this.Len_Claster.Size = new System.Drawing.Size(144, 31);
            this.Len_Claster.TabIndex = 9;
            this.Len_Claster.Text = "50";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 771);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "Format output file";
            // 
            // Start_Claster
            // 
            this.Start_Claster.Location = new System.Drawing.Point(50, 270);
            this.Start_Claster.Margin = new System.Windows.Forms.Padding(2);
            this.Start_Claster.Name = "Start_Claster";
            this.Start_Claster.Size = new System.Drawing.Size(144, 79);
            this.Start_Claster.TabIndex = 12;
            this.Start_Claster.Text = "Start show point";
            this.Start_Claster.UseVisualStyleBackColor = true;
            this.Start_Claster.Click += new System.EventHandler(this.Start_Claster_Click);
            // 
            // Line_but
            // 
            this.Line_but.Location = new System.Drawing.Point(46, 439);
            this.Line_but.Margin = new System.Windows.Forms.Padding(2);
            this.Line_but.Name = "Line_but";
            this.Line_but.Size = new System.Drawing.Size(148, 79);
            this.Line_but.TabIndex = 13;
            this.Line_but.Text = "Generate line";
            this.Line_but.UseVisualStyleBackColor = true;
            this.Line_but.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 386);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 25);
            this.label4.TabIndex = 14;
            this.label4.Text = "Blue line - y_mediane";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 411);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(210, 25);
            this.label5.TabIndex = 15;
            this.label5.Text = "Black line - line of best fit";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 361);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(174, 25);
            this.label6.TabIndex = 16;
            this.label6.Text = "Red line - x_mediane";
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.SystemColors.Highlight;
            this.progressBar1.Location = new System.Drawing.Point(12, 1018);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1682, 34);
            this.progressBar1.TabIndex = 17;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(51, 639);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 79);
            this.button1.TabIndex = 18;
            this.button1.Text = "Show Z-line";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Z_size
            // 
            this.Z_size.Location = new System.Drawing.Point(54, 600);
            this.Z_size.Margin = new System.Windows.Forms.Padding(2);
            this.Z_size.Name = "Z_size";
            this.Z_size.Size = new System.Drawing.Size(144, 31);
            this.Z_size.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(50, 572);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(152, 25);
            this.label7.TabIndex = 20;
            this.label7.Text = "Size pixel in Z-line";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(1701, 1050);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Z_size);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Line_but);
            this.Controls.Add(this.Start_Claster);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Len_Claster);
            this.Controls.Add(this.fileFormat);
            this.Controls.Add(this.Save_but);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Size_data);
            this.Controls.Add(this.Open_but);
            this.Controls.Add(this.Generate_but);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Kholodilov_Lab_1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private Button Generate_but;
        private FileSystemWatcher fileSystemWatcher1;
        private Label label1;
        private TextBox Size_data;
        private Button Open_but;
        private OpenFileDialog openFileDialog1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn X;
        private DataGridViewTextBoxColumn Y;
        private DataGridViewTextBoxColumn Z;
        private Button Save_but;
        private ComboBox fileFormat;
        private Label label3;
        private Label label2;
        private TextBox Len_Claster;
        private Button Start_Claster;
        private Button Line_but;
        private Label label4;
        private Label label6;
        private Label label5;
        private ProgressBar progressBar1;
        private Button button1;
        private Label label7;
        private TextBox Z_size;
    }
}