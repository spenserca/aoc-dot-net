using AoC.Common;

namespace AoC._2023;

public class Day09 : IDayPartOne
{
    public string Title => "--- Day 9: Mirage Maintenance ---";

    public object PartOne(string[] input)
    {
        return input.Select(GetNextValueInHistory).Sum();
    }

    private static int GetNextValueInHistory(string history)
    {
        var sequences = new List<List<int>>();
        var sequence = history.Split(' ')
            .Select(int.Parse)
            .ToList();

        sequences.Add(sequence);

        while (!sequence.TrueForAll(v => v == 0))
        {
            sequence = GetNextSequence(sequence);
            sequences.Add(sequence);
        }

        for (var i = sequences.Count - 1; i > 0; i--)
        {
            var sequenceBelowLastValue = sequences[i].Last();
            var sequenceAboveLastValue = sequences[i - 1].Last();

            var aboveSequenceNextValue = sequenceBelowLastValue + sequenceAboveLastValue;
            sequences[i - 1].Add(aboveSequenceNextValue);
        }

        return sequences[0].Last();
    }

    private static List<int> GetNextSequence(IReadOnlyList<int> sequence)
    {
        var nextSequence = new List<int>();
        for (var i = 0; i < sequence.Count - 1; i++)
        {
            var a = sequence[i];
            var b = sequence[i + 1];
            nextSequence.Add(b - a);
        }

        if (nextSequence.TrueForAll(v => v == 0)) nextSequence.Add(0);

        return nextSequence;
    }
}