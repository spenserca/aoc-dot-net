using AoC.Common;

namespace AoC._2021;

public class DayFour : IDay
{
    public string Title => "--- Day 4: Giant Squid ---";

    public object PartOne(string[] input)
    {
        return new BingoGame(input).RunGame();
    }

    public object PartTwo(string[] input)
    {
        throw new NotImplementedException();
    }

    private class BingoGame
    {
        private readonly List<string> _bingoNumbers;
        private readonly List<BingoCard> _bingoCards = new();

        public BingoGame(string[] input)
        {
            _bingoNumbers = input.First().Split(',').ToList();

            var rows = new List<string>();
            for (int i = 2; i < input.Length; i++)
            {
                var row = input[i];
                var isBingoRow = !row.Equals(string.Empty);
                if (isBingoRow)
                {
                    rows.Add(row);
                }

                var isLastEntry = i == input.Length - 1;
                if (!isBingoRow || isLastEntry)
                {
                    _bingoCards.Add(new BingoCard(rows));
                    rows.Clear();
                }
            }
        }

        public int RunGame()
        {
            foreach (var bingoNumber in _bingoNumbers)
            {
                foreach (var bingoBoard in _bingoCards)
                {
                    bingoBoard.MarkCardForBingoNumber(bingoNumber);

                    if (bingoBoard.HasBingo())
                    {
                        return bingoBoard.GetScore();
                    }
                }
            }

            return -1;
        }
    }

    private class BingoCard
    {
        private const string Marker = "X";
        private readonly List<List<string>> _board = new();
        private int _lastMarkedNumber;

        public BingoCard(List<string> rows)
        {
            rows.ForEach(row => { _board.Add(row.Split(' ').Where(v => v != string.Empty).ToList()); });
        }

        public void MarkCardForBingoNumber(string bingoNumber)
        {
            _board.ForEach(r =>
            {
                var indexOfBingoNumber = r.IndexOf(bingoNumber);
                if (indexOfBingoNumber != -1)
                {
                    _lastMarkedNumber = Convert.ToInt32(bingoNumber);
                    r[indexOfBingoNumber] = Marker;
                }
            });
        }

        public int GetScore()
        {
            return _board
                .SelectMany(r => r.Where(v => v != Marker))
                .Select(n => Convert.ToInt32(n))
                .Sum() * _lastMarkedNumber;
        }

        public bool HasBingo()
        {
            for (int i = 0; i < _board.Count; i++)
            {
                var row = _board[i];
                var column = new List<string>();
                _board.ForEach(r => column.Add(r[i]));

                if (row.All(r => r == Marker) || column.All(r => r == Marker))
                {
                    return true;
                }
            }

            return false;
        }
    }
}