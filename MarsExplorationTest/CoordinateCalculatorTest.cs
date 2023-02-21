using Codecool.MarsExploration.Calculators.Model;
using Codecool.MarsExploration.Calculators.Service;

namespace MarsExplorationTest;

public class CoordinateCalculatorTest
{
    private CoordinateCalculator _coordinateCalculator = new CoordinateCalculator();
    
    private List<Coordinate> testCoordinates = new List<Coordinate>()
    {
        new Coordinate(2, 1),
        new Coordinate(3, 1),
        new Coordinate(4, 1),
        new Coordinate(2, 5),
        new Coordinate(3, 5),
        new Coordinate(4, 5),
        new Coordinate(5, 2),
        new Coordinate(5, 3),
        new Coordinate(5, 4),
        new Coordinate(1, 2),
        new Coordinate(1, 3),
        new Coordinate(1, 4),
    };

    private Coordinate coordinateOfTestElement = new Coordinate(2, 2);
    private int dimensionOfTestElement = 3;
    
    [Test]
    public void TestAdjacentCoordinates()
    {

        var actual = _coordinateCalculator.GetAdjacentCoordinates(coordinateOfTestElement, dimensionOfTestElement);
        
        Assert.That(testCoordinates, Is.EquivalentTo(actual));

    }
}