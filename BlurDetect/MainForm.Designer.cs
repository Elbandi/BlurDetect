namespace BlurDetect
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.blurDetectBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.labelBlur = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // blurDetectBackgroundWorker
            // 
            this.blurDetectBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.blurDetectBackgroundWorker_DoWork);
            this.blurDetectBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.blurDetectBackgroundWorker_RunWorkerCompleted);
            // 
            // labelBlur
            // 
            this.labelBlur.AllowDrop = true;
            this.labelBlur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelBlur.Location = new System.Drawing.Point(0, 0);
            this.labelBlur.Name = "labelBlur";
            this.labelBlur.Size = new System.Drawing.Size(582, 353);
            this.labelBlur.TabIndex = 0;
            this.labelBlur.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelBlur.DragDrop += new System.Windows.Forms.DragEventHandler(this.labelBlur_DragDrop);
            this.labelBlur.DragEnter += new System.Windows.Forms.DragEventHandler(this.labelBlur_DragEnter);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 353);
            this.Controls.Add(this.labelBlur);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Blur Detect";
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker blurDetectBackgroundWorker;
        private System.Windows.Forms.Label labelBlur;
    }
}

