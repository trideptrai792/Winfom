namespace TruongMinhTri_2123110137
{
    partial class Form13
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox pbEgg;      // trứng mẫu
        private System.Windows.Forms.PictureBox pbChicken;  // gà
        private System.Windows.Forms.PictureBox pbBasket;   // giỏ
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblScore;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form13));
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
            pbEgg.Location = new Point(125, 117);
            pbEgg.Margin = new Padding(3, 4, 3, 4);
            pbEgg.Name = "pbEgg";
            pbEgg.Size = new Size(46, 53);
            pbEgg.SizeMode = PictureBoxSizeMode.StretchImage;
            pbEgg.TabIndex = 0;
            pbEgg.TabStop = false;
            // 
            // pbChicken
            // 
            pbChicken.Image = (Image)resources.GetObject("pbChicken.Image");
            pbChicken.Location = new Point(114, 13);
            pbChicken.Margin = new Padding(3, 4, 3, 4);
            pbChicken.Name = "pbChicken";
            pbChicken.Size = new Size(91, 80);
            pbChicken.SizeMode = PictureBoxSizeMode.Zoom;
            pbChicken.TabIndex = 1;
            pbChicken.TabStop = false;
            // 
            // pbBasket
            // 
            pbBasket.Image = Properties.Resources.cart;
            pbBasket.Location = new Point(157, 467);
            pbBasket.Margin = new Padding(3, 4, 3, 4);
            pbBasket.Name = "pbBasket";
            pbBasket.Size = new Size(91, 80);
            pbBasket.SizeMode = PictureBoxSizeMode.Zoom;
            pbBasket.TabIndex = 2;
            pbBasket.TabStop = false;
            // 
            // lblScore
            // 
            lblScore.Location = new Point(11, 13);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(171, 31);
            lblScore.TabIndex = 3;
            lblScore.Text = "Điểm: 0";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 30;
            timer1.Tick += timer1_Tick;
            // 
            // Form13
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(pbEgg);
            Controls.Add(pbChicken);
            Controls.Add(pbBasket);
            Controls.Add(lblScore);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form13";
            Text = "Catch Egg – Hard Mode";
            Load += Form13_Load;
            ((System.ComponentModel.ISupportInitialize)pbEgg).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbChicken).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbBasket).EndInit();
            ResumeLayout(false);
        }
    }
}
