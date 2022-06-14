using RoboticMoves.Helpers;
using RoboticMoves.Models;
using System;

namespace RoboticMoves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string coordinateStr, initialRobotPositionStr, instructionStr;
            CoordinateParser coordinateParser = new();
            RobotPositionParser robotPositionParser = new();
            RobotInstructionParser robotInstructionParser = new();
            Grid grid = new();

            //bool executionContinue = true;

            bool robotLoopContinue = true;
            while (robotLoopContinue)
            {
                try
                {
                    Console.Write("Enter coordinate: ");
                    coordinateStr = Console.ReadLine();

                    coordinateParser.Parse(coordinateStr, grid);
                    robotLoopContinue = false;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            int number = 3;
            while (number > 0)
            {
                Robot robot = new(grid);

                robotLoopContinue = true;
                while (robotLoopContinue)
                {
                    try
                    {
                        Console.Write("Enter Robot Position: ");
                        initialRobotPositionStr = Console.ReadLine();

                        robotPositionParser.Parse(initialRobotPositionStr, robot);
                        robotLoopContinue = false;
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                robotLoopContinue = true;
                while (robotLoopContinue)
                {
                    try
                    {
                        Console.Write("Enter Instructions: ");
                        instructionStr = Console.ReadLine();

                        robotInstructionParser.Parse(instructionStr, robot);
                        robotLoopContinue = false;
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                grid.Robots.Add(robot);
                number--;
            }
            using var robotEnumerator = grid.Robots.GetEnumerator();
            while (robotEnumerator.MoveNext())
            {
                robotEnumerator.Current.Move();
            }
        }
    }
}
