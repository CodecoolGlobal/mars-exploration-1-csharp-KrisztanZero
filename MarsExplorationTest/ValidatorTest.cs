using Codecool.MarsExploration.Configuration.Model;
using Codecool.MarsExploration.Configuration.Service;

namespace MarsExplorationTest;

public class Tests
{
    const string mountainSymbol = "#";
    const string pitSymbol = "&";
    const string mineralSymbol = "%";
    const string waterSymbol = "*";

    private static readonly MapElementConfiguration MountainsCfg = new MapElementConfiguration(mountainSymbol, "mountain", new[]
    {
        new ElementToDimension(2, 20),
        new ElementToDimension(1, 30),
    }, 3);

    private static readonly List<MapElementConfiguration> ElementsCfg = new() { MountainsCfg };
    private MapConfiguration _mapCfgTrue = new MapConfiguration(1000, 0.5, ElementsCfg);
    
    private MapConfiguration _mapCfgFalse = new MapConfiguration(10, 0.5, ElementsCfg);
    
    private MapConfigurationValidator _validator = new MapConfigurationValidator();
    
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestValidMapConfiguration()
    {
        const bool expected = true;
        var actual = _validator.Validate(_mapCfgTrue);
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [Test]
    public void TestInvalidMapConfiguration()
    {
        const bool expected = false;
        var actual = _validator.Validate(_mapCfgFalse);
        Assert.That(actual, Is.EqualTo(expected));
    }
}