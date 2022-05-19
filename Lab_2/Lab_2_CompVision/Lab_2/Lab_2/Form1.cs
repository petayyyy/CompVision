using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(400, 400);
            pictureBox2.Image = new Bitmap(400, 400);
            //pictureBox2.Image = new Bitmap(640, 480);
            pictureBox3.Image = new Bitmap(400, 400);

        }
        Image work_image = new Bitmap(400, 400);
        Image output_image = new Bitmap(400, 400);
        bool Open_flag = false;
        public void filtred_image()
        {
            if (filter.Checked)
            {
                pictureBox3.Image = (Bitmap)work_image.Clone();
                double R = 0; double G = 0; double B = 0;
                for (int i = 0; i < work_image.Width; i++)
                {
                    for (int j = 0; j < work_image.Height; j++)
                    {
                        Color pixel = ((Bitmap)work_image).GetPixel(i, j);
                        R += pixel.R;
                        G += pixel.G;
                        B += pixel.B;
                    }
                }
                R /= work_image.Width * work_image.Height;
                B /= work_image.Width * work_image.Height;
                G /= work_image.Width * work_image.Height;
                double k = (R + B + G) / 3;
                R = k / R;
                G = k / G;
                B = k / B;
                for (int i = 0; i < work_image.Width; i++)
                {
                    for (int j = 0; j < work_image.Height; j++)
                    {
                        Color pixel = ((Bitmap)work_image).GetPixel(i, j);
                        ((Bitmap)work_image).SetPixel(i, j, Color.FromArgb(data_rgb(pixel.R * R), data_rgb(pixel.G * G), data_rgb(pixel.B * B)));
                    }
                }
            }
            else
            {
                Graphics graphics = Graphics.FromImage(pictureBox3.Image);
                graphics.FillRectangle(Brushes.White, new Rectangle(0, 0, pictureBox3.Width, pictureBox3.Height));
            }
            output_image = (Bitmap)work_image.Clone();
            pictureBox1.Image = output_image;
            pictureBox1.Refresh();
            pictureBox3.Refresh();
        }
        private void Open_but_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res = openFileDialog1.ShowDialog();
                if (res == DialogResult.OK)
                {
                    work_image = Image.FromFile(openFileDialog1.FileName);
                    filtred_image();
                }
                else MessageBox.Show("Error, you don't take any file.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error, your file have incorrect type. You must take .png, .jpg or .bmp.");
            }
            Start_trafic_but.BackColor = Color.White;
            Output_string.Text = "";
            Graphics graphics2 = Graphics.FromImage(pictureBox2.Image);
            graphics2.FillRectangle(Brushes.Black, new Rectangle(0, 0, pictureBox2.Width, pictureBox2.Height));
            pictureBox1.Refresh();
            pictureBox2.Refresh();
            Open_flag = true;
        }
        int[] rectangle = new int[4];
        int[] pix = new int[2];
        Rectangle rect;
        int R = 0; int G = 0; int B = 0;
        public int data_rgb (double data)
        {
            if (data > 255) return 255;
            else if (data < 0 ) return 0;
            return (int)data;
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Graphics graphics = Graphics.FromImage(pictureBox1.Image);
            if (comboBox1.Text == "One pixel")
            {
                pix[0] = e.Location.X;
                pix[1] = e.Location.Y;
                Font drawFont = new Font("Arial", 20);
                StringFormat drawFormat = new StringFormat();
                SolidBrush drawBrush = new SolidBrush(Color.Blue);
                Color pixel = ((Bitmap)work_image).GetPixel(pix[0], pix[1]);
                drawFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;
                graphics.DrawString(pixel.B.ToString()+", "+ pixel.G.ToString() + ", "+ pixel.R.ToString(), drawFont, drawBrush, e.Location.X, e.Location.Y, drawFormat);
                pictureBox1.Refresh();
            }
            else
            {
                rectangle[0] = e.Location.X;
                rectangle[1] = e.Location.Y;
            }
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Graphics graphics = Graphics.FromImage(pictureBox1.Image);
            if (comboBox1.Text != "One pixel")
            {
                rectangle[2] = e.Location.X;
                rectangle[3] = e.Location.Y;

                Pen pen = new Pen(Color.Blue);
                graphics.DrawRectangle(pen, GetRect());
                Font drawFont = new Font("Arial", 20);
                StringFormat drawFormat = new StringFormat();
                SolidBrush drawBrush = new SolidBrush(Color.Blue);
                drawFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;
                graphics.DrawString(B.ToString() + ", " + G.ToString() + ", " + R.ToString(), drawFont, drawBrush, e.Location.X, e.Location.Y, drawFormat);
                
                pictureBox1.Refresh();
            }
        }
        public Rectangle GetRect(){
            rect = new Rectangle();
            rect.X = Math.Min(rectangle[0], rectangle[2]);
            rect.Y = Math.Min(rectangle[1], rectangle[3]);
            rect.Width = Math.Abs(rectangle[0] - rectangle[2]);
            rect.Height = Math.Abs(rectangle[1] - rectangle[3]);
            sr_RGB(rect.X, rect.Y, rect.Height, rect.Width);
            return rect;
        }
        public void sr_RGB (int x, int y, int w, int h)
        {
            Color pixel = ((Bitmap)work_image).GetPixel(x, y);
            R = pixel.R; G = pixel.G; B = pixel.B;
            int R_minn = 255; int G_minn = 255; int B_minn = 255;
            int R_maxx = 0; int G_maxx = 0; int B_maxx = 0;

            for (int i = x; i < x+h; i++)
            {
                for (int j = y; j < y+w; j++)
                {
                    pixel = ((Bitmap)work_image).GetPixel(i, j);
                    R = (R + pixel.R)/2;
                    G = (G + pixel.G)/2;
                    B = (B + pixel.B)/2;
                    if (R_minn > R) R_minn = R;
                    else if (G_minn > G) G_minn = G;
                    else if (B_minn > B) B_minn = B;
                    else if (R_maxx < R) R_maxx = R;
                    else if (G_maxx < G) G_maxx = G;
                    else if (B_maxx < B) B_maxx = B;
                }
            }
            B_min.Text = R_minn.ToString();
            G_min.Text = G_minn.ToString();
            R_min.Text = B_minn.ToString();
            B_max.Text = R_maxx.ToString();
            G_max.Text = G_maxx.ToString();
            R_max.Text = B_maxx.ToString();
            pictureBox1.Refresh();
        }

        public void clear()
        {
            //Graphics graphics = Graphics.FromImage(pictureBox1.Image);
            //graphics.FillRectangle(Brushes.White, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
            Graphics graphics2 = Graphics.FromImage(pictureBox2.Image);
            graphics2.FillRectangle(Brushes.Black, new Rectangle(0, 0, pictureBox2.Width, pictureBox2.Height));
            output_image = (Bitmap)work_image.Clone();
            pictureBox1.Image = output_image;
            Output_string.Text = "";
            pictureBox1.Refresh();
            pictureBox2.Refresh();
        }
        private void Clear_but_Click(object sender, EventArgs e)
        {
            if (Open_flag)
            {
                clear();
            }
            else MessageBox.Show("First of all open some image");
        }
        private void Start_but_Click(object sender, EventArgs e)
        {
            if (Open_flag)
            {
                Graphics graphics = Graphics.FromImage(pictureBox2.Image);
                if (Start_but.Text != "Refresh")
                {
                    detect_claster(pictureBox2, Int32.Parse(B_min.Text), Int32.Parse(B_max.Text), Int32.Parse(G_min.Text), Int32.Parse(G_max.Text), Int32.Parse(R_min.Text), Int32.Parse(R_max.Text));
                    pictureBox2.Refresh();
                    Start_but.Text = "Refresh";
                }
                else
                {
                    Start_but.Text = "Start find color";
                    graphics.FillRectangle(Brushes.Black, new Rectangle(0, 0, pictureBox2.Width, pictureBox2.Height));
                    pictureBox2.Refresh();
                }
            }
            else MessageBox.Show("First of all open some image");
        }
        List<Rectangle> list_claster = new List<Rectangle>();
        public int detect_claster(PictureBox pictureBox, int R_minn, int R_maxx, int G_minn, int G_maxx, int B_minn, int B_maxx, bool is_detect_claster = false)
        {
            Graphics graphics = Graphics.FromImage(pictureBox1.Image);
            list_claster.Clear();
            int[,] frame = new int[work_image.Width, work_image.Height];
            Rectangle rectangle = new Rectangle();
            Pen pen = new Pen(Color.Black);
            for (int i = 0; i < work_image.Width; i++)
            {
                for (int j = 0; j < work_image.Height; j++)
                {
                    Color pixel = ((Bitmap)work_image).GetPixel(i, j);
                    if (pixel.R >= R_minn && pixel.R <= R_maxx && pixel.B >= B_minn && pixel.B <= B_maxx && pixel.G >= G_minn && pixel.G <= G_maxx)
                    {
                        frame[i, j] = 1;
                        ((Bitmap)pictureBox2.Image).SetPixel(i, j, Color.White);
                    }
                }
            }
            pictureBox2.Refresh();
            progressBar2.Maximum = work_image.Width;
            for (int i = 10; i < work_image.Width; i += 10)
            {
                for (int j = 10; j < work_image.Height; j += 10)
                {
                    if (frame[i, j] == 1)
                    {
                        int k = 1;
                        bool last = false;
                        double f;
                        while (true )
                        {
                            if (last) f = counttt(frame, i, j, k, true);
                            else f = counttt(frame, i, j, k);
                            if (f < 0.2 && !last) break;
                            else if (f > 0.4)
                            {
                                k++;
                                last = true;
                            }
                            else if (f <= 0.4 && f >= 0.2)
                            {
                                rectangle.X = i - 5 * (k - 1);
                                rectangle.Y = j - 5 * (k - 1);
                                rectangle.Height = 10 * (k - 1);
                                rectangle.Width = 10 * (k - 1);
                                pictureBox1.Refresh();
                                list_claster.Add(rectangle);
                                break;
                            }
                        }
                    }
                }
                progressBar2.Value = i;
            }
            progressBar2.Value = 0;
            int r = 0;
            pen = new Pen(Color.Blue);
            while (list_claster.Count > 1)
            {
                int g = list_claster.Count;
                while (r < list_claster.Count)
                {
                    while (r < list_claster.Count && (list_claster[r].Width == 0 || list_claster[r].Width == 0)) list_claster.RemoveAt(r);
                    int j = r+1;
                    while (j < list_claster.Count)
                    {
                        while (j < list_claster.Count && (list_claster[j].Width == 0 || list_claster[j].Width == 0)) list_claster.RemoveAt(j);
                        if (j < list_claster.Count && check_claster(list_claster[r], list_claster[j])) add_claster(list_claster[r], list_claster[j]);
                        else j++;
                    }
                    r++;
                }
                r = 0;
                if (g - list_claster.Count <= 0) break;
                g = list_claster.Count;
            }
            if (list_claster.Count == 1 && list_claster[0].Height + list_claster[0].Width < 2 * Int32.Parse(min_claster_size.Text)) list_claster.Clear();
            for (int k = 0; k < list_claster.Count; k++)
            {
                graphics.DrawRectangle(pen, list_claster[k]);
            }
            pictureBox2.Refresh();
            pictureBox1.Refresh();
            return list_claster.Count;

        }
        public void add_claster(Rectangle last, Rectangle neww)
        {
            int x_min = Math.Min(last.X, neww.X);
            int x_max = Math.Max(last.X + last.Width, neww.X + neww.Width);
            int y_min = Math.Min(last.Y, neww.Y);
            int y_max = Math.Max(last.Y + last.Height, neww.Y + neww.Height);
            if ((x_max - x_min >= Int32.Parse(min_claster_size.Text) && y_max - y_min >= Int32.Parse(min_claster_size.Text)) && (x_max - x_min <= Int32.Parse(max_claster_size.Text) && y_max - y_min >= Int32.Parse(max_claster_size.Text)))
            {
                list_claster.Remove(last);
                list_claster.Remove(neww);
                list_claster.Add(new Rectangle(x_min, y_min, x_max - x_min, y_max - y_min));
            }
            else
            {
                if (last.Height * last.Width > neww.Height * neww.Width)
                {
                    list_claster.Remove(neww);
                    if (last.Height + last.Width <= 2 * Int32.Parse(min_claster_size.Text)) list_claster.Remove(last);
                }
                else
                {
                    list_claster.Remove(last);
                    if (neww.Height + neww.Width <= 2 * Int32.Parse(min_claster_size.Text)) list_claster.Remove(neww);
                }
            }
        }
        public bool check_claster(Rectangle first, Rectangle last)
        {
            int first_x = first.X+ first.Width / 2;
            int first_y = first.Y + first.Height / 2;
            int last_x = last.X + last.Width / 2;
            int last_y = last.Y + last.Height / 2;
            if ((last.X <= first_x && first_x <= last.X + last.Width) && (last.Y <= first_y && first_y <= last.Y + last.Height)) return true;
            else if ((first.X <= last_x && last_x <= first.X + first.Width) && (first.Y <= last_y && last_y <= first.Y + first.Height)) return true;
            return false;
        }
        public double counttt(int[,] frame, int i, int j, int h, bool tr = false)
        {
            int[] sum = new int[2] { 0, 0 };
            for (int k_x = i - 5*h; k_x < i + 5*h && i + 5 * h < 400 && k_x >= 0; k_x++)
            {
                for (int k_y = j - 5*h; k_y < j + 5*h && j + 5 * h < 400 && k_y >= 0; k_y++)
                {
                    sum[0] += frame[k_x, k_y];
                    sum[1]++;
                }
            }
            return (double)sum[0] / sum[1];
        }

        private void Start_trafic_but_Click(object sender, EventArgs e)
        {
            if (Open_flag) {
                clear();
                int rect = detect_claster(pictureBox1, 240, 255, 240, 255, 10, 80);
                if (rect != 0) Output_string.Text += " Yellow: "+ rect.ToString();

                rect = detect_claster(pictureBox1, 122, 202, 230, 255, 180, 255); 
                if (rect != 0) Output_string.Text += " Green: " + rect.ToString();

                rect = detect_claster(pictureBox1, 185, 229, 13, 140, 26, 115);
                if (rect != 0) Output_string.Text += " Red: " + rect.ToString();
                if (Output_string.Text == "") Output_string.Text = "No traffic lights detected";
            }
            else MessageBox.Show("First of all open some image");
        }

        private void filter_CheckedChanged(object sender, EventArgs e)
        {
        if (Open_flag) filtred_image();
        else MessageBox.Show("First of all open some image");
        }

        private void min_claster_size_TextChanged(object sender, EventArgs e)
        {
            //if (Int32.Parse(max_claster_size.Text) < Int32.Parse(min_claster_size.Text))
            //{
            //    MessageBox.Show("Min");
            //}
        }

        private void max_claster_size_TextChanged(object sender, EventArgs e)
        {
            if (Int32.Parse(max_claster_size.Text) < Int32.Parse(min_claster_size.Text))
            {
                MessageBox.Show("Min");
            }
        }
    }
}
