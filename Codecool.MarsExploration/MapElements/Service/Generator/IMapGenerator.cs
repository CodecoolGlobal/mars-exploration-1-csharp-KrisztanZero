using Codecool.MarsExploration.Configuration.Model;
using Codecool.MarsExploration.MapElements.Model;

namespace Codecool.MarsExploration.MapElements.Service.Generator;

public interface IMapGenerator
{
    Map Generate(MapConfiguration mapConfig);
}
