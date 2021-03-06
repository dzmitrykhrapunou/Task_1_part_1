﻿using System;
using Task_1_part_2.Entities;

namespace Task_1_part_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape[] shapes = FileReader.ReadTxt();

            var circle = new Circle(5);
            OutputMethod(shapes, circle, String.Format("The list of circles with radius = {0}:", circle.radius));

            var triangle = new Triangle(2, 5, 5);
            OutputMethod(shapes, triangle, String.Format("The list of triangles with sides:{0}, {1}, {2}:", triangle.side1, triangle.side2, triangle.side3));

            var rectangle = new Rectangle(5, 4);
            OutputMethod(shapes, rectangle, String.Format("The list of rectangles with length = {0}, width = {1}:", rectangle.length, rectangle.width));

            Console.ReadKey();
        }

        public static void OutputMethod(Shape[] shapesMas, Shape shape, string title)
        {
            Console.WriteLine(title);
            for (int i = 0; i < shapesMas.Length; i++)
            {
                if (shape.Equals(shapesMas[i]))
                {
                    Console.WriteLine("i = {0}, info = {1}", i, shapesMas[i].ToString());
                }
            }
        }
    }
}
