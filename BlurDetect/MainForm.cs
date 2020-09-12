using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlurDetect
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void labelBlur_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            labelBlur.BackColor = Color.Yellow;
            blurDetectBackgroundWorker.RunWorkerAsync(files[0]);
        }

        private readonly string[] AllowedExtensions = {
            ".jpg",
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

        private void blurDetectBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Mat src = Cv2.ImRead(e.Argument as string);
            Mat mat = src.CvtColor(ColorConversionCodes.BGR2GRAY);
            Mat lap = mat.Laplacian(MatType.CV_64F);
            Cv2.MeanStdDev(lap, out var mean, out var stddev);
            e.Result = (stddev.Val0 * stddev.Val0).ToString();
        }

        private void blurDetectBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                labelBlur.BackColor = SystemColors.Control;
                labelBlur.Text = e.Result as string;
            }
            else
            {
                labelBlur.BackColor = Color.Red;
            }
        }
    }
}
