using System;
using System.Drawing;
using System.Windows.Forms;

namespace TruongMinhTri_2123110137
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            // Thiết lập dữ liệu cho ComboBox
            cb_Faculty.Items.Add("Công nghệ thông tin");
            cb_Faculty.Items.Add("Quản trị kinh doanh");
            cb_Faculty.Items.Add("Kế toán tài chính");
        }

        private void cb_Faculty_SelectedValueChanged(object sender, EventArgs e)
        {
            // Lấy giá trị đã chọn từ ComboBox
            string faculty = cb_Faculty.SelectedItem.ToString();
            MessageBox.Show("Bạn đã chọn khoa: " + faculty);
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            // Lấy tên từ TextBox và hiển thị
            string name = tbName.Text;
            MessageBox.Show("Tên của bạn là: " + name);
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}