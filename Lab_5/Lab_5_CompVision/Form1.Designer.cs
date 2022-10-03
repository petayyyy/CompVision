namespace Lab_5_CompVision
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Open_but = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.Result_square = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Auto_flag = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Cam_but = new System.Windows.Forms.Button();
            this.Refr_but = new System.Windows.Forms.Button();
            this.Open_sampl_but = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.V_max_bar = new System.Windows.Forms.TrackBar();
            this.S_max_bar = new System.Windows.Forms.TrackBar();
            this.H_max_bar = new System.Windows.Forms.TrackBar();
            this.V_min_bar = new System.Windows.Forms.TrackBar();
            this.S_min_bar = new System.Windows.Forms.TrackBar();
            this.H_min_bar = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.HSV_box = new System.Windows.Forms.TextBox();
            this.Degrees = new System.Windows.Forms.TrackBar();
            this.Angle = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.Distance = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.degr_box = new System.Windows.Forms.TextBox();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.label6 = new System.Windows.Forms.Label();
            this.Otstyp = new System.Windows.Forms.TextBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.Save_sam_but = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.Sample_point_list = new System.Windows.Forms.ListBox();
            this.Result_point = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.V_max_bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_max_bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.H_max_bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.V_min_bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_min_bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.H_min_bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Degrees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Angle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "PNG|*.png|JPG|*.jpg|BMP|*.bmp|AVI|*.avi|MP4|*.mp4|MOV|*.mov";
            // 
            // Open_but
            // 
            this.Open_but.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Open_but.Location = new System.Drawing.Point(7, 377);
            this.Open_but.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Open_but.Name = "Open_but";
            this.Open_but.Size = new System.Drawing.Size(119, 54);
            this.Open_but.TabIndex = 0;
            this.Open_but.Text = "Open input image/video";
            this.Open_but.UseVisualStyleBackColor = false;
            this.Open_but.Click += new System.EventHandler(this.Open_but_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Pink;
            this.pictureBox1.Location = new System.Drawing.Point(132, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(640, 480);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Pink;
            this.pictureBox2.Location = new System.Drawing.Point(848, 628);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(300, 300);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Pink;
            this.pictureBox3.Location = new System.Drawing.Point(1154, 628);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(300, 300);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 38;
            this.pictureBox3.TabStop = false;
            // 
            // Result_square
            // 
            this.Result_square.BackColor = System.Drawing.Color.IndianRed;
            this.Result_square.Location = new System.Drawing.Point(188, 685);
            this.Result_square.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Result_square.Name = "Result_square";
            this.Result_square.Size = new System.Drawing.Size(195, 22);
            this.Result_square.TabIndex = 47;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.IndianRed;
            this.label10.Location = new System.Drawing.Point(186, 667);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 16);
            this.label10.TabIndex = 46;
            this.label10.Text = "Result square";
            // 
            // Auto_flag
            // 
            this.Auto_flag.AutoSize = true;
            this.Auto_flag.BackColor = System.Drawing.Color.LightPink;
            this.Auto_flag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Auto_flag.Location = new System.Drawing.Point(575, 678);
            this.Auto_flag.Margin = new System.Windows.Forms.Padding(4);
            this.Auto_flag.Name = "Auto_flag";
            this.Auto_flag.Size = new System.Drawing.Size(197, 29);
            this.Auto_flag.TabIndex = 48;
            this.Auto_flag.Text = "Auto rotate sample";
            this.Auto_flag.UseVisualStyleBackColor = false;
            this.Auto_flag.CheckedChanged += new System.EventHandler(this.Auto_flag_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // Cam_but
            // 
            this.Cam_but.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Cam_but.Location = new System.Drawing.Point(7, 435);
            this.Cam_but.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Cam_but.Name = "Cam_but";
            this.Cam_but.Size = new System.Drawing.Size(119, 54);
            this.Cam_but.TabIndex = 50;
            this.Cam_but.Text = "Start work with laptop camera";
            this.Cam_but.UseVisualStyleBackColor = false;
            this.Cam_but.Click += new System.EventHandler(this.Cam_but_Click_1);
            // 
            // Refr_but
            // 
            this.Refr_but.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Refr_but.Location = new System.Drawing.Point(7, 493);
            this.Refr_but.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Refr_but.Name = "Refr_but";
            this.Refr_but.Size = new System.Drawing.Size(119, 54);
            this.Refr_but.TabIndex = 51;
            this.Refr_but.Text = "Refresh";
            this.Refr_but.UseVisualStyleBackColor = false;
            this.Refr_but.Click += new System.EventHandler(this.Refr_but_Click_1);
            // 
            // Open_sampl_but
            // 
            this.Open_sampl_but.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Open_sampl_but.Location = new System.Drawing.Point(7, 131);
            this.Open_sampl_but.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Open_sampl_but.Name = "Open_sampl_but";
            this.Open_sampl_but.Size = new System.Drawing.Size(119, 54);
            this.Open_sampl_but.TabIndex = 64;
            this.Open_sampl_but.Text = "Open sample";
            this.Open_sampl_but.UseVisualStyleBackColor = false;
            this.Open_sampl_but.Click += new System.EventHandler(this.Find_object_but_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Pink;
            this.pictureBox4.Location = new System.Drawing.Point(1260, 32);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(540, 480);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox4.TabIndex = 65;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox4_MouseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.IndianRed;
            this.label2.Location = new System.Drawing.Point(417, 728);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 73;
            this.label2.Text = "MAX HSV";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.IndianRed;
            this.label1.Location = new System.Drawing.Point(8, 729);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 72;
            this.label1.Text = "MIN HSV";
            // 
            // V_max_bar
            // 
            this.V_max_bar.BackColor = System.Drawing.Color.IndianRed;
            this.V_max_bar.Location = new System.Drawing.Point(420, 871);
            this.V_max_bar.Maximum = 255;
            this.V_max_bar.Name = "V_max_bar";
            this.V_max_bar.Size = new System.Drawing.Size(407, 56);
            this.V_max_bar.TabIndex = 71;
            // 
            // S_max_bar
            // 
            this.S_max_bar.BackColor = System.Drawing.Color.IndianRed;
            this.S_max_bar.Location = new System.Drawing.Point(420, 809);
            this.S_max_bar.Maximum = 255;
            this.S_max_bar.Name = "S_max_bar";
            this.S_max_bar.Size = new System.Drawing.Size(407, 56);
            this.S_max_bar.TabIndex = 70;
            // 
            // H_max_bar
            // 
            this.H_max_bar.BackColor = System.Drawing.Color.IndianRed;
            this.H_max_bar.Location = new System.Drawing.Point(420, 747);
            this.H_max_bar.Maximum = 255;
            this.H_max_bar.Name = "H_max_bar";
            this.H_max_bar.Size = new System.Drawing.Size(407, 56);
            this.H_max_bar.TabIndex = 69;
            // 
            // V_min_bar
            // 
            this.V_min_bar.BackColor = System.Drawing.Color.IndianRed;
            this.V_min_bar.Location = new System.Drawing.Point(7, 872);
            this.V_min_bar.Maximum = 255;
            this.V_min_bar.Name = "V_min_bar";
            this.V_min_bar.Size = new System.Drawing.Size(407, 56);
            this.V_min_bar.TabIndex = 68;
            // 
            // S_min_bar
            // 
            this.S_min_bar.BackColor = System.Drawing.Color.IndianRed;
            this.S_min_bar.Location = new System.Drawing.Point(7, 810);
            this.S_min_bar.Maximum = 255;
            this.S_min_bar.Name = "S_min_bar";
            this.S_min_bar.Size = new System.Drawing.Size(407, 56);
            this.S_min_bar.TabIndex = 67;
            // 
            // H_min_bar
            // 
            this.H_min_bar.BackColor = System.Drawing.Color.IndianRed;
            this.H_min_bar.Location = new System.Drawing.Point(7, 748);
            this.H_min_bar.Maximum = 255;
            this.H_min_bar.Name = "H_min_bar";
            this.H_min_bar.Size = new System.Drawing.Size(407, 56);
            this.H_min_bar.TabIndex = 66;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.IndianRed;
            this.label3.Location = new System.Drawing.Point(5, 666);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 16);
            this.label3.TabIndex = 76;
            this.label3.Text = "Hsv param";
            // 
            // HSV_box
            // 
            this.HSV_box.BackColor = System.Drawing.Color.IndianRed;
            this.HSV_box.Location = new System.Drawing.Point(8, 685);
            this.HSV_box.Name = "HSV_box";
            this.HSV_box.Size = new System.Drawing.Size(165, 22);
            this.HSV_box.TabIndex = 75;
            // 
            // Degrees
            // 
            this.Degrees.BackColor = System.Drawing.Color.LightPink;
            this.Degrees.Cursor = System.Windows.Forms.Cursors.Default;
            this.Degrees.LargeChange = 1;
            this.Degrees.Location = new System.Drawing.Point(1006, 11);
            this.Degrees.Maximum = 90;
            this.Degrees.Minimum = -90;
            this.Degrees.Name = "Degrees";
            this.Degrees.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.Degrees.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Degrees.Size = new System.Drawing.Size(56, 590);
            this.Degrees.TabIndex = 77;
            this.Degrees.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            // 
            // Angle
            // 
            this.Angle.BackColor = System.Drawing.Color.LightPink;
            this.Angle.LargeChange = 1;
            this.Angle.Location = new System.Drawing.Point(1260, 545);
            this.Angle.Maximum = 360;
            this.Angle.Name = "Angle";
            this.Angle.Size = new System.Drawing.Size(500, 56);
            this.Angle.TabIndex = 78;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.LightPink;
            this.label4.Location = new System.Drawing.Point(1075, 330);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 16);
            this.label4.TabIndex = 80;
            this.label4.Text = "Distance from camera (mm)";
            // 
            // Distance
            // 
            this.Distance.BackColor = System.Drawing.Color.LightPink;
            this.Distance.Location = new System.Drawing.Point(1078, 349);
            this.Distance.Name = "Distance";
            this.Distance.Size = new System.Drawing.Size(119, 22);
            this.Distance.TabIndex = 79;
            this.Distance.Text = "500";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.LightPink;
            this.label5.Location = new System.Drawing.Point(1075, 282);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 16);
            this.label5.TabIndex = 82;
            this.label5.Text = "Degrees camera Y";
            // 
            // degr_box
            // 
            this.degr_box.BackColor = System.Drawing.Color.LightPink;
            this.degr_box.Location = new System.Drawing.Point(1078, 301);
            this.degr_box.Name = "degr_box";
            this.degr_box.Size = new System.Drawing.Size(119, 22);
            this.degr_box.TabIndex = 81;
            this.degr_box.Text = "0";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            this.openFileDialog2.Filter = "CSV|*.csv";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.LightPink;
            this.label6.Location = new System.Drawing.Point(1075, 233);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 16);
            this.label6.TabIndex = 84;
            this.label6.Text = "Otstyp";
            // 
            // Otstyp
            // 
            this.Otstyp.BackColor = System.Drawing.Color.LightPink;
            this.Otstyp.Location = new System.Drawing.Point(1078, 252);
            this.Otstyp.Name = "Otstyp";
            this.Otstyp.Size = new System.Drawing.Size(119, 22);
            this.Otstyp.TabIndex = 83;
            this.Otstyp.Text = "15";
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Pink;
            this.pictureBox5.Location = new System.Drawing.Point(1460, 628);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(300, 300);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 85;
            this.pictureBox5.TabStop = false;
            // 
            // Save_sam_but
            // 
            this.Save_sam_but.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Save_sam_but.Enabled = false;
            this.Save_sam_but.Location = new System.Drawing.Point(7, 73);
            this.Save_sam_but.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Save_sam_but.Name = "Save_sam_but";
            this.Save_sam_but.Size = new System.Drawing.Size(119, 54);
            this.Save_sam_but.TabIndex = 86;
            this.Save_sam_but.Text = "Save sample";
            this.Save_sam_but.UseVisualStyleBackColor = false;
            this.Save_sam_but.Click += new System.EventHandler(this.Save_sam_but_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "CSV|*.csv";
            // 
            // Sample_point_list
            // 
            this.Sample_point_list.BackColor = System.Drawing.Color.Pink;
            this.Sample_point_list.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Sample_point_list.FormattingEnabled = true;
            this.Sample_point_list.ItemHeight = 16;
            this.Sample_point_list.Location = new System.Drawing.Point(8, 190);
            this.Sample_point_list.Name = "Sample_point_list";
            this.Sample_point_list.Size = new System.Drawing.Size(118, 84);
            this.Sample_point_list.TabIndex = 87;
            // 
            // Result_point
            // 
            this.Result_point.BackColor = System.Drawing.Color.IndianRed;
            this.Result_point.Location = new System.Drawing.Point(404, 685);
            this.Result_point.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Result_point.Name = "Result_point";
            this.Result_point.Size = new System.Drawing.Size(137, 22);
            this.Result_point.TabIndex = 89;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.IndianRed;
            this.label7.Location = new System.Drawing.Point(402, 666);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 16);
            this.label7.TabIndex = 88;
            this.label7.Text = "Result point";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.BackgroundImage = global::Lab_3_CompVision.Properties.Resources.Anime;
            this.ClientSize = new System.Drawing.Size(1790, 935);
            this.Controls.Add(this.Result_point);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Sample_point_list);
            this.Controls.Add(this.Save_sam_but);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Otstyp);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.degr_box);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Distance);
            this.Controls.Add(this.Angle);
            this.Controls.Add(this.Degrees);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.HSV_box);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.V_max_bar);
            this.Controls.Add(this.S_max_bar);
            this.Controls.Add(this.H_max_bar);
            this.Controls.Add(this.V_min_bar);
            this.Controls.Add(this.S_min_bar);
            this.Controls.Add(this.H_min_bar);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.Open_sampl_but);
            this.Controls.Add(this.Refr_but);
            this.Controls.Add(this.Cam_but);
            this.Controls.Add(this.Auto_flag);
            this.Controls.Add(this.Result_square);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Open_but);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Kholodilov_Lab_5";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.V_max_bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_max_bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.H_max_bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.V_min_bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_min_bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.H_min_bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Degrees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Angle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button Open_but;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox Result_square;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox Auto_flag;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button Cam_but;
        private System.Windows.Forms.Button Refr_but;
        private System.Windows.Forms.Button Open_sampl_but;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar V_max_bar;
        private System.Windows.Forms.TrackBar S_max_bar;
        private System.Windows.Forms.TrackBar H_max_bar;
        private System.Windows.Forms.TrackBar V_min_bar;
        private System.Windows.Forms.TrackBar S_min_bar;
        private System.Windows.Forms.TrackBar H_min_bar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox HSV_box;
        private System.Windows.Forms.TrackBar Degrees;
        private System.Windows.Forms.TrackBar Angle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Distance;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox degr_box;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Otstyp;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Button Save_sam_but;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ListBox Sample_point_list;
        private System.Windows.Forms.TextBox Result_point;
        private System.Windows.Forms.Label label7;
    }
}

