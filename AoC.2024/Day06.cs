using AoC.Common;

namespace AoC._2024;

public class Day06: IDayPartOne
{
    public string Title => "--- Day 6: Guard Gallivant ---";
    
    public object PartOne(string[] input)
    {
        var grid = new Grid(input);

        var distinctPositions = new HashSet<GridCoordinate>();
        var guardPosition = GetGuardPosition(grid);
        distinctPositions.Add(guardPosition!);
        
        while (guardPosition is not null)
        {
            if (guardPosition.Value == "^")
            {
                while (guardPosition is not null)
                {
                    if (guardPosition.Value == "#")
                    {
                        guardPosition = guardPosition with { Value = ">" };
                        break;
                    }
                    guardPosition = grid.GetValueInDirection(guardPosition, Direction.Up);
                    distinctPositions.Add(guardPosition!);
                }
            }
            else if (guardPosition.Value == ">")
            {
                while (guardPosition is not null)
                {
                    if (guardPosition.Value == "#")
                    {
                        guardPosition = guardPosition with { Value = "v" };
                        break;
                    }
                    guardPosition = grid.GetValueInDirection(guardPosition, Direction.Right);
                    distinctPositions.Add(guardPosition!);
                }
            }
            else if (guardPosition.Value == "v")
            {
                while (guardPosition is not null)
                {
                    if (guardPosition.Value == "#")
                    {
                        guardPosition = guardPosition with { Value = "<" };
                        break;
                    }
                    guardPosition = grid.GetValueInDirection(guardPosition, Direction.Down);
                    distinctPositions.Add(guardPosition!);
                }
            }
            else if (guardPosition.Value == "<")
            {
                while (guardPosition is not null)
                {
                    if (guardPosition.Value == "#")
                    {
                        guardPosition = guardPosition with { Value = "^" };
                        break;
                    }
                    guardPosition = grid.GetValueInDirection(guardPosition, Direction.Left);
                    distinctPositions.Add(guardPosition!);
                }
            }
        }

        return distinctPositions.Count;
    }

    private GridCoordinate? GetGuardPosition(Grid grid)
    {
        return grid.GetByValue("^") ?? grid.GetByValue(">") ?? grid.GetByValue("v") ?? grid.GetByValue("<");
    }
}