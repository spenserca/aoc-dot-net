using AoC.Common;

namespace AoC._2023;

public class Day06 : IDayPartOne, IDayPartTwo
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
        var races = raceDurations.Select((r, index) => new BoatRace(r, recordDistances[index]));

        return races.Select(r => r.NumberOfWaysToWin())
            .Aggregate(1, (a, b) => a * b);
    }

    public object PartTwo(string[] input)
    {
        var raceDuration = string.Join("", input[0].Split(' ')
            .Where(v => int.TryParse(v, out _))
            .Select(int.Parse)
            .ToArray());
        var recordDistance = string.Join("", input[1].Split(' ')
            .Where(v => int.TryParse(v, out _))
            .Select(int.Parse)
            .ToArray());

        return new BoatRace(long.Parse(raceDuration), long.Parse(recordDistance)).NumberOfWaysToWin();
    }

    private sealed class BoatRace
    {
        private readonly long _duration;
        private readonly long _recordDistance;

        public BoatRace(int duration, int recordDistance)
        {
            _duration = duration;
            _recordDistance = recordDistance;
        }

        public BoatRace(long duration, long recordDistance)
        {
            _duration = duration;
            _recordDistance = recordDistance;
        }

        public int NumberOfWaysToWin()
        {
            var numberOfWaysToWin = new List<long>();
            for (var i = 0; i <= _duration; i++)
            {
                var distanceTravelled = GetDistanceTravelled(i);
                if (distanceTravelled > _recordDistance) numberOfWaysToWin.Add(distanceTravelled);
            }

            return numberOfWaysToWin.Count;
        }

        private long GetDistanceTravelled(int speed)
        {
            var numberOfMillisTravelling = _duration - speed;

            return speed * numberOfMillisTravelling;
        }
    }
}