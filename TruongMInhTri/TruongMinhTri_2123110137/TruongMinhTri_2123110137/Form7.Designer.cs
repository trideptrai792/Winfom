using System.Drawing;
using System.Windows.Forms;

namespace TruongMinhTri_2123110137
{
    partial class Form7
    {
        private System.ComponentModel.IContainer components = null;

        // Control
        private DateTimePicker dtpDate;

        // Giải phóng tài nguyên
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        // Khởi tạo các điều khiển trên Form
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // Form7
            // 
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(400, 200);
            this.BackColor = Color.WhiteSmoke;
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = "Form7";
            this.Text = "Chọn ngày";
            // 
            // dtpDate
            // 
            this.dtpDate.Format = DateTimePickerFormat.Short;
            this.dtpDate.Size = new Size(200, 27);
            this.dtpDate.Location = new Point(
                (this.ClientSize.Width - this.dtpDate.Width) / 2,
                (this.ClientSize.Height - this.dtpDate.Height) / 2
            );
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.TabIndex = 0;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // Add controls
            // 
            this.Controls.Add(this.dtpDate);
            this.ResumeLayout(false);
        }
    }
}
