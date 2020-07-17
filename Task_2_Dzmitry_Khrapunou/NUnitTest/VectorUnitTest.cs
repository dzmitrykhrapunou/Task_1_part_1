using NUnit.Framework;
using System;
using Task_2_Part_1_Dzmitry_Khrapunou;

namespace NUnitTest
{
    [TestFixture]
    public class VectorUnitTests
    {
        [TestCase(5, 6, 7, 6, 9, 8)]
        public void SummationTwoVectors_ReturnsNewVector(int x1, int y1, int z1, int x2, int y2, int z2)
        {
            var v1 = new Vector(x1, y1, z1);
            var v2 = new Vector(x2, y2, z2);

            var expectedRes = new Vector(x1+x2, y1+y2, z1+z2);
            var res = v1 + v2;

            Assert.AreEqual(expectedRes, res);
        }

        [TestCase(5, 6, 7, 6, 9, 8)]
        public void SubtractionTwoVectors_ReturnsNewVector(int x1, int y1, int z1, int x2, int y2, int z2)
        {
            var v1 = new Vector(x1, y1, z1);
            var v2 = new Vector(x2, y2, z2);

            var expectedRes = new Vector(x1 - x2, y1 - y2, z1 - z2);
            var res = v1 - v2;

            Assert.AreEqual(expectedRes, res);
        }

        [TestCase(5, 6, 7, 6)]
        public void ScalarMultiplication_ReturnsNewVector(int x1, int y1, int z1, int scalar)
        {
            var v1 = new Vector(x1, y1, z1);
            
            var expectedRes = new Vector(x1 * scalar, y1 * scalar, z1 * scalar);
            var res = v1 * scalar;

            Assert.AreEqual(expectedRes, res);
        }

        [TestCase(5, 6, 7, 6, 9, 8)]
        public void Scalar—ompositionTwoVectors_ReturnsScalar—omposition(int x1, int y1, int z1, int x2, int y2, int z2)
        {
            var v1 = new Vector(x1, y1, z1);
            var v2 = new Vector(x2, y2, z2);

            var expectedRes = x1 * x2 + y1 * y2 + z1 * z2;
            var res = Vector.Scalar—omposition(v1, v2);
            
            Assert.AreEqual(expectedRes, res);
        }

        [TestCase(5, 6, 7, 6, 9, 8)]
        public void Vector—ompositionTwoVectors_ReturnsScalar—omposition(int x1, int y1, int z1, int x2, int y2, int z2)
        {
            var v1 = new Vector(x1, y1, z1);
            var v2 = new Vector(x2, y2, z2);

            var expectedRes = (y1 * z2 - z1 * y2) + (z1 * x2 - x1 * z2) + (x1 * y2 - y1 * x2);
            var res = Vector.Vector—omposition(v1, v2);

            Assert.AreEqual(expectedRes, res);
        }

        [TestCase(5, 6, 7)]
        public void ModulVector_ReturnsModulVector(int x1, int y1, int z1)
        {
            var v1 = new Vector(x1, y1, z1);

            var expectedRes = Math.Sqrt(x1 * x1 + y1 * y1 + z1 * z1);
            var res = Vector.ModulVector(v1);

            Assert.AreEqual(expectedRes, res);
        }


    }
}