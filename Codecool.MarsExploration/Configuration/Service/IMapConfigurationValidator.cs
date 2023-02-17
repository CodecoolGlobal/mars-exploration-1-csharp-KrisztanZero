using Codecool.MarsExploration.Configuration.Model;

namespace Codecool.MarsExploration.Configuration.Service;

public interface IMapConfigurationValidator
{
    bool Validate(MapConfiguration mapConfig);
}
