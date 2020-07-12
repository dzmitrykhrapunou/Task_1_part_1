using System;
using System.Diagnostics;
using System.Threading;

namespace Task_1_part_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Euclidean Algorithm");
            Console.WriteLine("Please enter five integers");
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

            Console.WriteLine("The greatest common factor for the first two numbers {0}, {1} is {2}", a, b, AlgorithmGCD.GCD(a, b, out long elapsedTime));
            Console.WriteLine("The greatest common factor for the first three numbers {0}, {1}, {2} is {3}", a, b, c, AlgorithmGCD.GCD(a, b, c));
            Console.WriteLine("The greatest common factor for the first four numbers {0}, {1}, {2}, {3} is {4}", a, b, c, d, AlgorithmGCD.GCD(a, b, c, d));
            Console.WriteLine("The greatest common factor for the five numbers {0}, {1}, {2}, {3}, {4} is {5}", a, b, c, d, e, AlgorithmGCD.GCD(a, b, c, d, e));
            Console.WriteLine($"The Euclidean algorithm running time for two parameters is {elapsedTime} mkSec");

            Console.WriteLine();
            Console.WriteLine("Stein's Algorithm");
            Console.WriteLine("Please enter two integers");
            Console.Write("A = ");
            int i = Convert.ToInt32(Console.ReadLine());
            Console.Write("B = ");
            int j = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("The greatest common factor for the numbers {0}, {1} is {2}", i, j, AlgorithmGCD.GCD_ByStein(i, j, out elapsedTime));
            Console.WriteLine($"Stein's algorithm running time is {elapsedTime} mkSec");

            Console.ReadKey();            
        }
    }
}
