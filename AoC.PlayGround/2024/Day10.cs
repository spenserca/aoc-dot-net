namespace AoC.PlayGround._2024;

public class Day10
{
    public void Blah()
    {
        var input = new[]
        {
            "89010123",
            "78121874",
            "87430965",
            "96549874",
            "45678903",
            "32019012",
            "01329801",
            "10456732"
        };

        var startingPoints = new Dictionary<(int, int), List<string>>();
        for (var i = 0; i < input.Length; i++)
        {
            for (var j = 0; j < input[0].Length; j++)
            {
                var value = int.Parse(input[i][j].ToString());
                switch (value)
                {
                    case 0: startingPoints.Add((i, j), new List<string>(value)); break;
                }
                
                var above = i == 0 ? null : (int?)int.Parse(input[i - 1][j].ToString());
                var below = i == input.Length - 1 ? null : (int?)int.Parse(input[i + 1][j].ToString());
                var left = j == 0 ? null : (int?)int.Parse(input[i][j - 1].ToString());
                var right = j == input[0].Length - 1 ? null : (int?)int.Parse(input[i][j + 1].ToString());
                
                if (above == value + 1)
                {
                    
                }
            }
        }
    }
}