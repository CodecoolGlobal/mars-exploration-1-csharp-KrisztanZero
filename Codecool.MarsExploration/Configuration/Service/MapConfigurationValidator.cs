using Codecool.MarsExploration.Configuration.Model;

namespace Codecool.MarsExploration.Configuration.Service;

public class MapConfigurationValidator : IMapConfigurationValidator
{
    public bool Validate(MapConfiguration mapConfig)
    {
        // Check that the total number of elements doesn't exceed ElementToSpaceRatio
        int totalElementCount = mapConfig.MapElementConfigurations.Sum(config => config.ElementsToDimensions.Sum(e => e.ElementCount));
        int maxElementCount = (int)(mapConfig.MapSize * mapConfig.MapSize * mapConfig.ElementToSpaceRatio * 0.5);
        if (totalElementCount > maxElementCount)
        {
            return false;
        }

        // Check that all elements are 1-dimensional or 2-dimensional
        foreach (var config in mapConfig.MapElementConfigurations)
        {
            foreach (var elementToDimension in config.ElementsToDimensions)
            {
                if (elementToDimension.Dimension != 1 || elementToDimension.Dimension != 2)
                {
                    return false;
                }
            }
        }

        // Check that there are no multi-dimensional minerals
        var mineralConfig = mapConfig.MapElementConfigurations.FirstOrDefault(config => config.Symbol == "M");
        if (mineralConfig != null)
        {
            foreach (var elementToDimension in mineralConfig.ElementsToDimensions)
            {
                if (elementToDimension.Dimension > 1)
                {
                    return false;
                }
            }
        }

        return true;
    }
}