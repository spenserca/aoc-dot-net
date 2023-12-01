using AoC.Common;

namespace AoC._2021;

public class Day03 : IDayPartOne, IDayPartTwo
{
    public string Title => "--- Day 3: Binary Diagnostic ---";

    public object PartOne(string[] input)
    {
        var bitCounters = GetBitCounts(input);

        var epsilonRate = "";
        var gammaRate = "";
        foreach (var (index, bits) in bitCounters)
        {
            var sumOfZeroes = bits.Count(b => b == 0);
            var sumOfOnes = bits.Count(b => b == 1);

            if (sumOfZeroes > sumOfOnes)
            {
                gammaRate += "0";
                epsilonRate += "1";
            }
            else
            {
                gammaRate += "1";
                epsilonRate += "0";
            }
        }

        return Convert.ToInt32(epsilonRate, 2) * Convert.ToInt32(gammaRate, 2);
    }

    public object PartTwo(string[] input)
    {
        var length = input.First().Length;
        var diagnosticsForOxygenRating = new List<string>(input);
        var diagnosticsForC02Rating = new List<string>(input);

        for (var i = 0; i < length; i++)
        {
            if (diagnosticsForOxygenRating.Count() > 1)
            {
                diagnosticsForOxygenRating = FilterDiagnosticsForOxygenRating(diagnosticsForOxygenRating, i);
            }

            if (diagnosticsForC02Rating.Count() > 1)
            {
                diagnosticsForC02Rating = FilterDiagnosticsForC02Rating(diagnosticsForC02Rating, i);
            }
        }

        var oxygenRating = Convert.ToInt32(diagnosticsForOxygenRating.First(), 2);
        var c02Rating = Convert.ToInt32(diagnosticsForC02Rating.First(), 2);

        return oxygenRating * c02Rating;
    }

    private static Dictionary<int, List<int>> GetBitCounts(string[] input)
    {
        var bitCounters = new Dictionary<int, List<int>>();

        foreach (var powerConsumption in input)
        {
            for (var j = 0; j < powerConsumption.Length; j++)
            {
                var bitValue = Convert.ToInt32(powerConsumption[j].ToString());
                if (bitCounters.ContainsKey(j))
                {
                    bitCounters[j].Add(bitValue);
                }
                else
                {
                    bitCounters[j] = new List<int> { bitValue };
                }
            }
        }

        return bitCounters;
    }

    private List<string> FilterDiagnosticsForC02Rating(List<string> diagnosticsForC02Rating, int index)
    {
        var bitCounters = GetBitCounts(diagnosticsForC02Rating.ToArray());
        var sumOfZeroes = bitCounters[index].Count(i => i == 0);
        var sumOfOnes = bitCounters[index].Count(i => i == 1);
        var valueToFind = sumOfZeroes <= sumOfOnes ? 0 : 1;

        return diagnosticsForC02Rating.Where(pc => pc[index].ToString() == valueToFind.ToString()).ToList();
    }

    private List<string> FilterDiagnosticsForOxygenRating(List<string> diagnosticsForOxygenRating, int index)
    {
        var bitCounters = GetBitCounts(diagnosticsForOxygenRating.ToArray());
        var sumOfZeroes = bitCounters[index].Count(i => i == 0);
        var sumOfOnes = bitCounters[index].Count(i => i == 1);
        var valueToFind = sumOfOnes >= sumOfZeroes ? 1 : 0;

        return diagnosticsForOxygenRating.Where(pc => pc[index].ToString() == valueToFind.ToString()).ToList();
    }
}