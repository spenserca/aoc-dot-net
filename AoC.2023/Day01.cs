using System.Text.RegularExpressions;
using AoC.Common;

namespace AoC._2023;

public class Day01 : IDayPartOne, IDayPartTwo
{
    private readonly Dictionary<string, string> _digitWordToStringValueMap =
        new()
        {
            ["one"] = "1",
            ["two"] = "2",
            ["three"] = "3",
            ["four"] = "4",
            ["five"] = "5",
            ["six"] = "6",
            ["seven"] = "7",
            ["eight"] = "8",
            ["nine"] = "9",
        };

    private const string DigitOnlyPattern = "[0-9]";
    private readonly Regex _partOneForwardRegex = new(DigitOnlyPattern);
    private readonly Regex _partOneBackwardRegex = new(DigitOnlyPattern, RegexOptions.RightToLeft);

    private const string DigitAndStringValuePattern =
        "(\\d)|(one|two|three|four|five|six|seven|eight|nine)";
    private readonly Regex _partTwoForwardRegex = new(DigitAndStringValuePattern);
    private readonly Regex _partTwoBackwardRegex =
        new(DigitAndStringValuePattern, RegexOptions.RightToLeft);

    public string Title => "--- Day 1: Trebuchet?! ---";

    public object PartOne(string[] input)
    {
        return input
            .Select(i =>
            {
                var forwardMatch = _partOneForwardRegex.Match(i);
                var backwardMatch = _partOneBackwardRegex.Match(i);

                return int.Parse(
                    GetNumericDigitAsString(forwardMatch.Value)
                        + GetNumericDigitAsString(backwardMatch.Value)
                );
            })
            .Sum();
    }

    public object PartTwo(string[] input)
    {
        return input
            .Select(i =>
            {
                var forwardMatch = _partTwoForwardRegex.Match(i);
                var backwardMatch = _partTwoBackwardRegex.Match(i);

                var first = GetNumericDigitAsString(forwardMatch.Value);
                var last = GetNumericDigitAsString(backwardMatch.Value);

                return int.Parse(first + last);
            })
            .Sum();
    }

    private string GetNumericDigitAsString(string digit)
    {
        return _digitWordToStringValueMap.TryGetValue(digit, out var value) ? value : digit;
    }
}
