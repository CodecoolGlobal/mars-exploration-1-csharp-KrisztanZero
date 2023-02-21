using Codecool.MarsExploration.Calculators.Service;
using Codecool.MarsExploration.MapElements.Model;

namespace Codecool.MarsExploration.MapElements.Service.Builder;

public class MapElementBuilder : IMapElementBuilder
{
    public MapElement Build(int size, string symbol, string name, int dimensionGrowth, string? preferredLocationSymbol = null)
    {
        // string?[,] Representation, string Name, int Dimension, string? PreferredLocationSymbol = null
        
        var dimensionCalculator = new DimensionCalculator();
        var dimension = dimensionCalculator.CalculateDimension(size, dimensionGrowth);
        var representation = Representation(dimension, dimensionGrowth, symbol);

        return new MapElement(representation, name, dimension, preferredLocationSymbol);

    }

    public string?[,] Representation(int dimension, int dimensionGrowth, string symbol)
    {
        string[,] myArray = new string[dimension,dimension];
        
        for (int i = 0; i < 5; i++) {
            for (int j = 0; j < 5; j++) {
                if (i < dimension - dimensionGrowth || j < dimension - dimensionGrowth)
                {
                    myArray[i, j] = symbol;
                }
                else
                {
                    myArray[i, j] = " ";
                }
            }
        }

        return myArray;
    }
    
}