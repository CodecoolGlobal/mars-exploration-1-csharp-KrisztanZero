using Codecool.MarsExploration.MapElements.Model;

namespace Codecool.MarsExploration.Output.Service;

public interface IMapFileWriter
{
    void WriteMapFile(Map map, string file);
}
