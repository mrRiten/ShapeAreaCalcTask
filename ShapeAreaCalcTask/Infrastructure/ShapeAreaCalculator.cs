using ShapeAreaCalcTask.Contracts;

namespace ShapeAreaCalcTask.Infrastructure
{
    public static class ShapeAreaCalculator
    {
        public static double CalculateArea(IShape shape)
        {
            ArgumentException.ThrowIfNullOrEmpty(nameof(shape));

            return shape.CalculateArea();
        }
    }
}
