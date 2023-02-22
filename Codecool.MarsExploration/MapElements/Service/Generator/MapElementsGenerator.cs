using Codecool.MarsExploration.Configuration.Model;
using Codecool.MarsExploration.MapElements.Model;
using Codecool.MarsExploration.MapElements.Service.Builder;

namespace Codecool.MarsExploration.MapElements.Service.Generator;

public class MapElementsGenerator : IMapElementsGenerator
{
    /*
     public record MapConfiguration(
        int MapSize,
        double ElementToSpaceRatio,
        IEnumerable<MapElementConfiguration> MapElementConfigurations);
    */
    
    /*
    public record MapElementConfiguration(
        string Symbol,
        string Name,
        IEnumerable<ElementToDimension> ElementsToDimensions,
        int DimensionGrowth = 0,
        string? PreferredLocationSymbol = null);
    */
    
    //public record ElementToDimension(int ElementCount, int Dimension);
    
    //public MapElement Build(int size, string symbol, string name, int dimensionGrowth, string? preferredLocationSymbol = null)

    private MapElementBuilder _mapElementBuilder = new MapElementBuilder();
    
    public IEnumerable<MapElement> CreateAll(MapConfiguration mapConfig)
    {
        var mapElements = new List<MapElement>();
        foreach (var mapElementConfiguration in mapConfig.MapElementConfigurations)
        {
            foreach (var elementsToDimension in mapElementConfiguration.ElementsToDimensions)
            {
                for (int i = 0; i < elementsToDimension.ElementCount; i++)
                {
                    _mapElementBuilder.Build(elementsToDimension.Dimension, mapElementConfiguration.Symbol, mapElementConfiguration.Name, mapElementConfiguration.DimensionGrowth,mapElementConfiguration.PreferredLocationSymbol);
                }
            }
        }
        throw new NotImplementedException();
    }
};