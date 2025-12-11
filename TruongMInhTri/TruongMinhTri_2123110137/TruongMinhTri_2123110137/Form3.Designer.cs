using System.Drawing;
using System.Windows.Forms;

namespace TruongMinhTri_2123110137
{
    partial class Form3
    {
        private System.ComponentModel.IContainer components = null;
        private PictureBox pbEgg;
        private System.Windows.Forms.Timer tmEgg;   // chỉ dùng 1 Timer này

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pbEgg = new PictureBox();
            tmEgg = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pbEgg).BeginInit();
            SuspendLayout();
            // 
            // pbEgg
            // 
            pbEgg.Image = Properties.Resources.egg;
            pbEgg.Location = new Point(99, 107);
            pbEgg.Name = "pbEgg";
            pbEgg.Size = new Size(50, 50);
            pbEgg.SizeMode = PictureBoxSizeMode.StretchImage;
            pbEgg.TabIndex = 0;
            pbEgg.TabStop = false;
            // 
            // tmEgg
            // 
            tmEgg.Interval = 10;
            tmEgg.Tick += tmEgg_Tick;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pbEgg);
            Name = "Form3";
            Text = "Egg Falling";
            Load += Form3_Load;
            ((System.ComponentModel.ISupportInitialize)pbEgg).EndInit();
            ResumeLayout(false);
        }
    }
}
