using System.ComponentModel;
using AoC.Common;

namespace AoC._2022;

public class Day02 : IDay
{
    public string Title => "--- Day 2: Rock Paper Scissors ---";

    private enum GameActionsWithScores
    {
        Rock = 1,
        Paper = 2,
        Scissors = 3
    }

    private enum GameOutcomesWithScores
    {
        Win = 6,
        Lose = 0,
        Draw = 3
    }

    public object PartOne(string[] input)
    {
        var totalScore = 0;
        Dictionary<string, GameActionsWithScores> inputActionToGameActionMap = new()
        {
            ["A"] = GameActionsWithScores.Rock,
            ["B"] = GameActionsWithScores.Paper,
            ["C"] = GameActionsWithScores.Scissors,
            ["X"] = GameActionsWithScores.Rock,
            ["Y"] = GameActionsWithScores.Paper,
            ["Z"] = GameActionsWithScores.Scissors
        };

        foreach (var round in input)
        {
            var actions = round.Split(' ');
            var opponentAction = inputActionToGameActionMap[actions[0]];
            var myAction = inputActionToGameActionMap[actions[1]];

            var myRockPaperScissorsScore = GetMyRockPaperScissorsScore(opponentAction, myAction);
            totalScore += myRockPaperScissorsScore + (int)myAction;
        }

        return totalScore;
    }

    private static int GetMyRockPaperScissorsScore(GameActionsWithScores opponentAction,
        GameActionsWithScores myAction)
    {
        if (opponentAction == myAction) return (int)GameOutcomesWithScores.Draw;

        switch (opponentAction)
        {
            case GameActionsWithScores.Rock when myAction is GameActionsWithScores.Scissors:
            case GameActionsWithScores.Paper when myAction is GameActionsWithScores.Rock:
            case GameActionsWithScores.Scissors when myAction is GameActionsWithScores.Paper:
                return (int)GameOutcomesWithScores.Lose;
            default:
                return (int)GameOutcomesWithScores.Win;
        }
    }

    public object PartTwo(string[] input)
    {
        var totalScore = 0;
        Dictionary<string, GameActionsWithScores> inputActionToGameActionMap = new()
        {
            ["A"] = GameActionsWithScores.Rock,
            ["B"] = GameActionsWithScores.Paper,
            ["C"] = GameActionsWithScores.Scissors
        };
        Dictionary<string, GameOutcomesWithScores> inputActionToGameOutcomeMap = new()
        {
            ["X"] = GameOutcomesWithScores.Lose,
            ["Y"] = GameOutcomesWithScores.Draw,
            ["Z"] = GameOutcomesWithScores.Win
        };

        foreach (var round in input)
        {
            var actions = round.Split(' ');
            var opponentAction = inputActionToGameActionMap[actions[0]];
            var gameOutcome = inputActionToGameOutcomeMap[actions[1]];
            var myAction = GetMyActionFromOpponentsAndGameOutcome(opponentAction, gameOutcome);

            var myRockPaperScissorsScore = GetMyRockPaperScissorsScore(opponentAction, myAction);
            totalScore += myRockPaperScissorsScore + (int)myAction;
        }

        return totalScore;
    }

    private GameActionsWithScores GetMyActionFromOpponentsAndGameOutcome(GameActionsWithScores opponentAction,
        GameOutcomesWithScores gameOutcomeWithScores)
    {
        if (gameOutcomeWithScores is GameOutcomesWithScores.Draw) return opponentAction;

        return gameOutcomeWithScores is GameOutcomesWithScores.Win
            ? GetWinningAction(opponentAction)
            : GetLosingAction(opponentAction);
    }

    private GameActionsWithScores GetLosingAction(GameActionsWithScores opponentAction)
    {
        return opponentAction switch
        {
            GameActionsWithScores.Rock => GameActionsWithScores.Scissors,
            GameActionsWithScores.Paper => GameActionsWithScores.Rock,
            GameActionsWithScores.Scissors => GameActionsWithScores.Paper,
            _ => throw new InvalidEnumArgumentException(nameof(opponentAction), (int)opponentAction,
                typeof(GameActionsWithScores))
        };
    }

    private GameActionsWithScores GetWinningAction(GameActionsWithScores opponentAction)
    {
        return opponentAction switch
        {
            GameActionsWithScores.Rock => GameActionsWithScores.Paper,
            GameActionsWithScores.Paper => GameActionsWithScores.Scissors,
            GameActionsWithScores.Scissors => GameActionsWithScores.Rock,
            _ => throw new InvalidEnumArgumentException(nameof(opponentAction), (int)opponentAction,
                typeof(GameActionsWithScores))
        };
    }
}