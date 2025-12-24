using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TruongMinhTri_2123110137
{
    public partial class Form13 : Form
    {
        const int MaxEggs = 3;        // tối đa 3 trứng cùng lúc
        readonly List<PictureBox> _eggs = new();   // danh sách trứng
        readonly List<bool> _eggActive = new();    // trứng đang rơi hay không

        int _eggSpeed = 7;
           int _brokenEggCount = 0; 
        int _chickenX;
        int _chickenSpeed = 5;
        int _chickenDir = 1;
        private readonly Random _rand = new Random();
        int _score = 0;

        public Form13()
        {
            InitializeComponent();
            DoubleBuffered = true;

        }

        private void Form13_Load(object sender, EventArgs e)
        {
            // đảm bảo control thuộc về Form
            pbChicken.Parent = this;
            pbBasket.Parent = this;
            pbEgg.Parent = this;

            // dùng pbEgg làm mẫu, ẩn nó đi
            pbEgg.Visible = false;

            // vị trí gà ban đầu (giữa màn hình phía trên)
            _chickenX = ClientSize.Width / 2 - pbChicken.Width / 2;
            pbChicken.Top = 20;
            pbChicken.Left = _chickenX;

            // tạo 3 picturebox trứng từ mẫu
            for (int i = 0; i < MaxEggs; i++)
            {
                var egg = new PictureBox
                {
                    Size = pbEgg.Size,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Image = Properties.Resources.egg,
                    BackColor = Color.Transparent,
                    Visible = false
                };
                Controls.Add(egg);
                egg.BringToFront();

                _eggs.Add(egg);
                _eggActive.Add(false);
            }
        }

        // sinh trứng mới tại vị trí gần gà, tùy index để lệch trái/phải
        private void SpawnEgg(int index)
        {
            var egg = _eggs[index];
            _eggActive[index] = true;
            egg.Image = Properties.Resources.egg;
            egg.Visible = true;

            // Random vị trí X trên màn hình
            int x;
            bool ok;

            do
            {
                // random trong toàn màn hình
                x = _rand.Next(0, ClientSize.Width - egg.Width);

                // kiểm tra không đứng quá sát trứng đang rơi khác
                ok = true;
                for (int i = 0; i < MaxEggs; i++)
                {
                    if (i == index) continue;
                    if (!_eggActive[i]) continue;

                    // nếu khoảng cách X nhỏ hơn bề rộng trứng → coi là dính chùm
                    if (Math.Abs(_eggs[i].Left - x) < egg.Width)
                    {
                        ok = false;
                        break;
                    }
                }
            } while (!ok);

            int y = pbChicken.Bottom;      // cho rơi từ ngang bụng gà xuống
            egg.Location = new Point(x, y);
        }




        private void UpdateEgg(int index)
        {
            if (!_eggActive[index]) return;

            var egg = _eggs[index];
            egg.Top += _eggSpeed;

            // bắt được
            if (egg.Bounds.IntersectsWith(pbBasket.Bounds))
            {
                _score++;
                lblScore.Text = "Điểm: " + _score;
                _eggActive[index] = false;
                egg.Visible = false;
                return;
            }

            // rơi xuống đất -> vỡ
            if (egg.Bottom >= ClientSize.Height - 5)
            {
                egg.Image = Properties.Resources.egg_broken;
                _eggActive[index] = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // 1. gà bay qua lại
            _chickenX += _chickenDir * _chickenSpeed;
            if (_chickenX <= 0)
            {
                _chickenX = 0;
                _chickenDir = 1;
            }
            else if (_chickenX + pbChicken.Width >= ClientSize.Width)
            {
                _chickenX = ClientSize.Width - pbChicken.Width;
                _chickenDir = -1;
            }
            pbChicken.Left = _chickenX;

            // 2. xác định số trứng tối đa đang rơi theo độ khó
            int targetEggs =
                _score >= 10 ? 3 :
                _score >= 5 ? 2 :
                1;

            // đảm bảo luôn có đủ số trứng rơi
            for (int i = 0; i < targetEggs; i++)
            {
                if (!_eggActive[i])
                    SpawnEgg(i);
            }

            // 3. cập nhật tất cả trứng
            for (int i = 0; i < MaxEggs; i++)
                UpdateEgg(i);


            for (int i = 0; i < MaxEggs; i++)
            {
                if (!_eggActive[i]) continue;

                var egg = _eggs[i];
                egg.Top += _eggSpeed;

                // trứng chạm giỏ -> bắt được
                if (egg.Bounds.IntersectsWith(pbBasket.Bounds))
                {
                    _score++;
                    lblScore.Text = "Điểm: " + _score;
                    _eggActive[i] = false;
                    egg.Visible = false;
                    continue;
                }

                // TRỨNG VỠ (chạm đáy form)
                if (egg.Bottom >= ClientSize.Height)
                {
                    _brokenEggCount++;                         // +1 trứng vỡ
                    _eggActive[i] = false;
                    egg.Visible = false;

                    // nếu muốn hiện hình trứng vỡ thì có thể đổi ảnh trước khi ẩn
                    // egg.Image = Properties.Resources.egg_broken;

                    // kiểm tra điều kiện thua
                    if (_brokenEggCount > 7)
                    {
                        timer1.Stop();
                        MessageBox.Show("Bạn đã làm vỡ hơn 7 quả trứng. Gà bạn đã thua!");
                        Close();                                // đóng form
                        return;                                // thoát khỏi Tick
                    }
                }
            }
        }

        // di chuyển giỏ bằng ← →
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            int moveSpeed = 20;

            if (keyData == Keys.Left)
            {
                pbBasket.Left -= moveSpeed;
                if (pbBasket.Left < 0)
                    pbBasket.Left = 0;
                return true;
            }

            if (keyData == Keys.Right)
            {
                pbBasket.Left += moveSpeed;
                if (pbBasket.Right > ClientSize.Width)
                    pbBasket.Left = ClientSize.Width - pbBasket.Width;
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void pbEgg_Click(object sender, EventArgs e) { }

        private void pbBasket_Click(object sender, EventArgs e) { }
    }
}
