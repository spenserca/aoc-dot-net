using AoC.Common;

namespace AoC._2021;

public class Day04 : IDayPartOne, IDayPartTwo
{
    public string Title => "--- Day 4: Giant Squid ---";

    public object PartOne(string[] input)
    {
        var bingoCards = new BingoGame(input).RunGame();
        var firstWinnerTurn = bingoCards.Min(bc => bc.LastTurn);
        var winningCard = bingoCards.Single(bc => bc.LastTurn == firstWinnerTurn);

        return winningCard.GetScore();
    }

    public object PartTwo(string[] input)
    {
        var bingoCards = new BingoGame(input).RunGame();
        var firstWinnerTurn = bingoCards.Max(bc => bc.LastTurn);
        var winningCard = bingoCards.Single(bc => bc.LastTurn == firstWinnerTurn);

        return winningCard.GetScore();
    }

    private class BingoGame
    {
        private readonly List<BingoCard> _bingoCards = new();
        private readonly List<string> _bingoNumbers;

        public BingoGame(string[] input)
        {
            _bingoNumbers = input.First().Split(',').ToList();

            var rows = new List<string>();
            for (var i = 2; i < input.Length; i++)
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

        public List<BingoCard> RunGame()
        {
            for (var i = 0; i < _bingoNumbers.Count; i++)
            {
                var bingoNumber = _bingoNumbers[i];
                foreach (var bingoBoard in _bingoCards)
                {
                    if (!bingoBoard.HasBingo())
                    {
                        bingoBoard.MarkCardForBingoNumber(bingoNumber, i);
                    }
                }
            }

            return _bingoCards;
        }
    }

    private class BingoCard
    {
        private const string Marker = "X";
        private readonly List<List<string>> _board = new();
        private int _lastMarkedNumber;
        public int LastTurn;

        public BingoCard(List<string> rows)
        {
            rows.ForEach(row => { _board.Add(row.Split(' ').Where(v => v != string.Empty).ToList()); });
        }

        public void MarkCardForBingoNumber(string bingoNumber, int turn)
        {
            _board.ForEach(r =>
            {
                var indexOfBingoNumber = r.IndexOf(bingoNumber);
                if (indexOfBingoNumber != -1)
                {
                    LastTurn = turn;
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
            for (var i = 0; i < _board.Count; i++)
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