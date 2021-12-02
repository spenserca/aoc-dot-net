using System.Linq;
using AoC.Common;

namespace AoC._2020
{
    public class DayTwo : IDay
    {
        public string Title => "--- Day 2: Password Philosophy ---";

        public object PartOne(string[] input)
        {
            return input
                .Select(i => new DayOneParsedPasswordRecord(i))
                .Count(r => r.IsValid());
        }

        public object PartTwo(string[] input)
        {
            return input
                .Select(i => new DayTwoParsedPasswordRecord(i))
                .Count(r => r.IsValid());
        }

        private abstract class ParsedPasswordRecord
        {
            protected ParsedPasswordRecord(string passwordRecord)
            {
                var parsed = passwordRecord.Split(' ');
                var validRange = parsed[0];
                Letter = parsed[1].Replace(":", "");
                Password = parsed[2];
                var dashIndex = validRange.IndexOf('-');
                MinimumValueOrPosition = int.Parse(validRange.Substring(0, dashIndex));
                MaximumValueOrPosition = int.Parse(validRange.Substring(dashIndex + 1));
            }

            protected string Letter { get; }
            protected string Password { get; }
            protected int MinimumValueOrPosition { get; }
            protected int MaximumValueOrPosition { get; }

            public abstract bool IsValid();
        }

        private class DayOneParsedPasswordRecord : ParsedPasswordRecord
        {
            public DayOneParsedPasswordRecord(string passwordRecord) : base(passwordRecord)
            {
            }

            public override bool IsValid()
            {
                var letterCount = Password.Count(c => c.ToString() == Letter);
                return letterCount >= MinimumValueOrPosition && letterCount <= MaximumValueOrPosition;
            }
        }

        private class DayTwoParsedPasswordRecord : ParsedPasswordRecord
        {
            public DayTwoParsedPasswordRecord(string passwordRecord) : base(passwordRecord)
            {
            }

            public override bool IsValid()
            {
                var isValueAtFirstPosition = Password[MinimumValueOrPosition - 1].ToString() == Letter;
                var isValueAtSecondPosition = Password[MaximumValueOrPosition - 1].ToString() == Letter;

                if (isValueAtFirstPosition && isValueAtSecondPosition)
                {
                    return false;
                }

                return isValueAtFirstPosition ||
                       isValueAtSecondPosition;
            }
        }
    }
}