namespace Lab_2
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Open_but = new System.Windows.Forms.Button();
            this.Clear_but = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Start_but = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.B_min = new System.Windows.Forms.TextBox();
            this.B_max = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.G_max = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.G_min = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.R_max = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.R_min = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Start_trafic_but = new System.Windows.Forms.Button();
            this.min_claster_size = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.max_claster_size = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Output_string = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.filter = new System.Windows.Forms.CheckBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.pictureBox1.Location = new System.Drawing.Point(169, 105);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 400);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // Open_but
            // 
            this.Open_but.BackColor = System.Drawing.SystemColors.HighlightText;
            this.Open_but.Location = new System.Drawing.Point(23, 26);
            this.Open_but.Name = "Open_but";
            this.Open_but.Size = new System.Drawing.Size(111, 72);
            this.Open_but.TabIndex = 1;
            this.Open_but.Text = "Open file";
            this.Open_but.UseVisualStyleBackColor = false;
            this.Open_but.Click += new System.EventHandler(this.Open_but_Click);
            // 
            // Clear_but
            // 
            this.Clear_but.BackColor = System.Drawing.SystemColors.HighlightText;
            this.Clear_but.Location = new System.Drawing.Point(23, 139);
            this.Clear_but.Name = "Clear_but";
            this.Clear_but.Size = new System.Drawing.Size(111, 72);
            this.Clear_but.TabIndex = 2;
            this.Clear_but.Text = "Clear";
            this.Clear_but.UseVisualStyleBackColor = false;
            this.Clear_but.Click += new System.EventHandler(this.Clear_but_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Black;
            this.pictureBox2.Location = new System.Drawing.Point(808, 105);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(400, 400);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(165, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Work Image";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(804, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Mask";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "BMP|*.bmp|PNG|*.png|JPG|*.jpg";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "One pixel",
            "Area of pixels"});
            this.comboBox1.Location = new System.Drawing.Point(23, 105);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(111, 28);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.Text = "One pixel";
            // 
            // Start_but
            // 
            this.Start_but.BackColor = System.Drawing.SystemColors.HighlightText;
            this.Start_but.Location = new System.Drawing.Point(23, 295);
            this.Start_but.Name = "Start_but";
            this.Start_but.Size = new System.Drawing.Size(111, 72);
            this.Start_but.TabIndex = 7;
            this.Start_but.Text = "Start find color";
            this.Start_but.UseVisualStyleBackColor = false;
            this.Start_but.Click += new System.EventHandler(this.Start_but_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 491);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "R_min";
            // 
            // B_min
            // 
            this.B_min.Location = new System.Drawing.Point(23, 514);
            this.B_min.Name = "B_min";
            this.B_min.Size = new System.Drawing.Size(111, 26);
            this.B_min.TabIndex = 9;
            this.B_min.Text = "0";
            // 
            // B_max
            // 
            this.B_max.Location = new System.Drawing.Point(23, 571);
            this.B_max.Name = "B_max";
            this.B_max.Size = new System.Drawing.Size(111, 26);
            this.B_max.TabIndex = 11;
            this.B_max.Text = "255";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 548);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "R_max";
            // 
            // G_max
            // 
            this.G_max.Location = new System.Drawing.Point(23, 689);
            this.G_max.Name = "G_max";
            this.G_max.Size = new System.Drawing.Size(111, 26);
            this.G_max.TabIndex = 15;
            this.G_max.Text = "255";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 666);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "G_max";
            // 
            // G_min
            // 
            this.G_min.Location = new System.Drawing.Point(23, 632);
            this.G_min.Name = "G_min";
            this.G_min.Size = new System.Drawing.Size(111, 26);
            this.G_min.TabIndex = 13;
            this.G_min.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 609);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "G_min";
            // 
            // R_max
            // 
            this.R_max.Location = new System.Drawing.Point(23, 808);
            this.R_max.Name = "R_max";
            this.R_max.Size = new System.Drawing.Size(111, 26);
            this.R_max.TabIndex = 19;
            this.R_max.Text = "255";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 785);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 20);
            this.label7.TabIndex = 18;
            this.label7.Text = "B_max";
            // 
            // R_min
            // 
            this.R_min.Location = new System.Drawing.Point(23, 751);
            this.R_min.Name = "R_min";
            this.R_min.Size = new System.Drawing.Size(111, 26);
            this.R_min.TabIndex = 17;
            this.R_min.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 728);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "B_min";
            // 
            // Start_trafic_but
            // 
            this.Start_trafic_but.BackColor = System.Drawing.SystemColors.HighlightText;
            this.Start_trafic_but.Location = new System.Drawing.Point(23, 217);
            this.Start_trafic_but.Name = "Start_trafic_but";
            this.Start_trafic_but.Size = new System.Drawing.Size(111, 72);
            this.Start_trafic_but.TabIndex = 20;
            this.Start_trafic_but.Text = "Start trafic ligth detect";
            this.Start_trafic_but.UseVisualStyleBackColor = false;
            this.Start_trafic_but.Click += new System.EventHandler(this.Start_trafic_but_Click);
            // 
            // min_claster_size
            // 
            this.min_claster_size.Location = new System.Drawing.Point(23, 407);
            this.min_claster_size.Name = "min_claster_size";
            this.min_claster_size.Size = new System.Drawing.Size(111, 26);
            this.min_claster_size.TabIndex = 22;
            this.min_claster_size.Text = "10";
            this.min_claster_size.TextChanged += new System.EventHandler(this.min_claster_size_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 384);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 20);
            this.label9.TabIndex = 21;
            this.label9.Text = "Claster min.size";
            // 
            // max_claster_size
            // 
            this.max_claster_size.Location = new System.Drawing.Point(23, 462);
            this.max_claster_size.Name = "max_claster_size";
            this.max_claster_size.Size = new System.Drawing.Size(111, 26);
            this.max_claster_size.TabIndex = 24;
            this.max_claster_size.Text = "60";
            this.max_claster_size.TextChanged += new System.EventHandler(this.max_claster_size_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 439);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(124, 20);
            this.label10.TabIndex = 23;
            this.label10.Text = "Claster max.size";
            // 
            // Output_string
            // 
            this.Output_string.Location = new System.Drawing.Point(169, 49);
            this.Output_string.Name = "Output_string";
            this.Output_string.Size = new System.Drawing.Size(603, 26);
            this.Output_string.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(165, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(127, 20);
            this.label11.TabIndex = 26;
            this.label11.Text = "Output message";
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(169, 766);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(1253, 68);
            this.progressBar2.TabIndex = 28;
            // 
            // filter
            // 
            this.filter.AutoSize = true;
            this.filter.Location = new System.Drawing.Point(808, 49);
            this.filter.Name = "filter";
            this.filter.Size = new System.Drawing.Size(168, 24);
            this.filter.TabIndex = 29;
            this.filter.Text = "Gray world method";
            this.filter.UseVisualStyleBackColor = true;
            this.filter.CheckedChanged += new System.EventHandler(this.filter_CheckedChanged);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.HighlightText;
            this.pictureBox3.Location = new System.Drawing.Point(1445, 105);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(400, 400);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 30;
            this.pictureBox3.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1441, 78);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 20);
            this.label12.TabIndex = 31;
            this.label12.Text = "Input Image";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(1924, 843);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.filter);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.Output_string);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.max_claster_size);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.min_claster_size);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Start_trafic_but);
            this.Controls.Add(this.R_max);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.R_min);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.G_max);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.G_min);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.B_max);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.B_min);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Start_but);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Clear_but);
            this.Controls.Add(this.Open_but);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Kholodilov_Lab_2";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Open_but;
        private System.Windows.Forms.Button Clear_but;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button Start_but;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox B_min;
        private System.Windows.Forms.TextBox B_max;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox G_max;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox G_min;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox R_max;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox R_min;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button Start_trafic_but;
        private System.Windows.Forms.TextBox min_claster_size;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox max_claster_size;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox Output_string;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.CheckBox filter;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label12;
    }
}

