namespace Codecool.MarsExploration.Calculators.Service;

public class DimensionCalculator : IDimensionCalculator
{
    public int CalculateDimension(int size, int dimensionGrowth)
    {
        return (int)Math.Floor(Math.Sqrt(size)) + dimensionGrowth;
    }
}