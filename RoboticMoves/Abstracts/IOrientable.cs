using RoboticMoves.Enums;
using System.Collections.Generic;

namespace RoboticMoves.Abstracts
{
    public interface IOrientable
    {
        IDictionary<OrientationEnum, OrientationEnum> OrientationDeterminationList { get; set; }
    }
}
