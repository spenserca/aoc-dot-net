using AoC.Common;

namespace AoC._2021;

public class Day06 : IDayPartOne, IDayPartTwo
{
    public string Title => "--- Day 6: Lanternfish ---";

    public object PartOne(string[] input)
    {
        var lanternFishSchool = new LanternFishSchool(input);

        for (var i = 0; i < 80; i++)
        {
            lanternFishSchool.SimulateDay();
        }

        return lanternFishSchool.Count();
    }

    public object PartTwo(string[] input)
    {
        var lanternFishSchool = new LanternFishSchool(input);

        for (var i = 0; i < 256; i++)
        {
            lanternFishSchool.SimulateDay();
        }

        return lanternFishSchool.Count();
    }

    private class LanternFishSchool
    {
        private readonly List<long> _fishWithGivenDaysToReproduction;

        public LanternFishSchool(string[] lanternFish)
        {
            _fishWithGivenDaysToReproduction = new List<long>()
            {
                0L,
                0L,
                0L,
                0L,
                0L,
                0L,
                0L,
                0L,
                0L
            };

            lanternFish
                .Select(i => Convert.ToInt32(i))
                .ToList()
                .ForEach(lf =>
                {
                    _fishWithGivenDaysToReproduction[lf] += 1;
                });
        }

        public void SimulateDay()
        {
            var countOfReproducingFish = _fishWithGivenDaysToReproduction[0];
            _fishWithGivenDaysToReproduction.RemoveAt(0);
            _fishWithGivenDaysToReproduction[6] += countOfReproducingFish;
            _fishWithGivenDaysToReproduction.Add(countOfReproducingFish);
        }

        public long Count()
        {
            return _fishWithGivenDaysToReproduction.Sum();
        }
    }
}
