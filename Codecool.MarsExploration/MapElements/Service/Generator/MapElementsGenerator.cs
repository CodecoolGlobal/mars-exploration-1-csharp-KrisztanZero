using Codecool.MarsExploration.Configuration.Model;
using Codecool.MarsExploration.MapElements.Model;
using Codecool.MarsExploration.MapElements.Service.Builder;

namespace Codecool.MarsExploration.MapElements.Service.Generator;

public class MapElementsGenerator : IMapElementsGenerator
{
    private readonly MapElementBuilder _mapElementBuilder = new();
    
    public IEnumerable<MapElement> CreateAll(MapConfiguration mapConfig)
    {
        var mapElements = new List<MapElement>();
        foreach (var mapElementConfiguration in mapConfig.MapElementConfigurations)
        {
            foreach (var elementsToDimension in mapElementConfiguration.ElementsToDimensions)
            {
                for (int i = 0; i < elementsToDimension.ElementCount; i++)
                {
                    mapElements.Add(_mapElementBuilder
                        .Build(elementsToDimension.Dimension,
                            mapElementConfiguration.Symbol,
                            mapElementConfiguration.Name,
                            mapElementConfiguration.DimensionGrowth,
                            mapElementConfiguration.PreferredLocationSymbol));
                }
            }
        }
        return mapElements;
    }
};