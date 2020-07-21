using NUnit.Framework;
using Task2Part3DzmitryKhrapunou;

namespace NUnitTest
{
    [TestFixture]
    class ProductUnitTest
    {
        [TestCase(3, "Savushkin", 4.45, 3, "Slavita", 3.47)]
        public void SummationOfTwoProducts_ReturnsNewProduct(int x1, string name1, double cost1, int x2, string name2, double cost2)
        {
            ProductType type1 = (ProductType)x1;
            ProductType type2 = (ProductType)x2;

            var product1 = new Product(type1, name1, cost1);
            var product2 = new Product(type2, name2, cost2);

            var expectedRes = product1 + product2;
            var res = new Product(type2, name1 + " - " + name2, (cost1 + cost2)/2);

            Assert.AreEqual(expectedRes, res);
        }
        
         [TestCase(0, "Savushkin", 4.45, 1)]
        public void ChangeProductType_ReturnsNewProduct(int x1, string name1, double cost1, int x2)
        {
            ProductType type1 = (ProductType)x1;
            ProductType type2 = (ProductType)x2;

            var product1 = new Product(type1, name1, cost1);            
            var expectedRes = new Product(type2, name1, cost1);
            var res = product1.ChangeType(type2);
            
            Assert.AreEqual(expectedRes, res);
        }

        [TestCase(0, "Savushkin", 4.45, 445)]
        public void CostProductTransformation_ReturnsNewCost(int x1, string name1, double cost1, int cost2)
        {
            ProductType type1 = (ProductType)x1;
            
            var product1 = new Product(type1, name1, cost1);
            var expectedRes = cost2;
            var res = (int)product1;

            Assert.AreEqual(expectedRes, res);
        }
    }
}
