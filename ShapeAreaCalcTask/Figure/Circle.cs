using ShapeAreaCalcTask.Contracts;

namespace ShapeAreaCalcTask.Figure
{
    public class Circle : IShape
    {
        private double _radius;

        public double Radius
        {
            get => _radius;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Radius must be greater than zero.", nameof(value));
                _radius = value;
            }
        }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double CalculateArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }
}
