using NUnit.Framework;
using Task_1_part_1;

namespace NUnitTest
{
    /// <summary>
    /// NUnit tests
    /// </summary>
    [TestFixture]
    public class GcdUnitTests
    {
        [TestCase(36, -12, 12)]
        [TestCase(150, 250, 50)]
        [TestCase(10, -10, 10)]
        [TestCase(1, 0, 1)]
        [TestCase(0, 0, 0)]
        public void GCD_FirstNumberIsGreaterThenSecond_ReturnsGCD(int a, int b, int expectedResult)
        {
            long time;
            int gcd = AlgorithmGCD.GCD(a, b, out time);
            Assert.AreEqual(expectedResult, gcd);
        }

        [TestCase(36, 12, 24, 12)]
        [TestCase(125, 500, 250, 125)]
        [TestCase(1, 0, 0, 1)]
        public void GCD_ThreeParametres_ReturnsGCD(int a, int b, int c, int expectedResult)
        {
            int gcd = AlgorithmGCD.GCD(a, b, c);
            Assert.AreEqual(expectedResult, gcd);
        }

        [TestCase(6, 18, -12, 24, 6)]
        [TestCase(15, 30, -45, 60, 15)]
        [TestCase(100, -50, 25, 175, 25)]
        public void GCD_FourParametres_ReturnsGCD(int a, int b, int c, int d, int expectedResult)
        {
            int gcd = AlgorithmGCD.GCD(a, b, c, d);
            Assert.AreEqual(expectedResult, gcd);
        }

        [TestCase(6, 18, -12, 24, 30, 6)]
        [TestCase(15, 30, -45, 60, 75, 15)]
        [TestCase(100, -50, 25, 175, 250, 25)]
        public void GCD_FiveParametres_ReturnsGCD(int a, int b, int c, int d, int e, int expectedResult)
        {
            int gcd = AlgorithmGCD.GCD(a, b, c, d, e);
            Assert.AreEqual(expectedResult, gcd);
        }

        [TestCase(36, -12, 12)]
        [TestCase(150, 250, 50)]
        [TestCase(10, -10, 10)]
        [TestCase(1, 0, 1)]
        [TestCase(0, 0, 0)]
        public void GCD_ByStein_FirstNumberIsGreaterThenSecond_ReturnsGCD(int a, int b, int expectedResult)
        {
            long time;
            int gcd = AlgorithmGCD.GCD_ByStein(a, b, out time);
            Assert.AreEqual(expectedResult, gcd);
        }
    }
}