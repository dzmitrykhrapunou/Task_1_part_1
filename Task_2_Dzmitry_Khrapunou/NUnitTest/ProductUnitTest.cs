using NUnit.Framework;
using Task2Part3DzmitryKhrapunou;
using Task2Part3DzmitryKhrapunou.Entities;

namespace NUnitTest
{
    [TestFixture]
    class ProductUnitTest
    {
        [Test]
        public void SummationOfTwoProducts_ReturnsNewProduct()
        {
            var product1 = new Product(new Food("Milk"), new ProductName("Savushkin"), new Cost(4.45));
            var product2 = new Product(new Food("Milk"), new ProductName("Milkavita"), new Cost(3.47));

            var res = product1 + product2;            
            var newCost = (product1.Cost.CostValue + product2.Cost.CostValue) / 2;
            var expectedRes = new Product(product1.Type, new ProductName(product1.Name.Name + " - " + product2.Name.Name), new Cost(newCost));

            Assert.AreEqual(expectedRes, res);
        }

        [Test]
        public void ChangeProductType_ReturnsNewProduct()
        {
            var type = new Food("Milk");
            var res = (Clothes)type;
            var expectedRes = new Clothes("Milk");      

            Assert.AreEqual(expectedRes, res);
        }

        [Test]
        public void CostProductTransformation_ReturnsNewCost()
        {            
            var product1 = new Product(new Food("Milk"), new ProductName("Savushkin"), new Cost(4.45));
            var expectedRes = 445;
            var res = (int)product1;

            Assert.AreEqual(expectedRes, res);
        }

        [Test]
        public void ComparisonOfTwoProducts_ReturnsEquals()
        {
            var product1 = new Product(new Food("Milk"), new ProductName("Savushkin"), new Cost(4.45));
            var product2 = new Product(new Food("Milk"), new ProductName("Savushkin"), new Cost(4.45));
            bool expectedRes = true;
            bool res = product1.Equals(product2);

            Assert.AreEqual(expectedRes, res);
        }
    }
}
