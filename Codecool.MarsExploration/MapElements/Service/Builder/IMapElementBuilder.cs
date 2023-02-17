using Codecool.MarsExploration.MapElements.Model;

namespace Codecool.MarsExploration.MapElements.Service.Builder;

public interface IMapElementBuilder
{
    MapElement Build(int size, string symbol, string name, int dimensionGrowth, string? preferredLocationSymbol = null);
}
