using System.Drawing;
using System.Windows.Forms;

namespace FlappyBird3Layer.Presentation
{
    partial class FormGame
    {
        private System.ComponentModel.IContainer components = null;

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
            this.SuspendLayout();
            // 
            // FormGame
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 450);
            this.Name = "FormGame";
            this.Text = "Flappy Bird 3 Layer";
            this.Load += new System.EventHandler(this.FormGame_Load);
            this.ResumeLayout(false);
        }
    }
}
