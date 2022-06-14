using RoboticMoves.Models;

namespace RoboticMoves.Abstracts
{
    public interface IInstruction
    {
        void Run(Robot robot);
    }
}
