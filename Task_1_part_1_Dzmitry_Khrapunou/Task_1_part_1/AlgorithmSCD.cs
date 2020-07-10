using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1_part_1
{
    public class AlgorithmGCD
    {
        public static int GCD(int a, int b)
        {
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
    }
}
