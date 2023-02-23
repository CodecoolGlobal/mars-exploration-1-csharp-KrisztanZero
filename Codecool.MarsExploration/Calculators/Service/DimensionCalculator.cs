namespace Codecool.MarsExploration.Calculators.Service;

public class DimensionCalculator : IDimensionCalculator
{
    public int CalculateDimension(int size, int dimensionGrowth)
    {
        return (int)Math.Ceiling(Math.Sqrt(size)) + dimensionGrowth * 2;
    }
}