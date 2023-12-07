using AoC.Common;

namespace AoC._2023;

public class Day04 : IDayPartOne
{
    public string Title => "--- Day 4: Scratchcards ---";

    public object PartOne(string[] input)
    {
        return input.Select(i => i.Substring(i.IndexOf(':') + 2))
            .Select(g =>
            {
                var card = g.Split('|')
                    .Select(c => c.Trim())
                    .ToList();

                var winningNumbers = card[0].Split(' ')
                    .Where(v => int.TryParse(v, out _))
                    .Select(int.Parse);
                var myNumbers = card[1].Split(' ')
                    .Where(v => int.TryParse(v, out _))
                    .Select(int.Parse);

                var overlap = myNumbers.Count(n => winningNumbers.Contains(n));

                if (overlap == 0) return 0;
                if (overlap == 1) return 1;
             
                

                return 2 * overlap;
            })
            .ToList()
            .Sum();
    }
}