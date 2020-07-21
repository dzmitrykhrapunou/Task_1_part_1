using NUnit.Framework;
using Task2Part2DzmitryKhrapunou;

namespace NUnitTest
{
    [TestFixture]
    class PolynomialUnitTest
    {
        [TestCase(-5, 7, 12, 6, -9, 8, 2)]
        public void SummationTwoPolynomials_ReturnsNewPolynomial(int x1, int y1, int z1, int x2, int y2, int z2, int power)
        {
            int[] kof1 = { x1, y1, z1 };
            var pol1 = new Polynomial(kof1, power);

            int[] kof2 = { x2, y2, z2 };
            var pol2 = new Polynomial(kof2, power);

            int[] kof = { 1, -2, 20 };
            var expectedRes = new Polynomial(kof, power);
            var res = pol1 + pol2;

            Assert.AreEqual(expectedRes, res);
        }

        [TestCase(-5, 7, 12, 6, -9, 8, 2)]
        public void SubtractionTwoPolynomials_ReturnsNewPolynomial(int x1, int y1, int z1, int x2, int y2, int z2, int power)
        {
            int[] kof1 = { x1, y1, z1 };
            var pol1 = new Polynomial(kof1, power);

            int[] kof2 = { x2, y2, z2 };
            var pol2 = new Polynomial(kof2, power);

            int[] kof = { -11, 16, 4 };
            var expectedRes = new Polynomial(kof, power);
            var res = pol1 - pol2;

            Assert.AreEqual(expectedRes, res);
        }

        [TestCase(-5, 7, 12, 6, -9, 8, 2)]
        public void CompositionTwoPolynomials_ReturnsNewPolynomial(int x1, int y1, int z1, int x2, int y2, int z2, int power)
        {
            int[] kof1 = { x1, y1, z1 };
            var pol1 = new Polynomial(kof1, power);

            int[] kof2 = { x2, y2, z2 };
            var pol2 = new Polynomial(kof2, power);

            int[] kof = { -30, -63, 96 };
            var expectedRes = new Polynomial(kof, power);
            var res = pol1 * pol2;

            Assert.AreEqual(expectedRes, res);
        }

        [TestCase(-5, 7, 12, 2, 4)]
        public void CompositionTwoPolynomials_ReturnsNewPolynomial(int x1, int y1, int z1, int power, int num)
        {
            int[] kof1 = { x1, y1, z1 };
            var pol = new Polynomial(kof1, power);
            
            int[] kof = { -20, 28, 48 };
            var expectedRes = new Polynomial(kof, power);
            var res = pol * num;

            Assert.AreEqual(expectedRes, res);
        }
    }
}
