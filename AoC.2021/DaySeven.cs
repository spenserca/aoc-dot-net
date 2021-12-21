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

    public object PartTwo(string[] input)
    {
        throw new NotImplementedException();
    }
}