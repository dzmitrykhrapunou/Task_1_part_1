using System;
using System.Diagnostics;

namespace Task_1_part_1
{
    /// <summary>
    /// GCD Algorithm
    /// </summary>
    public class AlgorithmGCD
    {
        /// <summary>
        /// GCD by Euclid for two numbers
        /// </summary>
        /// <param name="a">the first number</param>
        /// <param name="b">the second number</param>
        /// <param name="elapsedTime">elapsed time</param>
        /// <returns>GCD for a and b</returns>
        public static int GCD(int a, int b, out long elapsedTime1)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            a = (int)Math.Abs(a);
            b = (int)Math.Abs(b);

            if (a == 0 && b != 0)
            {
                sw.Stop();
                elapsedTime1 = sw.ElapsedTicks;
                return b;
            }
            if (b == 0 && a != 0)
            {
                sw.Stop();
                elapsedTime1 = sw.ElapsedTicks;
                return a;
            }
            if (b == 0 && a == 0)
            {
                sw.Stop();
                elapsedTime1 = sw.ElapsedTicks;
                return 0;
            }
            while (a != b)
            {
                if (a > b)
                {
                    a = a - b;
                }
                else
                {
                    b = b - a;
                }
            }
            sw.Stop();
            elapsedTime1 = sw.ElapsedTicks;
            return b;
        }

        /// <summary>
        /// GCD by Euclid for thee numbers
        /// </summary>
        /// <param name="a">the first number</param>
        /// <param name="b">the second number</param>
        /// <param name="c">the third number</param>
        /// <returns>GCD for a, b and c</returns>
        public static int GCD(int a, int b, int c)
        {
            int n = GCD(a, b, out long elapsedTime);

            c = (int)Math.Abs(c);

            if (c == 0) return n;
            if (n == 0 && c != 0) return c;

            while (n != c)
            {
                if (n > c)
                {
                    n = n - c;
                }
                else
                {
                    c = c - n;
                }
            }
            return c;
        }

        /// <summary>
        /// GCD by Euclid for four numbers
        /// </summary>
        /// <param name="a">the first number</param>
        /// <param name="b">the second number</param>
        /// <param name="c">the third number</param>
        /// <param name="d">the fourth number</param>
        /// <returns>GCD for a, b, c and d</returns>
        public static int GCD(int a, int b, int c, int d)
        {
            int n = GCD(a, b, out long elapsedTime);
            int m = GCD(c, d, out elapsedTime);

            d = (int)Math.Abs(d);

            if (n == 0 && m == 0 && d == 0) return 0;
            if (n == 0 && m == 0 && d != 0) return d;
            if (n != 0 && m == 0 && d == 0) return n;
            if (n == 0 && m != 0 && d != 0) return GCD(m, d, out elapsedTime);


            while (n != m)
            {
                if (n > m)
                {
                    n = n - m;
                }
                else
                {
                    m = m - n;
                }
            }
            return m;
        }

        /// <summary>
        /// GCD by Euclid for five numbers
        /// </summary>
        /// <param name="a">the first number</param>
        /// <param name="b">the second number</param>
        /// <param name="c">the third number</param>
        /// <param name="d">the fourth number</param>
        /// <param name="e">the fifth number</param>
        /// <returns>GCD for a, b, c, d and e</returns>
        public static int GCD(int a, int b, int c, int d, int e)
        {
            int n = GCD(a, b, out long elapsedTime);
            int m = GCD(c, d, e);

            if (n == 0 && m == 0) return 0;
            if (n != 0 && m == 0) return n;
            if (n == 0 && m != 0) return m;

            while (n != m)
            {
                if (n > m)
                {
                    n = n - m;
                }
                else
                {
                    m = m - n;
                }
            }
            return m;
        }

        /// <summary>
        /// GCD by Stein
        /// </summary>
        /// <param name="i">the first number</param>
        /// <param name="j">the second number</param>
        /// <param name="elapsedTime">elapsed time</param>
        /// <returns>GCD for i and j</returns>
        public static int GCD_ByStein(int i, int j, out long elapsedTime2)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            if (i == 0)
            {
                sw.Stop();
                elapsedTime2 = sw.ElapsedTicks;
                return j;
            }
            if (j == 0)
            {
                sw.Stop();
                elapsedTime2 = sw.ElapsedTicks;
                return i;
            }
            if (i != 0 && j != 0)
            {
                i = (int)Math.Abs(i);
                j = (int)Math.Abs(j);

                int x = 1;

                while (i != 0 && j != 0)
                {
                    while (i % 2 == 0 && j % 2 == 0)
                    {
                        i /= 2;
                        j /= 2;
                        x *= 2;
                    }

                    if (i % 2 == 0 && j % 2 != 0)
                        while (i % 2 == 0)
                            i /= 2;

                    if (j % 2 == 0 && i % 2 != 0)
                        while (j % 2 == 0)
                            j /= 2;

                    if (i >= j)
                        i -= j;
                    else
                        j -= i;
                }
                sw.Stop();
                elapsedTime2 = sw.ElapsedTicks;
                return j * x;
            }
            else
                sw.Stop();
            elapsedTime2 = sw.ElapsedTicks;
            return 0;
        }
        /// <summary>
        /// The method that compares the running time of two algorithms
        /// </summary>
        /// <param name="time1">Euclid's algorithm running time</param>
        /// <param name="time2">Stein's algorithm running time</param>
        /// <param name="difference">time difference</param>
        public static void ElapsedTimeForTwoMetods()
        {
            int[,] numbers = new int[3,2] { { 0, 1 }, { 2, 3 }, { 4, 5 } };
            long[,] timeResult = new long[3, 3];                       
            
            for (int r = 0, w = 0, i = 0, j = 0; w < 3; w++, i++, r++)
            {
                 int a = numbers[i, j];
                 int b = numbers[i, j + 1];
                 long difference = 0;

                 AlgorithmGCD.GCD(a, b, out long elapsedTime1);
                 long time1 = elapsedTime1;
                 AlgorithmGCD.GCD_ByStein(a, b, out long elapsedTime2);
                 long time2 = elapsedTime2;

                 if (time1 > time2)
                     difference = time1 - time2;
                 else
                     difference = time2 - time1;

                 timeResult[0, w] = time1;
                 timeResult[1, w] = time2;
                 timeResult[2, w] = difference;
            }

            int rows = timeResult.GetUpperBound(0) + 1;
            int columns = timeResult.Length / rows;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{timeResult[i, j]} mkSek \t");
                }
                Console.WriteLine();
                Console.WriteLine();
            }                
        }       
    }
}
