using AoC.Common;

namespace AoC._2022;

public class Day11 : IDayPartOne, IDayPartTwo
{
    public string Title => "--- Day 11: Monkey in the Middle ---";

    public object PartOne(string[] input)
    {
        var game = new MonkeyInTheMiddle(
            input,
            new GameOptions() { NumberOfRounds = 20, ShouldUseDefaultReliefCalculation = true }
        );

        game.Play();

        return game.GetMonkeyBusinessLevel();
    }

    public object PartTwo(string[] input)
    {
        var game = new MonkeyInTheMiddle(
            input,
            new GameOptions() { NumberOfRounds = 10000, ShouldUseDefaultReliefCalculation = false }
        );

        game.Play();

        return game.GetMonkeyBusinessLevel();
    }

    private class MonkeyInTheMiddle
    {
        private readonly GameOptions _gameOptions;
        private readonly List<Monkey> _monkeys;

        public MonkeyInTheMiddle(string[] input, GameOptions gameOptions)
        {
            _gameOptions = gameOptions;
            _monkeys = ParseMonkeys(input);
        }

        private List<Monkey> ParseMonkeys(string[] input)
        {
            var monkeys = new List<Monkey>();
            var monkey = new Monkey();

            foreach (var note in input)
            {
                var trimmedNoted = note.Trim();

                if (trimmedNoted.StartsWith("Monkey"))
                {
                    monkey = new Monkey();
                }

                if (trimmedNoted.StartsWith("Starting items"))
                    monkey.ParseStartingItems(trimmedNoted);

                if (trimmedNoted.StartsWith("Operation"))
                    monkey.ParseOperation(trimmedNoted);

                if (trimmedNoted.StartsWith("Test"))
                    monkey.ParseTest(trimmedNoted);

                if (trimmedNoted.StartsWith("If true"))
                    monkey.ParseTrueAction(trimmedNoted);

                if (trimmedNoted.StartsWith("If false"))
                    monkey.ParseFalseAction(trimmedNoted);

                if (
                    trimmedNoted == string.Empty
                    || Array.IndexOf(input, note, 0) == input.Length - 1
                )
                {
                    monkeys.Add(monkey);
                }
            }

            return monkeys;
        }

        public void Play()
        {
            var mod = 1;
            if (!_gameOptions.ShouldUseDefaultReliefCalculation)
            {
                mod = _monkeys.Select(m => m.TestValue).Aggregate((a, b) => a * b);
            }

            for (var i = 0; i < _gameOptions.NumberOfRounds; i++)
            {
                foreach (var monkey in _monkeys)
                {
                    while (monkey.ItemWorryLevels.Any())
                    {
                        var itemWorryLevel = monkey.InspectItem(
                            _gameOptions.ShouldUseDefaultReliefCalculation,
                            mod
                        );

                        var monkeyToThrowTo = monkey.GetMonkeyIdToThrowTo(itemWorryLevel);

                        _monkeys[monkeyToThrowTo].CatchItem(itemWorryLevel);
                    }
                }
            }
        }

        public long GetMonkeyBusinessLevel() =>
            _monkeys
                .Select(m => m.Inspections)
                .OrderByDescending(i => i)
                .Take(2)
                .Aggregate((a, b) => a * b);
    }

    private class Monkey
    {
        public readonly List<long> ItemWorryLevels;
        private string _operationType;
        private string _operationValue;
        public int TestValue { get; private set; } = 0;
        private int _throwToIfTrueId;
        private int _throwToIfFalseId;
        public long Inspections { get; private set; } = 0;

        public Monkey()
        {
            ItemWorryLevels = new List<long>();
        }

        public long InspectItem(bool shouldUseDefaultReliefCalculation, int mod)
        {
            Inspections++;

            var itemWorryLevel = ItemWorryLevels.First();
            ItemWorryLevels.RemoveAt(0);

            var updatedItemWorryLevel = CalculateItemWorryLevel(
                _operationType,
                _operationValue,
                itemWorryLevel
            );

            return shouldUseDefaultReliefCalculation
                ? CalculateReliefWorryLevel(updatedItemWorryLevel)
                : CalculateManuallyReducedWorryLevel(updatedItemWorryLevel, mod);
        }

        private static long CalculateManuallyReducedWorryLevel(long itemWorryLevel, long monkeyMod)
        {
            return itemWorryLevel % monkeyMod;
        }

        private static long CalculateReliefWorryLevel(long itemWorryLevel)
        {
            return (long)Math.Floor(itemWorryLevel / 3.0);
        }

        private static long CalculateItemWorryLevel(
            string operationType,
            string operationValue,
            long itemWorryLevel
        )
        {
            if (operationValue == "old")
                operationValue = itemWorryLevel.ToString();

            return operationType switch
            {
                "+" => itemWorryLevel + int.Parse(operationValue),
                "-" => itemWorryLevel - int.Parse(operationValue),
                "*" => itemWorryLevel * int.Parse(operationValue),
                "/" => itemWorryLevel / int.Parse(operationValue),
                _ => int.Parse(operationValue)
            };
        }

        public void ParseStartingItems(string startingItemNote)
        {
            var notePieces = startingItemNote.Split(":");
            var startingItems = notePieces[1].Trim().Split(",").Select(long.Parse);

            ItemWorryLevels.AddRange(startingItems);
        }

        public void ParseOperation(string operationNote)
        {
            var notePieces = operationNote.Split("=");
            var operationPieces = notePieces[1].Trim().Split(" ");
            _operationType = operationPieces[1];
            _operationValue = operationPieces[2];
        }

        public void ParseTest(string testNote)
        {
            var notePieces = testNote.Split(" ");
            TestValue = int.Parse(notePieces[^1]);
        }

        public void ParseTrueAction(string trueTestNote)
        {
            var notePieces = trueTestNote.Split(" ");
            _throwToIfTrueId = int.Parse(notePieces[^1]);
        }

        public void ParseFalseAction(string falseTestNote)
        {
            var notePieces = falseTestNote.Split(" ");
            _throwToIfFalseId = int.Parse(notePieces[^1]);
        }

        public int GetMonkeyIdToThrowTo(long worryLevel)
        {
            var didTestPass = worryLevel % TestValue == 0;
            return didTestPass ? _throwToIfTrueId : _throwToIfFalseId;
        }

        public void CatchItem(long item)
        {
            ItemWorryLevels.Add(item);
        }
    }

    private class GameOptions
    {
        public int NumberOfRounds { get; set; }
        public bool ShouldUseDefaultReliefCalculation { get; set; }
    }
}
