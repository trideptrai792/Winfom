#nullable disable
using System;
using System.Collections.Generic;
using System.Drawing;

namespace FlappyBird3Layer.Business
{
    public class GameManager
    {
        public Bird Bird { get; private set; }
        public List<Pipe> Pipes { get; private set; } = new List<Pipe>();
        public int Score { get; private set; }
        public bool IsGameOver { get; private set; }
        public Image BirdImage { get; set; }
        private readonly int _formWidth;
        private readonly int _formHeight;
        private readonly Random _rand = new Random();

        public GameManager(int formWidth, int formHeight)
        {
            _formWidth = formWidth;
            _formHeight = formHeight;
            Reset();
        }

        public void Reset()
        {
            Score = 0;
            IsGameOver = false;
            Bird = new Bird(100, _formHeight / 2);
            Pipes.Clear();
            SpawnPipe();
        }

        public void BirdJump()
        {
            if (!IsGameOver)
                Bird.Jump();
        }

        public void Update()
        {
            if (IsGameOver) return;

            Bird.Update();

            foreach (var p in Pipes)
                p.Update();

            // pipe ra khỏi màn hình → bỏ, cộng điểm, spawn pipe mới
            if (Pipes.Count > 0 && Pipes[0].X < -50)
            {
                Pipes.RemoveAt(0);
                Score++;
                SpawnPipe();
            }

            CheckCollision();
        }

        private void SpawnPipe()
        {
            int gapY = _rand.Next(100, _formHeight - 100);
            int gapH = 150;
            int startX = _formWidth + 50;

            Pipes.Add(new Pipe(startX, gapY, gapH));
        }

        private void CheckCollision()
        {
            // chạm đất hoặc trần
            if (Bird.Y < 0 || Bird.Y > _formHeight - 30)
            {
                IsGameOver = true;
                return;
            }

            // va chạm pipe
            foreach (var p in Pipes)
            {
                bool collideX = Bird.X + 30 > p.X && Bird.X < p.X + 60;
                if (!collideX) continue;

                int topPipeBottom = p.GapY - p.GapHeight / 2;
                int bottomPipeTop = p.GapY + p.GapHeight / 2;
                bool hitTop = Bird.Y < topPipeBottom;
                bool hitBottom = Bird.Y + 30 > bottomPipeTop;

                if (hitTop || hitBottom)
                {
                    IsGameOver = true;
                    return;
                }
            }
        }

        // ====== VẼ GAME ======
        public void Draw(Graphics g)
        {
            // nền
            g.Clear(Color.SkyBlue);

            int groundHeight = 80;

            // mặt đất
            using (Brush groundBrush = new SolidBrush(Color.ForestGreen))
            {
                g.FillRectangle(groundBrush,
                    0, _formHeight - groundHeight,
                    _formWidth, groundHeight);
            }

            // ống
            using (Brush pipeBrush = new SolidBrush(Color.ForestGreen))
            {
                int pipeWidth = 60;

                foreach (var p in Pipes)
                {
                    int topPipeBottom = p.GapY - p.GapHeight / 2;
                    int bottomPipeTop = p.GapY + p.GapHeight / 2;

                    // ống trên
                    g.FillRectangle(pipeBrush,
                        p.X, 0,
                        pipeWidth, topPipeBottom);

                    // ống dưới
                    g.FillRectangle(pipeBrush,
                        p.X, bottomPipeTop,
                        pipeWidth, _formHeight - groundHeight - bottomPipeTop);
                }
            }

            // chim
            Bird.Draw(g);
            // điểm + Game Over
            using (Brush textBrush = new SolidBrush(Color.Black))
            using (Font font = new Font("Segoe UI", 16, FontStyle.Bold))
            {
                g.DrawString($"Score: {Score}", font, textBrush, 10, 10);

                if (IsGameOver)
                {
                    g.DrawString("Game Over - nhấn Space để chơi lại",
                        font, textBrush, 80, _formHeight / 2);
                }
            }
        }
    }
}
