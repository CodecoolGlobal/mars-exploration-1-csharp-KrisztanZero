using Codecool.MarsExploration.Calculators.Model;

namespace Codecool.MarsExploration.Calculators.Service;

public class CoordinateCalculator : ICoordinateCalculator
{
    private readonly Random _random = new();

    // add MapSize to constructor
    public Coordinate GetRandomCoordinate(int dimension)
    {
        // check if element is not outside map - once mapgeneration is ready
        // upper limit is MapConfiguration.MapSize - dimension
        var x = _random.Next();
        var y = _random.Next();
        return new Coordinate(x, y);
    }

    // check if adjacent coordinate is in the map
    public IEnumerable<Coordinate> GetAdjacentCoordinates(Coordinate coordinate, int dimension)
    {
        List<Coordinate> adjacentCoordinates = new List<Coordinate>();

        for (var i = coordinate.X; i < coordinate.X + dimension; i++)
        {
            var upperBound = new Coordinate(i, coordinate.Y - 1);
            adjacentCoordinates.Add(upperBound);
            var lowerBound = new Coordinate(i, coordinate.Y + dimension);
            adjacentCoordinates.Add(lowerBound);
        }

        for (int i = coordinate.Y; i < coordinate.Y + dimension; i++)
        {
            var leftBound = new Coordinate(coordinate.X - 1, i); 
            adjacentCoordinates.Add(leftBound);
            var rightBound = new Coordinate(coordinate.X + dimension, i);
            adjacentCoordinates.Add(rightBound);
        }

        return adjacentCoordinates;
    }

    public IEnumerable<Coordinate> GetAdjacentCoordinates(IEnumerable<Coordinate> coordinates, int dimension)
    {
        throw new NotImplementedException();
    }
}