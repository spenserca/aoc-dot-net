using AoC.Common;

namespace AoC._2022;

public class Day08 : IDay
{
    public string Title => "--- Day 8: Treetop Tree House ---";

    public object PartOne(string[] input)
    {
        var visibleTreeCount = 0;

        for (var i = 0; i < input.Length; i++)
        {
            var row = input[i];

            var isTopOrBottomRowOfTrees = i == 0 || i == input.Length - 1;
            if (isTopOrBottomRowOfTrees)
            {
                visibleTreeCount += row.Length;
                continue;
            }

            for (var j = 0; j < row.Length; j++)
            {
                var isLeftEdgeOutsideTopAndBottomRowOfTrees = j == 0 && i != input.Length - 1;
                if (isLeftEdgeOutsideTopAndBottomRowOfTrees)
                {
                    visibleTreeCount++;
                    continue;
                }

                var isRightEdgeOutsideOfTopAndBottomRowOfTrees = j == row.Length - 1 && i != input.Length - 1;
                if (isRightEdgeOutsideOfTopAndBottomRowOfTrees)
                {
                    visibleTreeCount++;
                    continue;
                }

                var currentTreeHeight = int.Parse(input[i][j].ToString());
                var isVisibleVertically = IsVisibleVertically(input, i, j, currentTreeHeight);
                var isVisibleHorizontally = IsVisibleHorizontally(input, i, j, currentTreeHeight);

                if (isVisibleHorizontally || isVisibleVertically) visibleTreeCount++;
            }
        }

        return visibleTreeCount;
    }

    private static bool IsVisibleHorizontally(string[] input, int i, int j, int currentTreeHeight)
    {
        var isVisibleFromLeft = true;
        var isVisibleFromRight = true;

        for (var x = 0; x < input[i].Length; x++)
        {
            if (x == j) continue;

            var treeHeight = int.Parse(input[i][x].ToString());

            if (x < j && treeHeight >= currentTreeHeight) isVisibleFromLeft = false;
            if (x > j && treeHeight >= currentTreeHeight) isVisibleFromRight = false;
        }

        return isVisibleFromLeft || isVisibleFromRight;
    }

    private static bool IsVisibleVertically(string[] input, int i, int j, int currentTreeHeight)
    {
        var isVisibleFromTop = true;
        var isVisibleFromBottom = true;

        for (var y = 0; y < input.Length; y++)
        {
            if (y == i) continue;

            var treeHeight = int.Parse(input[y][j].ToString());

            if (y < i && treeHeight >= currentTreeHeight) isVisibleFromTop = false;
            if (y > i && treeHeight >= currentTreeHeight) isVisibleFromBottom = false;
        }

        return isVisibleFromTop || isVisibleFromBottom;
    }

    public object PartTwo(string[] input)
    {
        throw new NotImplementedException();
    }
}