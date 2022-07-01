namespace Lab_4_CompVision
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
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.Result = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Auto_flag = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Cam_but = new System.Windows.Forms.Button();
            this.Refr_but = new System.Windows.Forms.Button();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.V_max_bar = new System.Windows.Forms.TrackBar();
            this.S_max_bar = new System.Windows.Forms.TrackBar();
            this.H_max_bar = new System.Windows.Forms.TrackBar();
            this.V_min_bar = new System.Windows.Forms.TrackBar();
            this.S_min_bar = new System.Windows.Forms.TrackBar();
            this.H_min_bar = new System.Windows.Forms.TrackBar();
            this.Find_countours_but = new System.Windows.Forms.Button();
            this.Create_mask_but = new System.Windows.Forms.Button();
            this.Find_object_but = new System.Windows.Forms.Button();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.V_max_bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_max_bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.H_max_bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.V_min_bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_min_bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.H_min_bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
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
            this.Open_but.Location = new System.Drawing.Point(943, 201);
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
            this.pictureBox1.Location = new System.Drawing.Point(12, 11);
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
            this.pictureBox2.Location = new System.Drawing.Point(340, 630);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(320, 240);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Pink;
            this.pictureBox3.Location = new System.Drawing.Point(666, 630);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(320, 240);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 38;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Pink;
            this.pictureBox4.Location = new System.Drawing.Point(992, 630);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(320, 240);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 39;
            this.pictureBox4.TabStop = false;
            // 
            // Result
            // 
            this.Result.Location = new System.Drawing.Point(2080, 526);
            this.Result.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(247, 22);
            this.Result.TabIndex = 47;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(2078, 507);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 16);
            this.label10.TabIndex = 46;
            this.label10.Text = "Result";
            // 
            // Auto_flag
            // 
            this.Auto_flag.AutoSize = true;
            this.Auto_flag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Auto_flag.Location = new System.Drawing.Point(2083, 556);
            this.Auto_flag.Margin = new System.Windows.Forms.Padding(4);
            this.Auto_flag.Name = "Auto_flag";
            this.Auto_flag.Size = new System.Drawing.Size(228, 29);
            this.Auto_flag.TabIndex = 48;
            this.Auto_flag.Text = "Auto detect road signs";
            this.Auto_flag.UseVisualStyleBackColor = true;
            this.Auto_flag.CheckedChanged += new System.EventHandler(this.Auto_flag_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // Cam_but
            // 
            this.Cam_but.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Cam_but.Location = new System.Drawing.Point(943, 268);
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
            this.Refr_but.Location = new System.Drawing.Point(944, 326);
            this.Refr_but.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Refr_but.Name = "Refr_but";
            this.Refr_but.Size = new System.Drawing.Size(119, 54);
            this.Refr_but.TabIndex = 51;
            this.Refr_but.Text = "Refresh";
            this.Refr_but.UseVisualStyleBackColor = false;
            this.Refr_but.Click += new System.EventHandler(this.Refr_but_Click_1);
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Pink;
            this.pictureBox6.Location = new System.Drawing.Point(1644, 630);
            this.pictureBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(320, 240);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 52;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Pink;
            this.pictureBox5.Location = new System.Drawing.Point(1318, 630);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(320, 240);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 53;
            this.pictureBox5.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label11.Location = new System.Drawing.Point(1548, 383);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 16);
            this.label11.TabIndex = 61;
            this.label11.Text = "MAX HSV";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label12.Location = new System.Drawing.Point(1103, 383);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 16);
            this.label12.TabIndex = 60;
            this.label12.Text = "MIN HSV";
            // 
            // V_max_bar
            // 
            this.V_max_bar.BackColor = System.Drawing.Color.Pink;
            this.V_max_bar.Location = new System.Drawing.Point(1551, 548);
            this.V_max_bar.Maximum = 255;
            this.V_max_bar.Name = "V_max_bar";
            this.V_max_bar.Size = new System.Drawing.Size(407, 56);
            this.V_max_bar.TabIndex = 59;
            this.V_max_bar.Value = 255;
            // 
            // S_max_bar
            // 
            this.S_max_bar.BackColor = System.Drawing.Color.Pink;
            this.S_max_bar.Location = new System.Drawing.Point(1551, 479);
            this.S_max_bar.Maximum = 255;
            this.S_max_bar.Name = "S_max_bar";
            this.S_max_bar.Size = new System.Drawing.Size(407, 56);
            this.S_max_bar.TabIndex = 58;
            this.S_max_bar.Value = 255;
            // 
            // H_max_bar
            // 
            this.H_max_bar.BackColor = System.Drawing.Color.Pink;
            this.H_max_bar.Location = new System.Drawing.Point(1551, 402);
            this.H_max_bar.Maximum = 255;
            this.H_max_bar.Name = "H_max_bar";
            this.H_max_bar.Size = new System.Drawing.Size(407, 56);
            this.H_max_bar.TabIndex = 57;
            this.H_max_bar.Value = 255;
            // 
            // V_min_bar
            // 
            this.V_min_bar.BackColor = System.Drawing.Color.Pink;
            this.V_min_bar.Location = new System.Drawing.Point(1102, 548);
            this.V_min_bar.Maximum = 255;
            this.V_min_bar.Name = "V_min_bar";
            this.V_min_bar.Size = new System.Drawing.Size(407, 56);
            this.V_min_bar.TabIndex = 56;
            // 
            // S_min_bar
            // 
            this.S_min_bar.BackColor = System.Drawing.Color.Pink;
            this.S_min_bar.Location = new System.Drawing.Point(1102, 479);
            this.S_min_bar.Maximum = 255;
            this.S_min_bar.Name = "S_min_bar";
            this.S_min_bar.Size = new System.Drawing.Size(407, 56);
            this.S_min_bar.TabIndex = 55;
            // 
            // H_min_bar
            // 
            this.H_min_bar.BackColor = System.Drawing.Color.Pink;
            this.H_min_bar.Location = new System.Drawing.Point(1102, 402);
            this.H_min_bar.Maximum = 255;
            this.H_min_bar.Name = "H_min_bar";
            this.H_min_bar.Size = new System.Drawing.Size(407, 56);
            this.H_min_bar.TabIndex = 54;
            // 
            // Find_countours_but
            // 
            this.Find_countours_but.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Find_countours_but.Location = new System.Drawing.Point(945, 442);
            this.Find_countours_but.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Find_countours_but.Name = "Find_countours_but";
            this.Find_countours_but.Size = new System.Drawing.Size(119, 54);
            this.Find_countours_but.TabIndex = 63;
            this.Find_countours_but.Text = "Find countours";
            this.Find_countours_but.UseVisualStyleBackColor = false;
            this.Find_countours_but.Click += new System.EventHandler(this.Find_countours_but_Click);
            // 
            // Create_mask_but
            // 
            this.Create_mask_but.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Create_mask_but.Location = new System.Drawing.Point(944, 384);
            this.Create_mask_but.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Create_mask_but.Name = "Create_mask_but";
            this.Create_mask_but.Size = new System.Drawing.Size(119, 54);
            this.Create_mask_but.TabIndex = 62;
            this.Create_mask_but.Text = "Create mask";
            this.Create_mask_but.UseVisualStyleBackColor = false;
            this.Create_mask_but.Click += new System.EventHandler(this.Create_mask_but_Click);
            // 
            // Find_object_but
            // 
            this.Find_object_but.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Find_object_but.Location = new System.Drawing.Point(943, 548);
            this.Find_object_but.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Find_object_but.Name = "Find_object_but";
            this.Find_object_but.Size = new System.Drawing.Size(119, 54);
            this.Find_object_but.TabIndex = 64;
            this.Find_object_but.Text = "Find object";
            this.Find_object_but.UseVisualStyleBackColor = false;
            this.Find_object_but.Click += new System.EventHandler(this.Find_object_but_Click);
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.Pink;
            this.pictureBox7.Location = new System.Drawing.Point(14, 630);
            this.pictureBox7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(320, 240);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 65;
            this.pictureBox7.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.BackgroundImage = global::Lab_3_CompVision.Properties.Resources.Anime;
            this.ClientSize = new System.Drawing.Size(1970, 877);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.Find_object_but);
            this.Controls.Add(this.Find_countours_but);
            this.Controls.Add(this.Create_mask_but);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.V_max_bar);
            this.Controls.Add(this.S_max_bar);
            this.Controls.Add(this.H_max_bar);
            this.Controls.Add(this.V_min_bar);
            this.Controls.Add(this.S_min_bar);
            this.Controls.Add(this.H_min_bar);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.Refr_but);
            this.Controls.Add(this.Cam_but);
            this.Controls.Add(this.Auto_flag);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Open_but);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Kholodilov_Lab_4";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.V_max_bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_max_bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.H_max_bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.V_min_bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_min_bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.H_min_bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button Open_but;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.TextBox Result;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox Auto_flag;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button Cam_but;
        private System.Windows.Forms.Button Refr_but;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TrackBar V_max_bar;
        private System.Windows.Forms.TrackBar S_max_bar;
        private System.Windows.Forms.TrackBar H_max_bar;
        private System.Windows.Forms.TrackBar V_min_bar;
        private System.Windows.Forms.TrackBar S_min_bar;
        private System.Windows.Forms.TrackBar H_min_bar;
        private System.Windows.Forms.Button Find_countours_but;
        private System.Windows.Forms.Button Create_mask_but;
        private System.Windows.Forms.Button Find_object_but;
        private System.Windows.Forms.PictureBox pictureBox7;
    }
}

