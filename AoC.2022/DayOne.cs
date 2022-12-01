using AoC.Common;

namespace AoC._2022;

public class DayOne : IDay
{
    public string Title => "--- Day 1: Calorie Counting ---";

    public object PartOne(string[] input)
    {
        var mostCalories = 0;
        var currentElfCalories = 0;

        foreach (var elvesCalories in input)
        {
            if (elvesCalories == string.Empty)
            {
                if (currentElfCalories > mostCalories) mostCalories = currentElfCalories;
                currentElfCalories = 0;
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
        throw new NotImplementedException();
    }
}