using Codecool.MarsExploration.Calculators.Model;
using Codecool.MarsExploration.Calculators.Service;
using Codecool.MarsExploration.Configuration.Model;
using Codecool.MarsExploration.MapElements.Model;
using Codecool.MarsExploration.MapElements.Service.Placer;

namespace Codecool.MarsExploration.MapElements.Service.Generator;

public class MapGenerator : IMapGenerator
{
    private readonly MapElementsGenerator _mapElementsGenerator = new();

    private readonly MapElementPlacer _placer = new();
    private readonly CoordinateCalculator _calculator = new();

    public Map Generate(MapConfiguration mapConfig)
    {
        var mapElements = _mapElementsGenerator.CreateAll(mapConfig);
        var mapSize = (int)(Math.Sqrt(mapConfig.MapSize));
        var coordinate = _calculator.GetRandomCoordinate(mapSize);

        string?[,] map = GetMap(mapConfig.MapSize);

        foreach (var mapElement in mapElements)
        {
            if (_placer.CanPlaceElement(mapElement, map, coordinate))
            {
                _placer.PlaceElement(mapElement, map, coordinate);
            }
        }

        return new Map(map);
    }

    private string[,] GetMap(int mapSize)
    {
        string[,] mapRepresentation = new string[(int)Math.Sqrt(mapSize), (int)Math.Sqrt(mapSize)];
        for (int i = 0; i < Math.Sqrt(mapSize); i++)
        {
            for (int j = 0; j < Math.Sqrt(mapSize); j++)
            {
                mapRepresentation[i, j] = " ";
            }
        }

        return mapRepresentation;
    }
}