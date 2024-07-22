using ShapeAreaCalcTask.Contracts;
using ShapeAreaCalcTask.Figure;
using ShapeAreaCalcTask.Infrastructure;

namespace TestModule
{
    [TestClass]
    public class ShapeTests
    {
        [TestMethod]
        public void CircleAreaTest()
        {
            var circle = new Circle(5);
            Assert.AreEqual(Math.PI * 25, circle.CalculateArea(), 1e-10, "Площадь круга вычислена неверно.");
        }

        [TestMethod]
        public void CircleRadiusSetterTest()
        {
            var circle = new Circle(5);
            circle.Radius = 10;
            Assert.AreEqual(10, circle.Radius, "Радиус круга установлен неверно.");
            Assert.AreEqual(Math.PI * 100, circle.CalculateArea(), 1e-10, "Площадь круга после изменения радиуса вычислена неверно.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CircleInvalidRadiusTest()
        {
            var circle = new Circle(5);
            circle.Radius = -1;
        }

        [TestMethod]
        public void TriangleAreaTest()
        {
            var triangle = new Triangle(3, 4, 5);
            Assert.AreEqual(6, triangle.CalculateArea(), 1e-10, "Площадь треугольника вычислена неверно.");
        }

        [TestMethod]
        public void TriangleIsRightTest()
        {
            var triangle = new Triangle(3, 4, 5);
            Assert.IsTrue(triangle.IsRightTriangle(), "Треугольник не определяется как прямоугольный.");
        }

        [TestMethod]
        public void ShapeAreaCalculatorTest()
        {
            IShape circle = new Circle(5);
            IShape triangle = new Triangle(3, 4, 5);
            Assert.AreEqual(Math.PI * 25, ShapeAreaCalculator.CalculateArea(circle), 1e-10, "Площадь круга через ShapeAreaCalculator вычислена неверно.");
            Assert.AreEqual(6, ShapeAreaCalculator.CalculateArea(triangle), 1e-10, "Площадь треугольника через ShapeAreaCalculator вычислена неверно.");
        }

    }
}
