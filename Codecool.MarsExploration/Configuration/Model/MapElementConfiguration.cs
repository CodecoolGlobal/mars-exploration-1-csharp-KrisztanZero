namespace Codecool.MarsExploration.Configuration.Model;

public record MapElementConfiguration(
    string Symbol,
    string Name, IEnumerable<ElementToDimension> ElementsToDimensions,
    int DimensionGrowth = 0,
    string? PreferredLocationSymbol = null);
