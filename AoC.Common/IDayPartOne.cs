namespace AoC.Common;

public interface IDayPartOne
{
    public string Title { get; }
    public object PartOne(string[] input);
}
