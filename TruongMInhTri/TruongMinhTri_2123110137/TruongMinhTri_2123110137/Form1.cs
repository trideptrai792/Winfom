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


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();

            // Hiển thị Form2
            form2.Show();

            // Ẩn Form1 (nếu cần)
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();

            // Hiển thị Form3
            form3.Show();

            // Ẩn Form1 (nếu cần)
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();

            // Hiển thị Form3
            form4.Show();

            // Ẩn Form1 (nếu cần)
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
                    }
    }
}
