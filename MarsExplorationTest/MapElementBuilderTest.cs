using Codecool.MarsExploration.MapElements.Model;
using Codecool.MarsExploration.MapElements.Service.Builder;

namespace MarsExplorationTest;

public class MapElementBuilderTest
{
    private static readonly string[,] TestRepresentation =
    {
        {"#","#"," "},
        {"#","#"," "},
        {" "," "," "}
    };
    
    private readonly MapElement _mapelement = new MapElement(TestRepresentation, "mountain", 3);
    
    private readonly MapElementBuilder _mapElementBuilder = new MapElementBuilder();
    
    [Test]
    public void MapElementBuildTest()
    {
        var actual = _mapElementBuilder.Build(4, "#", "mountain", 1);
        Assert.That(actual, Is.EqualTo(_mapelement));
    }
}