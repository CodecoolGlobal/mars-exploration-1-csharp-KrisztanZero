using Codecool.MarsExploration.Calculators.Model;
using Codecool.MarsExploration.MapElements.Model;

namespace Codecool.MarsExploration.MapElements.Service.Placer;

public class MapElementPlacer : IMapElementPlacer
{
    // MapElement(string?[,] Representation, string Name, int Dimension, string? PreferredLocationSymbol = null) : Map(Representation)
    
    public bool CanPlaceElement(MapElement element, string?[,] map, Coordinate coordinate)
    {
        // check if area at coordinate is available
        
        // check if element is still on map
        
        throw new NotImplementedException();
    }

    public void PlaceElement(MapElement element, string?[,] map, Coordinate coordinate)
    {
        
        for (int i = 0; i < element.Dimension; i++)
        {
            for (int j = 0; j < element.Dimension; j++)
            {
                map[coordinate.X + i, coordinate.Y + j] = element.Representation[i, j];
            }
        }
        
    }
}