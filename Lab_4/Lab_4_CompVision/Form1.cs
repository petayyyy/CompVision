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
using OpenCvSharp.Extensions;

namespace Lab_4_CompVision
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();            
            list_sample.Add(new Mat(@"C:/Users/ilyah/Desktop/Data/Left.png"));
            list_sample.Add(new Mat(@"C:/Users/ilyah/Desktop/Data/Around.png"));
            list_sample.Add(new Mat(@"C:/Users/ilyah/Desktop/Data/Forward.png"));
            list_sample.Add(new Mat(@"C:/Users/ilyah/Desktop/Data/Stop.png"));
            list_sample.Add(new Mat(@"C:/Users/ilyah/Desktop/Data/Brick.png"));
            for (int i = 0; i < list_sample.Count; i++)
            {
                Cv2.InRange(list_sample[i], new Scalar(0, 0, 1), new Scalar(255, 255, 255), list_sample[i]);
            }
            H_max_bar.Value = blue_hsv[0];
            H_max_bar.Value = blue_hsv[3];
            S_min_bar.Value = blue_hsv[1];
            S_max_bar.Value = blue_hsv[4];
            V_min_bar.Value = blue_hsv[2];
            V_max_bar.Value = blue_hsv[5];

        }
        Image work_image = new Bitmap(640, 480);
        Image work_mask = new Bitmap(640, 480);
        Image shablon_image = new Bitmap(80, 80);
        Image work_mask_80 = new Bitmap(80, 80);
        int[,] work_data_80 = new int[80, 80];
        Image output_image = new Bitmap(640, 480);
        int[,] frame = new int[640, 480];
        int[,] frame_80 = new int[80, 80];
        int[,] shablon_80 = new int[80, 80];
        bool Open_flag = false;
        bool Open_shablon_flag = false;
        bool is_auto = true;
        bool is_cam = false;
        int[] blue_hsv = new int[6] { 117, 179, 0, 131, 255, 255 };
        int[] red_hsv = new int[6] { 0, 190, 0, 100, 255, 255 };
        int[] Blue = new int[6] { 0, 15, 0, 95, 30, 200 };
        int[] Red_light1 = new int[6] { 160, 255, 30, 104, 30, 122 };
        int[] Red_light2 = new int[6] { 90, 220, 15, 55, 20, 65 };
        int[] Red_dark = new int[6] { 55, 100, 0, 15, 0, 20 };
        int[,] contur = new int[2, 80];
        List<Rect> list_claster = new List<Rect>();
        List<Mat> list_sample = new List<Mat>();
        List<String> list_claster_name = new List<String> { "Left", "Around", "Forward", "Stop", "Brick" };
        private void Open_but_Click(object sender, EventArgs e)
        {
            //try
            //{
                DialogResult res = openFileDialog1.ShowDialog();
                if (res == DialogResult.OK)
                {
                    if (openFileDialog1.FileName.Contains(".mp4") || openFileDialog1.FileName.Contains(".avi"))
                    {
                        is_video = true;
                        video_capture.Open(openFileDialog1.FileName);
                        timer1.Start();
                        Graphics graphics2 = Graphics.FromImage(pictureBox2.Image);
                        list_claster.Clear();
                        graphics2.FillRectangle(Brushes.Black, new Rectangle(0, 0, pictureBox2.Width, pictureBox2.Height));
                        pictureBox1.Refresh();
                        pictureBox2.Refresh();
                        Cam_but.Enabled = false;
                    }
                    else
                    {
                        is_video = false;
                        input_flow = new Mat(openFileDialog1.FileName);
                        pictureBox1.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(input_flow);
                        list_claster.Clear();
                        work();
                    }
                    
                }
                else MessageBox.Show("Error, you don't take any file.");
            //}
            //catch (Exception ex)
           // {
           //     MessageBox.Show(ex.Message);
           //     MessageBox.Show("Error, your file have incorrect type. You must take .png, .jpg or .bmp.");
          //  }
        }
        Mat input_flow = new Mat();
        Mat output_flow = new Mat();
        Mat canny_flow = new Mat();
        Mat hsv_flow = new Mat();
        Mat blur_flow = new Mat();
        Mat smooth_flow = new Mat();
        Mat blue_flow = new Mat();
        Mat red_flow = new Mat();
        Mat mask_flow = new Mat();
        Mat masking_flow = new Mat();
        bool view_flag = true;
        bool is_video = false;
        bool is_mask = false;
        bool is_countor = false;
        bool is_detect = false;
        int[] mask_hsv = { 0, 0, 0, 255, 255, 255 };
        VideoCapture video_capture = new VideoCapture();
        private void Auto_flag_CheckedChanged(object sender, EventArgs e)
        {
        }
        public void work()
        {
            blue_hsv[0] = H_max_bar.Value;
            blue_hsv[3] = H_max_bar.Value;
            blue_hsv[1] = S_min_bar.Value;
            blue_hsv[4] = S_max_bar.Value;
            blue_hsv[2] = V_min_bar.Value;
            blue_hsv[5] = V_max_bar.Value;
            //try
            //{
            mask_hsv[0] = (int)H_min_bar.Value; mask_hsv[1] = (int)S_min_bar.Value; mask_hsv[2] = (int)V_min_bar.Value; mask_hsv[3] = (int)H_max_bar.Value; mask_hsv[4] = (int)S_max_bar.Value; mask_hsv[5] = (int)V_max_bar.Value;
            output_flow = input_flow.Clone();
            // RGB data from pixel
            if (point_click.X != -1)
            {
                Vec3b color = input_flow.Get<Vec3b>(point_click.Y, point_click.X); ;
                int b = color.Item0;
                int g = color.Item1;
                int r = color.Item2;
                Cv2.PutText(output_flow, "R: " + r.ToString() + " G: " + g.ToString() + " B: " + b.ToString(), point_click, HersheyFonts.Italic, 1, new Scalar(255, 0, 255));
            }
            // to hsv
            Cv2.CvtColor(input_flow, hsv_flow, ColorConversionCodes.RGB2HSV);
            // Filtred image
            Mat kernel = new Mat(rows: 3, cols: 3, type: MatType.CV_32FC1, data: new float[,] { { -2, -1, 0 }, { -1, 1, 1 }, { 0, 1, 2 } });
            Cv2.Filter2D(input_flow, blur_flow, MatType.CV_8U, kernel, anchor: new OpenCvSharp.Point(0, 0));
            // Blure
            Cv2.Blur(input_flow, smooth_flow, new OpenCvSharp.Size(11, 11));
            // to canny
            //Cv2.Canny(smooth_flow, canny_flow, 20, 135);
            Cv2.Canny(input_flow, canny_flow, 20, 135);

            if (is_mask)
            {
                // Mask
                red_flow = new Mat();
                Cv2.InRange(hsv_flow, new Scalar(blue_hsv[0], blue_hsv[1], blue_hsv[2]), new Scalar(blue_hsv[3], blue_hsv[4], blue_hsv[5]), mask_flow);
                Cv2.InRange(hsv_flow, new Scalar(0, 190, 0), new Scalar(100, 255, 255), red_flow);
                Cv2.BitwiseOr(mask_flow, red_flow, mask_flow);
                Cv2.BitwiseAnd(output_flow, output_flow, masking_flow, mask: mask_flow);
            }

            if (is_countor)
            {
                Cv2.FindContours(canny_flow, out OpenCvSharp.Point[][] countorss, out HierarchyIndex[] hierarchyIndexess, RetrievalModes.External, ContourApproximationModes.ApproxSimple);
                int d = 0;
                foreach (var contour in countorss)
                {
                    double ar = Cv2.ArcLength(contour, true);
                    OpenCvSharp.Point[][] cntr = { Cv2.ApproxPolyDP(contour, ar * 0.01, true) };
                    //Cv2.DrawContours(output_flow, cntr, 0, new Scalar(255, 0, 255));
                    Rect c = Cv2.BoundingRect(cntr[0]);
                    if (c.Width > 20 && c.Height > 20 && c.Width < 150 && c.Height < 150)
                    {
                        Cv2.Rectangle(output_flow, c, new Scalar(0, 0, 255));
                        Cv2.PutText(output_flow, c.ToString(), new OpenCvSharp.Point(c.X, c.Y), HersheyFonts.Italic, 0.5, new Scalar(255, 0, 255));
                    }
                }
                //is_countor = false;
            }
            if (is_detect)
            {
                // find object
                Cv2.InRange(hsv_flow, new Scalar(0, 190, 0), new Scalar(100, 255, 255), blue_flow);
                Cv2.FindContours(blue_flow, out OpenCvSharp.Point[][] countors, out HierarchyIndex[] hierarchyIndexes, RetrievalModes.External, ContourApproximationModes.ApproxSimple);
                foreach (var contour in countors)
                {
                    Rect c = Cv2.BoundingRect(contour);
                    if (c.Width > 20 && c.Height > 20 && c.Width < 150 && c.Height < 150)
                    {
                        list_claster.Add(c);
                    }
                }
                Cv2.InRange(hsv_flow, new Scalar(117, 179, 0), new Scalar(131, 255, 255), red_flow);
                Cv2.FindContours(red_flow, out countors, out hierarchyIndexes, RetrievalModes.External, ContourApproximationModes.ApproxSimple);
                foreach (var contour in countors)
                {
                    Rect c = Cv2.BoundingRect(contour);
                    if (c.Width > 20 && c.Height > 20 && c.Width < 150 && c.Height < 150)
                    {
                        list_claster.Add(c);
                    }
                }
                /*
                for (int i = 0; i < list_claster.Count; i++)
                {
                    int j = i + 1;
                    while (j < list_claster.Count)
                    {
                        if (list_claster[i].Contains(list_claster[j]) || list_claster[j].Contains(list_claster[i]) && i != j)
                        {
                            //MessageBox.Show("");
                            list_claster.RemoveAt(j);
                        }
                        else j++;
                    }
                }
                MessageBox.Show(list_claster.Count.ToString());
                */
                for (int i = 0; i < list_claster.Count; i++)
                {
                    float max_per = 0;
                    int max_index = -1;
                    Mat mini_blue_flow = blue_flow.Clone()[list_claster[i]];
                    for (int h = 0; h < list_sample.Count-2; h++)
                    {
                        Mat dd_flow = new Mat();
                        Cv2.Resize(mini_blue_flow, mini_blue_flow, list_sample[h].Size());
                        Cv2.BitwiseAnd(mini_blue_flow, mini_blue_flow, dd_flow, mask: list_sample[h]);
                        if (max_per < Cv2.CountNonZero(dd_flow))
                        {
                            max_per = Cv2.CountNonZero(dd_flow);
                            max_index = h;
                        }
                    }
                    Mat mini_red_flow = red_flow.Clone()[list_claster[i]];
                    for (int h = 3; h < list_sample.Count; h++)
                    {
                        Mat d_flow = new Mat();
                        Cv2.Resize(mini_red_flow, mini_red_flow, list_sample[h].Size());
                        Cv2.BitwiseAnd(mini_red_flow, mini_red_flow, d_flow, mask: list_sample[h]);
                        if (max_per < Cv2.CountNonZero(d_flow))
                        {
                            max_per = Cv2.CountNonZero(d_flow);
                            max_index = h;
                        }
                    }
                    Cv2.Rectangle(output_flow, list_claster[i], new Scalar(0, 0, 255));
                    Cv2.PutText(output_flow, list_claster_name[max_index].ToString(), new OpenCvSharp.Point(list_claster[i].X, list_claster[i].Y), HersheyFonts.Italic, 1, new Scalar(255, 0, 255));
                                    }
            }
            // Image to picturebox
            // input image
            pictureBox1.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(output_flow);
            pictureBox1.Refresh();
            // mask
            if (is_mask)
            {
                pictureBox2.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(masking_flow);
                pictureBox2.Refresh();
                pictureBox7.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(mask_flow);
                pictureBox7.Refresh();
                is_mask = false;
            }
            // canny
            pictureBox3.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(canny_flow);
            pictureBox3.Refresh();
            // hsv
            pictureBox4.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(hsv_flow);
            pictureBox4.Refresh();

            // blur
            pictureBox5.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(blur_flow);
            pictureBox5.Refresh();

            //pictureBox6.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(smooth_flow);
            //pictureBox6.Refresh();
            point_click = new OpenCvSharp.Point(-1, -1);
            //}
            //catch { }
        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            try
            {
                if (video_capture.IsOpened() && (is_cam || is_video))
                {
                    video_capture.Read(input_flow);
                    work_image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(input_flow);
                    pictureBox1.Image = (Bitmap)work_image.Clone();
                    pictureBox1.Refresh();
                }
            }
            catch
            {
                if (is_video)
                {
                    Refr_but.Text = "Restart video";
                }
            }
            work();
        }
        OpenCvSharp.Point point_click = new OpenCvSharp.Point(-1, -1);
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            point_click.X = e.X;
            point_click.Y = e.Y;
            work();
        }

        private void Create_mask_but_Click(object sender, EventArgs e)
        {
            if (!is_mask)
            {
                is_mask = true;
                work();
            }else is_mask = false;
        }

        private void Cam_but_Click_1(object sender, EventArgs e)
        {
            is_cam = true;
            Open_but.Enabled = false;
            timer1.Start();
            video_capture = new VideoCapture(0);
            video_capture.Open(0);
        }

        private void Refr_but_Click_1(object sender, EventArgs e)
        {
            if (Refr_but.Text == "Restart video")
            {
                video_capture.Open(openFileDialog1.FileName);
                Refr_but.Text = "Refresh";
            }
            else
            {
                try
                {
                    timer1.Stop();
                    is_cam = false;
                    is_video = false;
                    is_countor = false;
                    is_detect = false;
                    is_mask = false;
                    Cam_but.Enabled = true;
                    Open_but.Enabled = true;
                    //Graphics graphics2 = Graphics.FromImage(pictureBox2.Image);
                    //graphics2.FillRectangle(Brushes.Pink, new Rectangle(0, 0, pictureBox2.Width, pictureBox2.Height));
                    Graphics graphics = Graphics.FromImage(pictureBox1.Image);
                    graphics.FillRectangle(Brushes.Pink, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
                    pictureBox1.Refresh();
                    //pictureBox2.Refresh();
                    list_claster.Clear();
                    video_capture.Release();
                }
                catch { }
            }
        }

        private void Find_countours_but_Click(object sender, EventArgs e)
        {
            if (!is_countor)
            {
                is_countor = true;
                work();
            } else is_countor = false;
        }

        private void Find_object_but_Click(object sender, EventArgs e)
        {
            if (!is_detect)
            {
                is_detect = true;
                work();
            }
            else is_detect = false;
        }
    }
}
