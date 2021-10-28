namespace AoC._2020
{
    public interface IDay
    {
        public string Title { get; }
        public object PartOne(string[] input);
        public object PartTwo(string[] input);
    }
}