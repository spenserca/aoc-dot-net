namespace AoC.Common
{
    public interface IDay
    {
        public string Title { get; }
        public object PartOne(string[] input);
        public object PartTwo(string[] input);
    }   
}