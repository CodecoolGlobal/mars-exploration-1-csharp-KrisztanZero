using Codecool.MarsExploration.MapElements.Model;

namespace Codecool.MarsExploration.Output.Service;

public class MapFileWriter : IMapFileWriter
{
    public void WriteMapFile(Map map, string file)
    {
        var text = map.ToString();
        var replacedText = text.Replace(".", " ");
        File.WriteAllText(file, replacedText);
    }
}