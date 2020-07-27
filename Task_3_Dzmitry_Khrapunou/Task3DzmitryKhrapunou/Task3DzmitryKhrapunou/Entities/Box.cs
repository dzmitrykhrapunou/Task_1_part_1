using System;
using System.Collections.Generic;
using Task3DzmitryKhrapunou.Interfaces;

namespace Task3DzmitryKhrapunou.Entities
{
    /// <summary>
    /// class Box
    /// </summary>
    public class Box
    {
        /// <summary>
        /// Shapes
        /// </summary>
        public IShape[] Shapes { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Box()
        {
            Shapes = new IShape[20];
        }

        /// <summary>
        /// Gets Free index in mas
        /// </summary>
        /// <returns>Index of empty element</returns>
        public int? GetFree()
        {
            int? indexOfEmpty = null;
            for (int i = 0; i < Shapes.Length; i++)
            {
                if (Shapes[i] == null)
                {
                    indexOfEmpty = i;
                    break;
                }
            }

            return indexOfEmpty;
        }

        /// <summary>
        /// Returns true if there is any equal shape in mas.
        /// </summary>
        /// <param name="shape">objest to compare</param>
        /// <returns>Returns true if there is any equal shape in mas.</returns>
        public bool IsAnyEqual(IShape shape)
        {
            var isAnyEqual = false;
            for (int i = 0; i < Shapes.Length; i++)
            {
                if (Shapes[i].Equals(shape))
                {
                    isAnyEqual = true;
                    break;
                }
            }

            return isAnyEqual;
        }

        /// <summary>
        /// Adds a new shape to mas
        /// </summary>
        /// <param name="shape">object to add</param>
        public void Add(IShape shape)
        {
            int? indexOfEmpty = GetFree();
            if (indexOfEmpty == null)
            {
                throw new Exception("There is no free place in the box");
            }
            else
            {
                if (IsAnyEqual(shape) == true)
                    throw new Exception("This shape is already exist in the box");

                Shapes[(int)indexOfEmpty] = shape;
            }
        }

        /// <summary>
        /// Gets shape by index
        /// </summary>
        /// <param name="index">index in mas</param>
        /// <returns>shape by index</returns>
        public IShape GetByIndex(int index)
        {
            var shape = Shapes[index - 1];

            return shape;
        }

        /// <summary>
        /// Delete by index
        /// </summary>
        /// <param name="index">index in mas</param>
        public void Extract(int index)
        {
            Shapes[index] = null;
        }

        /// <summary>
        /// Replace by index
        /// </summary>
        /// <param name="shape">object to replace</param>
        /// <param name="index">index in mas</param>
        public void Change(IShape shape, int index)
        {
            Shapes[index] = shape;
        }

        /// <summary>
        /// Find
        /// </summary>
        /// <param name="shape">object to find</param>
        /// <returns>index in mas</returns>
        public int? Find(IShape shape)
        {
            int? index = null;
            for (int i = 0; i < Shapes.Length; i++)
            {
                if (Shapes[i].Equals(shape))
                {
                    index = i;
                }
                break;
            }

            return index;
        }

        /// <summary>
        /// Get count of not empty elements in mas
        /// </summary>
        /// <returns>count of not empty elements in mas</returns>
        public int GetCount()
        {
            int quantity = 0;

            for (int i = 0; i < Shapes.Length; i++)
            {
                if (Shapes[i] != null)
                    quantity++;
            }

            return quantity;
        }

        /// <summary>
        /// Gets summ area
        /// </summary>
        /// <returns>summ area</returns>
        public double SummArea()
        {
            double summ = 0;

            for (int i = 0; i < Shapes.Length; i++)
            {
                if (Shapes[i] != null)
                {
                    summ += Shapes[i].Area();
                }
            }

            return summ;
        }

        /// <summary>
        /// Gets summ Perimeter
        /// </summary>
        /// <returns>summ Perimeter</returns>
        public double SumPerimeter()
        {
            double summ = 0;

            for (int i = 0; i < Shapes.Length; i++)
            {
                if (Shapes[i] != null)
                {
                    summ += Shapes[i].Perimeter();
                }
            }

            return summ;
        }

        /// <summary>
        /// Gets all circles
        /// </summary>
        /// <returns>circles</returns>
        public List<IShape> ExtractAllCircles()
        {
            var circles = new List<IShape>();
            for (int i = 0; i < Shapes.Length; i++)
            {
                if (Shapes[i] is Circle)
                {
                    circles.Add(Shapes[i]);
                }
            }

            return circles;
        }

        /// <summary>
        /// Gets all Shapes from Film
        /// </summary>
        /// <returns>Shapes from Film</returns>
        public List<IShape> ExtractAllFilmShapes()
        {
            var list = new List<IShape>();
            for (int i = 0; i < Shapes.Length; i++)
            {
                if (Shapes[i] != null && Shapes[i].Material.GetType() == typeof(Film))
                {
                    list.Add(Shapes[i]);
                }
            }

            return list;
        }

        /// <summary>
        /// Gets all Shapes from Paper
        /// </summary>
        /// <returns>Shapes from Paper</returns>
        public List<IShape> ExtractAllPaperShapes()
        {
            var list = new List<IShape>();
            for (int i = 0; i < Shapes.Length; i++)
            {
                if (Shapes[i] != null && Shapes[i].Material.GetType() == typeof(Paper))
                {
                    list.Add(Shapes[i]);
                }
            }

            return list;
        }
    }
}
