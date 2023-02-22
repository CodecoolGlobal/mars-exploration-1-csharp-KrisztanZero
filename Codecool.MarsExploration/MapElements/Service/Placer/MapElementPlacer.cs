﻿using Codecool.MarsExploration.Calculators.Model;
using Codecool.MarsExploration.MapElements.Model;

namespace Codecool.MarsExploration.MapElements.Service.Placer;

public class MapElementPlacer : IMapElementPlacer
{
    // MapElement(string?[,] Representation, string Name, int Dimension, string? PreferredLocationSymbol = null) : Map(Representation)

    public bool CanPlaceElement(MapElement element, string?[,] map, Coordinate coordinate)
    {
        // check if element is still on map
        bool elementIsOnMap = coordinate.X + element.Dimension < map.GetLength(0) && coordinate.Y + element.Dimension < map.GetLength(1);

        // check if area at coordinate is available
        bool coordinateIsTaken = false;
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (var j = 0; j < 5; j++)
            {
                if (map[i, j] != " ")
                {
                    coordinateIsTaken = true;
                    break;
                }
                
            }
            
        }

        // check adjecent coordinates if that prevents element from being placed on map

        return elementIsOnMap && !coordinateIsTaken;
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