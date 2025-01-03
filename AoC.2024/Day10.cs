using AoC.Common;

namespace AoC._2024;

public class Day10 : IDayPartOne
{
    private ValueGrid _grid;
    public string Title => "--- Day 10: Hoof It ---";

    public object PartOne(string[] input)
    {
        _grid = GridBuilder.FromInput(input)
            .IncludeFilteredSubset(v => v.Value.AsInt == 0)
            .Build();

        var routes = FindRoutes(0, 9, [0], input.ToList());

        // create a map where the key is the trail head, and the value is the path
        // var map = _grid.FilteredSubset.Where(v => _grid.GetSurroundingCoordinates(v).).ToDictionary(trailHead => trailHead, _ => new List<ValueCoordinate>());
        //
        // foreach (var trailHead in map.Keys)
        // {
        //     var surroundingAndGraduallyIncreasing = _grid.GetSurroundingCoordinates(trailHead)
        //         .Where(v => v.Value.AsInt == trailHead.Value.AsInt + 1).ToList();
        //
        //     if (!surroundingAndGraduallyIncreasing.Any()) continue;
        //
        //     map[trailHead].AddRange(RecurseStuff(surroundingAndGraduallyIncreasing));
        // }
        //
        // // foreach trailhead in map
        // var totalScore = 0;
        // foreach (var trailHead in map.Keys)
        // {
        //     var score = map[trailHead].Where(v => v.Value.AsInt == 9).ToList();
        //     totalScore += score.Count;
        // }

        return 0;
    }

    // "89010123",
    // "78121874",
    // "87430965",
    // "96549874",
    // "45678903",
    // "32019012",
    // "01329801",
    // "10456732"    
    private void Blah()
    {
        
    }

    private List<List<int>> FindRoutes(int current, int target, List<int> path, List<string> input)
    {
        if (current == target) return [new List<int>(path)];

        var routes = new List<List<int>>();
        foreach (var value in input)
        {
            var index = value.IndexOf(current.ToString());
            if (index != -1 && index + 1 < value.Length)
            {
                var nextDigit = int.Parse(value[index + 1].ToString());
                if (nextDigit == current + 1 && !path.Contains(nextDigit))
                {
                    var newPath = new List<int>(path) { nextDigit };
                    routes.AddRange(FindRoutes(nextDigit, target, newPath, input));
                }
            }
        }
        
        return routes;
    }

    private List<ValueCoordinate> RecurseStuff(List<ValueCoordinate> valuesToRecurse)
    {
        var map = new List<ValueCoordinate>();
        foreach (var value in valuesToRecurse)
        {
            var surroundingAndGraduallyIncreasingValues = _grid.GetSurroundingCoordinates(value)
                .Where(v => v.Value.AsInt == value.Value.AsInt + 1).ToList();

            if (surroundingAndGraduallyIncreasingValues.Any()) map.Add(value);
        }


        foreach (var value in new List<ValueCoordinate>(map))
        {
            var surroundingAndGraduallyIncreasing = _grid.GetSurroundingCoordinates(value)
                .Where(v => v.Value.AsInt == value.Value.AsInt + 1).ToList();

            // return if no matches
            if (!surroundingAndGraduallyIncreasing.Any()) continue;

            // add surrounding coordinates to map for this starting point
            var recursed = RecurseStuff(surroundingAndGraduallyIncreasing);
            map.AddRange(recursed);
        }

        return map;
    }
}

public record Trail();

public record TrailHead(List<Trail> Trails);