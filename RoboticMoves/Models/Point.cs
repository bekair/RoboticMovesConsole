using System;

namespace RoboticMoves.Models
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool Equals(Point obj)
        {
            return obj != null && obj.X == X && obj.Y == Y;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Point);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }
}
