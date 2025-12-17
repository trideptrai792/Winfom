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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        // Nút chọn ảnh
        private void btFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image Files|*.jpg;*.png;*.bmp";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                picImage.Image = Image.FromFile(dlg.FileName);
            }
        }

        // Di chuyển sang trái
        private void btLeft_Click(object sender, EventArgs e)
        {
            picImage.Left -= 20;
        }

        // Di chuyển sang phải
        private void btRight_Click(object sender, EventArgs e)
        {
            picImage.Left += 20;
        }
    }
}
