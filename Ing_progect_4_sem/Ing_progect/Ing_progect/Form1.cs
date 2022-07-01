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

            range_otbiv = Double.Parse(Range_box.Text);
            Otrisovka.Image = new Bitmap(350, 200);

            vect_final[1, 0] = (point_click.X - 320) / 640 * (range_otbiv * Math.Tan((double)(75/2) * (double)(Math.PI/180)));
            vect_final[1, 1] = (point_click.Y - 240) / 480 * (range_otbiv * Math.Tan((double)(50 / 2) * (double)(Math.PI / 180)));
            vect_final[1, 2] = range_otbiv;
        }
        int[] ball_hsv = { 14, 81, 107, 100, 169, 255 };
        float real_size_ball = 0.067f; // in m

        //Mat cam;
        Mat cam_matrix = new Mat(3, 3, MatType.CV_32FC1, new float[,] { { 1.35662728e+03f, 0.0f, 2.91998600e+02f }, { 0.0f, 1.37532524e+03f, 2.25387379e+02f }, { 0.0f, 0.0f, 1.0f } });

        // Dist coef
        Mat dis_coef = new Mat(14, 1, MatType.CV_32FC1, new float[] { -1.32575155e+00f, -7.35188200e+00f, 4.29782934e-02f, 7.66436446e-02f, 5.18928027e+01f, 0.00000000e+00f, 0.00000000e+00f, 0.00000000e+00f, 0.00000000e+00f, 0.00000000e+00f, 0.00000000e+00f, 0.00000000e+00f, 0.00000000e+00f, 0.00000000e+00f });
        OpenCvSharp.Point point_click = new OpenCvSharp.Point(100, 100);
        double range_otbiv = 0.50;
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
        double[,] vect_ball = new double[2, 3] {{ -1, -1, -1 }, {-1, -1, -1} };
        double[,] vect_final = new double[2, 3] { { -1, -1, -1 }, { -1, -1, -1 } };
        List<OpenCvSharp.CircleSegment> balls_coord = new List<OpenCvSharp.CircleSegment>();
        VideoCapture video_capture = new VideoCapture();
        private void timer1_Tick(object sender, EventArgs e)
        {
            // bar to hsv 
            //Real_coord.Text = "";
            ball_hsv[0] = (int)H_min_bar.Value; ball_hsv[1] = (int)S_min_bar.Value; ball_hsv[2] = (int)V_min_bar.Value; ball_hsv[3] = (int)H_max_bar.Value; ball_hsv[4] = (int)S_max_bar.Value; ball_hsv[5] = (int)V_max_bar.Value;
            HSV_box.Text = H_min_bar.Value.ToString() + ", " + S_min_bar.Value.ToString() + ", " + V_min_bar.Value.ToString() + ", " + H_max_bar.Value.ToString() + ", " + S_max_bar.Value.ToString() + ", " + V_max_bar.Value.ToString();
            Par_box.Text = Par1_bar.Value.ToString() + ", " + Par2_bar.Value.ToString();
            try
            {
                if (video_capture.IsOpened() && (is_cam || is_video))
                {
                    video_capture.Read(input_flow);
                    //pictureBox1.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(input_flow);
                    //pictureBox1.Refresh();
                }
            }
            catch
            {
                if (is_video)
                {
                    Refr_but.Text = "Restart video";
                }
            }
            CircleSegment[] circles;
            balls_coord.Clear();
            red_flow = new Mat();

            // BGR to GRAY
            Cv2.CvtColor(input_flow, gray_flow, ColorConversionCodes.BGR2GRAY);

            // to canny
            //Cv2.Canny(gray_flow, canny_flow, 100, 150);
            //Cv2.FindContours(canny_flow, out OpenCvSharp.Point[][] canny_countors, out HierarchyIndex[] canny_hierarchyIndexes, RetrievalModes.External, ContourApproximationModes.ApproxSimple);

            // blur
            Cv2.GaussianBlur(input_flow, output_flow, new OpenCvSharp.Size(33, 33), 0);
            // to hsv
            Cv2.CvtColor(output_flow, output_flow, ColorConversionCodes.BGR2HSV);
            Cv2.InRange(output_flow, new Scalar(ball_hsv[0], ball_hsv[1], ball_hsv[2]), new Scalar(ball_hsv[3], ball_hsv[4], ball_hsv[5]), blue_flow);
            // Work whith mask
            Cv2.Erode(blue_flow, blue_flow, null, iterations: 2);
            Cv2.Dilate(blue_flow, blue_flow, null, iterations: 2);
            // Find object in image
            Cv2.FindContours(blue_flow, out OpenCvSharp.Point[][] countors, out HierarchyIndex[] hierarchyIndexes, RetrievalModes.External, ContourApproximationModes.ApproxSimple);
            Cv2.BitwiseAnd(input_flow, input_flow, red_flow, mask: blue_flow);
            for (int i = 0; i < countors.Length; i++)
            {
                Moments mom = Cv2.Moments(countors[i], true);
                if (mom.M00 > 100)
                {
                    float rad;
                    pyr_flow = blue_flow.Clone();
                    Cv2.MinEnclosingCircle(OpenCvSharp.InputArray.Create(countors[i]), out OpenCvSharp.Point2f coord, out rad);
                    if ((int)coord.X - (int)rad > 0 && (int)coord.Y - (int)rad > 0 && (int)rad * 2 + (int)coord.X < pyr_flow.Width && (int)coord.Y + (int)rad * 2 < pyr_flow.Height)
                    {
                        if ((int)coord.X - (int)rad - (int)rad > 0 && (int)coord.Y - (int)rad - (int)rad > 0 && (int)rad * 4 + (int)coord.X < pyr_flow.Width && (int)coord.Y + (int)rad * 4 < pyr_flow.Height)
                        {
                            pyr_flow = new Mat(pyr_flow, new Rect((int)coord.X - (int)rad - (int)rad, (int)coord.Y - (int)rad - (int)rad, (int)rad * 4, (int)rad * 4));
                        }
                        else pyr_flow = new Mat(pyr_flow, new Rect((int)coord.X - (int)rad, (int)coord.Y - (int)rad, (int)rad * 2, (int)rad * 2));
                    }
                    circles = Cv2.HoughCircles(pyr_flow, HoughModes.Gradient, 1, pyr_flow.Height / 8, Par1_bar.Value, Par2_bar.Value, 0, 0);
                    if (circles.Length > 0 && circles.Length < 10)
                    {
                        balls_coord.Add(new CircleSegment(coord, rad));
                    }
                }
            }
            if (balls_coord.Count > 0)
            {
                int j, i = 0;
                while (i < balls_coord.Count)
                {
                    j = 0;
                    while (j < balls_coord.Count)
                    {
                        if (true && i != j)
                        {
                            //float x = Math.Min(balls_coord[i].Center.X, balls_coord[j].Center.X) + Math.Abs((balls_coord[i].Center - balls_coord[j].Center).X);
                            //float y = Math.Min(balls_coord[i].Center.Y, balls_coord[j].Center.Y) + Math.Abs((balls_coord[i].Center - balls_coord[j].Center).Y);
                            //OpenCvSharp.CircleSegment ball_coord = new OpenCvSharp.CircleSegment(new Point2f(x,y), balls_coord[i].Radius + balls_coord[j].Radius);
                            balls_coord.RemoveAt(j);
                            break;
                        } else j++;
                    }
                    i++;
                }
            }
            if (balls_coord.Count > 0)
            {
                Cv2.Circle(input_flow, (OpenCvSharp.Point)balls_coord[0].Center, (int)balls_coord[0].Radius, Scalar.FromRgb(255, 0, 255), 5);
                Cv2.Circle(input_flow, (OpenCvSharp.Point)balls_coord[0].Center, 1, Scalar.FromRgb(255, 0, 0), 2);
                Pix_coord.Text = balls_coord[0].Center.ToString();
                Mat tvec = convert_to_real(balls_coord[0].Center, balls_coord[0].Radius);
                Real_coord.Text = "x: " + Math.Round(tvec.Get<double>(0), 3).ToString() + "; y: " + Math.Round(tvec.Get<double>(1), 3).ToString() + "; z: " + Math.Round(tvec.Get<double>(2) / 2, 3).ToString();
                if (vect_ball[0,0] == -1)
                {
                    vect_ball[0, 0] = tvec.Get<double>(0); 
                    vect_ball[0, 1] = tvec.Get<double>(1); 
                    vect_ball[0, 2] = tvec.Get<double>(2);
                }
                else
                {
                    vect_ball[1, 0] = tvec.Get<double>(0);
                    vect_ball[1, 1] = tvec.Get<double>(1);
                    vect_ball[1, 2] = tvec.Get<double>(2);

                    OpenCvSharp.Point2d final_point = new OpenCvSharp.Point2d();
                    final_point.X = vect_ball[0, 0] - ((vect_ball[0,0] - vect_ball[1,0]) * ((int)(vect_ball[0, 2] / (vect_ball[0, 2] - vect_ball[1, 2]))));
                    final_point.Y = - (vect_ball[0, 1] - ((vect_ball[0,1] - vect_ball[1,1]) * ((int)(vect_ball[0, 2] / (vect_ball[0, 2] - vect_ball[1, 2])))));

                    vect_final[0, 0] = final_point.X;
                    vect_final[0, 1] = final_point.Y;
                    vect_final[0, 2] = 0;
                    FP_box.Text = "X = " + Math.Round(final_point.X, 2).ToString() + ", Y = " + Math.Round(final_point.Y, 2);
                    
                    if (final_point.X * 100 < Final_pointX_bar.Maximum && final_point.Y * 100 < Final_pointY_bar.Maximum && final_point.X * 100 > Final_pointX_bar.Minimum && final_point.Y * 100 > Final_pointY_bar.Minimum) { 
                        Final_pointX_bar.Value = (int)(100 * final_point.X);
                        Final_pointY_bar.Value = (int)(100 * final_point.Y);
                        double angle_X = - (180 / Math.PI) * (Math.Atan((double)(vect_ball[1, 2] / (vect_ball[1, 0] - vect_final[0, 0]))) + Math.Atan((double)(vect_final[1, 2] / (vect_final[1, 0] - vect_final[0, 0]))));
                        double angle_Y =  - (180 / Math.PI) * (Math.Atan((double)(vect_ball[1,2]/(vect_ball[1, 1]- vect_final[0, 1]))) + Math.Atan((double)(vect_final[1, 2] / (vect_final[1, 1] - vect_final[0, 1]))));

                        if (angle_X >  90) angle_X = 180 - angle_X;
                        if (angle_Y >  90) angle_Y -= 180;
                        if (angle_X < -90) angle_X = 180 + angle_X;
                        if (angle_Y < -90) angle_Y += 180;


                        // Otrisovka
                        Angles_box.Text = "dx = " + Math.Round(angle_X, 2).ToString() + ", dy = " + Math.Round(angle_Y, 2);
                        Graphics graphics = Graphics.FromImage(Otrisovka.Image);
                        graphics.FillRectangle(Brushes.Pink, new Rectangle(0, 0, Otrisovka.Image.Width, Otrisovka.Image.Height));

                        int x_size = (int)(100*angle_X/90);
                        int y_size = (int)(100*angle_Y/90);
                        Pen pen = new Pen(Color.Black);

                        graphics.DrawLine(pen, 50,     100 - x_size,     150,     100 + x_size * 2);
                        graphics.DrawLine(pen, 50 - 1, 100 - x_size - 1, 150 - 1, 100 + x_size * 2 - 1);
                        graphics.DrawString("x hitting the ball", new Font("", 12), Brushes.Black, 50, 150);

                        graphics.DrawLine(pen, 200,    100 - y_size,     300,     100 + y_size * 2);
                        graphics.DrawLine(pen, 200 - 1,100 - y_size - 1, 300 - 1, 100 + y_size * 2 - 1);
                        graphics.DrawString("y hitting the ball", new Font("", 12), Brushes.Black, 200, 150);
                        Otrisovka.Refresh();
                    }
                    else {
                        //Angles_box.Text = "";
                        //Graphics graphics2 = Graphics.FromImage(Otrisovka.Image);
                        //graphics2.FillRectangle(Brushes.Pink, new Rectangle(0, 0, Otrisovka.Image.Width, Otrisovka.Image.Height));
                        //Otrisovka.Refresh();
                    }
                }
            }
            else
            {
                //Angles_box.Text = "";
                //FP_box.Text = "";
                //Pix_coord.Text = "";
                //Graphics graphics2 = Graphics.FromImage(Otrisovka.Image);
                //graphics2.FillRectangle(Brushes.Pink, new Rectangle(0, 0, Otrisovka.Image.Width, Otrisovka.Image.Height));
                //Otrisovka.Refresh();
            }
            Mat input_calibr = input_flow.Clone();
            Cv2.Undistort(input_flow, input_calibr, cam_matrix, dis_coef, cam_matrix);
            //Cv2.Line(input_calibr, 0, 240, 640, 240, Scalar.FromRgb(255, 0, 0));
            //Cv2.Line(input_calibr, 320, 0, 320, 480, Scalar.FromRgb(255, 0, 0));

            // A4 work zone ////////////////////////
            //float[,] A4 = new float[,] { { 120f, 140f }, { 220f, 145f}, { 130.0f, 200.0f }, { 230.0f, 190.0f }};
            //float[,] A = new float[,] { { 100f, 100f }, { 200f, 100f}, { 100.0f, 300.0f }, { 200.0f, 200.0f } };

            //Mat A4_matrix = new Mat(4, 2, MatType.CV_32F, A4);
            //Mat A_matrix = new Mat(4, 2, MatType.CV_32F, A);

            //Mat gg = Cv2.GetPerspectiveTransform(A4_matrix, A_matrix);
            //Cv2.WarpPerspective(input_flow, gg, gg, new OpenCvSharp.Size(100, 100));
            ////////////////////////////////////////

            // Draw point otbiv
            Cv2.Line(input_calibr, point_click.X - 5, point_click.Y - 5, point_click.X + 5, point_click.Y + 5, Scalar.FromRgb(255, 0, 0), thickness:5);
            Cv2.Line(input_calibr, point_click.X - 5, point_click.Y + 5, point_click.X + 5, point_click.Y - 5, Scalar.FromRgb(255, 0, 0), thickness: 5);

            //pictureBox1.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(input_flow);
            pictureBox1.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(input_calibr);
            pictureBox1.Refresh();
            pictureBox2.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(blue_flow);
            pictureBox2.Refresh();
            try
            {
                pictureBox3.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(pyr_flow);
                //pictureBox3.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(gg);
                //pictureBox3.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(input_calibr);
            }
            catch { }
            pictureBox3.Refresh();
            pictureBox4.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(red_flow);
            pictureBox4.Refresh();
        }
        public float range_two_point (OpenCvSharp.Point2f first, OpenCvSharp.Point2f second)
        {
            return (float)(Math.Sqrt(Math.Pow(first.X - second.X,2) + Math.Pow(first.Y - second.Y,2)));
        }
        public bool check_circl(CircleSegment circle, OpenCvSharp.Point ball_point)
        {
            if (Math.Pow((ball_point.X-circle.Center.X),2) + Math.Pow((ball_point.Y - circle.Center.Y), 2) < circle.Radius) return true;
            return false;
        }
        public Mat convert_to_real(OpenCvSharp.Point2f cor, float radius)
        {            
            float[,] ball = new float[,] { { cor.X - radius, cor.Y - radius },                         { cor.X + radius, cor.Y - radius },                          { cor.X + radius, cor.Y + radius },                          { cor.X - radius, cor.Y + radius }                          };
            float[,] real = new float[,] { { -(float)real_size_ball/2, -(float)real_size_ball / 2, 0}, { (float)real_size_ball / 2, -(float)real_size_ball / 2, 0}, { (float)real_size_ball / 2, (float)real_size_ball / 2, 0 }, { -(float)real_size_ball / 2, (float)real_size_ball / 2, 0} };
            Mat ball_mat = new Mat(4, 3, MatType.CV_32F, real);
            Mat ball_pix = new Mat(4, 2, MatType.CV_32F, ball);
            
            Mat recv = new Mat();
            Mat tvec = new Mat();
            Mat points = new Mat();
            Cv2.SolvePnP(ball_mat, ball_pix, cam_matrix, dis_coef, recv, tvec);
            return tvec;
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
                timer1.Stop();
                is_cam = false;
                is_video = false;
                Cam_but.Enabled = true;
                Open_but.Enabled = true;
                Graphics graphics = Graphics.FromImage(pictureBox1.Image);
                graphics.FillRectangle(Brushes.Pink, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
                pictureBox1.Refresh();
                video_capture.Release();
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

        private void pictureBox1_Click(object sender, MouseEventArgs e)
        {
            point_click.X = e.X;
            point_click.Y = e.Y;
            vect_final[1, 0] = (point_click.X - 320) / 640 * (range_otbiv * Math.Tan((double)(75 / 2) * (double)(Math.PI / 180)));
            vect_final[1, 1] = (point_click.Y - 240) / 480 * (range_otbiv * Math.Tan((double)(50 / 2) * (double)(Math.PI / 180)));
            vect_final[1, 2] = range_otbiv;
        }
    }
}
