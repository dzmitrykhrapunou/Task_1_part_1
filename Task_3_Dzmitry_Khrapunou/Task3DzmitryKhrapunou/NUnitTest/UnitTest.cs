using NUnit.Framework;
using System.Collections.Generic;
using Task3DzmitryKhrapunou.Data;
using Task3DzmitryKhrapunou.Entities;
using Task3DzmitryKhrapunou.Interfaces;

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

        [TestCase(1)]
        public void Index_GetsFreeIndexInMas_ReturnsIndexOfEmpty(int a)
        {
            var box = new Box();
            box.Shapes[0] = new Circle(new Film(), 2);
            box.Shapes[2] = new Circle(new Film(), 7);
            int? res = box.GetFree();

            Assert.AreEqual(res, a);
        }

        [TestCase(2)]
        public void Search_GetsShapeByIndex_ReturnsShape(int a)
        {
            var box = new Box();
            box.Shapes[0] = new Circle(new Film(), 2);
            box.Shapes[1] = new Triangle(new Film(), 7);
            box.Shapes[2] = new Square(new Film(), 2);
            box.Shapes[3] = new Circle(new Film(), 2);
            var res = box.GetByIndex(a);
            var expectedRes = new Triangle(new Film(), 7);

            Assert.AreEqual(res, expectedRes);
        }

        [TestCase(2)]
        public void Search_DeleteByIndex(int a)
        {
            var box = new Box();
            box.Shapes[0] = new Circle(new Film(), 2);
            box.Shapes[1] = new Triangle(new Film(), 7);
            box.Shapes[2] = new Square(new Film(), 2);
            box.Shapes[3] = new Circle(new Film(), 2);
            box.Extract(a);
            string expectedRes = null;

            Assert.AreEqual(box.Shapes[2], expectedRes);
        }

        [TestCase(3)]
        public void Search_ReplaceByIndex(int a)
        {
            var box = new Box();
            var shape = new Triangle(new Paper(Color.Blue), 7);
            box.Shapes[0] = new Circle(new Film(), 2);
            box.Shapes[1] = new Triangle(new Film(), 7);
            box.Shapes[2] = new Square(new Film(), 2);
            box.Shapes[3] = new Circle(new Film(), 2);
            box.Change(shape, a);
            var expectedRes = shape;

            Assert.AreEqual(box.Shapes[3], expectedRes);
        }

        [TestCase(0)]
        public void Search_Find_ReturnsIndex(int index)
        {
            var box = new Box();
            var shape = new Triangle(new Paper(Color.Blue), 7);
            box.Shapes[0] = new Triangle(new Paper(Color.Blue), 7);
            box.Shapes[1] = new Triangle(new Film(), 7);
            box.Shapes[2] = new Square(new Film(), 2);
            box.Shapes[3] = new Circle(new Film(), 2);
            
            var expectedRes = box.Find(shape); ;

            Assert.AreEqual(index, expectedRes);
        }

        [TestCase(true)]
        public void Search_IsAnyEqual_ReturnsTrueIfEqual(bool expRes)
        {
            var box = new Box();
            var shape = new Triangle(new Paper(Color.Blue), 7);
            box.Shapes[0] = new Triangle(new Paper(Color.Blue), 7);
            box.Shapes[1] = new Triangle(new Film(), 7);
            box.Shapes[2] = new Square(new Film(), 2);
            box.Shapes[3] = new Circle(new Film(), 2);

            var expectedRes = box.IsAnyEqual(shape); ;

            Assert.AreEqual(expRes, expectedRes);
        }

        [TestCase(4)]
        public void Search_GetCountOfNotEmptyElementsInMas_ReturnsQuantity(int a)
        {
            var box = new Box();
            
            box.Shapes[0] = new Circle(new Film(), 2);
            box.Shapes[1] = new Triangle(new Film(), 7);
            box.Shapes[2] = new Square(new Film(), 2);
            box.Shapes[3] = new Circle(new Film(), 2);
            int res = box.GetCount();
            var expectedRes = a;

            Assert.AreEqual(res, expectedRes);
        }

        [TestCase(50)]
        public void Search_GetsSummArea_ReturnSumm(int a)
        {
            var box = new Box();
            
            box.Shapes[0] = new Circle(new Film(), 2);
            box.Shapes[1] = new Triangle(new Film(), 7);
            box.Shapes[2] = new Square(new Film(), 2);
            box.Shapes[3] = new Circle(new Film(), 2);
            int res = (int)box.SummArea();
            var expectedRes = a;

            Assert.AreEqual(res, expectedRes);
        }

        [TestCase(54)]
        public void Search_GetsSummPerimeter_ReturnSumm(int a)
        {
            var box = new Box();

            box.Shapes[0] = new Circle(new Film(), 2);
            box.Shapes[1] = new Triangle(new Film(), 7);
            box.Shapes[2] = new Square(new Film(), 2);
            box.Shapes[3] = new Circle(new Film(), 2);
            int res = (int)box.SumPerimeter();
            var expectedRes = a;

            Assert.AreEqual(res, expectedRes);
        }

        [Test]
        public void Search_GetsAllCircles_ReturnCircles()
        {
            var box = new Box();
            var expectedRes = new List<IShape>();
            
            box.Shapes[0] = new Circle(new Film(), 2);
            box.Shapes[1] = new Triangle(new Film(), 7);
            box.Shapes[2] = new Square(new Film(), 2);
            box.Shapes[3] = new Circle(new Film(), 2);

            expectedRes.Add(box.Shapes[0]);
            expectedRes.Add(box.Shapes[3]);
            var res = box.ExtractAllCircles();
            
            Assert.AreEqual(res, expectedRes);
        }

        [Test]
        public void Search_GetsAllShapesFromFilm_ReturnShapesFromFilm()
        {
            var box = new Box();
            var expectedRes = new List<IShape>();

            box.Shapes[0] = new Circle(new Film(), 2);
            box.Shapes[1] = new Triangle(new Paper(), 7);
            box.Shapes[2] = new Square(new Film(), 2);
            box.Shapes[3] = new Circle(new Paper(), 2);

            expectedRes.Add(box.Shapes[0]);
            expectedRes.Add(box.Shapes[2]);
            var res = box.ExtractAllFilmShapes();

            Assert.AreEqual(res, expectedRes);
        }

        [Test]
        public void Search_GetsAllShapesFromPaper_ReturnShapesFromPaper()
        {
            var box = new Box();
            var expectedRes = new List<IShape>();

            box.Shapes[0] = new Circle(new Film(), 2);
            box.Shapes[1] = new Triangle(new Paper(), 7);
            box.Shapes[2] = new Square(new Film(), 2);
            box.Shapes[3] = new Circle(new Paper(), 2);

            expectedRes.Add(box.Shapes[1]);
            expectedRes.Add(box.Shapes[3]);
            var res = box.ExtractAllPaperShapes();

            Assert.AreEqual(res, expectedRes);
        }
        
    }
}