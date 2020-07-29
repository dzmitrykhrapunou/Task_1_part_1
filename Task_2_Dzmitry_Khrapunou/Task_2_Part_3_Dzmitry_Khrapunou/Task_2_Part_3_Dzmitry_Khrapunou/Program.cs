using System;
using Task2Part3DzmitryKhrapunou.Entities;

namespace Task2Part3DzmitryKhrapunou
{
    class Program
    {
        static void Main(string[] args)
        {
            var product1 = new Product(new Food("Milk"), new ProductName("Savushkin"), new Cost(4.45));
            var product2 = new Product(new Food("Milk"), new ProductName("Milkavita"), new Cost(3.47));
            var product3 = new Product(new Food("Milk"), new ProductName("Savushkin"), new Cost(4.45));
            
            var res = (int)product1;
            var summ = product2 + product3;

            var type = new Food("Milk");
            var newType = (Clothes)type;

            Console.WriteLine(newType.GetType().Name);     
            Console.WriteLine(res);       
            Console.WriteLine(summ.ToString());

            Console.ReadLine();
        }      
    }
}
