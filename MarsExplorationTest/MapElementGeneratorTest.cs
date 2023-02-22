using System.Security.Cryptography;
using Codecool.MarsExploration.Configuration.Model;
using Codecool.MarsExploration.MapElements.Model;
using Codecool.MarsExploration.MapElements.Service.Generator;

namespace MarsExplorationTest;

public class MapElementGeneratorTest
{
    private static readonly IEnumerable<ElementToDimension> TestElementsToDimensions = new[]
    {
        new ElementToDimension(2, 4),
        new ElementToDimension(1, 9),
    };

    private static readonly IEnumerable<MapElementConfiguration> TestMapelementconfiguration = new[]
    {
        new MapElementConfiguration("#", "mountain", TestElementsToDimensions, 1)
    };

    public MapConfiguration TestMapConfig = new MapConfiguration(1000, 0.5, TestMapelementconfiguration);


    public MapElementsGenerator _mapElementsGenerator = new MapElementsGenerator();

    private static readonly string[,] TestRepresentation1 =
    {
        { "#", "#", " " },
        { "#", "#", " " },
        { " ", " ", " " }
    };

    private static readonly string[,] TestRepresentation2 =
    {
        { "#", "#", "#", " " },
        { "#", "#", "#", " " },
        { "#", "#", "#", " " },
        { " ", " ", " ", " " }
    };

    [Test]
    public void TestCreateAll()
    {
        var actual = _mapElementsGenerator.CreateAll(TestMapConfig).ToList();

        IEnumerable<MapElement> expected = new[]
        {
            new MapElement(TestRepresentation1, "mountain", 3),
            new MapElement(TestRepresentation1, "mountain", 3),
            new MapElement(TestRepresentation2, "mountain", 4)
        };

        for (int i = 0; i < actual.Count(); i++)
        {
            for (int j = 0; j < actual[i].Dimension; j++)
            {
                for (int k = 0; k < actual[i].Dimension; k++)
                {
                    Assert.That(actual[i].Representation[j, k], Is.EqualTo(expected.ToList()[i].Representation[j, k]));
                }
            }
        }
    }
}