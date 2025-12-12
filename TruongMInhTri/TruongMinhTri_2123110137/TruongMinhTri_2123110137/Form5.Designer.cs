namespace TruongMinhTri_2123110137
{
    partial class Form5
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox pbEgg;  // Quả trứng
        private System.Windows.Forms.PictureBox pbChicken;  // Giỏ
        private System.Windows.Forms.PictureBox pbBasket;  // Giỏ
        private System.Windows.Forms.Timer timer1;  // Timer
        private System.Windows.Forms.Label lblScore;  // Điểm số

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
            pbChicken = new PictureBox();
            pbBasket = new PictureBox();
            lblScore = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pbEgg).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbChicken).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbBasket).BeginInit();
            SuspendLayout();
            // 
            // pbEgg
            // 
            pbEgg.Image = Properties.Resources.egg;
            pbEgg.Location = new Point(109, 88);
            pbEgg.Name = "pbEgg";
            pbEgg.Size = new Size(100, 100);
            pbEgg.SizeMode = PictureBoxSizeMode.StretchImage;
            pbEgg.TabIndex = 0;
            pbEgg.TabStop = false;
            pbEgg.Click += pbEgg_Click;
            // 
            // pbChicken
            // 
            pbChicken.Image = Properties.Resources.ball;
            pbChicken.Location = new Point(86, 10);
            pbChicken.Name = "pbChicken";
            pbChicken.Size = new Size(100, 50);
            pbChicken.SizeMode = PictureBoxSizeMode.Zoom;
            pbChicken.TabIndex = 1;
            pbChicken.TabStop = false;
            // 
            // pbBasket
            // 
            pbBasket.BackColor = SystemColors.Desktop;
            pbBasket.BackgroundImageLayout = ImageLayout.None;
            pbBasket.Image = Properties.Resources.cart;
            pbBasket.Location = new Point(109, 323);
            pbBasket.Name = "pbBasket";
            pbBasket.Size = new Size(100, 50);
            pbBasket.SizeMode = PictureBoxSizeMode.Zoom;
            pbBasket.TabIndex = 2;
            pbBasket.TabStop = false;
            pbBasket.Click += pbBasket_Click;
            // 
            // lblScore
            // 
            lblScore.Location = new Point(10, 10);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(100, 23);
            lblScore.TabIndex = 3;
            lblScore.Text = "Điểm: 0";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 50;
            timer1.Tick += timer1_Tick;
            // 
            // Form5
            // 
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(800, 450);
            Controls.Add(pbEgg);
            Controls.Add(pbChicken);
            Controls.Add(pbBasket);
            Controls.Add(lblScore);
            Name = "Form5";
            Text = "Egg Drop Game";
            Load += Form5_Load;
            ((System.ComponentModel.ISupportInitialize)pbEgg).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbChicken).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbBasket).EndInit();
            ResumeLayout(false);
        }
    }
}
