using AoC.Common;

namespace AoC._2020
{
    public class DayThree : IDay
    {
        public string Title => "--- Day 3: Toboggan Trajectory ---";

        public object PartOne(string[] input)
        {
            var x = 3;
            var treeCount = 0;

            // start on second line
            for (int i = 1; i < input.Length; i++)
            {
                var line = input[i];
                var location = line[x];
                var tree = '#';

                if (location == tree)
                {
                    treeCount++;
                }

                x = MoveHorizontally(x, line.Length);
            }

            return treeCount;
        }

        private static int MoveHorizontally(int currentLocation, int wrapPoint)
        {
            currentLocation += 3;
            if (currentLocation >= wrapPoint)
            {
                currentLocation -= wrapPoint;
            }

            return currentLocation;
        }

        public object PartTwo(string[] input)
        {
            throw new System.NotImplementedException();
        }
    }
}