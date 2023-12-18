using AoC.Common;

namespace AoC._2023;

public class Day06 : IDayPartOne
{
    public string Title => "--- Day 6: Wait For It ---";

    public object PartOne(string[] input)
    {
        var raceDurations = input[0].Split(' ')
            .Where(v => int.TryParse(v, out _))
            .Select(int.Parse)
            .ToArray();
        var recordDistances = input[1].Split(' ')
            .Where(v => int.TryParse(v, out _))
            .Select(int.Parse)
            .ToArray();
        var races = raceDurations.Select((r, index) => new Race(r, recordDistances[index]));


        return races.Select(r => r.NumberOfWaysToWin())
            .Aggregate(1, (a, b) => a * b);
    }

    private class Race
    {
        private readonly int _duration;
        private readonly int _recordDistance;

        public Race(int duration, int recordDistance)
        {
            _duration = duration;
            _recordDistance = recordDistance;
        }

        public int NumberOfWaysToWin()
        {
            var numberOfWaysToWin = new List<int>();
            for (int i = 0; i <= _duration; i++)
            {
                var distanceTravelled = GetDistanceTravelled(i);
                if (distanceTravelled > _recordDistance) numberOfWaysToWin.Add(distanceTravelled);
            }

            return numberOfWaysToWin.Count;
        }

        private int GetDistanceTravelled(int speed)
        {
            var numberOfMillisTravelling = _duration - speed;

            return speed * numberOfMillisTravelling;
        }
    }
}