using System.Text.RegularExpressions;
using AoC.Common;

namespace AoC._2022;

public class Day15 : IDay
{
    public string Title => "--- Day 15: Beacon Exclusion Zone ---";

    public int RowToInspect { get; set; }

    public object PartOne(string[] input)
    {
        var sensorBeaconCoordinateRegex = new Regex(@"(x\=[\+|\-]?[0-9]{1,},\sy=[\+|\-]?[0-9]{1,})");
        var sensors = new List<Sensor>();

        foreach (var sensorDetail in input)
        {
            var rawCoordinates = sensorBeaconCoordinateRegex.Matches(sensorDetail);
            var sensorLocation = ParseCoordinate(rawCoordinates[0]);
            var beaconLocation = ParseCoordinate(rawCoordinates[1]);
            
            sensors.Add(new Sensor(sensorLocation, beaconLocation, RowToInspect));
        }

        var partOne = sensors.SelectMany(s => s.CoordinatesInRowToInspect)
            .ToHashSet().Count;
        return partOne;
    }

    private static Coordinate ParseCoordinate(Capture rawCoordinateMatch)
    {
        var rawCoordinate = rawCoordinateMatch.Value;

        var rawCoordinatePieces = rawCoordinate.Split("=");
        var x = int.Parse(rawCoordinatePieces[1].Split(',')[0]);
        var y = int.Parse(rawCoordinatePieces[2]);

        return new Coordinate(x, y);
    }

    public object PartTwo(string[] input)
    {
        throw new NotImplementedException();
    }

    private class Sensor
    {
        private readonly Coordinate _location;
        private readonly Coordinate _closestBeacon;
        public readonly List<Coordinate> CoordinatesInRowToInspect;

        private int ManhattanDistanceToBeacon => GetManhattanDistance(_location, _closestBeacon);

        public Sensor(Coordinate location, Coordinate closestBeacon, int rowToInspect)
        {
            _location = location;
            _closestBeacon = closestBeacon;
            CoordinatesInRowToInspect = SetPointsThatExistInRowToInspect(rowToInspect);
        }

        private static int GetManhattanDistance(Coordinate a, Coordinate b)
        {
            return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
        }

        private List<Coordinate> SetPointsThatExistInRowToInspect(int rowToInspect)
        {
            // use manhattan distance to determine the radius of the sensor
            var topPoint = _location.IncrementY(ManhattanDistanceToBeacon);
            var bottomPoint = _location.IncrementY(-ManhattanDistanceToBeacon);
            var sensorCoverageInRowToInspect = new List<Coordinate>();

            // if row to inspect is between the top and bottom point
            var sensorRangeCrossesRowToInspect = rowToInspect <= topPoint.Y && rowToInspect >= bottomPoint.Y;
            if (sensorRangeCrossesRowToInspect)
            {
                // find the closest distance from either point to the row to inspect

                // add the distance * 2 + 1 to the

                // find diff between closest of top or bottom point and the row to inspect
                var distanceFromTopPoint = Math.Abs(topPoint.Y - rowToInspect); //  GetManhattanDistance(topPoint, topPoint with { Y = rowToInspect });
                var distanceFromBottomPoint = Math.Abs(bottomPoint.Y - rowToInspect);//  GetManhattanDistance(bottomPoint, bottomPoint with { Y = rowToInspect });

                // if (distanceFromBottomPoint == 0 && distanceFromTopPoint == 0) return 0;

                // diff * 2 + 1
                var shortestDistance = distanceFromTopPoint < distanceFromBottomPoint
                    ? distanceFromTopPoint
                    : distanceFromBottomPoint;

                var numberOfCoordinatesInRow = shortestDistance * 2 + 1;

                for (var i = 0; i < numberOfCoordinatesInRow; i++)
                {
                    sensorCoverageInRowToInspect.Add(new Coordinate(_closestBeacon.X + i, rowToInspect));
                }
            }

            return sensorCoverageInRowToInspect;
        }
    }
}