﻿using System.Text;
using System.Text.RegularExpressions;
using AoC.Common;

namespace AoC._2022;

public class Day05 : IDay
{
    public string Title => "--- Day 5: Supply Stacks ---";

    public object PartOne(string[] input)
    {
        var stacks = ParseStacks(input);

        for (int i = Array.IndexOf(input, "") + 1; i < input.Length; i++)
        {
            var procedure = input[i];
            var procedurePieces = procedure.Split(' ');
            var numberOfContainersToMove = int.Parse(procedurePieces[1]);
            var sourceContainer = int.Parse(procedurePieces[3]);
            var destinationContainer = int.Parse(procedurePieces[5]);

            for (int j = 0; j < numberOfContainersToMove; j++)
            {
                var container = stacks[sourceContainer - 1].Pop();
                stacks[destinationContainer -1].Push(container);
            }
        }

        var topContainers = new StringBuilder();

        foreach (var stack in stacks)
        {
            var topContainerForStack = stack.Pop();
            topContainers.Append(topContainerForStack);
        }

        return topContainers.ToString();
    }

    public object PartTwo(string[] input)
    {
        throw new NotImplementedException();
    }

    private List<Stack<string>> ParseStacks(string[] input)
    {
        var numberOfStacks = (input[0].Length + 1) / 4;
        var stacks = new List<Stack<string>>(numberOfStacks);
        for (int i = 0; i < stacks.Capacity; i++)
        {
            stacks.Add(new Stack<string>());
        }


        for (int i = Array.IndexOf(input, "") - 2; i >= 0; i--)
        {
            var current = input[i];
            var firstIndexOfCrate = current.IndexOf('[');
            const int numberOfCharsPerCrate = 4;
            var startingStackNumber = firstIndexOfCrate / numberOfCharsPerCrate;

            for (int j = firstIndexOfCrate + 1; j < current.Length; j++)
            {
                var currentValue = current[j].ToString();
                if (currentValue == "[" || j % 4 == 0)
                {
                    startingStackNumber++;
                }

                if (new Regex("[a-zA-Z]").IsMatch(currentValue))
                {
                    stacks[startingStackNumber].Push(currentValue);
                }
            }
        }

        return stacks;
    }
}