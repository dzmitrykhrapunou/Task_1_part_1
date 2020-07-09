using System;

namespace Task_1_part_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите два числа");
            Console.Write("A = ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("B = ");
            int b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Наибольший общий делитель чисел {0} и {1} равен {2}", a, b, Class1.NOD(a, b));

            Console.ReadKey();
        }
    }
}
