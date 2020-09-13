using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using OpenCvSharp;
using System.IO;

namespace BlurDetect
{
    public partial class ImageProcessPanel : UserControl
    {
        public ImageProcessPanel()
        {
            InitializeComponent();
        }

        private readonly string[] AllowedExtensions = {
            ".jpg",
            ".png",
            ".tif",
        };

        private void labelBlur_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) && !blurDetectBackgroundWorker.IsBusy)
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length == 1 && AllowedExtensions.Contains(Path.GetExtension(files[0])))
                {
                    e.Effect = DragDropEffects.Copy;
                }
            }
        }

        private void labelBlur_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            labelBlur.BackColor = Color.Yellow;
            blurDetectBackgroundWorker.RunWorkerAsync(files[0]);
        }

        private void blurDetectBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string fileName = e.Argument as string;
            Mat src = Cv2.ImRead(fileName);
            Mat mat = src.CvtColor(ColorConversionCodes.BGR2GRAY);
            Mat lap = mat.Laplacian(MatType.CV_64F);
            Scalar mean, stddev;
            Cv2.MeanStdDev(lap, out mean, out stddev);

            int[] dimensions = { 256 };
            Rangef[] ranges = { new Rangef(1, 256) };

            Mat HistR = new Mat();
            Mat HistG = new Mat();
            Mat HistB = new Mat();
            Mat HistGray = new Mat();

            //Mat[] mv = img.Split();
            //Cv2.CalcHist(new Mat[] { mv[0] }, new int[] { 0 }, null, HistB, 1, dimensions, ranges);
            //Cv2.CalcHist(new Mat[] { mv[1] }, new int[] { 0 }, null, HistG, 1, dimensions, ranges);
            //Cv2.CalcHist(new Mat[] { mv[2] }, new int[] { 0 }, null, HistR, 1, dimensions, ranges);

            Cv2.CalcHist(new Mat[] { src }, new int[] { 0 }, null, HistB, 1, dimensions, ranges);
            Cv2.CalcHist(new Mat[] { src }, new int[] { 1 }, null, HistG, 1, dimensions, ranges);
            Cv2.CalcHist(new Mat[] { src }, new int[] { 2 }, null, HistR, 1, dimensions, ranges);

            Cv2.CalcHist(new Mat[] { mat }, new int[] { 0 }, null, HistGray, 1, dimensions, ranges);

            Cv2.Normalize(HistR, HistR, 0, 256, NormTypes.MinMax);
            Cv2.Normalize(HistG, HistG, 0, 256, NormTypes.MinMax);
            Cv2.Normalize(HistB, HistB, 0, 256, NormTypes.MinMax);
            Cv2.Normalize(HistGray, HistGray, 0, 256, NormTypes.MinMax);

            Mat histogram = new Mat(256, 512, MatType.CV_8UC3, Scalar.White);
            for (int i = 1; i < 256; i++)
            {
//                Console.WriteLine("{0}, {1}, {2}", HistR.At<float>(i), HistG.At<float>(i), HistB.At<float>(i));
                Cv2.Line(histogram,
                    new OpenCvSharp.Point(2 * (i - 1), 256 - Convert.ToInt32(HistR.Get<float>(i - 1))),
                    new OpenCvSharp.Point(2 * i, 256 - Convert.ToInt32(HistR.Get<float>(i))),
                    Scalar.Red);
                Cv2.Line(histogram,
                    new OpenCvSharp.Point(2 * (i - 1), 256 - Convert.ToInt32(HistG.Get<float>(i - 1))),
                    new OpenCvSharp.Point(2 * i, 256 - Convert.ToInt32(HistG.Get<float>(i))),
                    Scalar.Green);
                Cv2.Line(histogram,
                    new OpenCvSharp.Point(2 * (i - 1), 256 - Convert.ToInt32(HistB.Get<float>(i - 1))),
                    new OpenCvSharp.Point(2 * i, 256 - Convert.ToInt32(HistB.Get<float>(i))),
                    Scalar.Blue);
                Cv2.Line(histogram,
                    new OpenCvSharp.Point(2 * (i - 1), 256 - Convert.ToInt32(HistGray.Get<float>(i - 1))),
                    new OpenCvSharp.Point(2 * i, 256 - Convert.ToInt32(HistGray.Get<float>(i))),
                    Scalar.Black);
            }

            e.Result = new DetectResult
            {
                FileName = Path.GetFileName(fileName),
                Blur = stddev.Val0 * stddev.Val0,
                //                Histogram = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(GetHistogram(src)),
                Histogram = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(histogram),
            };
        }

        private void blurDetectBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                DetectResult result = e.Result as DetectResult;
                labelBlur.BackColor = SystemColors.Control;
                labelBlur.Text = string.Format("{0}: {1}", result.FileName, result.Blur);
                result.Histogram.MakeTransparent(Color.White);
                histogramPictureBox.Image = result.Histogram;
            }
            else
            {
                labelBlur.BackColor = Color.Red;
            }
        }

        class DetectResult
        {
            public string FileName;
            public double Blur;
            public Bitmap Histogram;
        }
    }
}
