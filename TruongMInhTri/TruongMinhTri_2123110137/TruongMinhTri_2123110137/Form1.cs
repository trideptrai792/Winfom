using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TruongMinhTri_2123110137
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Khởi tạo đối tượng Form2
            Form2 f2 = new Form2();

            // 2. Hiển thị Form2
            f2.Show();

            // Tùy chọn: Nếu bạn muốn ẩn Form1 đi sau khi mở Form2, hãy thêm dòng sau:
            // this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // 1. Khởi tạo đối tượng Form2
            Form3 f3 = new Form3();

            // 2. Hiển thị Form2
            f3.Show();

            // Tùy chọn: Nếu bạn muốn ẩn Form1 đi sau khi mở Form2, hãy thêm dòng sau:
            // this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 1. Khởi tạo đối tượng Form2
            Form4 f4 = new Form4();

            // 2. Hiển thị Form2
            f4.Show();

            // Tùy chọn: Nếu bạn muốn ẩn Form1 đi sau khi mở Form2, hãy thêm dòng sau:
            // this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 1. Khởi tạo đối tượng Form2
            Form5 f5 = new Form5();

            // 2. Hiển thị Form2
            f5.Show();

            // Tùy chọn: Nếu bạn muốn ẩn Form1 đi sau khi mở Form2, hãy thêm dòng sau:
            // this.Hide();
        }
    }
}
