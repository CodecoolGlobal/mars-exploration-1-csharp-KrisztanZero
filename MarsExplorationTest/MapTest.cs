using Codecool.MarsExploration.MapElements.Model;

namespace MarsExplorationTest;

public class MapTest
{
    private static readonly string[,] Representation =
    {
        {"#","#"," "},
        {"#","#"," "},
        {" "," "," "}
    };
    private readonly Map _map = new(Representation);

    [Test]
    public void ToStringTest()
    {
        var expected = "## \n## \n   \n";
        var actual = _map.ToString();
        Assert.That(expected, Is.EquivalentTo(actual));
    }
}