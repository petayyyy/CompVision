namespace Lab_3_CompVision
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
            this.Open_but = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.R_max = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.R_min = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.G_max = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.G_min = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.B_max = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.B_min = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Start_but = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.Density = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Start_col_but = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.Max_size = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Min_size = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Open_sahblon_but = new System.Windows.Forms.Button();
            this.Start_anal_but = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "PNG|*.png|JPG|*.jpg|BMP|*.bmp";
            // 
            // Open_but
            // 
            this.Open_but.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Open_but.Location = new System.Drawing.Point(20, 10);
            this.Open_but.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Open_but.Name = "Open_but";
            this.Open_but.Size = new System.Drawing.Size(119, 54);
            this.Open_but.TabIndex = 0;
            this.Open_but.Text = "Open";
            this.Open_but.UseVisualStyleBackColor = false;
            this.Open_but.Click += new System.EventHandler(this.Open_but_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox1.Location = new System.Drawing.Point(156, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(640, 480);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ControlText;
            this.pictureBox2.Location = new System.Drawing.Point(1039, 10);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(569, 384);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // R_max
            // 
            this.R_max.Location = new System.Drawing.Point(20, 457);
            this.R_max.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.R_max.Name = "R_max";
            this.R_max.Size = new System.Drawing.Size(99, 22);
            this.R_max.TabIndex = 31;
            this.R_max.Text = "255";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 439);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 16);
            this.label7.TabIndex = 30;
            this.label7.Text = "B_max";
            // 
            // R_min
            // 
            this.R_min.Location = new System.Drawing.Point(20, 412);
            this.R_min.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.R_min.Name = "R_min";
            this.R_min.Size = new System.Drawing.Size(99, 22);
            this.R_min.TabIndex = 29;
            this.R_min.Text = "50";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 393);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 16);
            this.label8.TabIndex = 28;
            this.label8.Text = "B_min";
            // 
            // G_max
            // 
            this.G_max.Location = new System.Drawing.Point(20, 362);
            this.G_max.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.G_max.Name = "G_max";
            this.G_max.Size = new System.Drawing.Size(99, 22);
            this.G_max.TabIndex = 27;
            this.G_max.Text = "150";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 344);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 16);
            this.label5.TabIndex = 26;
            this.label5.Text = "G_max";
            // 
            // G_min
            // 
            this.G_min.Location = new System.Drawing.Point(20, 317);
            this.G_min.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.G_min.Name = "G_min";
            this.G_min.Size = new System.Drawing.Size(99, 22);
            this.G_min.TabIndex = 25;
            this.G_min.Text = "20";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 298);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 16);
            this.label6.TabIndex = 24;
            this.label6.Text = "G_min";
            // 
            // B_max
            // 
            this.B_max.Location = new System.Drawing.Point(20, 268);
            this.B_max.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.B_max.Name = "B_max";
            this.B_max.Size = new System.Drawing.Size(99, 22);
            this.B_max.TabIndex = 23;
            this.B_max.Text = "30";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 249);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 16);
            this.label4.TabIndex = 22;
            this.label4.Text = "R_max";
            // 
            // B_min
            // 
            this.B_min.Location = new System.Drawing.Point(20, 222);
            this.B_min.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.B_min.Name = "B_min";
            this.B_min.Size = new System.Drawing.Size(99, 22);
            this.B_min.TabIndex = 21;
            this.B_min.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 16);
            this.label3.TabIndex = 20;
            this.label3.Text = "R_min";
            // 
            // Start_but
            // 
            this.Start_but.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Start_but.Location = new System.Drawing.Point(20, 80);
            this.Start_but.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Start_but.Name = "Start_but";
            this.Start_but.Size = new System.Drawing.Size(119, 54);
            this.Start_but.TabIndex = 32;
            this.Start_but.Text = "Start auto detect";
            this.Start_but.UseVisualStyleBackColor = false;
            this.Start_but.Click += new System.EventHandler(this.Start_but_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(11, 743);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1689, 54);
            this.progressBar1.TabIndex = 33;
            // 
            // Density
            // 
            this.Density.Location = new System.Drawing.Point(20, 505);
            this.Density.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Density.Name = "Density";
            this.Density.Size = new System.Drawing.Size(99, 22);
            this.Density.TabIndex = 35;
            this.Density.Text = "60";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 487);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 34;
            this.label1.Text = "Density, %";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(1160, 429);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(289, 223);
            this.dataGridView1.TabIndex = 36;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Start_col_but
            // 
            this.Start_col_but.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Start_col_but.Location = new System.Drawing.Point(20, 148);
            this.Start_col_but.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Start_col_but.Name = "Start_col_but";
            this.Start_col_but.Size = new System.Drawing.Size(119, 54);
            this.Start_col_but.TabIndex = 37;
            this.Start_col_but.Text = "Start detect by color";
            this.Start_col_but.UseVisualStyleBackColor = false;
            this.Start_col_but.Click += new System.EventHandler(this.Start_col_but_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.HighlightText;
            this.pictureBox3.Location = new System.Drawing.Point(1039, 429);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(105, 98);
            this.pictureBox3.TabIndex = 38;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.SystemColors.HighlightText;
            this.pictureBox4.Location = new System.Drawing.Point(1039, 536);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(105, 98);
            this.pictureBox4.TabIndex = 39;
            this.pictureBox4.TabStop = false;
            // 
            // Max_size
            // 
            this.Max_size.Location = new System.Drawing.Point(20, 554);
            this.Max_size.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Max_size.Name = "Max_size";
            this.Max_size.Size = new System.Drawing.Size(99, 22);
            this.Max_size.TabIndex = 41;
            this.Max_size.Text = "90";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 536);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 40;
            this.label2.Text = "Max size";
            // 
            // Min_size
            // 
            this.Min_size.Location = new System.Drawing.Point(20, 606);
            this.Min_size.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Min_size.Name = "Min_size";
            this.Min_size.Size = new System.Drawing.Size(99, 22);
            this.Min_size.TabIndex = 43;
            this.Min_size.Text = "20";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 588);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 16);
            this.label9.TabIndex = 42;
            this.label9.Text = "Min size";
            // 
            // Open_sahblon_but
            // 
            this.Open_sahblon_but.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Open_sahblon_but.Location = new System.Drawing.Point(1039, 639);
            this.Open_sahblon_but.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Open_sahblon_but.Name = "Open_sahblon_but";
            this.Open_sahblon_but.Size = new System.Drawing.Size(105, 54);
            this.Open_sahblon_but.TabIndex = 44;
            this.Open_sahblon_but.Text = "Open shablon";
            this.Open_sahblon_but.UseVisualStyleBackColor = false;
            this.Open_sahblon_but.Click += new System.EventHandler(this.Open_sahblon_but_Click);
            // 
            // Start_anal_but
            // 
            this.Start_anal_but.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Start_anal_but.Location = new System.Drawing.Point(928, 639);
            this.Start_anal_but.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Start_anal_but.Name = "Start_anal_but";
            this.Start_anal_but.Size = new System.Drawing.Size(105, 54);
            this.Start_anal_but.TabIndex = 45;
            this.Start_anal_but.Text = "Start analaise";
            this.Start_anal_but.UseVisualStyleBackColor = false;
            this.Start_anal_but.Click += new System.EventHandler(this.Start_anal_but_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(1587, 731);
            this.Controls.Add(this.Start_anal_but);
            this.Controls.Add(this.Open_sahblon_but);
            this.Controls.Add(this.Min_size);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Max_size);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.Start_col_but);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Density);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.Start_but);
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
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Open_but);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Kholodilov_Lab_3";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button Open_but;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox R_max;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox R_min;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox G_max;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox G_min;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox B_max;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox B_min;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Start_but;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox Density;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Start_col_but;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.TextBox Max_size;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Min_size;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button Open_sahblon_but;
        private System.Windows.Forms.Button Start_anal_but;
    }
}

