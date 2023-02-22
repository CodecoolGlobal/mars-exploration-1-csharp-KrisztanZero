using Codecool.MarsExploration.MapElements.Model;

namespace Codecool.MarsExploration.Output.Service;

public class MapFileWriter : IMapFileWriter
{ 
    // parameter file => contains filename
    // path => Output/MapFile/map.txt
    public void WriteMapFile(Map map, string file)
    {
        var text = map.ToString();
        File.WriteAllText(file, text);
    }
}