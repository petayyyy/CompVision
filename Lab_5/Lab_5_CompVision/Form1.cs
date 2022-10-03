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

namespace Lab_5_CompVision
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            H_min_bar.Value = mask_hsv[0]; S_min_bar.Value = mask_hsv[1]; V_min_bar.Value = mask_hsv[2]; H_max_bar.Value = mask_hsv[3]; S_max_bar.Value = mask_hsv[4]; V_max_bar.Value = mask_hsv[5];
        }
        bool is_cam = false;
        bool is_sample = false;
        bool is_video = false;
        bool is_puc = false;
        private void Open_but_Click(object sender, EventArgs e)
        {
            DialogResult res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                if (openFileDialog1.FileName.Contains(".mp4") || openFileDialog1.FileName.Contains(".avi"))
                {
                    is_video = true;
                    video_capture.Open(openFileDialog1.FileName);
                    pictureBox1.Refresh();
                    Cam_but.Enabled = false;
                }
                else
                {
                    is_video = false;
                    is_puc = true;
                    input_flow = new Mat(openFileDialog1.FileName);
                    pictureBox1.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(input_flow);
                    work();
                }
                timer1.Start();
            }
            else MessageBox.Show("Error, you don't take any file.");
        }
        Mat input_flow = new Mat();
        Mat output_flow = new Mat();
        Mat hsv_flow = new Mat();
        Mat calibr_flow = new Mat();
        Mat mask_flow = new Mat();
        Mat out_mask_flow = new Mat();
        Mat canny_flow = new Mat();
        Mat final_flow = new Mat();
        int[] mask_hsv = { 0, 0, 0, 100, 180, 180 };
        //Mat cam;
        Mat cam_matrix = new Mat(3, 3, MatType.CV_32FC1, new float[,] { { 1.35662728e+03f, 0.0f, 2.91998600e+02f }, { 0.0f, 1.37532524e+03f, 2.25387379e+02f }, { 0.0f, 0.0f, 1.0f } });
        // Dist coef
        Mat dis_coef = new Mat(14, 1, MatType.CV_32FC1, new float[] { -1.32575155e+00f, -7.35188200e+00f, 4.29782934e-02f, 7.66436446e-02f, 5.18928027e+01f, 0.00000000e+00f, 0.00000000e+00f, 0.00000000e+00f, 0.00000000e+00f, 0.00000000e+00f, 0.00000000e+00f, 0.00000000e+00f, 0.00000000e+00f, 0.00000000e+00f });

        VideoCapture video_capture = new VideoCapture();
        List<OpenCvSharp.Point> sample = new List<OpenCvSharp.Point>();
        List<OpenCvSharp.Point> work_object = new List<OpenCvSharp.Point>();
        OpenCvSharp.Point object_center = new OpenCvSharp.Point();
        OpenCvSharp.Point sample_center = new OpenCvSharp.Point();
        int count_right = 0;
        int angle_auto = 0;
        public void work()
        {
            try
            {
                if (count_corner_new_sample >= 3) Save_sam_but.Enabled = true;
                else Save_sam_but.Enabled = false;
                work_object.Clear();
                count_right = 0;

                mask_hsv[0] = (int)H_min_bar.Value; mask_hsv[1] = (int)S_min_bar.Value; mask_hsv[2] = (int)V_min_bar.Value; mask_hsv[3] = (int)H_max_bar.Value; mask_hsv[4] = (int)S_max_bar.Value; mask_hsv[5] = (int)V_max_bar.Value;
                HSV_box.Text = H_min_bar.Value.ToString() + ", " + S_min_bar.Value.ToString() + ", " + V_min_bar.Value.ToString() + ", " + H_max_bar.Value.ToString() + ", " + S_max_bar.Value.ToString() + ", " + V_max_bar.Value.ToString();
                degr_box.Text = Degrees.Value.ToString();
                calibr_flow = input_flow.Clone();
                Cv2.Undistort(input_flow, calibr_flow, cam_matrix, dis_coef, cam_matrix);

                // Camera param
                float[,] A4;
                if (Degrees.Value > 0) A4 = new float[,] { { 3.555555555555555555f * Degrees.Value, 0f }, { calibr_flow.Width - 3.555555555555555555f * Degrees.Value, 0f }, { 0f, calibr_flow.Height }, { calibr_flow.Width, calibr_flow.Height } };
                else A4 = new float[,] { { 0f, 0f }, { calibr_flow.Width, 0f }, { -3.555555555555555555f * Degrees.Value, calibr_flow.Height }, { calibr_flow.Width + 3.555555555555555555f * Degrees.Value, calibr_flow.Height } };
                float[,] A = new float[,] { { 0f, 0f }, { 640f, 0f }, { 0f, 480f }, { 640f, 480f } };
                Mat A4_matrix = new Mat(4, 2, MatType.CV_32F, A4);
                Mat A_matrix = new Mat(4, 2, MatType.CV_32F, A);
                Mat gg = Cv2.GetPerspectiveTransform(A4_matrix, A_matrix);
                Cv2.WarpPerspective(calibr_flow, calibr_flow, gg, new OpenCvSharp.Size(640, 480));

                output_flow = calibr_flow.Clone();

                // Find control plase
                int xx = (int)((150d * (640d * 680d) / 705d) / Int32.Parse(Distance.Text));
                int yy = (int)((150d * (480d * 680d) / 530d) / Int32.Parse(Distance.Text));
                int x_p = point_click.X - xx; int y_p = point_click.Y - yy; int w_p = xx * 2; int h_p = yy * 2;
                if (point_click.X - xx <= 0) x_p = 0;
                if (point_click.X + xx >= 640) x_p = 640 - 2*xx;
                if (point_click.Y - yy <= 0) y_p = 0;
                if (point_click.Y + yy >= 480) y_p = 480 - 2*yy;
                Rect zone = new Rect(x_p, y_p, w_p, h_p);
                
                mask_flow = new Mat(calibr_flow, zone);
                Cv2.Rectangle(output_flow, zone, Scalar.FromRgb(255, 0, 0), thickness: 4);
                out_mask_flow = mask_flow.Clone();
                // to hsv
                Cv2.CvtColor(mask_flow, hsv_flow, ColorConversionCodes.RGB2HSV);
                // Blure
                Cv2.Blur(hsv_flow, hsv_flow, new OpenCvSharp.Size(11, 11));
                // to canny
                try
                {
                    Cv2.InRange(hsv_flow, new Scalar(mask_hsv[0], mask_hsv[1], mask_hsv[2]), new Scalar(mask_hsv[3], mask_hsv[4], mask_hsv[5]), hsv_flow);
                    Cv2.FindContours(hsv_flow, out OpenCvSharp.Point[][] countorss, out HierarchyIndex[] hierarchyIndexess, RetrievalModes.External, ContourApproximationModes.ApproxSimple);
                    double max_area = 0d;
                    OpenCvSharp.Point[] cvcc = countorss[0];
                    foreach (var contour in countorss)
                    {
                        double ar = Cv2.ArcLength(contour, true);
                        OpenCvSharp.Point[][] cntr = { Cv2.ApproxPolyDP(contour, ar * 0.03, true) };
                        if (Cv2.ContourArea(cntr[0]) > max_area)
                        {
                            max_area = Cv2.ContourArea(cntr[0]);
                            cvcc = cntr[0];
                        }
                    }
                    OpenCvSharp.Point[][] ccc = { cvcc };
                    Moments mom = Cv2.Moments(cvcc, true);
                    object_center.Y = (int)(mom.M01 / mom.M00);
                    object_center.X = (int)(mom.M10 / mom.M00);
                    Cv2.Circle(out_mask_flow, new OpenCvSharp.Point(object_center.X, object_center.Y), 8, new Scalar(255, 0, 255), thickness: -1);
                    for (int j = 0; j < cvcc.Count(); j++)
                    {
                        double x_step = 0; double y_step = 0;
                        if (j == cvcc.Count() - 1)
                        {
                            x_step = (1d / 4d) * (cvcc[0].X - cvcc[j].X);
                            y_step = (1d / 4d) * (cvcc[0].Y - cvcc[j].Y);
                        }
                        else
                        {
                            x_step = (1d / 4d) * (cvcc[j + 1].X - cvcc[j].X);
                            y_step = (1d / 4d) * (cvcc[j + 1].Y - cvcc[j].Y);
                        }
                        work_object.Add(new OpenCvSharp.Point(cvcc[j].X, cvcc[j].Y));
                        work_object.Add(new OpenCvSharp.Point(cvcc[j].X + x_step,   cvcc[j].Y + y_step));
                        work_object.Add(new OpenCvSharp.Point(cvcc[j].X + x_step*2, cvcc[j].Y + y_step*2));
                        work_object.Add(new OpenCvSharp.Point(cvcc[j].X + x_step*3, cvcc[j].Y + y_step*3));
                    }
                    Cv2.DrawContours(out_mask_flow, ccc, 0, new Scalar(255, 0, 255));
                }
                catch (Exception ex) { //MessageBox.Show(ex.ToString());
                }
                if (is_sample)
                {
                    Angle.Enabled = true;
                    sample_center = new OpenCvSharp.Point();
                    canny_flow = new Mat(new OpenCvSharp.Size(out_mask_flow.Width, out_mask_flow.Height), MatType.CV_8UC1, Scalar.Black);
                    //canny_flow = new Mat(new OpenCvSharp.Size(out_mask_flow.Width, out_mask_flow.Height), MatType.CV_8UC1);
                    List<OpenCvSharp.Point> points = new List<OpenCvSharp.Point>();
                    List<OpenCvSharp.Point> points_min = new List<OpenCvSharp.Point>();
                    List<OpenCvSharp.Point> points_max = new List<OpenCvSharp.Point>();
                    for (int i = 0; i < sample.Count; i++)
                    {
                        sample_center.X += sample[i].X;
                        sample_center.Y += sample[i].Y;
                    }
                    sample_center.X = (int)(sample_center.X / sample.Count);
                    sample_center.Y = (int)(sample_center.Y / sample.Count);

                    int delta_x = object_center.X - sample_center.X;
                    int delta_y = object_center.Y - sample_center.Y;
                    double ks = Double.Parse(Otstyp.Text) / Math.Sqrt(Math.Pow(object_center.X - sample[0].X - delta_x, 2) + Math.Pow(object_center.Y - sample[0].Y - delta_y, 2));
                    // Find otstyp plase
                    int x = (int)((Int32.Parse(Otstyp.Text) * (640d * 680d) / 705d) / Int32.Parse(Distance.Text));
                    int y = (int)((Int32.Parse(Otstyp.Text) * (480d * 680d) / 530d) / Int32.Parse(Distance.Text));
                    for (int i = 0; i < sample.Count; i++)
                    {
                        int x_new = (int)((object_center.X - sample[i].X - delta_x) * Math.Cos((Math.PI / 180) * Angle.Value) - (object_center.Y - sample[i].Y - delta_y) * Math.Sin((Math.PI / 180) * Angle.Value) + object_center.X);
                        int y_new = (int)((object_center.X - sample[i].X - delta_x) * Math.Sin((Math.PI / 180) * Angle.Value) + (object_center.Y - sample[i].Y - delta_y) * Math.Cos((Math.PI / 180) * Angle.Value) + object_center.Y);
                        points.Add(new OpenCvSharp.Point(x_new, y_new));
                        points_min.Add(new OpenCvSharp.Point(x_new + (object_center.X-x_new)*ks, y_new + (object_center.Y - y_new) * ks));
                        points_max.Add(new OpenCvSharp.Point(x_new - (object_center.X - x_new) * ks, y_new - (object_center.Y - y_new) * ks));
                    }
                    sample_center.X += delta_x;
                    sample_center.Y += delta_y;

                    List<List<OpenCvSharp.Point>> ListOfListOfPoint = new List<List<OpenCvSharp.Point>>();
                    List<List<OpenCvSharp.Point>> ListOfListOfPoint_min = new List<List<OpenCvSharp.Point>>();
                    List<List<OpenCvSharp.Point>> ListOfListOfPoint_max = new List<List<OpenCvSharp.Point>>();
                    
                    ListOfListOfPoint.Add(points);
                    ListOfListOfPoint_min.Add(points_min);
                    ListOfListOfPoint_max.Add(points_max);
                    
                    canny_flow.FillPoly(ListOfListOfPoint_max, new Scalar(255, 255, 255));
                    canny_flow.FillPoly(ListOfListOfPoint_min, new Scalar(0, 0, 0));
                    
                    out_mask_flow.Polylines(ListOfListOfPoint, true, new Scalar(0, 0, 0));
                    out_mask_flow.Polylines(ListOfListOfPoint_max, true, new Scalar(200, 255, 255));
                    out_mask_flow.Polylines(ListOfListOfPoint_min, true, new Scalar(200, 255, 255));
                    
                    final_flow = new Mat();
                    Cv2.Resize(hsv_flow, hsv_flow, canny_flow.Size());
                    Cv2.InRange(hsv_flow, new Scalar(1, 1, 1), new Scalar(255, 255, 255), hsv_flow);

                    Cv2.BitwiseNot(canny_flow, final_flow, mask: hsv_flow);
                    Result_square.Text = Cv2.CountNonZero(final_flow).ToString() + " / " + Cv2.CountNonZero(hsv_flow).ToString() + " = " + ((Cv2.CountNonZero(final_flow)*100) / Cv2.CountNonZero(hsv_flow)).ToString() + "%" ;
                    for (int j = 0; j < work_object.Count(); j++)
                    {
                        Vec3b color = canny_flow.Get<Vec3b>(work_object[j].Y, work_object[j].X);
                        if (color.Item0 == 0 && color.Item1 == 0 && color.Item2 == 0)
                        {
                            Cv2.Circle(out_mask_flow, work_object[j], 5, new Scalar(0, 0, 255), thickness: -1);
                        }
                        else
                        {
                            Cv2.Circle(out_mask_flow, work_object[j], 5, new Scalar(0, 255, 0), thickness: -1);
                            count_right++;
                        }
                    }
                    Result_point.Text = count_right.ToString() + " / " + work_object.Count().ToString() + " = " + ((count_right * 100) / work_object.Count()).ToString() + "%";
                }

                pictureBox1.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(output_flow);
                pictureBox1.Refresh();
                pictureBox3.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(hsv_flow);
                pictureBox3.Refresh();
                pictureBox4.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(out_mask_flow);
                pictureBox4.Refresh();
                try
                {
                    pictureBox2.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(canny_flow);
                    pictureBox2.Refresh();
                    pictureBox5.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(final_flow);
                    pictureBox5.Refresh();
                }
                catch (Exception ex) { }
            }
            catch (Exception ex) { //MessageBox.Show(ex.ToString()); 
            }
        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            try
            {
                if (video_capture.IsOpened() && (is_cam || is_video))
                {
                    video_capture.Read(input_flow);
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
        OpenCvSharp.Point point_click = new OpenCvSharp.Point(320, 240);
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            point_click.X = e.X;
            point_click.Y = e.Y;
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
                    is_puc = false;
                    Angle.Enabled = false;
                    Cam_but.Enabled = true;
                    Open_but.Enabled = true;
                    Graphics graphics = Graphics.FromImage(pictureBox1.Image);
                    graphics.FillRectangle(Brushes.Pink, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
                    Graphics graphics2 = Graphics.FromImage(pictureBox2.Image);
                    graphics2.FillRectangle(Brushes.Pink, new Rectangle(0, 0, pictureBox2.Width, pictureBox2.Height));
                    Graphics graphics3 = Graphics.FromImage(pictureBox3.Image);
                    graphics3.FillRectangle(Brushes.Pink, new Rectangle(0, 0, pictureBox3.Width, pictureBox3.Height));
                    Graphics graphics4 = Graphics.FromImage(pictureBox4.Image);
                    graphics4.FillRectangle(Brushes.Pink, new Rectangle(0, 0, pictureBox4.Width, pictureBox4.Height));
                    Graphics graphics5 = Graphics.FromImage(pictureBox5.Image);
                    graphics5.FillRectangle(Brushes.Pink, new Rectangle(0, 0, pictureBox5.Width, pictureBox5.Height));
                    pictureBox1.Refresh();
                    pictureBox2.Refresh();
                    pictureBox3.Refresh();
                    pictureBox4.Refresh();
                    pictureBox5.Refresh();
                    video_capture.Release();
                }
                catch { }
            }
        }

        private void Find_countours_but_Click(object sender, EventArgs e)
        {
            //if (!is_countor)
            //{
            //    is_countor = true;
            //    work();
            //} else is_countor = false;
        }

        private void Find_object_but_Click(object sender, EventArgs e)
        {
            if (is_cam || is_video || is_puc)
            {
                DialogResult res = openFileDialog2.ShowDialog();
                if (res == DialogResult.OK)
                {
                    is_sample = true;
                    sample.Clear();
                    string csvContentStr = System.IO.File.ReadAllText(openFileDialog2.FileName);
                    string[] vs = csvContentStr.Split(';');
                    for (int i = 0; i < vs.Length; i += 2)
                    {
                        sample.Add(new OpenCvSharp.Point(Int32.Parse(vs[i]), Int32.Parse(vs[i + 1])));
                        Sample_point_list.Items.Add(vs[i].ToString() + " " + vs[i+1].ToString());
                    }
                }
            }
            else is_sample = false;
        }
        List<OpenCvSharp.Point> new_sample = new List<OpenCvSharp.Point>();
        int count_corner_new_sample = 0;
        private void pictureBox4_MouseClick(object sender, MouseEventArgs e)
        {
            if (count_corner_new_sample == 0 && is_sample) Sample_point_list.Items.Add("_________");
            new_sample.Add(new OpenCvSharp.Point(e.X, e.Y));
            count_corner_new_sample++;
            Sample_point_list.Items.Add(e.X.ToString() + " " + e.Y.ToString());
        }
        private void Save_sam_but_Click(object sender, EventArgs e)
        {
            String data = "";
            sample.Clear();
            for (int i = 0; i < new_sample.Count; i++)
            {
                data += new_sample[i].X.ToString() + ";" + new_sample[i].Y.ToString() + ";";
                sample.Add(new OpenCvSharp.Point(new_sample[i].X, new_sample[i].Y));
            }
            DialogResult res = saveFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                System.IO.File.WriteAllText(saveFileDialog1.FileName, data.Remove(data.Length-1));
            }

        }
        private void Auto_flag_CheckedChanged(object sender, EventArgs e)
        {
            if (Auto_flag.Checked)
            {
                timer1.Stop();
                if (Auto_flag.Checked)
                {
                    int max_count_point = 0;
                    for (int j = 0; j < Angle.Maximum; j++)
                    {
                        Angle.Value = j;
                        work();
                        if (max_count_point < count_right)
                        {
                            max_count_point = count_right;
                            angle_auto = j;
                        }
                    }  
                }
                Angle.Value = angle_auto;
                timer1.Start();
                Auto_flag.Checked = false;
            }
        }
    }
}