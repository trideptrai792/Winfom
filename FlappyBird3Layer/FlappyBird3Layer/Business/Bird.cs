#nullable disable
using System.Drawing;

namespace FlappyBird3Layer.Business
{
    public class Bird
    {
        public int X { get; set; }
        public int Y { get; set; }

        private float _velocity;
        private float _gravity = 0.6f;
        private float _jumpForce = -10f;

        public Bird(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Jump()
        {
            _velocity = _jumpForce;
        }

        public void Update()
        {
            _velocity += _gravity;
            Y += (int)_velocity;
        }

        public void Draw(Graphics g)
        {
            // TEST 1: vẽ hình chữ nhật đỏ để chắc chắn chim đang được vẽ
            // g.FillRectangle(Brushes.Red, X, Y, 40, 30);

            // TEST 2: dùng đúng resource bird
            var img = global::FlappyBird3Layer.Properties.Resources.bird;
            g.DrawImage(img, X, Y, 40, 30);
        }
    }
}
