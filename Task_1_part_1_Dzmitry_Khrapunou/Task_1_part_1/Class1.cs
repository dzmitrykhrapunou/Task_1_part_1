using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1_part_1
{
    public class Class1
    {
        public static int NOD(int a, int b)
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
    }
}
