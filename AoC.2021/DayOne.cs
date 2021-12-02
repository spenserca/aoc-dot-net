using System;
using System.Linq;
using AoC.Common;

namespace AoC._2021
{
    public class DayOne : IDay
    {
        public string Title => "--- Day 1: Sonar Sweep ---";

        public object PartOne(string[] input)
        {
            var increaseCount = 0;
            for (var i = 0; i < input.Length - 1; i++)
            {
                var currentValue = Convert.ToInt32(input[i]);
                var nextValue = Convert.ToInt32(input[i + 1]);

                if (nextValue > currentValue)
                {
                    increaseCount++;
                }
            }

            return increaseCount;
        }

        public object PartTwo(string[] input)
        {
            throw new System.NotImplementedException();
        }
    }
}