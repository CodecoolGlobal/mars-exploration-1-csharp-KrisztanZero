using Codecool.MarsExploration.Calculators.Model;
using Codecool.MarsExploration.Calculators.Service;
using Codecool.MarsExploration.MapElements.Model;

namespace Codecool.MarsExploration.MapElements.Service.Placer;

public class MapElementPlacer : IMapElementPlacer
{
    // MapElement(string?[,] Representation, string Name, int Dimension, string? PreferredLocationSymbol = null) : Map(Representation)

    public bool CanPlaceElement(MapElement element, string?[,] map, Coordinate coordinate)
    {
        // check if element is still on map
        bool elementIsOnMap = coordinate.X + element.Dimension < map.GetLength(0) &&
                              coordinate.Y + element.Dimension < map.GetLength(1);
        if (!elementIsOnMap) return false;

        bool canPlaceElement = false;

        CoordinateCalculator coordinateCalculator = new CoordinateCalculator();
        
        if (element.PreferredLocationSymbol != null)
        {
            var adjacentCoordinates = coordinateCalculator.GetAdjacentCoordinates(coordinate, 1).ToList();
            foreach (var c in adjacentCoordinates.Where(c => c.X > map.GetLength(1) || c.Y > map.GetLength(0)))
            {
                adjacentCoordinates.Remove(c);
            }
            
            switch (element.Name)
            {
                case "mineral":
                    foreach (var c in adjacentCoordinates)
                    {
                        if (map[c.Y, c.X] == "#" && (map[coordinate.Y, coordinate.X] == " " || (map[coordinate.Y, coordinate.X] == ".")))
                        {
                            canPlaceElement = true;
                        }
                    }
                    break;
                case "water":
                    foreach (var c in adjacentCoordinates)
                    {
                        if (map[c.Y, c.X] == "&" && (map[coordinate.Y, coordinate.X] == " " || (map[coordinate.Y, coordinate.X] == ".")))
                        {
                            canPlaceElement = true;
                        }
                    }
                    break;
                default:
                    canPlaceElement = false;
                    break;
                    
            }
        }
        else
        {
            for (int i = 0; i < element.Dimension; i++)
            {
                for (var j = 0; j < element.Dimension; j++)
                {
                    if (map[i + coordinate.Y, j + coordinate.X] != " ")
                    {
                        canPlaceElement = false;
                        break;
                    }
                    canPlaceElement = true;
                }
                
            }
            
            
        }


        return elementIsOnMap && canPlaceElement;
    }

    public void PlaceElement(MapElement element, string?[,] map, Coordinate coordinate)
    {
        for (int i = 0; i < element.Dimension; i++)
        {
            for (int j = 0; j < element.Dimension; j++)
            {
                map[coordinate.Y + i, coordinate.X + j] = element.Representation[i, j];
            }
        }
    }
}