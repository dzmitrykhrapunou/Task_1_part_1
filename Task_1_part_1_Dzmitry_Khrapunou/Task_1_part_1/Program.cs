using System;

namespace Task_1_part_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Алгоритм Евклида");
            Console.WriteLine("Введите пять положительных чисел больших нуля");
            Console.Write("A = ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("B = ");
            int b = Convert.ToInt32(Console.ReadLine());
            Console.Write("C = ");
            int c = Convert.ToInt32(Console.ReadLine());
            Console.Write("D = ");
            int d = Convert.ToInt32(Console.ReadLine());
            Console.Write("E = ");
            int e = Convert.ToInt32(Console.ReadLine());

            if (a == 0 || b == 0 || c == 0 || d == 0 || e == 0)
            {
                Console.WriteLine("Вы ввели не корректное число");
            }
            else
            {
                Console.WriteLine("Наибольший общий делитель для первых двух чисел {0}, {1} равен {2}", a, b, AlgorithmGCD.GCD(a, b));
                Console.WriteLine("Наибольший общий делитель для первых трех чисел {0}, {1}, {2} равен {3}", a, b, c, AlgorithmGCD.GCD(a, b, c));
                Console.WriteLine("Наибольший общий делитель для первых четырех чисел {0}, {1}, {2}, {3} равен {4}", a, b, c, d, AlgorithmGCD.GCD(a, b, c, d));
                Console.WriteLine("Наибольший общий делитель для пяти чисел {0}, {1}, {2}, {3}, {4} равен {5}", a, b, c, d, e, AlgorithmGCD.GCD(a, b, c, d, e));
            }

            Console.WriteLine("Алгоритм Стейна");
            Console.WriteLine("Введите два целых числа");
            Console.Write("A = ");
            int i = Convert.ToInt32(Console.ReadLine());
            Console.Write("B = ");
            int j = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Наибольший общий делитель для первых двух чисел {0}, {1} равен {2}", i, j, AlgorithmGCD.GCD_byStein(i, j));

            Console.ReadKey();
        }
    }
}
