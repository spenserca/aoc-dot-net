using AoC.Common;

namespace AoC._2021;

public class DayOne : IDay
{
    public string Title => "--- Day 1: Sonar Sweep ---";

    public object PartOne(string[] input)
    {
        var increaseCount = 0;
        for (var i = 0; i < input.Length - 1; i++)
        {
            var currentValue = Convert.ToInt32(input[i]);
            var nextValue = Convert.ToInt32(input[i + 1]);

            if (nextValue > currentValue)
            {
                increaseCount++;
            }
        }

        return increaseCount;
    }

    public object PartTwo(string[] input)
    {
        var slidingWindowValues = new List<string>();

        for (var i = 0; i < input.Length - 2; i++)
        {
            var firstValue = Convert.ToInt32(input[i]);
            var secondValue = Convert.ToInt32(input[i + 1]);
            var thirdValue = Convert.ToInt32(input[i + 2]);

            slidingWindowValues.Add((firstValue + secondValue + thirdValue).ToString());
        }

        return PartOne(slidingWindowValues.ToArray());
    }
}