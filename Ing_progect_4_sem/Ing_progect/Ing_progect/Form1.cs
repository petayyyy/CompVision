using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;

namespace Ing_progect
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            H_min_bar.Value = ball_hsv[0];
            S_min_bar.Value = ball_hsv[1];
            V_min_bar.Value = ball_hsv[2];

            H_max_bar.Value = ball_hsv[3];
            S_max_bar.Value = ball_hsv[4];
            V_max_bar.Value = ball_hsv[5];
        }
        int[] ball_hsv = { 14, 81, 107, 100, 169, 255 };
        int real_size_ball = 67; // in mm
        Mat input_flow = new Mat();
        Mat output_flow = new Mat();
        Mat pyr_flow = new Mat();
        Mat gray_flow = new Mat();
        Mat canny_flow = new Mat();
        Mat blue_flow = new Mat();
        Mat red_flow = new Mat();
        bool view_flag = true;
        bool is_cam = false;
        bool is_video = false;
        List<OpenCvSharp.Point> balls_coord = new List<OpenCvSharp.Point>();
        OpenCvSharp.Point ball_coord;
        VideoCapture video_capture = new VideoCapture();

        private void timer1_Tick(object sender, EventArgs e)
        {
            // bar to hsv 
            ball_hsv[0] = (int)H_min_bar.Value; ball_hsv[1] = (int)S_min_bar.Value; ball_hsv[2] = (int)V_min_bar.Value; ball_hsv[3] = (int)H_max_bar.Value; ball_hsv[4] = (int)S_max_bar.Value; ball_hsv[5] = (int)V_max_bar.Value;
            HSV_box.Text = H_min_bar.Value.ToString() + ", " + S_min_bar.Value.ToString() + ", " + V_min_bar.Value.ToString() + ", " + H_max_bar.Value.ToString() + ", " + S_max_bar.Value.ToString() + ", " + V_max_bar.Value.ToString();
            Par_box.Text = Par1_bar.Value.ToString() + ", " + Par2_bar.Value.ToString();
            try
            {
                if (video_capture.IsOpened() && (is_cam || is_video))
                {
                    video_capture.Read(input_flow);
                    pictureBox1.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(input_flow);
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
            // BGR to GRAY
            Cv2.CvtColor(input_flow, gray_flow, ColorConversionCodes.BGR2GRAY);
            // blur
            //Cv2.GaussianBlur(gray_flow, output_flow, new OpenCvSharp.Size(3, 3), 0);
            //Cv2.GaussianBlur(gray_flow, gray_flow, new OpenCvSharp.Size(11, 11), 0);
            //Cv2.GaussianBlur(input_flow, input_flow, new OpenCvSharp.Size(33, 33), 0);
            // to canny
            Cv2.Canny(gray_flow, canny_flow, 100, 150);
            //Cv2.FindContours(canny_flow, out OpenCvSharp.Point[][] canny_countors, out HierarchyIndex[] canny_hierarchyIndexes, RetrievalModes.External, ContourApproximationModes.ApproxSimple);

            // to hsv
            Cv2.GaussianBlur(input_flow, output_flow, new OpenCvSharp.Size(33, 33), 0);
            Cv2.CvtColor(output_flow, output_flow, ColorConversionCodes.BGR2HSV);
            Cv2.InRange(output_flow, new Scalar(ball_hsv[0], ball_hsv[1], ball_hsv[2]), new Scalar(ball_hsv[3], ball_hsv[4], ball_hsv[5]), blue_flow);
            pyr_flow = blue_flow.Clone();
            Cv2.Erode(blue_flow, blue_flow, null, iterations: 2);
            Cv2.Dilate(blue_flow, blue_flow, null, iterations: 2);
            Cv2.FindContours(blue_flow, out OpenCvSharp.Point[][] countors, out HierarchyIndex[] hierarchyIndexes, RetrievalModes.External, ContourApproximationModes.ApproxSimple);
            try
            {
                foreach (var contour in countors)
                {
                    Moments mom = Cv2.Moments(contour, true);
                    if (mom.M00 > 100)
                    {
                        float rad;
                        Cv2.MinEnclosingCircle(OpenCvSharp.InputArray.Create(contour), out OpenCvSharp.Point2f coord, out rad);

                        double ar = Cv2.ArcLength(contour, true);
                        //OpenCvSharp.Point[][] cntr = { Cv2.ApproxPolyDP(contour, ar * 0.01, true) };
                        //Cv2.DrawContours(input_flow, cntr, 0, new Scalar(255, 0, 255));
                        //Cv2.DrawContours(input_flow, countors, i, new Scalar(255, 0, 255));

                        //ball_coord = new OpenCvSharp.Point(mom.M10 / mom.M00, mom.M01 / mom.M00);
                        // balls_coord.Add(ball_coord);
                        Cv2.PutText(input_flow, coord.ToString(), (OpenCvSharp.Point)coord, HersheyFonts.Italic, 1, new Scalar(255, 0, 255));
                        Cv2.Circle(input_flow, (OpenCvSharp.Point)coord, (int)rad, Scalar.FromRgb(255, 0, 255), 1);

                        //CircleSegment[] circles = Cv2.HoughCircles(gray_flow, HoughModes.Gradient, 1, gray_flow.Height/8, 150, 50, 1, 200);
                        if ((int)coord.X - (int)rad > 0 && (int)coord.Y - (int)rad > 0 && (int)rad * 2 + (int)coord.X - (int)rad < gray_flow.Width && (int)coord.Y + (int)rad < gray_flow.Height)
                        {
                            if ((int)coord.X - (int)rad - (int)rad > 0 && (int)coord.Y - (int)rad - (int)rad > 0 && (int)rad + (int)coord.X + (int)rad < gray_flow.Width && (int)coord.Y + (int)rad + (int)rad < gray_flow.Height)
                            {
                                pyr_flow = new Mat(pyr_flow, new Rect((int)coord.X - (int)rad - (int)rad, (int)coord.Y - (int)rad - (int)rad, (int)rad * 4, (int)rad * 4));
                            }
                            else pyr_flow = new Mat(pyr_flow, new Rect((int)coord.X - (int)rad, (int)coord.Y - (int)rad, (int)rad * 2, (int)rad * 2));
                            CircleSegment[] circles = Cv2.HoughCircles(pyr_flow, HoughModes.Gradient, 1, gray_flow.Height / 8, Par1_bar.Value, Par2_bar.Value, 0, 0);
                            Cv2.PutText(input_flow, circles.Length.ToString(), new OpenCvSharp.Point(600, 400), HersheyFonts.Italic, 1, new Scalar(255, 0, 255));
                            foreach (var circle in circles)
                            {
                                //if (check_circl(circle, ball_coord))
                                //{
                                //    Cv2.Circle(input_flow, (OpenCvSharp.Point)circle.Center, (int)circle.Radius, Scalar.FromRgb(0, 0, 255), 10);
                                //    Cv2.Circle(input_flow, (OpenCvSharp.Point)circle.Center, 1, Scalar.FromRgb(0, 0, 0), 1);
                                //}
                                //Cv2.Circle(input_flow, (OpenCvSharp.Point)coord, (int)rad, Scalar.FromRgb(0, 0, 255), 1);
                                //Cv2.Circle(input_flow, (OpenCvSharp.Point)coord, 1, Scalar.FromRgb(0, 0, 0), 1);
                                Cv2.Circle(input_flow, (int)circle.Center.X + (int)coord.X - (int)rad - (int)rad, (int)circle.Center.Y + (int)coord.Y - (int)rad - (int)rad, (int)circle.Radius, Scalar.FromRgb(0, 0, 255), 1);
                                //Cv2.Circle(input_flow, (int)circle.Center.X + (int)coord.Y, (int)circle.Center.Y + (int)coord.Y, 1, Scalar.FromRgb(0, 0, 0), 1);
                            }
                        }
                        /*
                        foreach (var canny_countor in canny_countors)
                        {
                            double ar = Cv2.ArcLength(canny_countor, true);
                            //OpenCvSharp.Point[][] cntr = { Cv2.ApproxPolyDP(canny_countor, ar * 0.001, true) };
                            OpenCvSharp.Point[][] cntr = { canny_countor };
                            Cv2.DrawContours(input_flow, cntr, 0, new Scalar(0, 0, 255));
                        }
                        */
                    }
                }
            }
            catch { }//(Exception ex) { MessageBox.Show(Text, ex.Message); }
            
            /*
            //Cv2.FindContours(canny_flow, out OpenCvSharp.Point[][] countors, out HierarchyIndex[] hierarchyIndexes, RetrievalModes.List, ContourApproximationModes.ApproxSimple);
            for (int i = 0; i < circles.Length; i++)
            {
                if (circles[i].Radius * 2 > 50)
                {
                    Cv2.Circle(input_flow, (OpenCvSharp.Point)circles[i].Center, (int)circles[i].Radius, new Scalar(125), 2);
                }
            }

            try
            {
                for (double dp = 1; dp < 5; dp += 0.2)
                {
                    // we use min dist = 1, to make sure we can detect concentric circles
                    // we use standard values for other parameters (canny, ...)
                    // we use your min max values (the max may be important when dp varies)
                    CircleSegment[] circless = Cv2.HoughCircles(gray_flow, HoughModes.Gradient, dp, 1, 100, 100, 10, 128);
                    foreach (var circle in circless)
                    {
                        Cv2.Circle(input_flow, (OpenCvSharp.Point)circle.Center, (int)circle.Radius, Scalar.FromRgb(235, 20, 30), 1);
                    }
                }
            }
            catch { } 
            */

            //CircleSegment[] circles = Cv2.HoughCircles(gray_flow, HoughModes.Gradient, 1, 20, param1: 50, param2: 30, minRadius: 0);
                        // to hsv
            /*Cv2.CvtColor(input_flow, output_flow, ColorConversionCodes.RGB2HSV);
            
            // find object
            Cv2.InRange(output_flow, new Scalar(28, 119, 111), new Scalar(45, 255, 255), blue_flow);
            Cv2.FindContours(blue_flow, out OpenCvSharp.Point[][] countors, out HierarchyIndex[] hierarchyIndexes, RetrievalModes.External, ContourApproximationModes.ApproxSimple);
            try
            {
                int i = 0;
                foreach (var contour in countors)
                {
                    if (contour.Length > 10)
                    {
                        Cv2.DrawContours(input_flow, countors, i, new Scalar(0, 0, 255));
                    }
                    i++;
                }
            }
            catch { }
            */
            pictureBox1.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(input_flow);
            pictureBox1.Refresh();
            pictureBox2.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(canny_flow);
            pictureBox2.Refresh();
            pictureBox3.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(pyr_flow);
            pictureBox3.Refresh();
            pictureBox4.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(blue_flow);
            pictureBox4.Refresh();
        }
        public bool check_circl(CircleSegment circle, OpenCvSharp.Point ball_point)
        {
            if (Math.Pow((ball_point.X-circle.Center.X),2) + Math.Pow((ball_point.Y - circle.Center.Y), 2) < circle.Radius) return true;
            return false;
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
                    Cam_but.Enabled = true;
                    Graphics graphics2 = Graphics.FromImage(pictureBox2.Image);
                    graphics2.FillRectangle(Brushes.Black, new Rectangle(0, 0, pictureBox2.Width, pictureBox2.Height));
                    Graphics graphics = Graphics.FromImage(pictureBox1.Image);
                    graphics.FillRectangle(Brushes.White, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
                    pictureBox1.Refresh();
                    pictureBox2.Refresh();
                    video_capture.Release();

                }
                catch { }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res = openFileDialog1.ShowDialog();
                if (res == DialogResult.OK)
                {
                    if (openFileDialog1.FileName.Contains(".mp4") || openFileDialog1.FileName.Contains(".avi"))
                    {
                        is_video = true;
                        video_capture.Open(openFileDialog1.FileName);
                    }
                    else
                    {
                        is_video = false;
                        input_flow = new Mat(openFileDialog1.FileName);
                        pictureBox1.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(input_flow);
                    }
                    timer1.Start();
                    Graphics graphics2 = Graphics.FromImage(pictureBox2.Image);
                    graphics2.FillRectangle(Brushes.Black, new Rectangle(0, 0, pictureBox2.Width, pictureBox2.Height));
                    pictureBox1.Refresh();
                    pictureBox2.Refresh();
                    Cam_but.Enabled = false;
                }
                else MessageBox.Show("Error, you don't take any file.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Error, your file have incorrect type. You must take .png, .jpg or .bmp.");
            }
        }
    }
}
