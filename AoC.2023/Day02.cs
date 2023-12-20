using System.Text.RegularExpressions;
using AoC.Common;

namespace AoC._2023;

public class Day02 : IDayPartOne, IDayPartTwo
{
    public string Title => "--- Day 2: Cube Conundrum ---";

    public object PartOne(string[] input)
    {
        return input
            .Select(i => new CubeGame(i, 12, 13, 14))
            .Where(g => g.IsPossible)
            .Sum(g => g.Id);
    }

    public object PartTwo(string[] input)
    {
        return input
            .Select(i =>
            {
                var minRedCubes = 0;
                var minGreenCubes = 0;
                var minBlueCubes = 0;

                var regex = new Regex("([0-9]+\\s(blue|red|green))");
                var matches = regex.Matches(i);

                foreach (Match match in matches)
                {
                    var handfulDetails = match.Value.Split(' ');
                    var intValue = int.Parse(handfulDetails[0]);

                    switch (handfulDetails[1])
                    {
                        case "blue" when intValue > minBlueCubes:
                        {
                            minBlueCubes = intValue;
                            break;
                        }
                        case "red" when intValue > minRedCubes:
                        {
                            minRedCubes = intValue;
                            break;
                        }
                        case "green" when intValue > minGreenCubes:
                        {
                            minGreenCubes = intValue;
                            break;
                        }
                    }
                }

                return minRedCubes * minGreenCubes * minBlueCubes;
            })
            .Sum();
    }

    private sealed class CubeGame
    {
        public int Id { get; }

        public bool IsPossible { get; }

        public CubeGame(string gameDetails, int maxRedCubes, int maxGreenCubes, int maxBlueCubes)
        {
            Id = ParseGameId(gameDetails);
            IsPossible = !ParseContainsImpossibleHandfuls(
                gameDetails,
                maxRedCubes,
                maxGreenCubes,
                maxBlueCubes
            );
        }

        private static bool ParseContainsImpossibleHandfuls(
            string gameDetails,
            int maxRedCubes,
            int maxGreenCubes,
            int maxBlueCubes
        )
        {
            var regex = new Regex("([0-9]+\\s(blue|red|green))");
            var matches = regex.Matches(gameDetails);

            foreach (Match match in matches)
            {
                var handfulDetails = match.Value.Split(' ');
                var intValue = int.Parse(handfulDetails[0]);

                switch (handfulDetails[1])
                {
                    case "blue" when intValue > maxBlueCubes:
                    {
                        return true;
                    }
                    case "red" when intValue > maxRedCubes:
                    {
                        return true;
                    }
                    case "green" when intValue > maxGreenCubes:
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static int ParseGameId(string gameDetails)
        {
            const int gameIdIndex = 5;
            var lengthOfGameId = gameDetails.IndexOf(':') - gameIdIndex;
            return int.Parse(gameDetails.Substring(gameIdIndex, lengthOfGameId));
        }
    }
}
