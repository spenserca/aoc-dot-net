using AoC.Common;

namespace AoC._2021;

public class DaySeven : IDay
{
    public string Title => "--- Day 7: The Treachery of Whales ---";

    public object PartOne(string[] input)
    {
        var fuelAmount = int.MaxValue;

        var positions = input.Select(i => Convert.ToInt32(i)).ToList();

        positions
            .ForEach(p =>
            {
                var positionToMoveTo = p;
                var totalFuel = positions.Select(currentPosition => Math.Abs(currentPosition - positionToMoveTo)).Sum();

                if (totalFuel < fuelAmount)
                {
                    fuelAmount = totalFuel;
                }
            });

        return fuelAmount;
    }

    private int GetFactorial(int number)
    {
        var factorial = 0;

        for (int i = number; i > 0; i--)
        {
            factorial += i;
        }

        return factorial;
    }

    public object PartTwo(string[] input)
    {
        var fuelAmount = int.MaxValue;

        var positions = input.Select(i => Convert.ToInt32(i)).ToList();
        var maxPosition = positions.Max();

        for (int i = maxPosition; i > 0; i--)
        {
            var positionToMoveTo = i;
            var totalFuel = positions
                .Select(currentPosition =>
                {
                    var distance = Math.Abs(currentPosition - positionToMoveTo);
                    var factorial = GetFactorial(distance);
                    return factorial;
                }).Sum();

            if (totalFuel < fuelAmount)
            {
                fuelAmount = totalFuel;
            }
        }

        return fuelAmount;
    }
}