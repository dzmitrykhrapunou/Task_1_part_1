using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Task_1_part_1
{
    public class AlgorithmGCD
    {
        public static int GCD(int a, int b, out long elapsedTime)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            a = (int)Math.Abs(a);
            b = (int)Math.Abs(b);

            if (a == 0 && b != 0)
            {
                sw.Stop();
                elapsedTime = sw.ElapsedTicks;
                return b; 
            }
            if (b == 0 && a != 0)
            {
                sw.Stop();
                elapsedTime = sw.ElapsedTicks;
                return a;
            }
            if (b == 0 && a == 0)
            {
                sw.Stop();
                elapsedTime = sw.ElapsedTicks;
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
            elapsedTime = sw.ElapsedTicks;
            return b;
        }
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
    
        public static int GCD_byStein(int i, int j, out long elapsedTime)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            if (i == 0)
            {
                sw.Stop();
                elapsedTime = sw.ElapsedTicks; 
                return j;
            }
            if (j == 0)
            {
                sw.Stop();
                elapsedTime = sw.ElapsedTicks;
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
                elapsedTime = sw.ElapsedTicks;
                return j * x;
            }
            else
            sw.Stop();
            elapsedTime = sw.ElapsedTicks;
            return 0;
        }
    }
}
