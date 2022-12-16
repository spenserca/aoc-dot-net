using System.Collections.Immutable;
using AoC.Common;

namespace AoC._2022;

public class Day11 : IDay
{
    public string Title => "--- Day 11: Monkey in the Middle ---";

    public object PartOne(string[] input)
    {
        var game = new MonkeyInTheMiddle(input);

        game.Play();

        return game.GetMonkeyBusinessLevel();
    }

    public object PartTwo(string[] input)
    {
        throw new NotImplementedException();
    }

    private class MonkeyInTheMiddle
    {
        private readonly Dictionary<int, Monkey> _monkeysById;

        public MonkeyInTheMiddle(string[] input)
        {
            _monkeysById = ParseMonkeys(input);
        }

        private Dictionary<int, Monkey> ParseMonkeys(string[] input)
        {
            var monkeys = new Dictionary<int, Monkey>();
            Monkey? monkey = null;
            var currentId = 0;

            foreach (var note in input)
            {
                var trimmedNoted = note.Trim();

                if (trimmedNoted.StartsWith("Monkey"))
                {
                    var pieces = trimmedNoted.Split(" ");
                    var idPiece = pieces[1].Replace(":", string.Empty);
                    currentId = int.Parse(idPiece);
                    monkey = new Monkey(currentId);
                }

                if (trimmedNoted.StartsWith("Starting items")) monkey?.ParseStartingItems(trimmedNoted);

                if (trimmedNoted.StartsWith("Operation")) monkey?.ParseOperation(trimmedNoted);

                if (trimmedNoted.StartsWith("Test")) monkey?.ParseTest(trimmedNoted);

                if (trimmedNoted.StartsWith("If true")) monkey?.ParseTrueAction(trimmedNoted);

                if (trimmedNoted.StartsWith("If false")) monkey?.ParseFalseAction(trimmedNoted);

                if (trimmedNoted == string.Empty || Array.IndexOf(input, note, 0) == input.Length - 1)
                {
                    monkeys.Add(currentId, monkey!);
                }
            }

            return monkeys;
        }

        public void Play()
        {
            for (var i = 0; i < 20; i++)
            {
                for (var j = 0; j < _monkeysById.Keys.Count(); j++)
                {
                    var monkey = _monkeysById[j];

                    // inspect items
                    while (monkey.ItemWorryLevels.Any())
                    {
                        var itemWorryLevel = monkey.InspectItem();

                        // test worry level
                        var monkeyToThrowTo = monkey.GetMonkeyIdToThrowTo(itemWorryLevel);

                        // throw item to monkey
                        _monkeysById[monkeyToThrowTo].CatchItem(itemWorryLevel);
                    }
                }
            }
        }

        public int GetMonkeyBusinessLevel()
        {
            var monkeyList = _monkeysById.Values.ToList();
            monkeyList.Sort(CompareMonkeysByTotalInspection);

            return monkeyList[0].Inspections * monkeyList[1].Inspections;
        }

        private int CompareMonkeysByTotalInspection(Monkey a, Monkey b)
        {
            return b.Inspections - a.Inspections;
        }
    }

    private class Monkey
    {
        private readonly int _id;
        public readonly List<int> ItemWorryLevels;
        private string _operationType;
        private string _operationValue;
        private int _testValue;
        private int _throwToIfTrueId;
        private int _throwToIfFalseId;
        public int Inspections { get; private set; } = 0;

        public Monkey(int id)
        {
            _id = id;
            ItemWorryLevels = new List<int>();
        }

        public int InspectItem()
        {
            Inspections++;

            // pop first item off the list
            var itemWorryLevel = ItemWorryLevels.First();
            ItemWorryLevels.RemoveAt(0);

            // increase worry level by operation (operationValue)
            var updatedItemWorryLevel = CalculateItemWorryLevel(_operationType, _operationValue, itemWorryLevel);

            // relief of no damage (divide by 3 and round down to nearest integer)
            var reliefWorryLevel = CalculateReliefWorryLevel(updatedItemWorryLevel);

            return reliefWorryLevel;
        }

        private int CalculateReliefWorryLevel(int itemWorryLevel)
        {
            // relief of no damage (divide by 3 and round down to nearest integer)
            var divided = itemWorryLevel / 3;
            Console.WriteLine($"Divided value {divided}");

            return (int)Math.Round((double)divided, MidpointRounding.ToNegativeInfinity);
        }

        private static int CalculateItemWorryLevel(string operationType, string operationValue, int itemWorryLevel)
        {
            if (operationValue == "old") operationValue = itemWorryLevel.ToString();

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
            var startingItems = notePieces[1].Trim().Split(",")
                .Select(int.Parse);

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
            _testValue = int.Parse(notePieces[^1]);
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

        public int GetMonkeyIdToThrowTo(int worryLevel)
        {
            var didTestPass = worryLevel % _testValue == 0;
            return didTestPass ? _throwToIfTrueId : _throwToIfFalseId;
        }

        public void CatchItem(int item)
        {
            ItemWorryLevels.Add(item);
        }
    }
}