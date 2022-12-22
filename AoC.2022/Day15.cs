using System.Text.RegularExpressions;
using AoC.Common;

namespace AoC._2022;

public class Day15: IDay
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

        return sensors.Select(s => s.NumberOfLocationsWhereABeaconIsNotPresent).Sum();
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
        private readonly List<Coordinate> _coordinatesInRowToInspect;

        private int manhattanDistanceToBeacon =>
            Math.Abs(_location.X - _closestBeacon.X) + Math.Abs(_location.Y - _closestBeacon.Y);

        public Sensor(Coordinate location, Coordinate closestBeacon, int rowToInspect)
        {
            _location = location;
            _closestBeacon = closestBeacon;
            _coordinatesInRowToInspect = SetPointsThatExistInRowToInspect(rowToInspect);
        }

        private List<Coordinate> SetPointsThatExistInRowToInspect(int rowToInspect)
        {
            // use manhattan distance to determine the radius of the sensor

            // if any points of the radius are in the row to inspect, add them to the list
            // otherwise skip them

            return new List<Coordinate>();
        }

        public int NumberOfLocationsWhereABeaconIsNotPresent => _coordinatesInRowToInspect.Count;
    }
}