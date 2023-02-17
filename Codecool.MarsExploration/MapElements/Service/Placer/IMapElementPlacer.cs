using Codecool.MarsExploration.Calculators.Model;
using Codecool.MarsExploration.MapElements.Model;

namespace Codecool.MarsExploration.MapElements.Service.Placer;

public interface IMapElementPlacer
{
    bool CanPlaceElement(MapElement element, string?[,] map, Coordinate coordinate);
    void PlaceElement(MapElement element, string?[,] map, Coordinate coordinate);
}
