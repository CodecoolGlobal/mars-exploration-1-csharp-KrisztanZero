using Codecool.MarsExploration.Calculators.Service;
using Codecool.MarsExploration.MapElements.Model;

namespace Codecool.MarsExploration.MapElements.Service.Builder;

public class MapElementBuilder : IMapElementBuilder
{
    public MapElement Build(int size, string symbol, string name, int dimensionGrowth, string? preferredLocationSymbol = null)
    {
        var dimensionCalculator = new DimensionCalculator();
        var dimension = dimensionCalculator.CalculateDimension(size, dimensionGrowth);
        var representation = Representation(dimension, dimensionGrowth, symbol);

        return new MapElement(representation, name, dimension, preferredLocationSymbol);

    }

    public string?[,] Representation(int dimension, int dimensionGrowth, string symbol)
    {
        string[,] representation = new string[dimension,dimension];
        
        
        for (int i = 0; i < dimension; i++) {
            for (int j = 0; j < dimension; j++) {
                if (i < dimensionGrowth || j < dimensionGrowth || i >= dimension - dimensionGrowth ||
                    j >= dimension - dimensionGrowth)
                {
                    representation[i, j] = ".";
                }
                else
                {
                    representation[i, j] = symbol;
                }
            }
        }

        return representation;
    }
    
}