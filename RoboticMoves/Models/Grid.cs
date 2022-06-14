using RoboticMoves.Abstracts;
using RoboticMoves.Helpers.Abstracts;
using System.Collections.Generic;

namespace RoboticMoves.Models
{
    public class Grid : IParseable
    {
        public ICollection<Robot> Robots { get; set; }
        public ICollection<Point> ProhibitedCoordinates { get; set; }
        public Point UpperRightCoordinate { get; set; }

        public Grid()
        {
            ProhibitedCoordinates = new List<Point>();
            Robots = new List<Robot>();
        }

        public bool IsProhibitedCoordinate(Point point)
        {
            return ProhibitedCoordinates.Contains(point);
        }
    }
}