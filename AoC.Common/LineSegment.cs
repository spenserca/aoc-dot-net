namespace AoC.Common;

public record Coordinate(int X, int Y);

public record LineSegment(Coordinate Start, Coordinate End)
{
    private int Run => End.X - Start.X;
    public bool IsHorizontal => Rise == 0;

    private int Rise => End.Y - Start.Y;
    public bool IsVertical => Run == 0;

    private double Slope => (double)Rise / Run;
    
    public bool IsStraightLine => IsHorizontal || IsVertical;

    public List<Coordinate> Points => GetPoints();

    private List<Coordinate> GetPoints()
    {
        // vertical line
        if (IsVertical) return GetVerticalLinePoints();
        
        // horizontal lines
        if (IsHorizontal) return GetHorizontalLinePoints();
        
        // slopes
        return GetSlopedLinePoints();
    }

    private List<Coordinate> GetSlopedLinePoints()
    {
        var coordinates = new List<Coordinate>() { Start };

        var x = Run > 0 ? Start.X + 1 : Start.X - 1;
        var y = Rise > 0 ? Start.Y + 1 : Start.Y - 1;
        while (x != End.X && y != End.Y)
        {
            coordinates.Add(new Coordinate(x, y));
            if (Run > 0) x++;
            else x--;
            if (Rise > 0) y++;
            else y--;
        }
        
        coordinates.Add(End);
        
        return coordinates;
    }

    private List<Coordinate> GetHorizontalLinePoints()
    {
        var coordinates = new List<Coordinate>()
        {
            Start
        };

        var x = Run > 0 ? Start.X + 1 : Start.X - 1;
        while (x != End.X)
        {
            coordinates.Add(Start with { X = x });
            if (Run > 0) x++;
            else x--;
        }

        coordinates.Add(End);

        return coordinates;
    }

    private List<Coordinate> GetVerticalLinePoints()
    {
        var coordinates = new List<Coordinate>()
        {
            Start
        };

        var y = Rise > 0 ? Start.Y + 1 : Start.Y - 1;
        while (y != End.Y)
        {
            coordinates.Add(Start with { Y = y });
            if (Rise > 0) y++;
            else y--;
        }

        coordinates.Add(End);

        return coordinates;
    }
}