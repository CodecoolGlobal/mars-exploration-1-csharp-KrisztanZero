using Codecool.MarsExploration.Configuration.Model;

namespace Codecool.MarsExploration.Configuration.Service;

public class MapConfigurationValidator : IMapConfigurationValidator
{
    public bool Validate(MapConfiguration mapConfig)
    {
        return CheckTotalNumberOfElements(mapConfig) && CheckValidDimensionOfElements(mapConfig);
    }

    private bool CheckTotalNumberOfElements(MapConfiguration mapConfig)
    {
        int totalElementCount =
            mapConfig.MapElementConfigurations.Sum(config => config.ElementsToDimensions.Sum(e => e.Dimension));

        int maxElementCount = (int)(mapConfig.MapSize * mapConfig.MapSize * mapConfig.ElementToSpaceRatio * 0.5);

        return totalElementCount < maxElementCount;
    }

    private bool CheckValidDimensionOfElements(MapConfiguration mapConfig)
    {
        foreach (var config in mapConfig.MapElementConfigurations)
        {
            switch (config.Name)
            {
                case "mountain":
                {
                    foreach (var element in config.ElementsToDimensions)
                    {
                        return element.Dimension > 1 && config is { DimensionGrowth: 3, Symbol: "#" };
                    }

                    break;
                }
                case "pit":
                {
                    foreach (var element in config.ElementsToDimensions)
                    {
                        return element.Dimension > 1 && config is { DimensionGrowth: 10, Symbol: "&" };
                    }

                    break;
                }
                case "mineral":
                {
                    foreach (var element in config.ElementsToDimensions)
                    {
                        return element.Dimension == 1 && config is { DimensionGrowth: 0, Symbol: "%" };
                    }

                    break;
                }
                case "water":
                {
                    foreach (var element in config.ElementsToDimensions)
                    {
                        return element.Dimension == 1 && config is { DimensionGrowth: 0, Symbol: "*" };
                    }

                    break;
                }
                default:
                    return false;
            }
        }

        return false;
    }
}