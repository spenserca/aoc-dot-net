using System;
using System.Linq;
using System.Security.AccessControl;
using AoC.Common;

namespace AoC._2021
{
    public class DayTwo : IDay
    {
        public string Title => "--- Day 2: Dive! ---";

        public object PartOne(string[] input)
        {
            var (finalHorizontalPosition, finalDepth, aim) = input.Select(i =>
            {
                var pieces = i.Split(' ');
                return new SubmarineMovement(pieces[0], Convert.ToInt32(pieces[1]));
            }).Aggregate((0, 0, 0), (acc, sm) =>
            {
                switch (sm.Direction)
                {
                    case "forward":
                        acc.Item1 += sm.Distance;
                        break;
                    case "down":
                        acc.Item2 += sm.Distance;
                        break;
                    case "up":
                        acc.Item2 -= sm.Distance;
                        break;
                }

                return acc;
            });

            return finalHorizontalPosition * finalDepth;
        }

        public object PartTwo(string[] input)
        {
            var (finalHorizontalPosition, finalDepth, aim) = input.Select(i =>
            {
                var pieces = i.Split(' ');
                return new SubmarineMovement(pieces[0], Convert.ToInt32(pieces[1]));
            }).Aggregate((0, 0, 0), (acc, sm) =>
            {
                switch (sm.Direction)
                {
                    case "forward":
                        acc.Item1 += sm.Distance;
                        acc.Item2 += acc.Item3 * sm.Distance;
                        break;
                    case "down":
                        acc.Item3 += sm.Distance;
                        break;
                    case "up":
                        acc.Item3 -= sm.Distance;
                        break;
                }

                return acc;
            });

            return finalHorizontalPosition * finalDepth;
        }

        private record SubmarineMovement(string Direction, int Distance);
    }
}