using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TruongMinhTri_2123110137
{
    public partial class Form3 : Form
    {
        int xEgg = 300;   // X của trứng
        int yEgg = 0;     // Y của trứng
        int yDelta = 3;   // tốc độ rơi

        // thư mục chứa ảnh: ..\..\img
        readonly string imgFolder = Path.Combine("..", "..", "img");

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // ảnh trứng nguyên
            string eggPath = Path.Combine(imgFolder, "egg.png");
            if (File.Exists(eggPath))
            {
                pbEgg.Image = Image.FromFile(eggPath);
            }

            // vị trí ban đầu
            yEgg = 0;
            xEgg = 300;
            pbEgg.Location = new Point(xEgg, yEgg);

            tmEgg.Start();
        }

        private void tmEgg_Tick(object sender, EventArgs e)
        {
            yEgg += yDelta;

            // chạm đáy hoặc chạm trên
            if (yEgg > this.ClientSize.Height - pbEgg.Height || yEgg <= 0)
            {
                if (yEgg > this.ClientSize.Height - pbEgg.Height)
                {
                    // trứng vỡ khi chạm đáy
                    string brokenPath = Path.Combine(imgFolder, "egg_broken.png");
                    if (File.Exists(brokenPath))
                        pbEgg.Image = Image.FromFile(brokenPath);
                }
                else
                {
                    // lên lại thì đổi về trứng nguyên
                    string eggPath = Path.Combine(imgFolder, "egg.png");
                    if (File.Exists(eggPath))
                        pbEgg.Image = Image.FromFile(eggPath);
                }

                // đổi chiều
                yDelta = -yDelta;
            }

            // cập nhật vị trí
            pbEgg.Location = new Point(xEgg, yEgg);
        }
    }
}
