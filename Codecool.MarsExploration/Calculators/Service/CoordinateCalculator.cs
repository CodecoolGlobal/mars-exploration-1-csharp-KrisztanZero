﻿using Codecool.MarsExploration.Calculators.Model;

namespace Codecool.MarsExploration.Calculators.Service;

public class CoordinateCalculator : ICoordinateCalculator
{
    private readonly Random _random = new();

    
    public Coordinate GetRandomCoordinate(int dimension)
    {
        
        var x = _random.Next(1, dimension + 1);
        var y = _random.Next(1, dimension + 1);
        return new Coordinate(x, y);
    }

    
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
        var adjacentCoordinates = new List<Coordinate>(coordinates);

        foreach (var coordinate in coordinates)
        {
            var adjacentCoords = GetAdjacentCoordinates(coordinate, dimension);
            adjacentCoordinates.AddRange(adjacentCoords);
        }
        
        return adjacentCoordinates;
    }
}