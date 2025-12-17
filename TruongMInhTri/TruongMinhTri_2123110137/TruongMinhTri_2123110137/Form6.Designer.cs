using System.Windows.Forms;

namespace TruongMinhTri_2123110137
{
    partial class Form6
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private ComboBox cb_Faculty;
        private TextBox tbName;
        private Button btOK;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            cb_Faculty = new ComboBox();
            tbName = new TextBox();
            btOK = new Button();
            SuspendLayout();
            // 
            // cb_Faculty
            // 
            cb_Faculty.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Faculty.FormattingEnabled = true;
            cb_Faculty.Location = new Point(30, 30);
            cb_Faculty.Name = "cb_Faculty";
            cb_Faculty.Size = new Size(200, 28);
            cb_Faculty.TabIndex = 0;
            cb_Faculty.SelectedValueChanged += cb_Faculty_SelectedValueChanged;
            // 
            // tbName
            // 
            tbName.Location = new Point(30, 80);
            tbName.Name = "tbName";
            tbName.Size = new Size(200, 27);
            tbName.TabIndex = 1;
            tbName.TextChanged += tbName_TextChanged;
            // 
            // btOK
            // 
            btOK.Location = new Point(30, 130);
            btOK.Name = "btOK";
            btOK.Size = new Size(75, 30);
            btOK.TabIndex = 2;
            btOK.Text = "OK";
            btOK.UseVisualStyleBackColor = true;
            btOK.Click += btOK_Click;
            // 
            // Form6
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(947, 395);
            Controls.Add(btOK);
            Controls.Add(tbName);
            Controls.Add(cb_Faculty);
            Name = "Form6";
            Text = "Form6 - Demo ComboBox";
            Load += Form6_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
