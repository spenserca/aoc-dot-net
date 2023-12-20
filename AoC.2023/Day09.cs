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
        var sequences = new List<IEnumerable<int>>();
        var sequence = history.Split(' ')
            .Select(int.Parse)
            .ToList();

        sequences.Add(sequence);

        while (!sequence.TrueForAll(v => v == 0))
        {
            sequence.Clear();
            sequence = GetNextSequence(sequence);
            sequences.Add(sequence);
        }

        return 0;
    }

    private static List<int> GetNextSequence(IReadOnlyList<int> sequence)
    {
        var nextSequence = new List<int>();
        for (var i = 0; i < sequence.Count - 1; i++)
        {
            var a = sequence[i];
            var b = sequence[i + 1];
            nextSequence.Add(a - b);
        }

        if (nextSequence.TrueForAll(v => v == 0)) nextSequence.Add(0);

        return nextSequence;
    }
}