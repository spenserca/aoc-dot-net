using AoC.Common;

namespace AoC._2024;

public class Day02 : IDayPartOne
{
    public string Title => "--- Day 2: Red-Nosed Reports ---";

    public object PartOne(string[] input)
    {
        return input.Select(i => new Report(i)).Count(r => r.IsSafe());
    }
}

public class Report(string value)
{
    private readonly List<int> _levels = value.Split(" ").Select(int.Parse).ToList();

    public bool IsSafe()
    {
        var isAscendingOrder = _levels.SequenceEqual(_levels.OrderBy(n => n));
        var isDescendingOrder = _levels.SequenceEqual(_levels.OrderByDescending(n => n));
        var isDiffNoLargerThanThree = true;
        for (int i = 0; i < _levels.Count - 1; i++)
        {
            var first = _levels[i];
            var second = _levels[i + 1];
            var diff = Math.Abs(first - second);
            if (diff == 0 || diff > 3)
                isDiffNoLargerThanThree = false;
        }

        return (isAscendingOrder || isDescendingOrder) && isDiffNoLargerThanThree;
    }
}
