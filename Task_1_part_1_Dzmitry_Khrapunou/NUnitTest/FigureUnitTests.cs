using NUnit.Framework;
using Task_1_part_2;

namespace NUnitTest
{
    [TestFixture]
    public class FigureUnitTests
    {
        [Test]
        public void CompareTwoEqualRectangles_ReturnsEqual()
        {
            var rectangle1 = new Rectangle(5, 6);
            var rectangle2 = new Rectangle(5, 6);

            Assert.That(rectangle1, Is.EqualTo(rectangle2));
        }

        [Test]
        public void CompareTwoDifferentRectangles_ReturnsEqual()
        {
            var rectangle1 = new Rectangle(5, 6);
            var rectangle2 = new Rectangle(7, 6);

            Assert.That(rectangle1, Is.Not.EqualTo(rectangle2));
        }

        [Test]
        public void CompareTwoEqualCircles_ReturnsEqual()
        {
            var circle1 = new Circle(5);
            var circle2 = new Circle(5);

            Assert.That(circle1, Is.EqualTo(circle2));
        }

        [Test]
        public void CompareTwoDifferentCircles_ReturnsEqual()
        {
            var circle1 = new Circle(5);
            var circle2 = new Circle(9);

            Assert.That(circle1, Is.Not.EqualTo(circle2));
        }

        [Test]
        public void CompareTwoEqualTriangles_ReturnsEqual()
        {
            var triangle1 = new Triangle(5, 7, 6);
            var triangle2 = new Triangle(5, 7, 6);

            Assert.That(triangle1, Is.EqualTo(triangle2));
        }

        [Test]
        public void CompareTwoDifferentTriangles_ReturnsEqual()
        {
            var triangle1 = new Triangle(5, 7, 6);
            var triangle2 = new Triangle(8, 5, 9);

            Assert.That(triangle1, Is.Not.EqualTo(triangle2));
        }

        [TestCase(5, 7, 9, 21)]
        public void Perimeter_PerimeterForTriangles_ReturnsPerimeter(int a, int b, int c, double perimeter)
        {
            var triangle = new Triangle(a, b, c);

            Assert.AreEqual(triangle.Perimeter(), perimeter);
        }

        [TestCase(5, 7, 24)]
        public void Perimeter_PerimeterForRectangles_ReturnsPerimeter(int a, int b, double perimeter)
        {
            var rectangle = new Rectangle(a, b);

            Assert.AreEqual(rectangle.Perimeter(), perimeter);
        }

        [TestCase(50, 314)]
        public void Perimeter_PerimeterForCircles_ReturnsPerimeter(int a, double perimeter)
        {
            var circle = new Circle(a);

            Assert.AreEqual(circle.Perimeter(), perimeter);
        }

        [TestCase(21, 10, 22, 104.02854175657755)]
        public void Area_AreaForTriangles_ReturnsArea(int a, int b, int c, double Area)
        {
            var triangle = new Triangle(a, b, c);

            Assert.AreEqual(triangle.Area(), Area);
        }

        [TestCase(5, 6, 30)]
        public void Area_AreaForRectangles_ReturnsArea(int a, int b, double Area)
        {
            var rectangle = new Rectangle(a, b);

            Assert.AreEqual(rectangle.Area(), Area);
        }

        [TestCase(8, 200.96)]
        public void Area_AreaForCircles_ReturnsArea(int a, double Area)
        {
            var circle = new Circle(a);

            Assert.AreEqual(circle.Area(), Area);
        }
    }
}
