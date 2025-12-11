using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TruongMinhTri_2123110137
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        // Sự kiện khi thay đổi nội dung của TextBox
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        // Sự kiện khi nhấn vào button3
        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        // Sự kiện khi người dùng thay đổi lựa chọn trong ComboBox
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra ComboBox có giá trị không
            if (comboBox1.SelectedItem != null)
            {
                // Lấy mục được chọn từ ComboBox và hiển thị
                string selectedItem = comboBox1.SelectedItem.ToString();
                MessageBox.Show($"Bạn đã chọn: {selectedItem}");
            }
        }
    }
}
