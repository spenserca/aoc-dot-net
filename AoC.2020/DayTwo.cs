using System.Linq;

namespace AoC._2020
{
    public class DayTwo : IDay
    {
        public string Title => "--- Day 2: Password Philosophy ---";

        public object PartOne(string[] input)
        {
            var count = 0;
            foreach (var passwordRecord in input)
            {
                var parsed = passwordRecord.Split(' ');
                var validRange = parsed[0];
                var letter = parsed[1].Replace(":", "");
                var password = parsed[2];
                var dashIndex = validRange.IndexOf('-');
                var minimumCount = int.Parse(validRange.Substring(0, dashIndex));
                var maximumCount = int.Parse(validRange.Substring(dashIndex + 1));
                var letterCount = password.Count(c => c.ToString() == letter);

                if (letterCount >= minimumCount && letterCount <= maximumCount)
                {
                    count++;
                }
            }

            return count;
        }

        public object PartTwo(string[] input)
        {
            throw new System.NotImplementedException();
        }
    }
}