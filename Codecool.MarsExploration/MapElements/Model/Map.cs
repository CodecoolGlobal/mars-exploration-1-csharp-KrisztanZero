using System.Text;

namespace Codecool.MarsExploration.MapElements.Model;

public record Map(string?[,] Representation, bool SuccessfullyGenerated = false)
{
    // In starter code this was protected and static so we couldn't test it from outside 👇
    protected static string CreateStringRepresentation(string?[,] arr)
    {
        StringBuilder stringBuilder = new StringBuilder("");

        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                stringBuilder.Append(arr[i,j]);
            }

            stringBuilder.Append('\n');
            //stringBuilder.AppendLine();
        }

        return stringBuilder.ToString();
    }

    public override string ToString()
    {
        return CreateStringRepresentation(Representation);
    }
}