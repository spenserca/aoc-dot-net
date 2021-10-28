﻿using System.Linq;

namespace AoC._2020
{
    public class DayOne
    {
        public string Title => "--- Day 1: Report Repair ---";

        public object PartOne(string[] input)
        {
            var inputAsInts = input.Select(int.Parse).ToList();

            for (var i = 0; i < inputAsInts.Count(); i++)
            {
                var currentValue = inputAsInts[i];

                for (var j = i + 1; j < inputAsInts.Count(); j++)
                {
                    var nextValue = inputAsInts[j];

                    if (currentValue + nextValue == 2020)
                    {
                        return currentValue * nextValue;
                    }
                }
            }

            return -1;
        }
    }
}