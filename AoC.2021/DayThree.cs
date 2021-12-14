using AoC.Common;

namespace AoC._2021
{
    public class DayThree : IDay
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

        private static Dictionary<int, List<int>> GetBitCounts(string[] input)
        {
            var bitCounters = new Dictionary<int, List<int>>();

            foreach (var powerConsumption in input)
            {
                for (int j = 0; j < powerConsumption.Length; j++)
                {
                    var bitValue = Convert.ToInt32(powerConsumption[j].ToString());
                    if (bitCounters.ContainsKey(j))
                    {
                        bitCounters[j].Add(bitValue);
                    }
                    else
                    {
                        bitCounters[j] = new List<int>() { bitValue };
                    }
                }
            }

            return bitCounters;
        }

        public object PartTwo(string[] input)
        {
            throw new NotImplementedException();
        }
    }
}