using System.Text;

namespace Codecool.MarsExploration.MapElements.Model;

public record Map(string?[,] Representation, bool SuccessfullyGenerated = false)
{
    // In starter code this was protected and static so we couldn't test it from outside 👇
    public string CreateStringRepresentation(string?[,] arr)
    {
        return arr.Cast<string?>().Aggregate("", (output, line) => output + (line + "\n"));
    }

    public override string ToString()
    {
        return CreateStringRepresentation(Representation);
    }
}
