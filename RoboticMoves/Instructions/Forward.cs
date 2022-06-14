using RoboticMoves.Abstracts;
using RoboticMoves.Models;

namespace RoboticMoves.Instructions
{
    public class Forward : IInstruction
    {
        public void Run(Robot robot)
        {
            Point newPoint = new(robot.Position.X, robot.Position.Y);
            bool canForward = true;

            switch (robot.Orientation)
            {
                case Enums.OrientationEnum.N:
                    newPoint.Y = robot.Position.Y + 1;
                    canForward = newPoint.Y <= robot.MovingArea.UpperRightCoordinate.Y;
                    break;
                case Enums.OrientationEnum.S:
                    newPoint.Y = robot.Position.Y - 1;
                    canForward = newPoint.Y >= 0;
                    break;
                case Enums.OrientationEnum.E:
                    newPoint.X = robot.Position.X + 1;
                    canForward = newPoint.X <= robot.MovingArea.UpperRightCoordinate.X;
                    break;
                case Enums.OrientationEnum.W:
                    newPoint.X = robot.Position.X - 1;
                    canForward = newPoint.X >= 0;
                    break;
                default:
                    break;
            }

            if (robot.MovingArea.IsProhibitedCoordinate(newPoint))
                return;

            if (canForward)
            {
                robot.Position = new Point(newPoint.X, newPoint.Y);
            }
            else
            {
                robot.IsLost = true;
                robot.MovingArea.ProhibitedCoordinates.Add(newPoint);
            }
        }
    }
}