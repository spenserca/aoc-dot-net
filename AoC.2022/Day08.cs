using AoC.Common;

namespace AoC._2022;

public class Day08 : IDayPartOne, IDayPartTwo
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
                var isRightEdgeOutsideOfTopAndBottomRowOfTrees =
                    j == row.Length - 1 && i != input.Length - 1;
                if (
                    isLeftEdgeOutsideTopAndBottomRowOfTrees
                    || isRightEdgeOutsideOfTopAndBottomRowOfTrees
                )
                {
                    visibleTreeCount++;
                    continue;
                }

                var currentTreeHeight = int.Parse(input[i][j].ToString());
                var isVisibleVertically = IsVisibleVertically(input, i, j, currentTreeHeight);
                var isVisibleHorizontally = IsVisibleHorizontally(input, i, j, currentTreeHeight);

                if (isVisibleHorizontally || isVisibleVertically)
                    visibleTreeCount++;
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
            if (x == j)
                continue;

            var treeHeight = int.Parse(input[i][x].ToString());

            if (x < j && treeHeight >= currentTreeHeight)
                isVisibleFromLeft = false;
            if (x > j && treeHeight >= currentTreeHeight)
                isVisibleFromRight = false;
        }

        return isVisibleFromLeft || isVisibleFromRight;
    }

    private static bool IsVisibleVertically(string[] input, int i, int j, int currentTreeHeight)
    {
        var isVisibleFromTop = true;
        var isVisibleFromBottom = true;

        for (var y = 0; y < input.Length; y++)
        {
            if (y == i)
                continue;

            var treeHeight = int.Parse(input[y][j].ToString());

            if (y < i && treeHeight >= currentTreeHeight)
                isVisibleFromTop = false;
            if (y > i && treeHeight >= currentTreeHeight)
                isVisibleFromBottom = false;
        }

        return isVisibleFromTop || isVisibleFromBottom;
    }

    public object PartTwo(string[] input)
    {
        var highestScenicScore = 0;

        for (var i = 0; i < input.Length; i++)
        {
            var row = input[i];

            var isTopOrBottomRowOfTrees = i == 0 || i == input.Length - 1;
            if (isTopOrBottomRowOfTrees)
            {
                continue;
            }

            for (var j = 0; j < row.Length; j++)
            {
                var isLeftEdgeOutsideTopAndBottomRowOfTrees = j == 0 && i != input.Length - 1;
                var isRightEdgeOutsideOfTopAndBottomRowOfTrees =
                    j == row.Length - 1 && i != input.Length - 1;

                if (
                    isLeftEdgeOutsideTopAndBottomRowOfTrees
                    || isRightEdgeOutsideOfTopAndBottomRowOfTrees
                )
                {
                    continue;
                }

                var scenicScore = CalculateScenicScore(input, i, j);

                if (scenicScore > highestScenicScore)
                    highestScenicScore = scenicScore;
            }
        }

        return highestScenicScore;
    }

    private int CalculateScenicScore(string[] input, int i, int j)
    {
        var scenicScoreLookingUp = 0;
        var scenicScoreLookingDown = 0;
        var scenicScoreLookingLeft = 0;
        var scenicScoreLookingRight = 0;
        var currentHeight = int.Parse(input[i][j].ToString());

        for (var y = i - 1; y >= 0; y--)
        {
            var treeHeight = int.Parse(input[y][j].ToString());
            scenicScoreLookingUp++;
            if (treeHeight >= currentHeight)
                break;
        }

        for (var y = i + 1; y < input.Length; y++)
        {
            var treeHeight = int.Parse(input[y][j].ToString());
            scenicScoreLookingDown++;
            if (treeHeight >= currentHeight)
                break;
        }

        for (var x = j - 1; x >= 0; x--)
        {
            var treeHeight = int.Parse(input[i][x].ToString());
            scenicScoreLookingLeft++;
            if (treeHeight >= currentHeight)
                break;
        }

        for (var x = j + 1; x < input[i].Length; x++)
        {
            var treeHeight = int.Parse(input[i][x].ToString());
            scenicScoreLookingRight++;
            if (treeHeight >= currentHeight)
                break;
        }

        return scenicScoreLookingDown
            * scenicScoreLookingUp
            * scenicScoreLookingLeft
            * scenicScoreLookingRight;
    }
}
