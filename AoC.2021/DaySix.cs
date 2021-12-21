using AoC.Common;

namespace AoC._2021;

public class DaySix : IDay
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
        throw new NotImplementedException();
    }

    private class LanternFishSchool
    {
        private const int NewFishDaysToReproduce = 8;
        private const int ExistingFishDaysToReproduce = 6;
        private IEnumerable<int> _lanternFish;

        public LanternFishSchool(string[] lanternFish)
        {
            _lanternFish = lanternFish.Select(i => Convert.ToInt32(i));
        }

        public void SimulateDay()
        {
            var newSchool = new List<int>();

            foreach (var i in _lanternFish)
            {
                if (i == 0)
                {
                    newSchool.Add(NewFishDaysToReproduce);
                    newSchool.Add(ExistingFishDaysToReproduce);
                }
                else
                {
                    var daysToReproduction = i - 1;

                    newSchool.Add(daysToReproduction);
                }
            }

            _lanternFish = newSchool;
        }

        public int Count()
        {
            return _lanternFish.Count();
        }
    }
}