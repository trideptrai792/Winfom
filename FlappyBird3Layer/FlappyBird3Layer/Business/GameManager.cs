#nullable disable
using System;
using System.Collections.Generic;
using System.Drawing;

namespace FlappyBird3Layer.Business
{

    public class GameManager
    {
        public List<PowerUp> PowerUps { get; private set; } = new List<PowerUp>();

        private int _shieldInvTicks;
        private bool _hasShield;

        private int _slowTicks;
        private int _magnetTicks;

        private int _drunkTicks;
        private int _drunkPhase;

        private double _speedMul = 1.0;

        private int _puCooldownPipes = 0;

        private const int BirdW = 40;
        private const int BirdH = 30;
        private const int PipeStartOffset = 80;

        public Bird Bird { get; private set; }
        public List<Pipe> Pipes { get; private set; } = new List<Pipe>();
        public int Score { get; private set; }
        public bool IsGameOver { get; private set; }
        public Image BirdImage { get; set; }

        private readonly int _formWidth;
        private readonly int _formHeight;
        private readonly Random _rand = new Random();

        private const int GroundHeight = 0;
        private const int PipeWidth = 60;

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
            PowerUps.Clear();

            SpawnPipe();

            _shieldInvTicks = 0;
            _hasShield = false;

            _slowTicks = 0;
            _magnetTicks = 0;

            _drunkTicks = 0;
            _drunkPhase = 0;

            _speedMul = 1.0;
            _puCooldownPipes = 0;
        }

   
        public void BirdJump()
        {
            if (IsGameOver) return;

            float jMul = (_drunkTicks > 0) ? -1f : 1f; // Drunk: đảo nhảy (nhấn là rơi)
            Bird.Jump(jMul);
        }

        public void Update()
        {
            if (IsGameOver) return;

            float gMul = (_drunkTicks > 0) ? -1f : 1f;   // Drunk: đảo gravity
            Bird.Update(gMul);

            if (_shieldInvTicks > 0) _shieldInvTicks--;
            if (_slowTicks > 0) _slowTicks--;
            if (_magnetTicks > 0) _magnetTicks--;
            if (_drunkTicks > 0) { _drunkTicks--; _drunkPhase++; }

            int baseSpeed = GetSpeed();
            int curSpeed = (_slowTicks > 0) ? (int)Math.Round(baseSpeed * 0.5) : baseSpeed;
            if (curSpeed < 1) curSpeed = 1;

            for (int i = 0; i < Pipes.Count; i++)
            {
                Pipes[i].Speed = curSpeed;
                Pipes[i].Update();
            }

            for (int i = 0; i < PowerUps.Count; i++)
            {
                PowerUps[i].X -= curSpeed;
            }

            for (int i = PowerUps.Count - 1; i >= 0; i--)
            {
                if (PowerUps[i].X < -120)
                    PowerUps.RemoveAt(i);
            }

            if (Pipes.Count > 0)
            {
                var last = Pipes[Pipes.Count - 1];
                int spawnDist = GetSpawnDistance();
                if (last.X < _formWidth - spawnDist)
                    SpawnPipe();
            }

            for (int i = Pipes.Count - 1; i >= 0; i--)
            {
                if (Pipes[i].X < -PipeWidth - 80)
                    Pipes.RemoveAt(i);
            }

            for (int i = 0; i < Pipes.Count; i++)
            {
                var p = Pipes[i];
                if (!p.Passed && (p.X + PipeWidth) < Bird.X)
                {
                    p.Passed = true;
                    Score++;
                }
            }

            float bcx = Bird.X + BirdW / 2f;
            float bcy = Bird.Y + BirdH / 2f;

            for (int i = PowerUps.Count - 1; i >= 0; i--)
            {
                var pu = PowerUps[i];

                // Magnet: hút powerup về chim
                if (_magnetTicks > 0)
                {
                    float mdx = bcx - pu.X;
                    float mdy = bcy - pu.Y;
                    float d2 = mdx * mdx + mdy * mdy;

                    if (d2 < 150f * 150f)
                    {
                        pu.X += (int)(mdx * 0.08f);
                        pu.Y += (int)(mdy * 0.08f);
                    }
                }

                float dx = bcx - pu.X;
                float dy = bcy - pu.Y;
                float r = pu.Radius + (BirdH / 2f);

                if (dx * dx + dy * dy <= r * r)
                {
                    switch (pu.Type)
                    {
                        case PowerUpType.Shield:
                            _hasShield = true;
                            break;

                        case PowerUpType.SlowTime:
                            _slowTicks = 150;
                            break;

                        case PowerUpType.Magnet:
                            _magnetTicks = 200;
                            break;

                        case PowerUpType.Drunk:
                            _drunkTicks = 220;
                            break;
                    }

                    PowerUps.RemoveAt(i);
                }
            }

            CheckCollision();
        }

        private void SpawnPipe()
        {
            int gapH = GetGapHeight();
            int speed = GetSpeed();

            int topMargin = 60;
            int bottomMargin = GroundHeight + 60;

            int minY = topMargin + gapH / 2;
            int maxY = _formHeight - bottomMargin - gapH / 2;
            if (maxY <= minY) maxY = minY + 1;

            int gapY = _rand.Next(minY, maxY);
            int startX = _formWidth + PipeStartOffset;

            Pipes.Add(new Pipe(startX, gapY, gapH, speed));

            if (_puCooldownPipes > 0) _puCooldownPipes--;

            if (_puCooldownPipes == 0 && _rand.NextDouble() < 0.25)
            {
                int t = _rand.Next(0, 4);
                PowerUpType type =
                    (t == 0) ? PowerUpType.Shield :
                    (t == 1) ? PowerUpType.SlowTime :
                    (t == 2) ? PowerUpType.Magnet :
                               PowerUpType.Drunk;

                int puX = startX + PipeWidth / 2;

                int yMin = gapY - gapH / 2 + 35;
                int yMax = gapY + gapH / 2 - 35;
                if (yMax <= yMin) yMax = yMin + 1;

                int puY = _rand.Next(yMin, yMax);

                PowerUps.Add(new PowerUp(type, puX, puY, 14));
                _puCooldownPipes = 4;
            }
        }

        private int GetSpeed()
        {
            int lv = Score / 5;
            int speed = 3 + lv;
            if (speed > 10) speed = 10;
            return speed;
        }

        private int GetGapHeight()
        {
            int lv = Score / 5;
            int gap = 170 - lv * 10;
            if (gap < 95) gap = 95;
            return gap;
        }

        private int GetSpawnDistance()
        {
            int lv = Score / 5;
            int dist = 290 - lv * 12;
            if (dist < 220) dist = 220;
            return dist;
        }

        private void CheckCollision()
        {
            if (_shieldInvTicks > 0) return;

            if (Bird.Y < 0 || Bird.Y > _formHeight - GroundHeight - BirdH)
            {
                if (_hasShield)
                {
                    _hasShield = false;
                    _shieldInvTicks = 40;

                    if (Bird.Y < 0) Bird.Y = 0;
                    if (Bird.Y > _formHeight - GroundHeight - BirdH)
                        Bird.Y = _formHeight - GroundHeight - BirdH;

                    return;
                }

                IsGameOver = true;
                return;
            }

            for (int i = 0; i < Pipes.Count; i++)
            {
                var p = Pipes[i];

                bool collideX = Bird.X + BirdW > p.X && Bird.X < p.X + PipeWidth;
                if (!collideX) continue;

                int topPipeBottom = p.GapY - p.GapHeight / 2;
                int bottomPipeTop = p.GapY + p.GapHeight / 2;

                bool hitTop = Bird.Y < topPipeBottom;
                bool hitBottom = Bird.Y + BirdH > bottomPipeTop;

                if (hitTop || hitBottom)
                {
                    if (_hasShield)
                    {
                        _hasShield = false;
                        _shieldInvTicks = 40;
                        return;
                    }

                    IsGameOver = true;
                    return;
                }
            }
        }

        public void Draw(Graphics g)
        {
            g.Clear(Color.SkyBlue);

            int camX = 0, camY = 0;
            if (_drunkTicks > 0)
            {
                camX = (_drunkPhase % 3) - 1;
                camY = ((_drunkPhase / 2) % 3) - 1;
            }
            g.TranslateTransform(camX, camY);

            string effects = "";
            if (_hasShield) effects += "S ";
            if (_slowTicks > 0) effects += "T ";
            if (_magnetTicks > 0) effects += "M ";
            if (_drunkTicks > 0) effects += "D ";
            if (effects.Length > 0)
                g.DrawString("PowerUp: " + effects, new Font("Arial", 14, FontStyle.Bold), Brushes.Black, 10, 25);

            using (Brush pipeBrush = new SolidBrush(Color.ForestGreen))
            {
                for (int i = 0; i < Pipes.Count; i++)
                {
                    var p = Pipes[i];

                    int topPipeBottom = p.GapY - p.GapHeight / 2;
                    int bottomPipeTop = p.GapY + p.GapHeight / 2;

                    g.FillRectangle(pipeBrush, p.X, 0, PipeWidth, topPipeBottom);
                    g.FillRectangle(pipeBrush, p.X, bottomPipeTop, PipeWidth, _formHeight - GroundHeight - bottomPipeTop);
                }
            }

            for (int i = 0; i < PowerUps.Count; i++)
            {
                var pu = PowerUps[i];

                Brush br = Brushes.Gold;
                string txt = "S";
                if (pu.Type == PowerUpType.SlowTime) { br = Brushes.LightBlue; txt = "T"; }
                else if (pu.Type == PowerUpType.Magnet) { br = Brushes.Violet; txt = "M"; }
                else if (pu.Type == PowerUpType.Drunk) { br = Brushes.Orange; txt = "D"; }

                g.FillEllipse(br, pu.X - pu.Radius, pu.Y - pu.Radius, pu.Radius * 2, pu.Radius * 2);
                g.DrawEllipse(Pens.Black, pu.X - pu.Radius, pu.Y - pu.Radius, pu.Radius * 2, pu.Radius * 2);

                using (Font f = new Font("Segoe UI", 10, FontStyle.Bold))
                    g.DrawString(txt, f, Brushes.Black, pu.X - 6, pu.Y - 8);
            }

            Bird.Draw(g);

            g.ResetTransform();

            using (Brush textBrush = new SolidBrush(Color.Black))
            using (Font font = new Font("Segoe UI", 16, FontStyle.Bold))
            {
                g.DrawString($"Score: {Score}", font, textBrush, 10, 10);

                if (IsGameOver)
                    g.DrawString("Game Over - nhấn Space để chơi lại", font, textBrush, 80, _formHeight / 2);
            }
        }
    }
}
