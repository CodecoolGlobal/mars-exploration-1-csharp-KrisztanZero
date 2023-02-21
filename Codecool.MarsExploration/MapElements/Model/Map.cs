using System.Text;

namespace Codecool.MarsExploration.MapElements.Model;

public record Map(string?[,] Representation, bool SuccessfullyGenerated = false)
{
    // In starter code this was protected and static so we couldn't test it from outside 👇
    public string CreateStringRepresentation(string?[,] arr)
    {
        return arr.Cast<string?>().Aggregate("", (output, line) => output + (line + "\n"));
        // List<string> rows = new List<string>();
        // for (int i = 0; i < arr.GetLength(0); i++)
        // {
        //     List<string> row = new List<string>();
        //     for (int j = 0; j < arr.GetLength(1); j++)
        //     {
        //         row.Add(arr[i, j] ?? " ");
        //         Console.Write(arr[i, j] + " ");
        //     }
        //
        //     rows.Add(string.Join("", row));
        // }
        //
        // return string.Join("\n", rows);
    }

    public override string ToString()
    {
        return CreateStringRepresentation(Representation);
    }
}