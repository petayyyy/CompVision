namespace Ing_progect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Cam_but = new System.Windows.Forms.Button();
            this.Refr_but = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Open_but = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.H_min_bar = new System.Windows.Forms.TrackBar();
            this.S_min_bar = new System.Windows.Forms.TrackBar();
            this.V_min_bar = new System.Windows.Forms.TrackBar();
            this.V_max_bar = new System.Windows.Forms.TrackBar();
            this.S_max_bar = new System.Windows.Forms.TrackBar();
            this.H_max_bar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.HSV_box = new System.Windows.Forms.TextBox();
            this.Par2_bar = new System.Windows.Forms.TrackBar();
            this.Par1_bar = new System.Windows.Forms.TrackBar();
            this.Par_box = new System.Windows.Forms.TextBox();
            this.Real_coord = new System.Windows.Forms.TextBox();
            this.Pix_coord = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.H_min_bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_min_bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.V_min_bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.V_max_bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_max_bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.H_max_bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Par2_bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Par1_bar)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.IndianRed;
            this.pictureBox1.Location = new System.Drawing.Point(22, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(640, 480);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.IndianRed;
            this.pictureBox2.Location = new System.Drawing.Point(1076, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(320, 240);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // Cam_but
            // 
            this.Cam_but.BackColor = System.Drawing.Color.IndianRed;
            this.Cam_but.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Cam_but.Location = new System.Drawing.Point(891, 70);
            this.Cam_but.Name = "Cam_but";
            this.Cam_but.Size = new System.Drawing.Size(158, 32);
            this.Cam_but.TabIndex = 2;
            this.Cam_but.Text = "Start cam";
            this.Cam_but.UseVisualStyleBackColor = false;
            this.Cam_but.Click += new System.EventHandler(this.Cam_but_Click_1);
            // 
            // Refr_but
            // 
            this.Refr_but.BackColor = System.Drawing.Color.IndianRed;
            this.Refr_but.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Refr_but.Location = new System.Drawing.Point(891, 108);
            this.Refr_but.Name = "Refr_but";
            this.Refr_but.Size = new System.Drawing.Size(158, 33);
            this.Refr_but.TabIndex = 3;
            this.Refr_but.Text = "Refresh";
            this.Refr_but.UseVisualStyleBackColor = false;
            this.Refr_but.Click += new System.EventHandler(this.Refr_but_Click_1);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Open_but
            // 
            this.Open_but.BackColor = System.Drawing.Color.IndianRed;
            this.Open_but.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Open_but.Location = new System.Drawing.Point(891, 29);
            this.Open_but.Name = "Open_but";
            this.Open_but.Size = new System.Drawing.Size(158, 35);
            this.Open_but.TabIndex = 5;
            this.Open_but.Text = "Open video";
            this.Open_but.UseVisualStyleBackColor = false;
            this.Open_but.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.IndianRed;
            this.pictureBox3.Location = new System.Drawing.Point(1076, 249);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(320, 240);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.IndianRed;
            this.pictureBox4.Location = new System.Drawing.Point(1076, 495);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(320, 240);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 7;
            this.pictureBox4.TabStop = false;
            // 
            // H_min_bar
            // 
            this.H_min_bar.BackColor = System.Drawing.Color.IndianRed;
            this.H_min_bar.Location = new System.Drawing.Point(15, 1069);
            this.H_min_bar.Maximum = 255;
            this.H_min_bar.Name = "H_min_bar";
            this.H_min_bar.Size = new System.Drawing.Size(407, 56);
            this.H_min_bar.TabIndex = 8;
            // 
            // S_min_bar
            // 
            this.S_min_bar.BackColor = System.Drawing.Color.IndianRed;
            this.S_min_bar.Location = new System.Drawing.Point(15, 1146);
            this.S_min_bar.Maximum = 255;
            this.S_min_bar.Name = "S_min_bar";
            this.S_min_bar.Size = new System.Drawing.Size(407, 56);
            this.S_min_bar.TabIndex = 9;
            // 
            // V_min_bar
            // 
            this.V_min_bar.BackColor = System.Drawing.Color.IndianRed;
            this.V_min_bar.Location = new System.Drawing.Point(15, 1215);
            this.V_min_bar.Maximum = 255;
            this.V_min_bar.Name = "V_min_bar";
            this.V_min_bar.Size = new System.Drawing.Size(407, 56);
            this.V_min_bar.TabIndex = 10;
            // 
            // V_max_bar
            // 
            this.V_max_bar.BackColor = System.Drawing.Color.IndianRed;
            this.V_max_bar.Location = new System.Drawing.Point(464, 1215);
            this.V_max_bar.Maximum = 255;
            this.V_max_bar.Name = "V_max_bar";
            this.V_max_bar.Size = new System.Drawing.Size(407, 56);
            this.V_max_bar.TabIndex = 13;
            // 
            // S_max_bar
            // 
            this.S_max_bar.BackColor = System.Drawing.Color.IndianRed;
            this.S_max_bar.Location = new System.Drawing.Point(464, 1146);
            this.S_max_bar.Maximum = 255;
            this.S_max_bar.Name = "S_max_bar";
            this.S_max_bar.Size = new System.Drawing.Size(407, 56);
            this.S_max_bar.TabIndex = 12;
            // 
            // H_max_bar
            // 
            this.H_max_bar.BackColor = System.Drawing.Color.IndianRed;
            this.H_max_bar.Location = new System.Drawing.Point(464, 1069);
            this.H_max_bar.Maximum = 255;
            this.H_max_bar.Name = "H_max_bar";
            this.H_max_bar.Size = new System.Drawing.Size(407, 56);
            this.H_max_bar.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 1050);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "MIN HSV";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(461, 1050);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "MAX HSV";
            // 
            // HSV_box
            // 
            this.HSV_box.BackColor = System.Drawing.Color.IndianRed;
            this.HSV_box.Location = new System.Drawing.Point(464, 941);
            this.HSV_box.Name = "HSV_box";
            this.HSV_box.Size = new System.Drawing.Size(158, 22);
            this.HSV_box.TabIndex = 16;
            // 
            // Par2_bar
            // 
            this.Par2_bar.BackColor = System.Drawing.Color.IndianRed;
            this.Par2_bar.Location = new System.Drawing.Point(15, 990);
            this.Par2_bar.Maximum = 255;
            this.Par2_bar.Name = "Par2_bar";
            this.Par2_bar.Size = new System.Drawing.Size(407, 56);
            this.Par2_bar.TabIndex = 18;
            this.Par2_bar.Value = 10;
            // 
            // Par1_bar
            // 
            this.Par1_bar.BackColor = System.Drawing.Color.IndianRed;
            this.Par1_bar.Location = new System.Drawing.Point(15, 921);
            this.Par1_bar.Maximum = 255;
            this.Par1_bar.Name = "Par1_bar";
            this.Par1_bar.Size = new System.Drawing.Size(407, 56);
            this.Par1_bar.TabIndex = 17;
            this.Par1_bar.Value = 150;
            // 
            // Par_box
            // 
            this.Par_box.BackColor = System.Drawing.Color.IndianRed;
            this.Par_box.Location = new System.Drawing.Point(464, 983);
            this.Par_box.Name = "Par_box";
            this.Par_box.Size = new System.Drawing.Size(158, 22);
            this.Par_box.TabIndex = 19;
            // 
            // Real_coord
            // 
            this.Real_coord.BackColor = System.Drawing.Color.IndianRed;
            this.Real_coord.Location = new System.Drawing.Point(22, 712);
            this.Real_coord.Name = "Real_coord";
            this.Real_coord.Size = new System.Drawing.Size(257, 22);
            this.Real_coord.TabIndex = 21;
            // 
            // Pix_coord
            // 
            this.Pix_coord.BackColor = System.Drawing.Color.IndianRed;
            this.Pix_coord.Location = new System.Drawing.Point(22, 656);
            this.Pix_coord.Name = "Pix_coord";
            this.Pix_coord.Size = new System.Drawing.Size(257, 22);
            this.Pix_coord.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 637);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 16);
            this.label3.TabIndex = 22;
            this.label3.Text = "PIxel coordinat";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 693);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 16);
            this.label4.TabIndex = 23;
            this.label4.Text = "Real world coordinat";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 875);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 32);
            this.label5.TabIndex = 24;
            this.label5.Text = "Dev mode";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(463, 922);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 16);
            this.label6.TabIndex = 25;
            this.label6.Text = "Hsv param";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(463, 964);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 16);
            this.label7.TabIndex = 26;
            this.label7.Text = "HoughCircles param";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1405, 744);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Real_coord);
            this.Controls.Add(this.Pix_coord);
            this.Controls.Add(this.Par_box);
            this.Controls.Add(this.Par2_bar);
            this.Controls.Add(this.Par1_bar);
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
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.Open_but);
            this.Controls.Add(this.Refr_but);
            this.Controls.Add(this.Cam_but);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.H_min_bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_min_bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.V_min_bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.V_max_bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.S_max_bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.H_max_bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Par2_bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Par1_bar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button Cam_but;
        private System.Windows.Forms.Button Refr_but;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button Open_but;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.TrackBar H_min_bar;
        private System.Windows.Forms.TrackBar S_min_bar;
        private System.Windows.Forms.TrackBar V_min_bar;
        private System.Windows.Forms.TrackBar V_max_bar;
        private System.Windows.Forms.TrackBar S_max_bar;
        private System.Windows.Forms.TrackBar H_max_bar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox HSV_box;
        private System.Windows.Forms.TrackBar Par2_bar;
        private System.Windows.Forms.TrackBar Par1_bar;
        private System.Windows.Forms.TextBox Par_box;
        private System.Windows.Forms.TextBox Real_coord;
        private System.Windows.Forms.TextBox Pix_coord;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}

