using Codecool.MarsExploration.MapElements.Model;

namespace MarsExplorationTest;

public class CreateStringRepresentationTest
{
    private string[,] _testMap1;
    private string[,] _testMap2;


    [SetUp]

    public void SetUp()
    {
        _testMap1 = new string[,] { { "#", "#", "#" },{ "#", "#", "#" },{ "#", "#", "#" } };
        _testMap2 = new string[,] { { "#", "#" },{"#", "#" }};
    }

    [Test]
    public void TestTheCorrectWorkingToCreateRepresentation()
    {

        var result = "###\n###\n###";

        Map map = new Map(_testMap1);

        Assert.That(map.ToString(), Is.EqualTo(result));
    }

    [Test]
    public void AnotherTestForCorrrectWorking()
    {

        var result = "##\n##";

        Map map = new Map(_testMap2);

        Assert.That(map.ToString(), Is.EqualTo(result));
    }

    [Test]
    public void TestWhenItWillBeFail()
    {
        var result = "###\n##&";

        Map map = new Map(_testMap2);

        Assert.That(map.ToString(), Is.Not.EqualTo(result));
    }
}