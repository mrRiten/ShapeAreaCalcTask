# ShapeAreaCalcTask
*(Задание для отлика)*

ShapeAreaCalcTask - это C# библиотека, предоставляющая функциональность для вычисления площади различных геометрических фигур и проверки свойств треугольника.

## Возможности

- Вычисление площади круга по радиусу.
- Вычисление площади треугольника по трём сторонам.
- Проверка, является ли треугольник прямоугольным.
- Вычисление площади фигуры без знания типа фигуры в compile-time.

## Установка

1. Склонируйте репозиторий или скачайте исходный код.
2. Откройте решение в Visual Studio.
3. Постройте проект, чтобы создать сборку библиотеки.

## Использование

### Вычисление площади круга

```csharp
using ShapeAreaCalcTask;

var circle = new Circle(5);
double area = circle.CalculateArea();
Console.WriteLine($"Площадь круга: {area}");
```

### Вычисление площади треугольника
```csharp
using ShapeAreaCalcTask;

var triangle = new Triangle(3, 4, 5);
double area = triangle.CalculateArea();
Console.WriteLine($"Площадь треугольника: {area}");
```
### Проверка, является ли треугольник прямоугольным

```csharp
using ShapeAreaCalcTask;

var triangle = new Triangle(3, 4, 5);
bool isRight = triangle.IsRightTriangle();
Console.WriteLine($"Треугольник прямоугольный: {isRight}");
```

### Вычисление площади фигуры через общий интерфейс
```csharp
using ShapeAreaCalcTask;

IShape circle = new Circle(5);
IShape triangle = new Triangle(3, 4, 5);
double circleArea = ShapeAreaCalculator.CalculateArea(circle);
double triangleArea = ShapeAreaCalculator.CalculateArea(triangle);
Console.WriteLine($"Площадь круга: {circleArea}");
Console.WriteLine($"Площадь треугольника: {triangleArea}");
```

### Примеры тестов
*CircleTests.cs*
```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ShapeAreaCalcTask.Tests
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
```

### Расширение библиотеки
Добавление новых фигур в библиотеку очень просто. Необходимо создать новый класс, реализующий интерфейс IShape, и реализовать метод CalculateArea.

Пример добавления новой фигуры:
*Rectangle.cs*
```csharp
public class Rectangle : IShape
{
    public double Width { get; }
    public double Height { get; }

    public Rectangle(double width, double height)
    {
        if (width <= 0 || height <= 0)
            throw new ArgumentException("Dimensions must be greater than zero.");

        Width = width;
        Height = height;
    }

    public double CalculateArea()
    {
        return Width * Height;
    }
}
```

### Заключение
Эта библиотека предоставляет базовый функционал для работы с геометрическими фигурами и легко расширяется.