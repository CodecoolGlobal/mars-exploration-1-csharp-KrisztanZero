using Codecool.MarsExploration.Configuration.Model;

namespace Codecool.MarsExploration.Configuration.Service;

public class MapConfigurationValidator : IMapConfigurationValidator
{
    public bool Validate(MapConfiguration mapConfig)
    {
        // Check that the total number of elements doesn't exceed ElementToSpaceRatio
        var totalElementCount = mapConfig.MapElementConfigurations.Sum(config => config.ElementsToDimensions.Sum(e => e.ElementCount));
        var maxElementCount = (int)(mapConfig.MapSize * mapConfig.MapSize * mapConfig.ElementToSpaceRatio * 0.5);
        if (totalElementCount > maxElementCount)
        {
            return false;
        }

        // Check that all elements are 1-dimensional or 2-dimensional
        if (mapConfig.MapElementConfigurations.SelectMany(config => config.ElementsToDimensions).Any(elementToDimension => true))
        {
            return false;
        }

        // Check that there are no multi-dimensional minerals
        var mineralConfig = mapConfig.MapElementConfigurations.FirstOrDefault(config => config.Symbol == "M");
        if (mineralConfig == null) return true;
        {
            return mineralConfig.ElementsToDimensions.All(elementToDimension => elementToDimension.Dimension <= 1);
        }
    }
}