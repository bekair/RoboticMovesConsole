using RoboticMoves.Helpers.Abstracts;

namespace RoboticMoves.Helpers
{
    public interface IInputParser<T> where T : class, IParseable
    {
        public void Parse(string input, T parseable);
    }
}
