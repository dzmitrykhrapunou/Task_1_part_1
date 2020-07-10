using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1_part_1
{
    public class AlgorithmGCD
    {
        public static int GCD(int a, int b)
        {
            a = (int)Math.Abs(a);
            b = (int)Math.Abs(b);

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
            return b;
        }
        public static int GCD(int a, int b, int c)
        {
            int n = GCD(a, b);
        
            c = (int)Math.Abs(c);

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
        public static int GCD(int a, int b, int c, int d)
        {
            int n = GCD(a, b);
            int m = GCD(c, d);

            d = (int)Math.Abs(d);

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
        public static int GCD(int a, int b, int c, int d, int e)
        {
            int n = GCD(a, b);
            int m = GCD(c, d, e);

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

            //int min;
            //if (a > b) min = b;
            //else min = a;
            //int i = min;
            //int c = 0;
            //while (i > 0 && c == 0)
            //{
            //    if ((a % i == 0) && (b % i == 0))
            //        c = i;
            //    i--;
            //}
            //Console.WriteLine(c);

            static int GCD_byStein(int i, int j)
        {
            if (i == 0) return j;
            if (j == 0) return i;
            if (i == j) return i;
            if (i == 1 || j == 1) return 1;
            if ((i % 2 == 0) && (j % 2 == 0)) return 2 * GCD_byStein(i / 2, j / 2);
            if ((i % 2 == 0) && (j % 2 != 0)) return GCD_byStein(i / 2, j);
            if ((i % 2 != 0) && (j % 2 == 0)) return GCD_byStein(i, j / 2);
            return GCD_byStein(j, (int)Math.Abs(i - j));
        }

    }
}
