using System;
using System.Drawing;
using System.Windows.Forms;

namespace TruongMinhTri_2123110137
{
    public partial class Form5 : Form
    {
        int yEgg = 0;   // Tọa độ Y của quả trứng
        int xEgg = 0;   // Tọa độ X của quả trứng
        int speed = 5;  // Tốc độ rơi của quả trứng
        int score = 0;  // Điểm số
        int xChickenSpeed = 5;   // tốc độ chạy ngang của con gà


        public Form5()
        {
            InitializeComponent();  // Gọi phương thức này để Visual Studio tự động khởi tạo các điều khiển
        }

        // Sự kiện khi Form được tải
        private void EggDrop_Load(object sender, EventArgs e)
        {
            // Khởi tạo vị trí quả trứng
            xEgg = pbChicken.Left + pbChicken.Width / 2 - pbEgg.Width / 2;
            yEgg = pbChicken.Top + pbChicken.Height;
            pbEgg.Location = new Point(xEgg, yEgg);  // Đặt vị trí của quả trứng

            timer1.Start();  // Bắt đầu Timer
        }

        // Sự kiện Timer "Tick" để cập nhật vị trí quả trứng
        private void timer1_Tick(object sender, EventArgs e)
        {
            // 1. GÀ CHẠY QUA LẠI Ở TRÊN
            pbChicken.Left += xChickenSpeed;

            // Nếu chạm biên trái/phải thì quay đầu
            if (pbChicken.Right >= ClientSize.Width || pbChicken.Left <= 0)
            {
                xChickenSpeed = -xChickenSpeed;
            }

            yEgg += speed;  // Trứng rơi xuống

            // Nếu trứng rơi đến đáy màn hình → trứng vỡ
            if (yEgg >= ClientSize.Height - pbEgg.Height)
            {
                pbEgg.Image = Properties.Resources.egg_broken;  // Đảm bảo sử dụng đúng tài nguyên
                ResetEgg();  // Reset lại trứng
            }

            // Kiểm tra va chạm với giỏ
            if (pbEgg.Bounds.IntersectsWith(pbBasket.Bounds))
            {
                score++;  // Tăng điểm khi bắt được trứng
                lblScore.Text = "Điểm: " + score;  // Cập nhật điểm
                pbEgg.Image = Properties.Resources.egg;  // Đổi hình ảnh quả trứng
                ResetEgg();  // Reset lại vị trí của trứng
            }

            pbEgg.Location = new Point(xEgg, yEgg);  // Cập nhật vị trí trứng
        }

        // Phương thức để reset lại vị trí quả trứng
        private void ResetEgg()
        {
            yEgg = pbChicken.Top + pbChicken.Height;
            xEgg = pbChicken.Left + pbChicken.Width / 2 - pbEgg.Width / 2;
            pbEgg.Location = new Point(xEgg, yEgg);  // Cập nhật lại vị trí trứng
        }

        // Điều khiển giỏ bằng phím ← và →
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            int moveSpeed = 20;  // Tốc độ di chuyển của giỏ
            if (keyData == Keys.Left)
            {
                pbBasket.Left -= moveSpeed;
                if (pbBasket.Left < 0) pbBasket.Left = 0;  // Giới hạn không để giỏ ra ngoài màn hình
                return true;
            }

            if (keyData == Keys.Right)
            {
                pbBasket.Left += moveSpeed;
                if (pbBasket.Right > ClientSize.Width)
                    pbBasket.Left = ClientSize.Width - pbBasket.Width;  // Giới hạn không để giỏ ra ngoài màn hình
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);  // Các phím khác
        }

        // Phương thức Click cho quả trứng (nếu bạn muốn xử lý khi click vào quả trứng)
        private void pbEgg_Click(object sender, EventArgs e)
        {
            // Ví dụ: Khi click vào quả trứng
            MessageBox.Show("Bạn đã click vào quả trứng!");
        }

        private void pbBasket_Click(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}