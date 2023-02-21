using Codecool.MarsExploration.Configuration.Model;
using Codecool.MarsExploration.Configuration.Service;

namespace MarsExplorationTest;

public class Tests
{
    private const string MountainSymbol = "#";
    private const string PitSymbol = "&";
    private const string MineralSymbol = "%";
    private const string WaterSymbol = "*";

    //valid map config
    private static readonly MapElementConfiguration MountainsCfg = 
        new MapElementConfiguration(MountainSymbol, "mountain", new[]
    {
        new ElementToDimension(2, 20),
        new ElementToDimension(1, 30),
    }, 3);
    private static readonly MapElementConfiguration PitCfg = 
        new MapElementConfiguration(PitSymbol, "pit", new[]
    {
        new ElementToDimension(2, 10),
        new ElementToDimension(1, 20),
    }, 10);
    private static readonly MapElementConfiguration MineralCfg = new 
        MapElementConfiguration(MineralSymbol, "mineral", new[]
    {
        new ElementToDimension(13, 1),
    },0,"#");
    private static readonly MapElementConfiguration WaterCfg = 
        new MapElementConfiguration(WaterSymbol, "water", new[]
    {
        new ElementToDimension(20, 1),
    },0,"&");
    
    // invalid map config
    private static readonly MapElementConfiguration InvalidMountainsCfg = 
        new MapElementConfiguration("m", "mountain", new[]
    {
        new ElementToDimension(200, 20),
        new ElementToDimension(1, 30),
    }, 1);
    private static readonly MapElementConfiguration InvalidPitCfg = 
        new MapElementConfiguration(PitSymbol, "", new[]
    {
        new ElementToDimension(2, 10),
        new ElementToDimension(0, 20),
    }, 10);
    private static readonly MapElementConfiguration InvalidMineralCfg = 
        new MapElementConfiguration("", "mineral", new[]
    {
        new ElementToDimension(13, 0),
    },2,"");
    private static readonly MapElementConfiguration InvalidWaterCfg = 
        new MapElementConfiguration(WaterSymbol, "fater", new[]
    {
        new ElementToDimension(20, 10),
    }, 1,WaterSymbol);

    private static readonly List<MapElementConfiguration> ElementsCfg = new()
    {
        MountainsCfg, 
        PitCfg, 
        MineralCfg, 
        WaterCfg
    };
    private static readonly List<MapElementConfiguration> InvalidElementsCfg = new()
    {
        InvalidMountainsCfg, 
        InvalidPitCfg, 
        InvalidMineralCfg, 
        InvalidWaterCfg
    };
    private readonly MapConfiguration _validMapConfiguration = 
        new MapConfiguration(1000, 0.5, ElementsCfg);
    
    private readonly MapConfiguration _invalidMapConfiguration = 
        new MapConfiguration(10, 0.5, InvalidElementsCfg);
    
    private readonly MapConfigurationValidator _validator = 
        new MapConfigurationValidator();

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestValidMapConfiguration()
    {
        const bool expected = true;
        var actual = _validator.Validate(_validMapConfiguration);
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [Test]
    public void TestInvalidMapConfiguration()
    {
        const bool expected = false;
        var actual = _validator.Validate(_invalidMapConfiguration);
        Assert.That(actual, Is.EqualTo(expected));
    }
}