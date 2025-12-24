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

        private static Bitmap _birdBmp;

        static Bird()
        {
            _birdBmp = new Bitmap(global::FlappyBird3Layer.Properties.Resources.bird);
            _birdBmp.MakeTransparent(Color.White);
        }

        public Bird(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Jump(float jumpMul = 1f) => _velocity = _jumpForce * jumpMul;

        public void Update(float gravityMul = 1f)
        {
            _velocity += _gravity * gravityMul;
            Y += (int)_velocity;
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(_birdBmp, X, Y, 40, 30);
        }
    }
}
