using Codecool.MarsExploration.MapElements.Model;

namespace Codecool.MarsExploration.Output.Service;

public class MapFileWriter : IMapFileWriter
{
    public void WriteMapFile(Map map, string file)
    {
        using StreamWriter writer = new StreamWriter(file);

        for (int i = 0; i < map.Representation.GetLength(0); i++)
        {
            for (int j = 0; j < map.Representation.GetLength(1); j++)
            {
                string symbol = map.Representation[i, j] ?? " ";
                writer.Write(symbol);
            }

            writer.WriteLine();
        }
    }
}

}