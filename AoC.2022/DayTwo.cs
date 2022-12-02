using AoC.Common;

namespace AoC._2022;

public class DayTwo : IDay
{
    public string Title => "--- Day 2: Rock Paper Scissors ---";

    private readonly Dictionary<string, RockPaperScissorsScores> _inputActionToGameActionMap = new()
    {
        ["A"] = RockPaperScissorsScores.Rock,
        ["B"] = RockPaperScissorsScores.Paper,
        ["C"] = RockPaperScissorsScores.Scissors,
        ["X"] = RockPaperScissorsScores.Rock,
        ["Y"] = RockPaperScissorsScores.Paper,
        ["Z"] = RockPaperScissorsScores.Scissors
    };

    private enum RockPaperScissorsScores
    {
        Rock = 1,
        Paper = 2,
        Scissors = 3
    }

    public object PartOne(string[] input)
    {
        var totalScore = 0;

        foreach (var round in input)
        {
            var actions = round.Split(' ');
            var opponentAction = _inputActionToGameActionMap[actions[0]];
            var myAction = _inputActionToGameActionMap[actions[1]];

            var myRockPaperScissorsScore = GetMyRockPaperScissorsScore(opponentAction, myAction);
            totalScore += myRockPaperScissorsScore + (int)myAction;
        }

        return totalScore;
    }

    private int GetMyRockPaperScissorsScore(RockPaperScissorsScores opponentAction, RockPaperScissorsScores myAction)
    {
        // draw
        if (opponentAction == myAction) return 3;

        // lost
        if (opponentAction is RockPaperScissorsScores.Rock && myAction is RockPaperScissorsScores.Scissors) return 0;
        if (opponentAction is RockPaperScissorsScores.Paper && myAction is RockPaperScissorsScores.Rock) return 0;
        if (opponentAction is RockPaperScissorsScores.Scissors && myAction is RockPaperScissorsScores.Paper) return 0;

        // won
        return 6;
    }

    public object PartTwo(string[] input)
    {
        throw new NotImplementedException();
    }
}