#nullable disable
namespace FlappyBird3Layer.Business
{
    public class Pipe
    {
        public int X { get; set; }
        public int GapY { get; set; }
        public int GapHeight { get; set; }
        public int Speed { get; set; }
        public bool Passed { get; set; }

        public Pipe(int startX, int gapY, int gapHeight, int speed)
        {
            X = startX;
            GapY = gapY;
            GapHeight = gapHeight;
            Speed = speed;
            Passed = false;
        }

        public void Update()
        {
            X -= Speed;
        }
    }
}
