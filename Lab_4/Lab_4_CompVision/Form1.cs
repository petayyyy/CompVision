using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

using OpenCvSharp;
//using OpenCvSharp.Extensions;

namespace Lab_4_CompVision
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //pictureBox1.Image = new Bitmap(640, 480);
            pictureBox2.Image = new Bitmap(640, 480);
            pictureBox3.Image = new Bitmap(80, 80);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.Image = new Bitmap(80, 80);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            dataGridView1.ColumnCount = 5;
            dataGridView1.RowCount = 1;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Columns[0].HeaderText = "X";
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].HeaderText = "Y";
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].HeaderText = "Width";
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].HeaderText = "Height";
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].HeaderText = "Density";
            dataGridView1.Columns[4].Width = 140;
            dataGridView1.Width = 540;

            //Thread thr = new Thread(cam_cap);
            //thr.Start();

        }
        Image work_image = new Bitmap(640, 480);
        Image work_mask = new Bitmap(640, 480);
        Image shablon_image = new Bitmap(80, 80);
        Image work_mask_80 = new Bitmap(80, 80);
        int[,] work_data_80 = new int[80,80];
        Image output_image = new Bitmap(640, 480);
        int [,] frame = new int[640, 480];
        int [,] frame_80 = new int[80, 80];
        int[,] shablon_80 = new int[80, 80];
        int[] Blue = new int[6] { 0, 15, 0, 95, 30, 200};
        int[] Red_light1 = new int[6] { 160, 255, 30, 104, 30, 122};
        int[] Red_light2 = new int[6] { 90, 220, 15, 55, 20, 65 };
        int[] Red_dark = new int[6] { 55, 100, 0, 15, 0, 20};
        int[,] contur = new int[2, 80];
        bool Open_flag = false;
        bool Open_shablon_flag = false;
        bool is_auto = true;
        List<Rectangle> list_claster = new List<Rectangle>();
        List<int[]> claster_point = new List<int[]>();
        private void Open_but_Click(object sender, EventArgs e)
        {
            cam_cap();

            try
            {
                DialogResult res = openFileDialog1.ShowDialog();
                if (res == DialogResult.OK)
                {
                    work_image = Image.FromFile(openFileDialog1.FileName);
                    Open_flag = true;
                    filtred_image();
                    output_image = (Bitmap)work_image.Clone();
                    pictureBox1.Image = output_image;

                }
                else MessageBox.Show("Error, you don't take any file.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Error, your file have incorrect type. You must take .png, .jpg or .bmp.");
            }
            Graphics graphics2 = Graphics.FromImage(pictureBox2.Image);
            list_claster.Clear();
            graphics2.FillRectangle(Brushes.Black, new Rectangle(0, 0, pictureBox2.Width, pictureBox2.Height));
            pictureBox1.Refresh();
            pictureBox2.Refresh();
        }

        public void cam_cap()
        {
            Mat input_flow = new Mat();
            Mat output_flow = new Mat();
            bool view_flag = true;
            VideoCapture video_capture = new VideoCapture(0);
            video_capture.Open(0);

            if (video_capture.IsOpened())
            {
                while (view_flag == true) //ѕолучение данных с камеры (при наличии)
                {
                    video_capture.Read(input_flow);
                    //pictureBox1.Image = input_flow.Clone();
                    pictureBox1.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(input_flow);
                    pictureBox1.Refresh();
                }
            }
        }
        public bool check_density(Rectangle rect, double d=0.50)
        {
            int[] sum = new int[2] { 0, 0 };
            for (int i=rect.X; i<rect.X+rect.Width && i < work_image.Width ; i++)
            {
                for(int j=rect.Y; j<rect.Y+rect.Height && j < work_image.Height; j++)
                {
                    sum[0] += frame[i, j];
                    sum[1]++;
                }
            }
            if ((double)sum[0] / sum[1] > d) return true;
            return false;
        }
        public void view_claster()
        {
            dataGridView1.RowCount = 1;
            for (int i = 0; i < list_claster.Count;i++)
            {
                dataGridView1.RowCount += 1;
                dataGridView1.Rows[i].Cells[0].Value = list_claster[i].X;
                dataGridView1.Rows[i].Cells[1].Value = list_claster[i].Y;
                dataGridView1.Rows[i].Cells[2].Value = list_claster[i].Width;
                dataGridView1.Rows[i].Cells[3].Value = list_claster[i].Height;
                dataGridView1.Rows[i].Cells[4].Value = counttt(frame, list_claster[i]);
            }
        }
        public double counttt(int[,] frame, Rectangle rect)
        {
            int[] sum = new int[2] { 0, 0 };
            int[] min_k = new int[4] { 640, 480, 0, 0 };
            if (rect.Width == 0) return 0;
            for (int k_x = rect.X; k_x < rect.X + rect.Width && k_x < work_image.Width && k_x >= 0; k_x++)
            {
                for (int k_y = rect.Y; k_y < rect.Y + rect.Height && k_y < work_image.Height && k_y >= 0 ; k_y++)
                {
                    sum[0] += frame[k_x, k_y];
                    sum[1]++;
                }
            }
            if (sum[1] != 0) return (double)sum[0] / sum[1];
            else return 0;
        }
        private void Start_but_Click(object sender, EventArgs e)
        {
            if (Open_flag)
            {
                Graphics graphics = Graphics.FromImage(pictureBox2.Image);
                if (Start_but.Text != "Refresh")
                {
                    detect_claster(pictureBox2, true);
                    pictureBox2.Refresh();
                    Start_but.Text = "Refresh";
                    is_auto = true;

                }
                else
                {
                    Start_but.Text = "Start auto detect";
                    graphics.FillRectangle(Brushes.Black, new Rectangle(0, 0, work_image.Width, work_image.Height));
                    pictureBox2.Refresh();
                }
            }
        }
        public void filtred_image()
        {
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
            R /= work_image.Width* work_image.Height;
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
            output_image = (Bitmap)work_image.Clone();
            pictureBox1.Image = output_image;
            pictureBox1.Refresh();
        }
        public int data_rgb(double data)
        {
            if (data > 255) return 255;
            else if (data < 0) return 0;
            return (int)data;
        }
        public Rectangle sum_clasters_by_two(Rectangle rect, Rectangle rect2)
        {
            int x_min = Math.Min(rect2.X, rect.X);
            int y_min = Math.Min(rect2.Y, rect.Y);
            int x_max = Math.Max(rect2.X + rect2.Width, rect.X + rect.Width);
            int y_max = Math.Max(rect2.Y + rect2.Height, rect.Y + rect.Height);
            return new Rectangle(x_min, y_min, x_max - x_min, y_max - y_min);            
        }
        public void analize_image(int x, int y, int m = 40, int x2 = 0, int y2 = 0)
        {
            Random random = new Random();
            Graphics graphics = Graphics.FromImage(pictureBox2.Image);
            Pen pen = new Pen(Color.Red);
            for (int i = 0; i < 10; i++)
            {
                claster_point.Add(new int[] { random.Next(x2, x), random.Next(y2, y) });
                list_claster.Add(new Rectangle(claster_point[i][0], claster_point[i][1], 0, 0));
            }

            for (int i = x2; i < x; i++)
            {
                for (int j = y2; j < y; j++)
                {
                    if (frame[i, j] == 1)
                    {
                        int min_radius_claster = 1000;
                        int min_index = 0;
                        for (int hi = 0; hi < claster_point.Count; hi++)
                        {
                            if (Math.Sqrt(Math.Pow(i - claster_point[hi][0], 2) + Math.Pow(j - claster_point[hi][1], 2)) <= min_radius_claster && Math.Sqrt(Math.Pow(i - claster_point[hi][0], 2) + Math.Pow(j - claster_point[hi][1], 2)) <= m)
                            {
                                min_radius_claster = (int)Math.Sqrt(Math.Pow(i - claster_point[hi][0], 2) + Math.Pow(j - claster_point[hi][1], 2));
                                min_index = hi;
                            }
                        }
                        if (min_radius_claster == 1000)
                        {
                            //MessageBox.Show("");
                            claster_point.Add(new int[] { i, j });
                            list_claster.Add(new Rectangle(i, j, 0, 0));
                        }
                        else
                        {
                            Rectangle clast = sum_clast(i, j, list_claster[min_index]);
                            list_claster[min_index] = clast;
                        }
                    }
                }
            }
            int p = 0;
            while(p < claster_point.Count)
            {
                if (list_claster[p].Width == 0)
                {
                    list_claster.RemoveAt(p);
                    claster_point.RemoveAt(p);
                }
                else
                {
                    //graphics.DrawRectangle(pen, list_claster[p]);
                    p++;
                }
            }
            pictureBox2.Refresh();
            //MessageBox.Show("");
        }
        public Rectangle find_contours(Rectangle rect, bool is_exit=false)
        {
            int x = 1000 , y = 1000;
            int h = 0, w = 0;  
            for (int i = rect.X+2; i < rect.X+rect.Width-2; i++)
            {
                for (int j = rect.Y+2; j < rect.Y + rect.Height-2; j++)
                {
                    if (frame[i,j] == 1) {
                        if (i < x)
                        {
                            x = i;
                        }
                        else if (i > w)
                        {
                            w = i;
                        }
                        if (j < y)
                        {
                            y = j;
                        }
                        else if (j > h)
                        {
                            h = j;
                        }
                    }
                }
            }
            if (x == 1000 || y == 1000) return new Rectangle(0,0,0,0);
            if (!is_exit)
            {
                bool flag = true;
                bool exit = true;
                while (x < 639 && x > 0 && w < 639 && w > 0 && exit)
                {
                    x--;
                    flag = true;
                    for (int i = y; i < h && i < 480; i++)
                    {
                        if (frame[x, i] == 1)
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag) exit = false;
                }
                flag = true;
                exit = true;
                while (x < 639 && x > 0 && w < 639 && w > 0 && exit)
                {
                    w++;
                    flag = true;
                    for (int i = y; i < h && i < 480; i++)
                    {
                        if (frame[w, i] == 1)
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag) exit = false;
                }
                flag = true;
                exit = true;
                while (y < 479 && y > 0 && h < 479 && h > 0 && exit)
                {
                    y--;
                    flag = true;
                    for (int i = x; i < w && i < 640; i++)
                    {
                        if (frame[i, y] == 1)
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag) exit = false;
                }
                flag = true;
                exit = true;
                while (y < 479 && y > 0 && h < 479 && h > 0 && exit)
                {
                    h++;
                    flag = true;
                    for (int i = x; i < w && i < 640; i++)
                    {
                        if (frame[i, h] == 1)
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag) exit = false;
                }
            }
            return new Rectangle(x, y, w-x, h-y);
        }
        public Rectangle sum_clast (int x, int y, Rectangle rect)
        {
            int x_min = Math.Min(x, rect.X);
            int y_min = Math.Min(y, rect.Y);
            int x_max = Math.Max(x, rect.X + rect.Width);
            int y_max = Math.Max(y, rect.Y + rect.Height);
            return new Rectangle(x_min, y_min, x_max-x_min, y_max-y_min);
        }
        public PictureBox resize(Rectangle rect, PictureBox pic, Image image)
        {
            try
            {
                pic.Size = new System.Drawing.Size(rect.Width, rect.Height);
                pic.Image = new Bitmap(rect.Width, rect.Height);
                for (int i = 0; i < rect.Width; i++)
                {
                    for (int j = 0; j < rect.Height; j++)
                    {
                        try
                        {
                            Color col = ((Bitmap)image).GetPixel(rect.X + i, rect.Y + j);
                            ((Bitmap)pic.Image).SetPixel(i, j, col);
                        }
                        catch { continue; }
                    }
                }
                pic.Image = new Bitmap(pic.Image, 80, 80);
                pic.Size = new System.Drawing.Size(100, 100);
                pic.Refresh();
                return pic;
            }
            catch { return pic; }
        }
        public void find_all_countours(double d = 0.1, bool flag = false)
        {
            int v = 0;
            for (int u = 0; u < 2; u++)
            {
                while (v < list_claster.Count)
                {
                    list_claster[v] = find_contours(list_claster[v]);
                    if (flag)
                    {
                        if (list_claster[v].Width != 0 && list_claster[v].Height != 0 || check_density(list_claster[v], d))
                        {
                            claster_point[v] = new int[] { list_claster[v].X + list_claster[v].Width / 2, list_claster[v].Y + list_claster[v].Height / 2 };
                            v++;
                        }
                        else
                        {
                            claster_point.RemoveAt(v);
                            list_claster.RemoveAt(v);
                        }
                    }
                    else
                    {
                        if (list_claster[v].Width != 0 && list_claster[v].Height != 0)
                        {
                            claster_point[v] = new int[] { list_claster[v].X + list_claster[v].Width / 2, list_claster[v].Y + list_claster[v].Height / 2 };
                            v++;
                        }
                        else
                        {
                            claster_point.RemoveAt(v);
                            list_claster.RemoveAt(v);
                        }
                    }
                }
            }
        }
        public void detect_claster(PictureBox pictureBox, bool is_auto = false, int R_minn = 0, int R_maxx = 255, int G_minn = 0, int G_maxx = 255, int B_minn = 0, int B_maxx = 255)
        {
            list_claster.Clear();
            claster_point.Clear();
            Graphics graphics = Graphics.FromImage(pictureBox2.Image);
            Graphics graphics1 = Graphics.FromImage(pictureBox1.Image);
            Pen pen = new Pen(Color.Red);
            frame =  new int[640, 480];
            progressBar1.Maximum = work_image.Width;
            for (int i = 0; i < work_image.Width; i++)
            {
                for (int j = 0; j < work_image.Height; j++)
                {
                    Color pixel = ((Bitmap)work_image).GetPixel(i, j);
                    if (is_auto)
                    {
                        if ( (pixel.R >= Red_light1[0] && pixel.R <= Red_light1[1] && pixel.B >= Red_light1[4] && pixel.B <= Red_light1[5] && pixel.G >= Red_light1[2] && pixel.G <= Red_light1[3]) ||
                            (pixel.R >= Red_light2[0]  && pixel.R <= Red_light2[1] && pixel.B >= Red_light2[4] && pixel.B <= Red_light2[5] && pixel.G >= Red_light2[2] && pixel.G <= Red_light2[3]) ||
                            (pixel.R >= Red_dark[0]    && pixel.R <= Red_dark[1]   && pixel.B >= Red_dark[4]   && pixel.B <= Red_dark[5]   && pixel.G >= Red_dark[2]   && pixel.G <= Red_dark[3])   ||
                            (pixel.R >= Blue[0]        && pixel.R <= Blue[1]       && pixel.B >= Blue[4]       && pixel.B <= Blue[5]       && pixel.G >= Blue[2]       && pixel.G <= Blue[3]) )
                        {
                            frame[i, j] = 1;
                            ((Bitmap)pictureBox2.Image).SetPixel(i, j, Color.White);
                        }
                    }
                    else
                    {
                        if (pixel.R >= R_minn && pixel.R <= R_maxx && pixel.B >= B_minn && pixel.B <= B_maxx && pixel.G >= G_minn && pixel.G <= G_maxx)
                        {
                            frame[i, j] = 1;
                            ((Bitmap)pictureBox2.Image).SetPixel(i, j, Color.White);
                        }
                    }
                }
                progressBar1.Value = i;
            }
            work_mask = (Bitmap)pictureBox2.Image.Clone();
            progressBar1.Value = 0;
            pictureBox2.Refresh(); 
            progressBar1.Maximum = work_image.Width;
            ///////////////////////////////
            analize_image(640, 480, 10);
            //////////////////////////
            for (int i = 0; i < list_claster.Count; i++)
            {
                int g = i+1;
                while (g < list_claster.Count)
                {
                    if (check_claster(list_claster[i], list_claster[g]))
                    {
                        Rectangle rect = sum_clasters_by_two(list_claster[i], list_claster[g]);
                        if (rect.Height != 0)
                        {
                            list_claster[i] = rect;
                            list_claster.RemoveAt(g);
                            claster_point.RemoveAt(g);
                            g--;
                        }
                    }
                    else break;
                    g++;
                }
            }
            /////////////////////////
            find_all_countours(Int32.Parse(Density.Text));
            find_all_countours(Int32.Parse(Density.Text));
            //////////////////////////////
            for (int i = 0; i < list_claster.Count; i++)
            {
                int g = 0;
                while (g < list_claster.Count && i < list_claster.Count)
                {
                    if (g != i)
                    {
                        if (list_claster[i].X == list_claster[g].X && list_claster[i].Y == list_claster[g].Y)
                        {
                            list_claster.RemoveAt(g);
                            claster_point.RemoveAt(g);
                            g--;
                        }
                        else if ((list_claster[i].Width + list_claster[i].X) == (list_claster[g].Width + list_claster[g].X) && (list_claster[i].Height + list_claster[i].Y) == (list_claster[g].Height + list_claster[g].Y) ||
                            (list_claster[i].Width + list_claster[i].X) == (list_claster[g].Width + list_claster[g].X) && (list_claster[i].Y) == (list_claster[g].Y))
                        {
                            if (list_claster[i].Width + list_claster[i].Height > list_claster[g].Width + list_claster[g].Height)
                            {
                                list_claster.RemoveAt(i);
                                claster_point.RemoveAt(i);
                            }
                            else
                            {
                                list_claster.RemoveAt(g);
                                claster_point.RemoveAt(g);
                                g--;
                            }
                        }
                        else if (check_claster(list_claster[i], list_claster[g]))
                        {
                            if (list_claster[i].Width + list_claster[i].Height > list_claster[g].Width + list_claster[g].Height)
                            {
                                list_claster.RemoveAt(g);
                                claster_point.RemoveAt(g);
                                g--;
                            }
                            else
                            {
                                list_claster.RemoveAt(i);
                                claster_point.RemoveAt(i);
                            }
                        }
                        try
                        {
                            if (list_claster[g].Width < Int32.Parse(Min_size.Text.ToString()) || list_claster[g].Height < Int32.Parse(Min_size.Text.ToString()) ||
                            list_claster[g].Width > Int32.Parse(Max_size.Text.ToString()) || list_claster[g].Height > Int32.Parse(Max_size.Text.ToString()) ||
                            !check_density(list_claster[g], (double)Int32.Parse(Density.Text) / 100))
                            {
                                list_claster.RemoveAt(g);
                                claster_point.RemoveAt(g);
                                g--;
                            }
                        }
                        catch { }
                    }
                    g++;
                }
            }
            view_claster();
        }
        public bool check_claster(Rectangle first, Rectangle last)
        {           
            if ( (first.X >= last.X && first.X <= last.X + last.Width) && (first.Y >= last.Y && first.Y <= last.Y + last.Height) ) return true;
            else if ((first.X + first.Width >= last.X && first.X + first.Width <= last.X + last.Width) && (first.Y >= last.Y && first.Y <= last.Y + last.Height)) return true;
            else if ((first.X >= last.X && first.X <= last.X + last.Width) && (first.Y + first.Height >= last.Y && first.Y + first.Height <= last.Y + last.Height)) return true;
            else if ((first.X + first.Width >= last.X && first.X + first.Width  <= last.X + last.Width) && (first.Y + first.Height >= last.Y && first.Y + first.Height <= last.Y + last.Height)) return true;
            
            else if ((last.X >= first.X && last.X <= first.X + first.Width) && (last.Y >= first.Y && last.Y <= first.Y + first.Height)) return true;
            else if ((last.X + last.Width >= first.X && last.X + last.Width <= first.X + first.Width) && (last.Y >= first.Y && last.Y <= first.Y + first.Height)) return true;
            else if ((last.X >= first.X && last.X <= first.X + first.Width) && (last.Y + last.Height >= first.Y && last.Y + last.Height <= first.Y + first.Height)) return true;
            else if ((last.X + last.Width >= first.X && last.X + last.Width <= first.X + first.Width) && (last.Y + last.Height >= first.Y && last.Y + last.Height <= first.Y + first.Height)) return true;
            
            return false;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                Graphics graphics = Graphics.FromImage(pictureBox1.Image);
                Pen pen = new Pen(Color.Red);
                graphics.DrawRectangle(pen, list_claster[e.RowIndex]);
                pictureBox1.Refresh();
                graphics = Graphics.FromImage(pictureBox3.Image);
                graphics.FillRectangle(Brushes.White, new Rectangle(0, 0, pictureBox3.Width, pictureBox3.Height));
                //graphics = Graphics.FromImage(pictureBox4.Image);
                //graphics.FillRectangle(Brushes.White, new Rectangle(0, 0, pictureBox4.Width, pictureBox4.Height));

                pictureBox3 = resize(list_claster[e.RowIndex], pictureBox3, work_image);

                pictureBox3.Refresh();
            }
        }
        private void Start_col_but_Click(object sender, EventArgs e)
        {
            if (Open_flag)
            {
                Graphics graphics = Graphics.FromImage(pictureBox2.Image);
                if (Start_col_but.Text != "Refresh")
                {
                    detect_claster(pictureBox2, false, Int32.Parse(B_min.Text), Int32.Parse(B_max.Text), Int32.Parse(G_min.Text), Int32.Parse(G_max.Text), Int32.Parse(R_min.Text), Int32.Parse(R_max.Text));
                    pictureBox2.Refresh();
                    Start_but.Text = "Refresh";
                    is_auto = false;
                }
                else
                {
                    Start_but.Text = "Start detect by color";
                    graphics.FillRectangle(Brushes.Black, new Rectangle(0, 0, work_image.Width, work_image.Height));
                    pictureBox2.Refresh();
                }
            }
        }
        private void Open_sahblon_but_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res = openFileDialog1.ShowDialog();
                if (res == DialogResult.OK)
                {
                    shablon_image = Image.FromFile(openFileDialog1.FileName);
                    pictureBox4.Image = new Bitmap(shablon_image, 80, 80);
                    pictureBox4.Size = new System.Drawing.Size(100, 100);
                    pictureBox4.Refresh();
                    Open_shablon_flag = true;
                }
                else MessageBox.Show("Error, you don't take any file.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Error, your file have incorrect type. You must take .png, .jpg or .bmp.");
            }
            pictureBox4.Refresh();
        }
        public bool shablon_analyze()
        {
            contur = new int[2, 80];
            shablon_80 = new int[80, 80];
            int count = 0;
            for (int j = 0; j < pictureBox4.Image.Height; j++)
            {
                int first = -1;
                int last = -1;
                for (int i = 0; i < pictureBox4.Image.Width; i++)
                {
                    Color pixel = ((Bitmap)pictureBox4.Image).GetPixel(i, j);
                    if (is_auto)
                    {
                        if ((pixel.R >= Red_light1[0] && pixel.R <= Red_light1[1] && pixel.B >= Red_light1[4] && pixel.B <= Red_light1[5] && pixel.G >= Red_light1[2] && pixel.G <= Red_light1[3]) ||
                            (pixel.R >= Red_light2[0] && pixel.R <= Red_light2[1] && pixel.B >= Red_light2[4] && pixel.B <= Red_light2[5] && pixel.G >= Red_light2[2] && pixel.G <= Red_light2[3]) ||
                            (pixel.R >= Red_dark[0] && pixel.R <= Red_dark[1] && pixel.B >= Red_dark[4] && pixel.B <= Red_dark[5] && pixel.G >= Red_dark[2] && pixel.G <= Red_dark[3]))
                        {
                            shablon_80[i, j] = 1;
                            if (first == -1) first = i;
                            last = i;
                            count++;
                            //((Bitmap)pictureBox4.Image).SetPixel(i, j, Color.White);
                        }
                        else if (pixel.R >= Blue[0] && pixel.R <= Blue[1] && pixel.B >= Blue[4] && pixel.B <= Blue[5] && pixel.G >= Blue[2] && pixel.G <= Blue[3])
                        {
                            shablon_80[i, j] = 1;
                            if (first == -1) first = i;
                            last = i;
                            count--;
                            //((Bitmap)pictureBox4.Image).SetPixel(i, j, Color.White);
                        }
                    }
                    else
                    {
                        if (pixel.R >= Int32.Parse(R_min.Text) && pixel.R <= Int32.Parse(R_max.Text) && pixel.B >= Int32.Parse(B_min.Text) && pixel.B <= Int32.Parse(B_max.Text) && pixel.G >= Int32.Parse(G_min.Text) && pixel.G <= Int32.Parse(G_max.Text))
                        {
                            shablon_80[i, j] = 1;
                            if (first == -1) first = i;
                            last = i;
                            //((Bitmap)pictureBox4.Image).SetPixel(i, j, Color.White);
                        }
                    }
                }
                contur[0, j] = first;
                contur[1, j] = last;           
            }           
            if (count > 0) return true;
            return false;
        }
        public double shablon_detect()
        {
            // return True if mask red and false if blue
            bool flag_color = shablon_analyze();
            frame_80 = new int[80, 80];
            for (int i = 0; i < pictureBox3.Image.Width; i++)
            {
                for (int j = 0; j < pictureBox3.Image.Height; j++)
                {
                    Color pixel = ((Bitmap)pictureBox3.Image).GetPixel(i, j);
                    
                    if (is_auto) { 
                        if (flag_color && ((pixel.R >= Red_light1[0] && pixel.R <= Red_light1[1] && pixel.B >= Red_light1[4] && pixel.B <= Red_light1[5] && pixel.G >= Red_light1[2] && pixel.G <= Red_light1[3]) ||
                                (pixel.R >= Red_light2[0] && pixel.R <= Red_light2[1] && pixel.B >= Red_light2[4] && pixel.B <= Red_light2[5] && pixel.G >= Red_light2[2] && pixel.G <= Red_light2[3]) ||
                                (pixel.R >= Red_dark[0] && pixel.R <= Red_dark[1] && pixel.B >= Red_dark[4] && pixel.B <= Red_dark[5] && pixel.G >= Red_dark[2] && pixel.G <= Red_dark[3])) ||
                                !flag_color && (pixel.R >= Blue[0] && pixel.R <= Blue[1] && pixel.B >= Blue[4] && pixel.B <= Blue[5] && pixel.G >= Blue[2] && pixel.G <= Blue[3]))
                        {
                            frame_80[i, j] = 1;
                            ((Bitmap)pictureBox3.Image).SetPixel(i, j, Color.White);
                        }
                    }
                    else
                    {
                        if (pixel.R >= Int32.Parse(R_min.Text) && pixel.R <= Int32.Parse(R_max.Text) && pixel.B >= Int32.Parse(B_min.Text) && pixel.B <= Int32.Parse(B_max.Text) && pixel.G >= Int32.Parse(G_min.Text) && pixel.G <= Int32.Parse(G_max.Text))
                        {
                            frame[i, j] = 1;
                            ((Bitmap)pictureBox2.Image).SetPixel(i, j, Color.White);
                        }
                    }
                }
            }
            ////////////////////////////
            int count_correct = 0;
            int count_incorrect = 0;
            for (int i = 0; i < pictureBox3.Image.Width; i++)
            {
                for (int j = 0; j < pictureBox3.Image.Height; j++)
                {
                    int r = 255;
                    int g = 255;
                    int b = 255;
                    
                    if (frame_80[i, j] == 1 && shablon_80[i, j] == 1 && contur[0, i] <= j && contur[1, i] >= j)
                    {
                        // Green
                        r = 0; b = 0;
                        count_correct++;
                    }
                    else if (frame_80[i, j] == 0 && shablon_80[i, j] == 0 && contur[0, i] <= j && contur[1, i] >= j)
                    {
                        // Dark Green
                        r = 0; g = 120; b = 0;
                        count_correct++;
                    }
                    else if (frame_80[i, j] == 1 && shablon_80[i, j] == 0 && contur[0, i] <= j && contur[1, i] >= j)
                    {
                        // Red
                        g = 0; b = 0;
                        count_incorrect++;
                    }
                    else if (frame_80[i, j] == 0 && shablon_80[i, j] == 1 && contur[0, i] <= j && contur[1, i] >= j)
                    {
                        // Dark Red
                        r = 120; g = 0; b = 0;
                        count_incorrect++;
                    }
                    else if (frame_80[i, j] == 1  && (contur[0, i] > j || contur[1, i] < j))
                    {
                        // Blue
                        r = 0; g = 0;
                    }
                    else if (frame_80[i, j] == 0 && (contur[0, i] > j || contur[1, i] < j))
                    {
                        // Dark Blue
                        r = 0; g = 0; b = 120;
                    }
                    ((Bitmap)pictureBox3.Image).SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }
            pictureBox3.Refresh();
            pictureBox4.Refresh();
            return Math.Round(((double)count_correct / (count_incorrect + count_correct)) * 100, 2);
        }
        private void Start_anal_but_Click(object sender, EventArgs e)
        {
            if (Open_flag)
            {
                if (Open_shablon_flag)
                {
                    double fff = shablon_detect();
                    if (fff == double.NaN) Result.Text = "Images match on - 0";
                    else Result.Text = "Images match on - " + fff.ToString();
                }
                else
                {
                    MessageBox.Show("You don't open any sample");
                }
            }
            else
            {
                MessageBox.Show("You don't open any image");
            }
        }

        private void Auto_flag_CheckedChanged(object sender, EventArgs e)
        {
            if (Auto_flag.Checked)
            {
                if (Open_shablon_flag)
                {
                    if (Open_flag)
                    {
                        detect_claster(pictureBox2, true);
                        double max_clast = 0.0;
                        int index_max_clast = 0;
                        for (int i = 0; i < list_claster.Count; i++)
                        {
                            Graphics graphics = Graphics.FromImage(pictureBox3.Image);
                            graphics.FillRectangle(Brushes.White, new Rectangle(0, 0, pictureBox3.Width, pictureBox3.Height));
                            pictureBox3 = resize(list_claster[i], pictureBox3, work_image);
                            pictureBox3.Refresh();
                            double ffff = shablon_detect();
                            if (ffff > max_clast)
                            {
                                index_max_clast = i;
                                max_clast = ffff;
                            }
                        }
                        Graphics graphics3 = Graphics.FromImage(pictureBox3.Image);
                        graphics3.FillRectangle(Brushes.White, new Rectangle(0, 0, pictureBox3.Width, pictureBox3.Height));
                        pictureBox3 = resize(list_claster[index_max_clast], pictureBox3, work_image);
                        pictureBox3.Refresh();
                        shablon_detect();
                        /////////////////////////////
                        Graphics graphics2 = Graphics.FromImage(pictureBox1.Image);
                        Pen pen = new Pen(Color.Red);
                        graphics2.DrawRectangle(pen, list_claster[index_max_clast]);
                        pictureBox1.Refresh();
                        if (max_clast == double.NaN) Result.Text = "Images match on - 0";
                        else Result.Text = "Images match on - " + max_clast.ToString();
                    }
                    else
                    {
                        MessageBox.Show("You don't open any image");
                    }
                }
                else
                {
                    MessageBox.Show("You don't open any sample");
                }
            }
            else
            {
                Graphics graphics = Graphics.FromImage(pictureBox2.Image);
                graphics.FillRectangle(Brushes.Black, new Rectangle(0, 0, work_image.Width, work_image.Height));
                pictureBox2.Refresh();
                pictureBox1.Image = (Bitmap)work_image.Clone();
                pictureBox1.Refresh();
            }
        }
    }
}
