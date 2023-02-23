using Codecool.MarsExploration.Calculators.Service;
using Codecool.MarsExploration.Configuration.Model;
using Codecool.MarsExploration.Configuration.Service;
using Codecool.MarsExploration.MapElements.Service.Builder;
using Codecool.MarsExploration.MapElements.Service.Generator;
using Codecool.MarsExploration.MapElements.Service.Placer;
using Codecool.MarsExploration.Output.Service;

internal class Program
{
    private static readonly string WorkDir = AppDomain.CurrentDomain.BaseDirectory;

    public static void Main(string[] args)
    {
        IMapGenerator mapGenerator = new MapGenerator();
        
        Console.WriteLine("Mars Exploration Sprint 1");
        var mapConfig = GetConfiguration();
        if (mapConfig.MapSize == -1)
        {
            Console.WriteLine("Map size is too small for the total dimension of elements!");
        }
        else
        {
            CreateAndWriteMaps(3, mapGenerator, mapConfig);

            Console.WriteLine("Mars maps successfully generated.");
            Console.ReadKey();
        }
    }

    private static void CreateAndWriteMaps(int count, IMapGenerator mapGenerator, MapConfiguration mapConfig)
    {
        var mapFileWriter = new MapFileWriter();
        for (int i = 0; i < count; i++)
        {
            mapFileWriter.WriteMapFile(mapGenerator.Generate(mapConfig), $"map{i}.txt");
        }
    }

    private static MapConfiguration GetConfiguration()
    {
        IMapConfigurationValidator mapConfigValidator = new MapConfigurationValidator();
        
        const string mountainSymbol = "#";
        const string pitSymbol = "&";
        const string mineralSymbol = "%";
        const string waterSymbol = "*";

        var mountainsCfg = new MapElementConfiguration(mountainSymbol, "mountain", new[]
        {
            new ElementToDimension(7, 90),
            new ElementToDimension(3, 40),
        }, 3);
        
        var pitCfg = new MapElementConfiguration(pitSymbol, "pit", new[]
        {
            new ElementToDimension(5, 90),
            new ElementToDimension(3, 40),
        }, 10);
        
        var mineralCfg = new MapElementConfiguration(mineralSymbol, "mineral", new[]
        {
            new ElementToDimension(50, 1),
            
        }, 0, mountainSymbol);
        
        var waterCfg = new MapElementConfiguration(waterSymbol, "water", new[]
        {
            new ElementToDimension(50, 1),
            
        }, 0, pitSymbol);

        List<MapElementConfiguration> elementsCfg = new() { mountainsCfg, pitCfg, mineralCfg, waterCfg };

        var mapCfg = new MapConfiguration(150, 0.5, elementsCfg); 
        
        return mapConfigValidator.Validate(mapCfg) ? mapCfg : new MapConfiguration(-1, 0.5, elementsCfg);

    }
}
