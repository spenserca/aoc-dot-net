using AoC.Common;

namespace AoC._2023;

public class Day09 : IDayPartOne
{
    public string Title => "--- Day 9: Mirage Maintenance ---";

    public object PartOne(string[] input)
    {
        return input.Select(GetNextValueInHistory).Sum();

        foreach (var i in input)
        {
            var sequence = i.Split(' ').ToList();

            while (!sequence.TrueForAll(v => v.Equals("0")))
            {
                sequence = GetNextSequence(sequence);
            }
        }

        return 0;
    }

    private int GetNextValueInHistory(string history)
    {
        var sequence = history.Split(' ')
            .Select(int.Parse)
            .Aggregate(0, (x, y) => x - y);

        return 0;
    }

    private List<string> GetNextSequence(List<string> sequence)
    {
        throw new NotImplementedException();
    }
}