using RoboticMoves.Abstracts;
using RoboticMoves.Enums;
using RoboticMoves.Models;
using System.Collections.Generic;

namespace RoboticMoves.Instructions
{
    public class Right : IInstruction, IOrientable
    {
        public IDictionary<OrientationEnum, OrientationEnum> OrientationDeterminationList { get; set; }

        public Right()
        {
            OrientationDeterminationList = new Dictionary<OrientationEnum, OrientationEnum>
            {
                { OrientationEnum.N, OrientationEnum.E },
                { OrientationEnum.E, OrientationEnum.S },
                { OrientationEnum.S, OrientationEnum.W },
                { OrientationEnum.W, OrientationEnum.N }
            };
        }

        public void Run(Robot robot)
        {
            OrientationDeterminationList.TryGetValue(robot.Orientation, out OrientationEnum newOrientation);
            robot.Orientation = newOrientation;
        }
    }
}