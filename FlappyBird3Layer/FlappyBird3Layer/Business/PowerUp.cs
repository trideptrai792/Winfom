#nullable disable
using System;

namespace FlappyBird3Layer.Business
{
    public enum PowerUpType
    {
        Shield,
        SlowTime,
        Magnet,
        Drunk
    }

    public class PowerUp
    {
        public PowerUpType Type { get; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Radius { get; }

        public PowerUp(PowerUpType type, int x, int y, int radius = 14)
        {
            Type = type;
            X = x;
            Y = y;
            Radius = radius;
        }
    }
}
