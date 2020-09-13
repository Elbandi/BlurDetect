namespace BlurDetect
{
    partial class ImageProcessPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.blurDetectBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.labelBlur = new System.Windows.Forms.Label();
            this.histogramPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.histogramPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // blurDetectBackgroundWorker
            // 
            this.blurDetectBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.blurDetectBackgroundWorker_DoWork);
            this.blurDetectBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.blurDetectBackgroundWorker_RunWorkerCompleted);
            // 
            // labelBlur
            // 
            this.labelBlur.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelBlur.Location = new System.Drawing.Point(0, 0);
            this.labelBlur.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelBlur.Name = "labelBlur";
            this.labelBlur.Size = new System.Drawing.Size(512, 32);
            this.labelBlur.TabIndex = 1;
            this.labelBlur.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelBlur.DragDrop += new System.Windows.Forms.DragEventHandler(this.labelBlur_DragDrop);
            this.labelBlur.DragEnter += new System.Windows.Forms.DragEventHandler(this.labelBlur_DragEnter);
            // 
            // histogramPictureBox
            // 
            this.histogramPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.histogramPictureBox.Location = new System.Drawing.Point(0, 32);
            this.histogramPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.histogramPictureBox.Name = "histogramPictureBox";
            this.histogramPictureBox.Size = new System.Drawing.Size(512, 256);
            this.histogramPictureBox.TabIndex = 2;
            this.histogramPictureBox.TabStop = false;
            // 
            // ImageProcessPanel
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.histogramPictureBox);
            this.Controls.Add(this.labelBlur);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(514, 290);
            this.MinimumSize = new System.Drawing.Size(514, 290);
            this.Name = "ImageProcessPanel";
            this.Size = new System.Drawing.Size(512, 288);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.labelBlur_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.labelBlur_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.histogramPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker blurDetectBackgroundWorker;
        private System.Windows.Forms.Label labelBlur;
        private System.Windows.Forms.PictureBox histogramPictureBox;
    }
}
