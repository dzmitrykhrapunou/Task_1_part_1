using System;

namespace Task2Part3DzmitryKhrapunou
{
    class Program
    {
        static void Main(string[] args)
        {
            var product1 = new Product(ProductType.Water, "Bonaqua", 2);
            var product2 = new Product(ProductType.Cake, "Napoleon", 2.56);
            var product3 = new Product(ProductType.Eggs, "Brest", 3);
            var product4 = new Product(ProductType.Eggs, "Gomel", 2.5);

            var res = (int)product2;
            var summ = product3 + product4;          

            Console.Write(product1.Type + " to ");

            product1.ChangeType(ProductType.Wine);

            Console.WriteLine(product1.Type);
            Console.WriteLine(res);
            Console.WriteLine(product2.Cost);
            Console.WriteLine(summ);

            Console.ReadLine();
        }      
    }
}
