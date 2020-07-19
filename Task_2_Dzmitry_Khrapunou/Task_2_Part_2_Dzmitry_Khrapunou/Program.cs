using System;

namespace Task_2_Part_2_Dzmitry_Khrapunou
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] kof1 = { -24, -14, 19 };
            var pol1 = new Polynomial(kof1, 2);

            int[] kof2 = { -9, -15, 17 };
            var pol2 = new Polynomial(kof2, 2);

            var sumPolynomials = pol1 + pol2;
            var substraction = pol1 - pol2;
            var multiplicationByNum1 = pol1 * 4;
            var multiplicationByNum2 = pol2 * 6;
            var polynomialСomposition = pol1 * pol2;

            Console.WriteLine("First Polynomial: " + pol1);
            Console.WriteLine("Second Polynomial: " + pol2);
            Console.WriteLine("Sum of Polynomials: " + sumPolynomials);
            Console.WriteLine("Substraction of Polynomials: " + substraction);
            Console.WriteLine("The first polynomial multiplied by 4: " + multiplicationByNum1);
            Console.WriteLine("The second polynomial multiplied by 6: " + multiplicationByNum2);
            Console.WriteLine("Composition of two Polynomials: " + polynomialСomposition);            
                      
            Console.ReadLine();
        }
    }
}
