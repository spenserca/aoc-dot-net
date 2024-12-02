using AoC.Common;

namespace AoC._2024;

public class Day02 : IDayPartOne, IDayPartTwo
{
    public string Title => "--- Day 2: Red-Nosed Reports ---";

    public object PartOne(string[] input)
    {
        return input.Select(i => new Report(i)).Count(r => r.IsSafe());
    }

    public object PartTwo(string[] input)
    {
        return input.Select(i => new Report(i)).Count(r => r.IsSafe() || r.IsSafeAfterDampening());
    }
}

public class Report(string value)
{
    private readonly List<Level> _levels = value
        .Split(" ")
        .Select(int.Parse)
        .Select(v => new Level(v))
        .ToList();

    public bool IsSafe() => IsSafe(_levels);

    private static bool IsSafe(List<Level> levels)
    {
        var isAscendingOrder = levels.SequenceEqual(levels.OrderBy(n => n.Value));
        var isDescendingOrder = levels.SequenceEqual(levels.OrderByDescending(n => n.Value));
        var isDiffNoLargerThanThree = true;
        for (var i = 0; i < levels.Count - 1; i++)
        {
            var first = levels[i];
            var second = levels[i + 1];
            var diff = Math.Abs(first.Value - second.Value);
            if (diff is 0 or > 3)
            {
                isDiffNoLargerThanThree = false;
            }
        }

        return (isAscendingOrder || isDescendingOrder) && isDiffNoLargerThanThree;
    }

    public bool IsSafeAfterDampening()
    {
        var isSafeAfterDampening = false;
        for (var i = 0; i < _levels.Count; i++)
        {
            var dampenedLevels = _levels.ToList();
            dampenedLevels.RemoveAt(i);

            if (IsSafe(dampenedLevels))
                isSafeAfterDampening = true;
        }

        return isSafeAfterDampening;
    }
}

public record Level(int Value);
