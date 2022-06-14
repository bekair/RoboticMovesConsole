using RoboticMoves.Constants;
using RoboticMoves.Models;
using System;

namespace RoboticMoves.Helpers
{
    public class CoordinateParser : IInputParser<Grid>
    {
        public void Parse(string input, Grid grid)
        {
            var splittedArray = input.Split(' ');
            if (Convert.ToInt32(splittedArray[0]) > Constant.MAX_X_COORDINATE)
                throw new ArgumentException(
                    $"'{nameof(input)}' must be lower than {Constant.MAX_X_COORDINATE}.",
                    nameof(input)
                );
            if (Convert.ToInt32(splittedArray[1]) > Constant.MAX_Y_COORDINATE)
                throw new ArgumentException(
                    $"'{nameof(input)}' must be lower than {Constant.MAX_Y_COORDINATE}.",
                    nameof(input)
                );

            grid.UpperRightCoordinate = new Point(
                Convert.ToInt32(splittedArray[0]),
                Convert.ToInt32(splittedArray[1])
            );
        }
    }
}
