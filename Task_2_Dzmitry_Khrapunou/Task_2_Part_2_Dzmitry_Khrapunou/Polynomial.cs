using System;
using System.Linq;

namespace Task_2_Part_2_Dzmitry_Khrapunou
{
    public class Polynomial
    {
        /// <summary>
        /// Massive of coefficients
        /// </summary>
        int[] coefficient { get; }

        /// <summary>
        /// Power of polynomial
        /// </summary>
        int power { get; }

        public Polynomial(int[] coefficient, int power)
        {
            this.coefficient = coefficient;
            this.power = power;
        }

        /// <summary>
        /// summation of two polynomials
        /// </summary>
        /// <param first polynomial="a"></param>
        /// <param second polynomial="b"></param>
        /// <returns>new polynomial</returns>
        public static Polynomial operator +(Polynomial a, Polynomial b)
        {            
            int[] coefs = new int[a.power + 1];
            Polynomial c = new Polynomial(coefs, a.power);
            for (int i = 0; i < a.power + 1; i++)
            {
                c.coefficient[i] = a.coefficient[i] + b.coefficient[i];
            }

            return c;
        }

        /// <summary>
        /// subtraction of two polynomials
        /// </summary>
        /// <param first polynomial="a"></param>
        /// <param second polynomial="b"></param>
        /// <returns>new polynomial</returns>
        public static Polynomial operator -(Polynomial a, Polynomial b)
        {
            int[] coefs = new int[a.power + 1];
            Polynomial c = new Polynomial(coefs, a.power);
            for (int i = 0; i < a.power + 1; i++)
            {
                c.coefficient[i] = a.coefficient[i] - b.coefficient[i];
            }

            return c;
        }

        /// <summary>
        /// multiplication of two polynomials
        /// </summary>
        /// <param first polynomial="a"></param>
        /// <param second polynomial="b"></param>
        /// <returns>new polynomial</returns>
        public static Polynomial operator *(Polynomial a, Polynomial b)
        {
            int[] coefs = new int[a.power + 1];
            Polynomial c = new Polynomial(coefs, a.power);
            for (int i = 0; i < a.power + 1; i++)
            {
                c.coefficient[i] = a.coefficient[i] * b.coefficient[i];
            }

            return c;
        }

        /// <summary>
        /// multiplication polynomial by a number
        /// </summary>
        /// <param polynomial="a"></param>
        /// <param number for multiplication="num"></param>
        /// <returns>new polynomial</returns>
        public static Polynomial operator *(Polynomial a, int num)
        {
            int[] coefs = new int[a.power + 1];
            Polynomial c = new Polynomial(coefs, a.power);
            for (int i = 0; i < a.power + 1; i++)
            {
                c.coefficient[i] = a.coefficient[i] * num;
            }

            return c;
        }

        /// <summary>
        /// overriding of ToString metod.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {            
            var str = String.Format(coefficient[0] + "x^" + power);

            for (int i = 1; i <= power; i++)
            {
                if (coefficient[i] > 0) str += String.Format("+" + coefficient[i] + "x^" + (power - i));
                else str += String.Format(coefficient[i] + "x^" + (power - i));
            }

            return str;
        }

        /// <summary>
        /// Redefinition of Equals method
        /// </summary>
        /// <param name="obj">object to compare with</param>
        /// <returns>true when objects are equal</returns>
        public override bool Equals(object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                var comparedPolynomial = (Polynomial)obj;                
                return coefficient.SequenceEqual(comparedPolynomial.coefficient) && (power == comparedPolynomial.power);
            }
        }

        /// <summary>
        /// Redefinition of GetHashCode method
        /// </summary>
        /// <returns>HashCode</returns>
        public override int GetHashCode()
        {
            int hash = 0;

            for (int i = 0; i < coefficient.Length; i++) 
            { 
                hash += coefficient[i]; 
            }

            hash = hash * power;

            return hash;
        }
    }
}

