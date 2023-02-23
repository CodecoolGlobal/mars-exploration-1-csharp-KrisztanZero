using Codecool.MarsExploration.Calculators.Model;
using Codecool.MarsExploration.Calculators.Service;
using Codecool.MarsExploration.MapElements.Model;

namespace Codecool.MarsExploration.MapElements.Service.Placer;

public class MapElementPlacer : IMapElementPlacer
{
    public bool CanPlaceElement(MapElement element, string?[,] map, Coordinate coordinate)
    {
        CoordinateCalculator coordinateCalculator = new();
        
        var elementIsOnMap = coordinate.X + element.Dimension < map.GetLength(0) &&
                             coordinate.Y + element.Dimension < map.GetLength(1);
        if (!elementIsOnMap) return false;
        
        var coordinateIsTaken = false;

        var canPlaceElement = false;

        if (element.PreferredLocationSymbol != null)
        {
            var adjacentCoordinates = coordinateCalculator.GetAdjacentCoordinates(coordinate, 1).ToList();
            
            /*foreach (var c in adjacentCoordinates.Where(c =>
                         c.X > map.GetLength(1) ||
                         c.Y > map.GetLength(0) ||
                         c.X < 0 ||
                         c.Y < 0))
            {
                adjacentCoordinates.Remove(c);
            }*/
            
            switch (element.Name)
            {
                case "mineral":
                    foreach (var c in adjacentCoordinates)
                        if (map[c.Y, c.X] == "#")
                        {
                            return true;
                        }
                    break;
                case "water":
                    foreach (var c in adjacentCoordinates) 
                        if(map[c.Y, c.X] == "&")
                        {
                            return true;
                        }
                    break;
            }
        }
        else
        {
            for (var i = 0; i < element.Dimension; i++)
            {
                for (var j = 0; j < element.Dimension; j++)
                {
                    if (map[i + coordinate.Y, j + coordinate.X] == " ") continue;
                    coordinateIsTaken = true;
                    break;
                }
            }
        }
        
        return elementIsOnMap && canPlaceElement && !coordinateIsTaken;
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