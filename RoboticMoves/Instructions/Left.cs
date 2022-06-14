using RoboticMoves.Abstracts;
using RoboticMoves.Enums;
using RoboticMoves.Models;
using System.Collections.Generic;

namespace RoboticMoves.Instructions
{
    public class Left : IInstruction, IOrientable
    {
        public IDictionary<OrientationEnum, OrientationEnum> OrientationDeterminationList { get; set; }

        public Left()
        {
            OrientationDeterminationList = new Dictionary<OrientationEnum, OrientationEnum>
            {
                { OrientationEnum.N, OrientationEnum.W },
                { OrientationEnum.W, OrientationEnum.S },
                { OrientationEnum.S, OrientationEnum.E },
                { OrientationEnum.E, OrientationEnum.N }
            };
        }
        public void Run(Robot robot)
        {
            OrientationDeterminationList.TryGetValue(robot.Orientation, out OrientationEnum newOrientation);
            robot.Orientation = newOrientation;
        }
    }
}
