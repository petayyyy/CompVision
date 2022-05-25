using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_3_CompVision
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(640, 480);
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
            dataGridView1.Columns[2].HeaderText = "Height";
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].HeaderText = "Width";
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].HeaderText = "Density";
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Width = 500;
        }
        Image work_image = new Bitmap(640, 480);
        Image shablon_image = new Bitmap(80, 80);
        Image work_mask_80 = new Bitmap(80, 80);
        int[,] work_data_80 = new int[80,80];
        Image output_image = new Bitmap(640, 480);
        int R = 0; int G = 0; int B = 0;
        int [,] frame = new int[640, 480];
        int [,] frame_80 = new int[80, 80];
        int[] Blue = new int[6] { 0, 15, 0, 95, 30, 200};
        int[] Red_light1 = new int[6] { 160, 255, 30, 104, 30, 122};
        int[] Red_light2 = new int[6] { 90, 220, 15, 55, 20, 65 };
        int[] Red_dark = new int[6] { 55, 100, 0, 15, 0, 20};
        double Grid = 0.0;
        double len_claster = 50.0;
        bool Open_flag = false;
        List<Rectangle> list_claster = new List<Rectangle>();
        List<int[]> claster_point = new List<int[]>();
        Rectangle correct_rect = new Rectangle();
        private void Open_but_Click(object sender, EventArgs e)
        {
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
        public bool check_density(Rectangle rect)
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
            if ((double)sum[0] / sum[1] > 0.50) return true;
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
            if (counttt(frame, new Rectangle(x_min, y_min, x_max - x_min, y_max - y_min)) >= Int32.Parse(Density.Text))
            {
                return new Rectangle(x_min, y_min, x_max - x_min, y_max - y_min);
            }
            else if (rect.Width+rect.Height > rect2.Height+ rect2.Width && counttt(frame, rect) >= Int32.Parse(Density.Text))
            {
                return rect;
            }
            else if (counttt(frame, rect2) >= Int32.Parse(Density.Text))
            {
                return rect2;
            }
            else if (counttt(frame, new Rectangle(x_min + (x_max - x_min)/2, y_min + (y_max - y_min)/2, (x_max - x_min)/2, (y_max - y_min)/2)) >= Int32.Parse(Density.Text))
            {
                return new Rectangle(x_min + (x_max - x_min) / 2, y_min + (y_max - y_min) / 2, (x_max - x_min) / 2, (y_max - y_min) / 2);
            }
            else
            {
                return new Rectangle (0,0,0,0);
            }
        }
        public void analize_image(int x, int y, int m = 80, int x2 = 0, int y2 = 0)
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
        public Rectangle find_contours(Rectangle rect)
        {
            int x = 1000 , y = 1000;
            int h = 0, w = 0;
            for (int i = rect.X; i < rect.X+rect.Width; i++)
            {
                for(int j = rect.Y; j < rect.Y+ rect.Height; j++)
                {
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
        public bool in_rect (int x, int y, Rectangle rect)
        {
            if (rect.X <= x && x <= rect.X+rect.Width && rect.Y <= y && y <= rect.Y + rect.Height) return true;
            return false;
        }
        public void resize(Rectangle rect)
        {
            pictureBox3.Size = new Size(rect.Width, rect.Height);
            pictureBox3.Image = new Bitmap(rect.Width, rect.Height);
            for (int i = 0; i < rect.Width; i++)
            {
                for (int j = 0; j < rect.Height; j++)
                {
                    Color col = ((Bitmap)work_image).GetPixel(rect.X + i, rect.Y + j);
                    ((Bitmap)pictureBox3.Image).SetPixel(i, j, col);
                }
            }
            pictureBox3.Image = new Bitmap(pictureBox3.Image, 80, 80);
            pictureBox3.Size = new Size(80, 80);
            pictureBox3.Refresh();
        }
        public int detect_claster(PictureBox pictureBox, bool is_auto = false, int R_minn = 0, int R_maxx = 255, int G_minn = 0, int G_maxx = 255, int B_minn = 0, int B_maxx = 255)
        {
            list_claster.Clear();
            claster_point.Clear();
            Graphics graphics = Graphics.FromImage(pictureBox2.Image);
            Graphics graphics1 = Graphics.FromImage(pictureBox1.Image);
            Pen pen = new Pen(Color.Red);
            Rectangle rectangle = new Rectangle();
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
            progressBar1.Value = 0;
            pictureBox2.Refresh(); 
            progressBar1.Maximum = work_image.Width;
            ///////////////////////////////

            analize_image(640, 480, Int32.Parse(Max_size.Text));
            /*
            for (int k = 0; k < list_claster.Count; k++)
            {
                graphics.DrawRectangle(pen, list_claster[k]);
            }
             pictureBox2.Refresh();
            MessageBox.Show("");
            */
            int last = 0;
            for (int u = 0; u < 10; u++)
            //while (true)
            {
                last = claster_point.Count;
                int h = 0;
                while (h < claster_point.Count)
                {
                    list_claster[h] = find_contours(list_claster[h]);
                    double ff = counttt(frame, list_claster[h]);
                    //MessageBox.Show(ff.ToString());
                    if (ff * 100 <= 10)
                    {
                        claster_point.RemoveAt(h);
                        list_claster.RemoveAt(h);
                    }
                    else
                    {
                        if (ff * 100 < Int32.Parse(Density.Text))
                        {
                            //MessageBox.Show("");
                            if ((int)(list_claster[h].Width / list_claster[h].Height) > 1)
                            {
                                int x_rect = list_claster[h].X;
                                int y_rect = list_claster[h].Y;
                                int width_rect = (int)(list_claster[h].Width / ((int)(list_claster[h].Width / list_claster[h].Height)));
                                int height_rect = (int)(list_claster[h].Height / ((int)(list_claster[h].Width / list_claster[h].Height)));
                                for (int d = 0; d < (int)(list_claster[h].Width / list_claster[h].Height); d++)
                                {
                                    claster_point.Add(new int[] { x_rect + width_rect / 2, y_rect + height_rect / 2 });
                                    list_claster.Add(new Rectangle(x_rect, y_rect, width_rect, height_rect));
                                    x_rect += width_rect;
                                    y_rect += height_rect;
                                }
                                claster_point.RemoveAt(h);
                                list_claster.RemoveAt(h);
                                //graphics.FillRectangle(Brushes.Black, new Rectangle(0, 0, pictureBox2.Width, pictureBox2.Height));
                                //analize_image(list_claster[h].X + list_claster[h].Width, list_claster[h].Y + list_claster[h].Height, 50, list_claster[h].X, list_claster[h].Y);
                            }
                            else
                            {
                                claster_point[h] = new int[] { list_claster[h].X + list_claster[h].Height / 2, list_claster[h].Y + list_claster[h].Height / 2 };
                                list_claster[h] = new Rectangle(list_claster[h].X, list_claster[h].Y, list_claster[h].Height, list_claster[h].Height);
                            }
          
                            //}
                        }
                        else
                        {
                            int i = h + 1;
                            while (i < claster_point.Count)
                            {
                                if (check_claster(list_claster[h], list_claster[i]))
                                {
                                    Rectangle rect = sum_clasters_by_two(list_claster[h], list_claster[i]);
                                    if (rect.Height != 0)
                                    {
                                        list_claster[h] = rect;
                                        list_claster.RemoveAt(i);
                                    }
                                }
                                i++;
                            }
                        }
                    }
                    h++;
                }
                if (last == claster_point.Count) break;
            }
            
            //MessageBox.Show("");
            /*
            for (int i = 10; i < work_image.Width; i += 10)
            {
                for (int j = 10; j < work_image.Height; j += 10)
                {
                    if (frame[i, j] == 1)
                    {
                        int k = 1;
                        bool last = false;
                        double f;
                        while (true)
                        {
                            if (last) f = counttt(frame, i, j, k, true);
                            else f = counttt(frame, i, j, k);
                            if (f < 0.25 && !last) break;
                            else if (f > 0.55)
                            {
                                k++;
                                last = true;
                            }
                            else
                            {
                                rectangle.X = i - 5 * (k);
                                rectangle.Y = j - 5 * (k);
                                rectangle.Height = 10 * (k);
                                rectangle.Width = 10 * (k);
                                //graphics.DrawRectangle(pen, rectangle);
                                //pictureBox1.Refresh();
                                list_claster.Add(rectangle);
                                break;
                            }
                        }
                    }
                }
                progressBar1.Value = i;
            }
            progressBar1.Value = 0;
            int r = 0;
            pen = new Pen(Color.Blue);
            //MessageBox.Show(list_claster.Count.ToString());
            while (list_claster.Count > 1)
            {
                int g = list_claster.Count;
                while (r < list_claster.Count)
                {
                    while (r < list_claster.Count && (list_claster[r].Width == 0 || list_claster[r].Width == 0)) list_claster.RemoveAt(r);
                    int j = r + 1;
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
            */

            //////////////////////////////////////////
            if (list_claster.Count == 1 && list_claster[0].Height + list_claster[0].Width < 2 * Int32.Parse(Min_size.Text)) list_claster.Clear();
            for (int k = 0; k < list_claster.Count; k++)
            {
                graphics.DrawRectangle(pen, list_claster[k]);
            }
            pictureBox2.Refresh();
            pictureBox1.Refresh();

            view_claster();
            return list_claster.Count;
        }
        public bool check_claster(Rectangle first, Rectangle last)
        {
            int first_x = first.X + first.Width / 2;
            int first_y = first.Y + first.Height / 2;
            int last_x = last.X + last.Width / 2;
            int last_y = last.Y + last.Height / 2;
            double len = (double)(Math.Sqrt(Math.Pow(first.Width / 2, 2) + Math.Pow(first.Height / 2, 2)) + Math.Sqrt(Math.Pow(last.Width / 2, 2) + Math.Pow(last.Height / 2, 2)))/2;
            if ((last.X <= first_x && first_x <= last.X + last.Width) && (last.Y <= first_y && first_y <= last.Y + last.Height)) return true;
            else if ((first.X <= last_x && last_x <= first.X + first.Width) && (first.Y <= last_y && last_y <= first.Y + first.Height)) return true;
            else if (Math.Sqrt(Math.Pow(first_x - last_x, 2) + Math.Pow(first_y - last_y, 2)) < len) return true;
            return false;
        }
        public void add_claster(Rectangle last, Rectangle neww)
        {
            int x_min = Math.Min(last.X, neww.X);
            int x_max = Math.Max(last.X + last.Width, neww.X + neww.Width);
            int y_min = Math.Min(last.Y, neww.Y);
            int y_max = Math.Max(last.Y + last.Height, neww.Y + neww.Height);
            if ((x_max - x_min >= Int32.Parse(Min_size.Text) && y_max - y_min >= Int32.Parse(Min_size.Text)) && 
                (x_max - x_min <= Int32.Parse(Max_size.Text) && y_max - y_min <= Int32.Parse(Max_size.Text)))
            {
                if (check_density(new Rectangle(x_min, y_min, x_max - x_min, y_max - y_min)))
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
                        if (last.Height + last.Width <= 2 * Int32.Parse(Min_size.Text)) list_claster.Remove(last);
                    }
                    else
                    {
                        list_claster.Remove(last);
                        if (neww.Height + neww.Width <= 2 * Int32.Parse(Min_size.Text)) list_claster.Remove(neww);
                    }
                }
            }
            else
            {
                if (last.Height * last.Width > neww.Height * neww.Width)
                {
                    list_claster.Remove(neww);
                    if (last.Height + last.Width <= 2 * Int32.Parse(Min_size.Text)) list_claster.Remove(last);
                }
                else
                {
                    list_claster.Remove(last);
                    if (neww.Height + neww.Width <= 2 * Int32.Parse(Min_size.Text)) list_claster.Remove(neww);
                }
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Graphics graphics = Graphics.FromImage(pictureBox1.Image);
            Pen pen = new Pen(Color.Red);
            graphics.DrawRectangle(pen, list_claster[e.RowIndex]);
            pictureBox1.Refresh();
            graphics = Graphics.FromImage(pictureBox3.Image);
            graphics.FillRectangle(Brushes.White, new Rectangle(0, 0, pictureBox3.Width, pictureBox3.Height));
            graphics = Graphics.FromImage(pictureBox4.Image);
            graphics.FillRectangle(Brushes.White, new Rectangle(0, 0, pictureBox4.Width, pictureBox4.Height));

            resize(list_claster[e.RowIndex]);

            pictureBox3.Refresh();
            pictureBox4.Refresh();
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
                    pictureBox4.Image = shablon_image;

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

        private void Start_anal_but_Click(object sender, EventArgs e)
        {
            bool is_auto = true;
            if (Open_flag)
            {
                for (int i = 0; i < pictureBox3.Width; i++)
                {
                    for (int j=0; j < pictureBox3.Height; j++)
                    {
                        Color pixel = ((Bitmap)pictureBox3.Image).GetPixel(i, j);
                        if (is_auto)
                        {
                            if ((pixel.R >= Red_light1[0] && pixel.R <= Red_light1[1] && pixel.B >= Red_light1[4] && pixel.B <= Red_light1[5] && pixel.G >= Red_light1[2] && pixel.G <= Red_light1[3]) ||
                                (pixel.R >= Red_light2[0] && pixel.R <= Red_light2[1] && pixel.B >= Red_light2[4] && pixel.B <= Red_light2[5] && pixel.G >= Red_light2[2] && pixel.G <= Red_light2[3]) ||
                                (pixel.R >= Red_dark[0] && pixel.R <= Red_dark[1] && pixel.B >= Red_dark[4] && pixel.B <= Red_dark[5] && pixel.G >= Red_dark[2] && pixel.G <= Red_dark[3]) ||
                                (pixel.R >= Blue[0] && pixel.R <= Blue[1] && pixel.B >= Blue[4] && pixel.B <= Blue[5] && pixel.G >= Blue[2] && pixel.G <= Blue[3]))
                            {
                                frame_80[i, j] = 1;
                                ((Bitmap)pictureBox3.Image).SetPixel(i, j, Color.White);
                            }
                            else
                            {
                                frame_80[i, j] = 0;
                                ((Bitmap)pictureBox3.Image).SetPixel(i, j, Color.Black);
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
            }
            pictureBox3.Refresh();
        }
    }
}
