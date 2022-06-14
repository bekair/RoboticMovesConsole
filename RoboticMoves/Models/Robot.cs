using RoboticMoves.Abstracts;
using RoboticMoves.Enums;
using RoboticMoves.Helpers.Abstracts;
using System;
using System.Collections.Generic;

namespace RoboticMoves.Models
{
    public class Robot : IParseable
    {
        public Grid MovingArea { get; set; }
        public ICollection<IInstruction> Instructions { get; set; }
        public OrientationEnum Orientation { get; set; }
        public Point Position { get; set; }
        public bool IsLost { get; set; }

        public Robot(Grid grid)
        {
            MovingArea = grid;
        }

        public void Move()
        {
            using var iterator = Instructions.GetEnumerator();
            while (iterator.MoveNext())
            {
                iterator.Current.Run(this);
                if (IsLost)
                {
                    Console.WriteLine(
                        $"{Position.X} {Position.Y} {Orientation} LOST"
                    );
                    return;
                }
            }
            Console.WriteLine(
                $"{Position.X} {Position.Y} {Orientation}"
            );
        }
    }
}
