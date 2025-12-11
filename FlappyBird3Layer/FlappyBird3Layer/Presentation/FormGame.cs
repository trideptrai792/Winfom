using System;
using System.Windows.Forms;
using FlappyBird3Layer.Business;

namespace FlappyBird3Layer.Presentation
{
    public partial class FormGame : Form
    {
        private GameManager _game;
        private System.Windows.Forms.Timer _timer;

        public FormGame()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            _game = new GameManager(this.ClientSize.Width, this.ClientSize.Height);

            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 20;
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        // >>> THÊM HÀM NÀY <<<
        private void FormGame_Load(object sender, EventArgs e)
        {
            // Nếu cần khởi tạo gì thêm thì viết ở đây,
            // không thì cứ để trống cũng được.
        }
        // >>> HẾT PHẦN THÊM <<<

        private void Timer_Tick(object sender, EventArgs e)
        {
            _game.Update();
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            _game.Draw(e.Graphics);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode == Keys.Space)
            {
                if (_game.IsGameOver)
                    _game.Reset();
                else
                    _game.BirdJump();
            }
        }
    }
}
