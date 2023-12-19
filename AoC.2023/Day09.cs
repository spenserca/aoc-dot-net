using AoC.Common;

namespace AoC._2023;

public class Day09: IDayPartOne
{
    public string Title => "--- Day 9: Mirage Maintenance ---";

    public object PartOne(string[] input)
    {
        foreach (var i in input)
        {
            var sequence = i.Split(' ').ToList();

            while (!sequence.TrueForAll(v => v.Equals("0")))
            {
                sequence = GetNextSequence(sequence);
            }
        }
    }

    private List<string> GetNextSequence(List<string> sequence)
    {
        throw new NotImplementedException();
    }
}