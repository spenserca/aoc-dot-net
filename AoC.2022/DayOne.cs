using AoC.Common;

namespace AoC._2022;

public class DayOne : IDay
{
    public string Title => "--- Day 1: Calorie Counting ---";

    public object PartOne(string[] input)
    {
        var mostCalories = 0;
        var currentElfCalories = 0;

        for (var i = 0; i < input.Length; i++)
        {
            var elvesCalories = input[i];
            if (elvesCalories == string.Empty)
            {
                if (currentElfCalories > mostCalories) mostCalories = currentElfCalories;
                currentElfCalories = 0;
            } else if (i == input.Length - 1)
            {
                currentElfCalories += int.Parse(elvesCalories);
                if (currentElfCalories > mostCalories) mostCalories = currentElfCalories;
            }
            else
            {
                currentElfCalories += int.Parse(elvesCalories);
            }
        }

        return mostCalories;
    }

    public object PartTwo(string[] input)
    {
        var summedElvesCalories = new List<int>();
        var currentElfCalories = 0;

        for (var i = 0; i < input.Length; i++)
        {
            var elvesCalories = input[i];
            if (elvesCalories == string.Empty)
            {
                summedElvesCalories.Add(currentElfCalories);
                currentElfCalories = 0;
            } else if (i == input.Length - 1)
            {
                currentElfCalories += int.Parse(elvesCalories);
                summedElvesCalories.Add(currentElfCalories);
            }
            else
            {
                currentElfCalories += int.Parse(elvesCalories);
            }
        }

        summedElvesCalories.Sort((a, b) => b - a);

        return summedElvesCalories.Take(3).Sum();
    }
}