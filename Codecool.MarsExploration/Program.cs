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
            //new ElementToDimension(7, 9),
            new ElementToDimension(1, 4),
        }, 3);
        
        var pitCfg = new MapElementConfiguration(pitSymbol, "pit", new[]
        {
            //new ElementToDimension(5, 9),
            new ElementToDimension(1, 4),
        }, 10);
        
        var mineralCfg = new MapElementConfiguration(mineralSymbol, "mineral", new[]
        {
            new ElementToDimension(10, 1),
            
        }, 0, mountainSymbol);
        
        var waterCfg = new MapElementConfiguration(waterSymbol, "water", new[]
        {
            new ElementToDimension(10, 1),
            
        }, 0, pitSymbol);

        List<MapElementConfiguration> elementsCfg = new() { mountainsCfg, pitCfg, mineralCfg, waterCfg };

        var mapCfg = new MapConfiguration(100, 0.5, elementsCfg); 
        
        
        // even if element ot space ration is right the program might not be able to use all the available space because of element sizes and shapes
        return mapConfigValidator.Validate(mapCfg) ? mapCfg : new MapConfiguration(-1, 0.5, elementsCfg);

    }
}
