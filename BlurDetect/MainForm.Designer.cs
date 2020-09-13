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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.imageProcessPanel2 = new BlurDetect.ImageProcessPanel();
            this.imageProcessPanel1 = new BlurDetect.ImageProcessPanel();
            this.SuspendLayout();
            // 
            // imageProcessPanel2
            // 
            this.imageProcessPanel2.AllowDrop = true;
            this.imageProcessPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageProcessPanel2.Location = new System.Drawing.Point(0, 290);
            this.imageProcessPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.imageProcessPanel2.MaximumSize = new System.Drawing.Size(514, 290);
            this.imageProcessPanel2.MinimumSize = new System.Drawing.Size(514, 290);
            this.imageProcessPanel2.Name = "imageProcessPanel2";
            this.imageProcessPanel2.Size = new System.Drawing.Size(514, 290);
            this.imageProcessPanel2.TabIndex = 1;
            // 
            // imageProcessPanel1
            // 
            this.imageProcessPanel1.AllowDrop = true;
            this.imageProcessPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageProcessPanel1.Location = new System.Drawing.Point(0, 0);
            this.imageProcessPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.imageProcessPanel1.MaximumSize = new System.Drawing.Size(514, 290);
            this.imageProcessPanel1.MinimumSize = new System.Drawing.Size(514, 290);
            this.imageProcessPanel1.Name = "imageProcessPanel1";
            this.imageProcessPanel1.Size = new System.Drawing.Size(514, 290);
            this.imageProcessPanel1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 581);
            this.Controls.Add(this.imageProcessPanel2);
            this.Controls.Add(this.imageProcessPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Blur Detect";
            this.ResumeLayout(false);

        }

        #endregion

        private ImageProcessPanel imageProcessPanel1;
        private ImageProcessPanel imageProcessPanel2;
    }
}

