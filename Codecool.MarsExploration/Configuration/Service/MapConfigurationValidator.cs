using Codecool.MarsExploration.Configuration.Model;

namespace Codecool.MarsExploration.Configuration.Service;

public class MapConfigurationValidator : IMapConfigurationValidator
{
    public bool Validate(MapConfiguration mapConfig)
    {
        return CheckTotalDimensionOfElements(mapConfig) && CheckConfigForInput(mapConfig) &&
               CheckValidDimensionOfElements(mapConfig);
    }

    private static bool CheckTotalDimensionOfElements(MapConfiguration mapConfig)
    {
        int totalElementDimension =
            mapConfig.MapElementConfigurations.Sum(config => config.ElementsToDimensions.Sum(e => e.Dimension));

        int maxElementCount = (int)(mapConfig.MapSize * mapConfig.MapSize * mapConfig.ElementToSpaceRatio * 0.5);

        return totalElementDimension < maxElementCount;
    }

    private static bool CheckValidDimensionOfElements(MapConfiguration mapConfig)
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

    private static bool CheckConfigForInput(MapConfiguration mapConfig)
    {
        // Validate each element configuration
        foreach (var elementConfig in mapConfig.MapElementConfigurations)
        {
            // Validate the element symbol
            if (string.IsNullOrWhiteSpace(elementConfig.Symbol))
            {
                Console.WriteLine($"Error: Element symbol is required for {elementConfig.Name}.");
                return false;
            }

            // Validate the element name
            if (string.IsNullOrWhiteSpace(elementConfig.Name))
            {
                Console.WriteLine($"Error: Element name is required for {elementConfig.Symbol}.");
                return false;
            }

            // Validate the element dimensions
            if (elementConfig.ElementsToDimensions.Any(dim => dim.ElementCount <= 0 || dim.Dimension <= 0))
            {
                Console.WriteLine($"Error: Invalid element dimension count or size for {elementConfig.Symbol}.");
                return false;
            }

            // Validate the element growth
            if (elementConfig.DimensionGrowth < 0)
            {
                Console.WriteLine($"Error: Invalid element dimension growth for {elementConfig.Symbol}.");
                return false;
            }

            // Validate the preferred location symbol
            if (!string.IsNullOrWhiteSpace(elementConfig.PreferredLocationSymbol))
            {
                if (elementConfig.Symbol == elementConfig.PreferredLocationSymbol)
                {
                    Console.WriteLine($"Error: Invalid preferred location symbol for {elementConfig.Symbol}.");
                    return false;
                }

                switch (elementConfig.Symbol)
                {
                    case "%" when elementConfig.PreferredLocationSymbol != "#":
                        Console.WriteLine(
                            $"Error: Minerals ({elementConfig.Symbol}) can only be placed next to mountains (#).");
                        return false;
                    case "*" when elementConfig.PreferredLocationSymbol != "&":
                        Console.WriteLine(
                            $"Error: Water ({elementConfig.Symbol}) can only be placed next to pits (&).");
                        return false;
                }
            }
        }

        return true;
    }
}