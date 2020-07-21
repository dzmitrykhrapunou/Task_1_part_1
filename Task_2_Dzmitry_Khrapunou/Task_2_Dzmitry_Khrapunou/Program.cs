using System;

namespace Task2Part1DzmitryKhrapunou
{
    class Program
    {
        static void Main(string[] args)
        {
            var v0 = new Vector(4, 7, -5);
            var v1 = new Vector(6, -4, 8);
            var sumVectors = v0 + v1;
            var substraction = v0 - v1;
            var scalarСomposition1 = v0 * 5;
            var scalarСomposition2 = v1 * 10;
            var vectorСomposition = Vector.VectorСomposition(v0, v1);
                        
            double modulVector1 = Vector.ModulVector(v0);
            double modulVector2 = Vector.ModulVector(v1);
            int scalarСomposition = Vector.ScalarСomposition(v0, v1);

            Console.WriteLine("First vector: " + v0);
            Console.WriteLine("Second vector: " + v1);
            Console.WriteLine("Sum of vectors: " + sumVectors);
            Console.WriteLine("Substraction of vectors: " + substraction);
            Console.WriteLine("The first vector multiplied by 5: " + scalarСomposition1);
            Console.WriteLine("The second vector multiplied by 10: " + scalarСomposition2);
            Console.WriteLine("Scalar composition of vectors: " + scalarСomposition);
            Console.WriteLine("Vector composition of vectors: " + vectorСomposition);
            Console.WriteLine("Module of the first vector: " + modulVector1);
            Console.WriteLine("Module of the second vector: " + modulVector2);

            Console.ReadKey();
        }
    }
}
