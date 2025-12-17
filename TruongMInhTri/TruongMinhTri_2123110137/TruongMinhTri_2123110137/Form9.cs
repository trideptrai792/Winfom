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
    public partial class Form9 : Form
    {
        
        
            public Form9()
            {
                InitializeComponent();
                LoadData();
            }

            // DỮ LIỆU MẪU (CÓ NAM + NỮ)
            void LoadData()
            {
                dgvNhanVien.Rows.Add("53418", "Tuan Em", 20, "Nam");
                dgvNhanVien.Rows.Add("53419", "ABRdhuas", 22, "Nữ");
            }

            // KHÔNG CHO TICK CẢ 2
            private void chkNam_CheckedChanged(object sender, EventArgs e)
            {
                if (chkNam.Checked)
                    chkNu.Checked = false;
            }

            private void chkNu_CheckedChanged(object sender, EventArgs e)
            {
                if (chkNu.Checked)
                    chkNam.Checked = false;
            }

            // NÚT THÊM
            private void btnThem_Click(object sender, EventArgs e)
            {
                string gioiTinh = chkNam.Checked ? "Nam" : "Nữ";

                dgvNhanVien.Rows.Add(
                    txtMa.Text,
                    txtTen.Text,
                    txtTuoi.Text,
                    gioiTinh
                );

                ClearInput();
            }

            // CLICK DÒNG → ĐỔ DỮ LIỆU
            private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                if (e.RowIndex >= 0)
                {
                    txtMa.Text = dgvNhanVien.Rows[e.RowIndex].Cells[0].Value.ToString();
                    txtTen.Text = dgvNhanVien.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtTuoi.Text = dgvNhanVien.Rows[e.RowIndex].Cells[2].Value.ToString();

                    string gt = dgvNhanVien.Rows[e.RowIndex].Cells[3].Value.ToString();
                    chkNam.Checked = (gt == "Nam");
                    chkNu.Checked = (gt == "Nữ");
                }
            }

            private void btnXoa_Click(object sender, EventArgs e)
            {
                if (dgvNhanVien.CurrentRow != null)
                    dgvNhanVien.Rows.Remove(dgvNhanVien.CurrentRow);
            }

            private void btnThoat_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            void ClearInput()
            {
                txtMa.Clear();
                txtTen.Clear();
                txtTuoi.Clear();
                chkNam.Checked = true;
                chkNu.Checked = false;
            }
        }
    }
