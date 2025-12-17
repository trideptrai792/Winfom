namespace TruongMinhTri_2123110137
{
    partial class Form9
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dgvNhanVien = new System.Windows.Forms.DataGridView();
            this.colMa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTuoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.txtMa = new System.Windows.Forms.TextBox();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.txtTuoi = new System.Windows.Forms.TextBox();

            this.chkNam = new System.Windows.Forms.CheckBox();
            this.chkNu = new System.Windows.Forms.CheckBox();

            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).BeginInit();
            this.SuspendLayout();

            // 
            // dgvNhanVien
            // 
            this.dgvNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhanVien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colMa,
                this.colTen,
                this.colTuoi,
                this.colGioiTinh});
            this.dgvNhanVien.Location = new System.Drawing.Point(20, 20);
            this.dgvNhanVien.Name = "dgvNhanVien";
            this.dgvNhanVien.RowHeadersWidth = 51;
            this.dgvNhanVien.RowTemplate.Height = 24;
            this.dgvNhanVien.Size = new System.Drawing.Size(600, 200);
            this.dgvNhanVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNhanVien_CellClick);

            // 
            // Columns
            // 
            this.colMa.HeaderText = "Mã nhân viên";
            this.colMa.Width = 120;

            this.colTen.HeaderText = "Tên nhân viên";
            this.colTen.Width = 200;

            this.colTuoi.HeaderText = "Tuổi";
            this.colTuoi.Width = 80;

            this.colGioiTinh.HeaderText = "Giới tính";
            this.colGioiTinh.Width = 120;

            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(100, 240);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(200, 22);

            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(100, 270);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(300, 22);

            // 
            // txtTuoi
            // 
            this.txtTuoi.Location = new System.Drawing.Point(100, 300);
            this.txtTuoi.Name = "txtTuoi";
            this.txtTuoi.Size = new System.Drawing.Size(100, 22);

            // 
            // chkNam
            // 
            this.chkNam.AutoSize = true;
            this.chkNam.Location = new System.Drawing.Point(100, 330);
            this.chkNam.Name = "chkNam";
            this.chkNam.Size = new System.Drawing.Size(55, 20);
            this.chkNam.Text = "Nam";
            this.chkNam.UseVisualStyleBackColor = true;
            this.chkNam.Checked = true;
            this.chkNam.CheckedChanged += new System.EventHandler(this.chkNam_CheckedChanged);

            // 
            // chkNu
            // 
            this.chkNu.AutoSize = true;
            this.chkNu.Location = new System.Drawing.Point(170, 330);
            this.chkNu.Name = "chkNu";
            this.chkNu.Size = new System.Drawing.Size(47, 20);
            this.chkNu.Text = "Nữ";
            this.chkNu.UseVisualStyleBackColor = true;
            this.chkNu.CheckedChanged += new System.EventHandler(this.chkNu_CheckedChanged);

            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(220, 370);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(90, 30);
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(320, 370);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(90, 30);
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(420, 370);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(90, 30);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);

            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(650, 420);
            this.Controls.Add(this.dgvNhanVien);
            this.Controls.Add(this.txtMa);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.txtTuoi);
            this.Controls.Add(this.chkNam);
            this.Controls.Add(this.chkNu);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThoat);
            this.Name = "Form1";
            this.Text = "Quản lý nhân viên";

            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTuoi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGioiTinh;

        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.TextBox txtTuoi;

        private System.Windows.Forms.CheckBox chkNam;
        private System.Windows.Forms.CheckBox chkNu;

        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThoat;
    }
}