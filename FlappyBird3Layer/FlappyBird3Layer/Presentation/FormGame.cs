#nullable disable
using FlappyBird3Layer.Business;
using System.Drawing.Drawing2D;


namespace FlappyBird3Layer.Presentation
{
    public partial class FormGame : Form
    {
        private const int VW = 900;
        private const int VH = 600;

        private enum UiState { Menu, Playing }
        private UiState _uiState = UiState.Menu;

        private readonly RectangleF _playRect = new RectangleF(360, 380, 180, 60);

        private GameManager _game;
        private System.Windows.Forms.Timer _timer;
        private int _prevScore;
        private bool _prevGameOver;

        public FormGame()
        {
            InitializeComponent();

            KeyPreview = true;
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            StartPosition = FormStartPosition.CenterScreen;
            DoubleBuffered = true;

            _game = new GameManager(VW, VH);
            _prevScore = _game.Score;
            _prevGameOver = _game.IsGameOver;

            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 20;
            _timer.Tick += Timer_Tick;
        }

        private void FormGame_Load(object sender, EventArgs e)
        {
        }

        private void StartGame()
        {
            _game.Reset();
            _prevScore = _game.Score;
            _prevGameOver = _game.IsGameOver;

            _uiState = UiState.Playing;
            _timer.Start();
            Focus();
            Invalidate();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (_uiState != UiState.Playing) return;

            _game.Update();

            if (_game.Score > _prevScore)
            {
              
                _prevScore = _game.Score;
            }

            if (!_prevGameOver && _game.IsGameOver)
            {

                FlappyBird3Layer.Business.Audio.PlayDie();
                _prevGameOver = true;
            }

            Invalidate();
        }

        private void GetViewport(out float s, out float ox, out float oy)
        {
            float sx = (float)ClientSize.Width / VW;
            float sy = (float)ClientSize.Height / VH;
            s = Math.Min(sx, sy);

            float drawW = VW * s;
            float drawH = VH * s;

            ox = (ClientSize.Width - drawW) / 2f;
            oy = (ClientSize.Height - drawH) / 2f;
        }

        private void DrawMenu(Graphics g)
        {
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.PixelOffsetMode = PixelOffsetMode.Half;

            var bg = Properties.Resources.back;
            g.DrawImage(bg, 0, 0, VW, VH);
            using (Font f = new Font("Segoe UI", 16, FontStyle.Bold))
            using (Brush b = new SolidBrush(Color.Black))
            {
                g.DrawString($"Best: {_game.HighScore}", f, b, 10, 10);
            }
            string title = "FlappyBird";
            using (Font f = new Font("Arial Black", 56, FontStyle.Bold))
            {
                SizeF sz = g.MeasureString(title, f);
                float x = (VW - sz.Width) / 2f;
                float y = 110f;

                using (Brush outline = new SolidBrush(Color.Black))
                using (Brush fill = new SolidBrush(Color.White))
                {
                    g.DrawString(title, f, outline, x - 3, y);
                    g.DrawString(title, f, outline, x + 3, y);
                    g.DrawString(title, f, outline, x, y - 3);
                    g.DrawString(title, f, outline, x, y + 3);
                    g.DrawString(title, f, fill, x, y);
                }
            }

            var bird = Properties.Resources.bird;
            g.DrawImage(bird, VW / 2 - 40, 250, 80, 60);

            using (Brush btnFill = new SolidBrush(Color.White))
            using (Pen btnPen = new Pen(Color.Black, 3))
            {
                g.FillRectangle(btnFill, _playRect.X, _playRect.Y, _playRect.Width, _playRect.Height);
                g.DrawRectangle(btnPen, _playRect.X, _playRect.Y, _playRect.Width, _playRect.Height);
            }

            using (Font f = new Font("Arial Black", 26, FontStyle.Bold))
            using (Brush b = new SolidBrush(Color.Black))
            {
                string t = "PLAY";
                SizeF ts = g.MeasureString(t, f);
                float tx = _playRect.X + (_playRect.Width - ts.Width) / 2f;
                float ty = _playRect.Y + (_playRect.Height - ts.Height) / 2f;
                g.DrawString(t, f, b, tx, ty);
            }

            using (Font f = new Font("Segoe UI", 14, FontStyle.Bold))
            using (Brush b = new SolidBrush(Color.Black))
            {
                g.DrawString("Click PLAY để bắt đầu", f, b, 320, 470);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            GetViewport(out float s, out float ox, out float oy);

            e.Graphics.TranslateTransform(ox, oy);
            e.Graphics.ScaleTransform(s, s);

            if (_uiState == UiState.Menu)
                DrawMenu(e.Graphics);
            else
                _game.Draw(e.Graphics);

            e.Graphics.ResetTransform();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (_uiState != UiState.Menu) return;

            GetViewport(out float s, out float ox, out float oy);
            if (s <= 0.0001f) return;

            float vx = (e.X - ox) / s;
            float vy = (e.Y - oy) / s;

            if (_playRect.Contains(vx, vy))
                StartGame();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (_uiState == UiState.Menu)
            {
                if (e.KeyCode == Keys.Space) StartGame();
                return;
            }


            if (e.KeyCode == Keys.Space)
            {
                if (_game.IsGameOver)
                {
                    _game.Reset();
                    _prevScore = _game.Score;
                    _prevGameOver = _game.IsGameOver;
                } 

                else
                {
                    FlappyBird3Layer.Business.Audio.PlayJump();
                    _game.BirdJump();
                }
            }
        }
    }
}
