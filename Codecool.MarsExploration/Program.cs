using Codecool.MarsExploration.Calculators.Service;
using Codecool.MarsExploration.Configuration.Model;
using Codecool.MarsExploration.Configuration.Service;
using Codecool.MarsExploration.MapElements.Service.Builder;
using Codecool.MarsExploration.MapElements.Service.Generator;
using Codecool.MarsExploration.MapElements.Service.Placer;
using Codecool.MarsExploration.Output.Service;

internal class Program
{
    //You can change this to any directory you like
    private static readonly string WorkDir = AppDomain.CurrentDomain.BaseDirectory;

    public static void Main(string[] args)
    {
        Console.WriteLine("Mars Exploration Sprint 1");
        var mapConfig = GetConfiguration();

        IDimensionCalculator dimensionCalculator = null;
        ICoordinateCalculator coordinateCalculator = null;

        IMapElementBuilder mapElementFactory = null;
        IMapElementsGenerator mapElementsGenerator = null;

        IMapConfigurationValidator mapConfigValidator = null;
        IMapElementPlacer mapElementPlacer = null;

        IMapGenerator mapGenerator = null;

        CreateAndWriteMaps(3, mapGenerator, mapConfig);

        Console.WriteLine("Mars maps successfully generated.");
        Console.ReadKey();
    }

    private static void CreateAndWriteMaps(int count, IMapGenerator mapGenerator, MapConfiguration mapConfig)
    {
    }

    private static MapConfiguration GetConfiguration()
    {
        const string mountainSymbol = "#";
        const string pitSymbol = "&";
        const string mineralSymbol = "%";
        const string waterSymbol = "*";

        var mountainsCfg = new MapElementConfiguration(mountainSymbol, "mountain", new[]
        {
            new ElementToDimension(2, 20),
            new ElementToDimension(1, 30),
        }, 3);

        List<MapElementConfiguration> elementsCfg = new() { mountainsCfg };
        return new MapConfiguration(1000, 0.5, elementsCfg);
    }
}
