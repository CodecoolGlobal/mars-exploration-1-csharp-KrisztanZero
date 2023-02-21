using Codecool.MarsExploration.Calculators.Model;

namespace Codecool.MarsExploration.Calculators.Service;

public class CoordinateCalculator : ICoordinateCalculator
{
    private readonly Random _random = new();

    public Coordinate GetRandomCoordinate(int dimension)
    {
        var x = _random.Next(dimension);
        var y = _random.Next(dimension);
        return new Coordinate(x, y);
    }

    public IEnumerable<Coordinate> GetAdjacentCoordinates(Coordinate coordinate, int dimension)
    {
        List<Coordinate> adjancentCoordinates = new List<Coordinate>();

        for (int i = coordinate.X; i <= coordinate.X + 1; i++)
        {
            for (int j = coordinate.Y; j <= coordinate.Y + 1; j++)
            {
                if (i >= 0 && i < dimension && j >= 0 && j < dimension && (i != coordinate.X || j != coordinate.Y))
                {
                    adjancentCoordinates.Add(new Coordinate(i,j));
                }
            }
        }

        return adjancentCoordinates;
    }

    public IEnumerable<Coordinate> GetAdjacentCoordinates(IEnumerable<Coordinate> coordinates, int dimension)
    {
        throw new NotImplementedException();
    }
}