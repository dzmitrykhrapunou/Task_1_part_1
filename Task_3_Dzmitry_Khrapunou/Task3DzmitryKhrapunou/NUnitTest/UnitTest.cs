using NUnit.Framework;
using Task3DzmitryKhrapunou.Data;
using Task3DzmitryKhrapunou.Entities;

namespace NUnitTest
{
    public class Tests
    {
        [Test]
        public void CompareTwoEqualSquares_ReturnsEqual()
        {
            var square1 = new Square(new Film(), 5);
            var square2 = new Square(new Film(), 5);

            Assert.That(square1, Is.EqualTo(square2));
        }

        [Test]
        public void CompareTwoDifferentSquares_ReturnsEqual()
        {
            var square1 = new Square(new Film(), 7);
            var square2 = new Square(new Film(), 5);

            Assert.That(square1, Is.Not.EqualTo(square2));
        }

        [Test]
        public void CompareTwoEqualCircles_ReturnsEqual()
        {
            var circle1 = new Circle(new Paper(), 5);
            var circle2 = new Circle(new Paper(), 5);

            Assert.That(circle1, Is.EqualTo(circle2));
        }

        [Test]
        public void CompareTwoDifferentCircles_ReturnsEqual()
        {
            var circle1 = new Circle(new Paper(), 5);
            var circle2 = new Circle(new Paper(Color.Red), 5);

            Assert.That(circle1, Is.Not.EqualTo(circle2));
        }

        [Test]
        public void CompareTwoEqualTriangles_ReturnsEqual()
        {
            var triangle1 = new Triangle(new Paper(Color.Red), 6);
            var triangle2 = new Triangle(new Paper(Color.Red), 6);

            Assert.That(triangle1, Is.EqualTo(triangle2));
        }

        [Test]
        public void CompareTwoDifferentTriangles_ReturnsEqual()
        {
            var triangle1 = new Triangle(new Paper(Color.Red), 6);
            var triangle2 = new Triangle(new Paper(Color.Blue), 9);

            Assert.That(triangle1, Is.Not.EqualTo(triangle2));
        }

        [TestCase(9, 27)]
        public void Perimeter_PerimeterForTriangles_ReturnsPerimeter(int a, double perimeter)
        {
            var triangle = new Triangle(new Film(), a);

            Assert.AreEqual(triangle.Perimeter(), perimeter);
        }

        [TestCase(7, 28)]
        public void Perimeter_PerimeterForSquare_ReturnsPerimeter(int a, double perimeter)
        {
            var square = new Square(new Film(), a);

            Assert.AreEqual(square.Perimeter(), perimeter);
        }

        [TestCase(50, 314)]
        public void Perimeter_PerimeterForCircles_ReturnsPerimeter(int a, double perimeter)
        {
            var circle = new Circle(new Film(), a);

            Assert.AreEqual(circle.Perimeter(), perimeter);
        }

        [TestCase(10, 43.301270189221931)]
        public void Area_AreaForTriangles_ReturnsArea(int a, double Area)
        {
            var triangle = new Triangle(new Film(), a);

            Assert.AreEqual(triangle.Area(), Area);
        }

        [TestCase(5, 25)]
        public void Area_AreaForRectangles_ReturnsArea(int a, double Area)
        {
            var square = new Square(new Film(), a);

            Assert.AreEqual(square.Area(), Area);
        }

        [TestCase(8, 200.96)]
        public void Area_AreaForCircles_ReturnsArea(int a, double Area)
        {
            var circle = new Circle(new Film(), a);

            Assert.AreEqual(circle.Area(), Area);
        }
    }
}