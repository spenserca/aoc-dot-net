using System.Text.RegularExpressions;
using AoC.Common;

namespace AoC._2023;

public class Day02 : IDayPartOne, IDayPartTwo
{
    public string Title => "--- Day 2: Cube Conundrum ---";

    public object PartOne(string[] input)
    {
        return input.Select(i => new CubeGame(i, 12, 13, 14))
            .Where(g => g.IsPossible)
            .Sum(g => g.Id);
    }

    public object PartTwo(string[] input)
    {
        var sumOfPowers = 0;
        
        foreach (var i in input)
        {
            var minRedCubes = 0;
            var minGreenCubes = 0;
            var minBlueCubes = 0;
            
            var regex = new Regex("([0-9]+\\s(blue|red|green))");
            var matches = regex.Matches(i);
            
            foreach (Match match in matches)
            {
                switch (match.Value)
                {
                    case { } v when v.Contains("blue"):
                    {
                        var intValue = int.Parse(v.Split(' ')[0]);
                        if (intValue > minBlueCubes) minBlueCubes = intValue;
                        break;
                    }
                    case { } v when v.Contains("red"):
                    {
                        var intValue = int.Parse(v.Split(' ')[0]);
                        if (intValue > minRedCubes) minRedCubes = intValue;
                        break;
                    }
                    case { } v when v.Contains("green"):
                    {
                        var intValue = int.Parse(v.Split(' ')[0]);
                        if (intValue > minGreenCubes) minGreenCubes = intValue;
                        break;
                    }
                }
            }

            sumOfPowers += minRedCubes * minGreenCubes * minBlueCubes;
        }

        return sumOfPowers;
    }
    
    private sealed class CubeGame
    {
        public int Id { get; }

        public bool IsPossible { get; }

        public CubeGame(string gameDetails, int maxRedCubes, int maxGreenCubes, int maxBlueCubes)
        {
            Id = ParseGameId(gameDetails);
            IsPossible = !ParseContainsImpossibleHandfuls(gameDetails, maxRedCubes, maxGreenCubes, maxBlueCubes);
        }

        private static bool ParseContainsImpossibleHandfuls(string gameDetails, int maxRedCubes, int maxGreenCubes, int maxBlueCubes)
        {
            var regex = new Regex("([0-9]+\\s(blue|red|green))");
            var matches = regex.Matches(gameDetails);

            foreach (Match match in matches)
            {
                switch (match.Value)
                {
                    case { } v when v.Contains("blue"):
                    {
                        var intValue = int.Parse(v.Split(' ')[0]);
                        if (intValue > maxBlueCubes) return true;
                        break;
                    }
                    case { } v when v.Contains("red"):
                    {
                        var intValue = int.Parse(v.Split(' ')[0]);
                        if (intValue > maxRedCubes) return true;
                        break;
                    }
                    case { } v when v.Contains("green"):
                    {
                        var intValue = int.Parse(v.Split(' ')[0]);
                        if (intValue > maxGreenCubes) return true;
                        break;
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