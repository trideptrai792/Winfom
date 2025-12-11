#nullable disable
namespace FlappyBird3Layer.Business
{
    public class Pipe
    {
        public int X { get; set; }
        public int GapY { get; set; }
        public int GapHeight { get; set; }
        public int Speed { get; set; } = 3;

        public Pipe(int startX, int gapY, int gapHeight)
        {
            X = startX;
            GapY = gapY;
            GapHeight = gapHeight;
        }

        public void Update()
        {
            X -= Speed;
        }
    }
}
