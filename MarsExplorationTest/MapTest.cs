using Codecool.MarsExploration.MapElements.Model;

namespace MarsExplorationTest;

public class MapTest
{
    private static readonly string?[,] TestRepresentation = new string?[,]
    { 
        { "one", "two", "three" }, 
        { "four", "five", "six" },
        { "seven", "eight", "nine" }
    };

    private readonly Map _map = new Map(TestRepresentation);
    
    [Test]
    
    public void TestCreateStringRepresentation()
    {
        var expected = "one\ntwo\nthree\nfour\nfive\nsix\nseven\neight\nnine\n";
        var actual = _map.CreateStringRepresentation(TestRepresentation);
        
        Assert.That(expected, Is.EquivalentTo(actual));
    }
}