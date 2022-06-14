using RoboticMoves.Abstracts;
using RoboticMoves.Constants;
using RoboticMoves.Instructions;
using RoboticMoves.Models;
using System;
using System.Collections.Generic;

namespace RoboticMoves.Helpers
{
    public class RobotInstructionParser : IInputParser<Robot>
    {
        private readonly IDictionary<string, IInstruction> _instructionPair;

        public RobotInstructionParser()
        {
            _instructionPair = new Dictionary<string, IInstruction>()
            {
                { InstructionConstant.Left, new Left() },
                { InstructionConstant.Right, new Right() },
                { InstructionConstant.Forward, new Forward() }
            };
        }

        public void Parse(string input, Robot parseable)
        {
            if (input.Length >= Constant.MAX_INSTRUCTION_LENGTH)
                throw new ArgumentException(
                    $"'{nameof(input)}' must be lower than {Constant.MAX_INSTRUCTION_LENGTH}.",
                    nameof(input)
                );

            parseable.Instructions = new List<IInstruction>();
            using var inputIterator = input.GetEnumerator();
            while (inputIterator.MoveNext())
            {
                _instructionPair.TryGetValue(inputIterator.Current.ToString(), out IInstruction currentInstruction);
                parseable.Instructions.Add(currentInstruction);
            }
        }
    }
}
