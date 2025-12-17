using System;
using System.Windows.Forms;

namespace TruongMinhTri_2123110137
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            // Đăng ký sự kiện Load cho Form
            this.Load += Form2_Load;
        }

        // Khi form load: đổ dữ liệu ban đầu
        private void Form2_Load(object sender, EventArgs e)
        {
            // Thêm dữ liệu cho ComboBox
            comboBox1.Items.Add("Công nghệ thông tin");
            comboBox1.Items.Add("Quản trị kinh doanh");
            comboBox1.Items.Add("Kế toán");
            comboBox1.Items.Add("Ngôn ngữ Anh");

            // Một số thiết lập khác (cho đẹp)
            numericUpDown1.Minimum = 1;
            numericUpDown1.Maximum = 100;
            numericUpDown1.Value = 18;

            checkBox1.Text = "Đăng ký CLB";
            radioButton1.Text = "Nam";

            // Thêm dữ liệu cho ListBox
            listBox1.Items.Add("C#");
            listBox1.Items.Add("Java");
            listBox1.Items.Add("Python");
        }

        // TextBox thay đổi nội dung
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Ví dụ: bật/tắt button1 khi textbox có / không có dữ liệu
            button1.Enabled = !string.IsNullOrWhiteSpace(textBox1.Text);
        }

        // Nút Name (button3) – hiển thị tên nhập trong textbox
        private void button3_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Vui lòng nhập tên vào ô TextBox.", "Thông báo");
                return;
            }

            MessageBox.Show($"Tên của bạn là: {name}", "Thông tin");
        }

        // Khi chọn mục trong ComboBox
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string selected = comboBox1.SelectedItem.ToString();
                MessageBox.Show($"Bạn đã chọn khoa: {selected}", "Khoa");
            }
        }
    }
}
