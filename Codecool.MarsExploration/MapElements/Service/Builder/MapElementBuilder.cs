using Codecool.MarsExploration.Calculators.Service;
using Codecool.MarsExploration.MapElements.Model;

namespace Codecool.MarsExploration.MapElements.Service.Builder;

public class MapElementBuilder : IMapElementBuilder
{
    public MapElement Build(int size, string symbol, string name, int dimensionGrowth, string? preferredLocationSymbol = null)
    {
        // string?[,] Representation, string Name, int Dimension, string? PreferredLocationSymbol = null
        /*
        this is the string?[,] Representation of a size: 16, dimensionGroth: 2 mountain
        
        [        ]         [####  ]
        [        ]         [####  ]
        [  ####  ]         [####  ]
        [  ####  ]         [####  ]
        [  ####  ]         [      ]
        [  ####  ]         [      ]
        [        ]
        [        ]
        
        */
        var dimensionCalculator = new DimensionCalculator();
        var dimension = dimensionCalculator.CalculateDimension(size, dimensionGrowth);

        
        
        var representation = new string?[,]{};


        //MapElement mapElement = new()
        throw new NotImplementedException();
    }
    
    private string[] getrepresentationLine(int dimension, int dimensionGrowth, string symbol)
    {
        string[] line = { };
        return line;
    }
}