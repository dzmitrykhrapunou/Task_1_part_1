using System;

namespace Task_2_Part_1_Dzmitry_Khrapunou
{
    class Program
    {
        static void Main(string[] args)
        {
            var v0 = new Vector(4, 7, -5);
            var v1 = new Vector(6, -4, 8);
            var SumVectors = v0 + v1;
            var Substraction = v0 - v1;
            var ScalarСomposition1 = v0 * 5;
            var ScalarСomposition2 = v1 * 10;
            var VectorСomposition = Vector.VectorСomposition(v0, v1);
                        
            double ModulVector1 = Vector.ModulVector(v0);
            double ModulVector2 = Vector.ModulVector(v1);
            int ScalarСomposition = Vector.ScalarСomposition(v0, v1);

            Console.WriteLine("First vector: " + v0);
            Console.WriteLine("Second vector: " + v1);
            Console.WriteLine("Sum of vectors: " + SumVectors);
            Console.WriteLine("Substraction of vectors: " + Substraction);
            Console.WriteLine("The first vector multiplied by 5: " + ScalarСomposition1);
            Console.WriteLine("The second vector multiplied by 10: " + ScalarСomposition2);
            Console.WriteLine("Scalar composition of vectors: " + ScalarСomposition);
            Console.WriteLine("Vector composition of vectors: " + VectorСomposition);
            Console.WriteLine("Module of the first vector: " + ModulVector1);
            Console.WriteLine("Module of the second vector: " + ModulVector2);

            Console.ReadKey();
        }
    }
}
