﻿using AoC.Common;

namespace AoC._2024;

public class Day01 : IDayPartOne
{
    public string Title => "--- Day 1: Historian Hysteria ---";

    public object PartOne(string[] input)
    {
        var leftValues = new List<int>();
        var rightValues = new List<int>();

        foreach (var i in input)
        {
            var split = i.Split(" ").Where(v => !string.IsNullOrEmpty(v)).ToArray();
            leftValues.Add(int.Parse(split[0]));
            rightValues.Add(int.Parse(split[1]));
        }

        leftValues.Sort();
        rightValues.Sort();
        var totalDistance = 0;

        for (int i = 0; i < input.Length; i++)
        {
            var right = rightValues[i];
            var left = leftValues[i];

            var distance = Math.Abs(right - left);
            totalDistance += distance;
        }

        return totalDistance;
    }
}