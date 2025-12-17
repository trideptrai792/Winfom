namespace TruongMinhTri_2123110137
{
    partial class Form10
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.picImage = new System.Windows.Forms.PictureBox();
            this.btLeft = new System.Windows.Forms.Button();
            this.btRight = new System.Windows.Forms.Button();
            this.btFile = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();

            // 
            // picImage
            // 
            this.picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImage.Location = new System.Drawing.Point(30, 30);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(150, 180);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

            // 
            // btLeft
            // 
            this.btLeft.Location = new System.Drawing.Point(40, 230);
            this.btLeft.Name = "btLeft";
            this.btLeft.Size = new System.Drawing.Size(50, 30);
            this.btLeft.Text = "<-";
            this.btLeft.UseVisualStyleBackColor = true;
            this.btLeft.Click += new System.EventHandler(this.btLeft_Click);

            // 
            // btRight
            // 
            this.btRight.Location = new System.Drawing.Point(100, 230);
            this.btRight.Name = "btRight";
            this.btRight.Size = new System.Drawing.Size(50, 30);
            this.btRight.Text = "->";
            this.btRight.UseVisualStyleBackColor = true;
            this.btRight.Click += new System.EventHandler(this.btRight_Click);

            // 
            // btFile
            // 
            this.btFile.Location = new System.Drawing.Point(170, 230);
            this.btFile.Name = "btFile";
            this.btFile.Size = new System.Drawing.Size(100, 30);
            this.btFile.Text = "File...";
            this.btFile.UseVisualStyleBackColor = true;
            this.btFile.Click += new System.EventHandler(this.btFile_Click);

            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(320, 300);
            this.Controls.Add(this.picImage);
            this.Controls.Add(this.btLeft);
            this.Controls.Add(this.btRight);
            this.Controls.Add(this.btFile);
            this.Name = "Form10";
            this.Text = "Simple Game";

            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Button btLeft;
        private System.Windows.Forms.Button btRight;
        private System.Windows.Forms.Button btFile;
    }
}