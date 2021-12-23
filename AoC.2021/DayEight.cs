using AoC.Common;

namespace AoC._2021;

public class DayEight : IDay
{
    public string Title => "--- Day 8: Seven Segment Search ---";

    private Dictionary<int, string[]> _signalPatternCountToPotentialSegments = new()
    {
        { 0, new[] { "a", "b", "c", "e", "f", "g" } },
        { 1, new[] { "c", "f" } },
        { 2, new[] { "a", "c", "d", "e", "g" } },
        { 3, new[] { "a", "c", "d", "f", "g" } },
        { 4, new[] { "b", "c", "d", "f" } },
        { 5, new[] { "a", "b", "d", "f", "g" } },
        { 6, new[] { "a", "b", "d", "e", "f", "g" } },
        { 7, new[] { "a", "c", "f" } },
        { 8, new[] { "a", "b", "c", "d", "e", "f", "g" } },
        { 9, new[] { "a", "b", "c", "d", "f", "g" } }
    };

    private Dictionary<int, int[]> _signalPatternLengthToDisplayNumbers = new Dictionary<int, int[]>()
    {
        { 2, new[] { 1 } },
        { 3, new[] { 7 } },
        { 4, new[] { 4 } },
        { 5, new[] { 2, 3, 5 } },
        { 6, new[] { 0, 6, 9 } },
        { 7, new[] { 8 } }
    };

    public object PartOne(string[] input)
    {
        return input.Select(i =>
            {
                var inputsAndOutputs = i.Split('|');

                return inputsAndOutputs[1];
            }).ToList()
            .SelectMany(o => o.Split(' '))
            .Count(v => new[] { 2, 3, 4, 7 }.Contains(v.Length));
    }

    public object PartTwo(string[] input)
    {
        throw new NotImplementedException();
    }
}