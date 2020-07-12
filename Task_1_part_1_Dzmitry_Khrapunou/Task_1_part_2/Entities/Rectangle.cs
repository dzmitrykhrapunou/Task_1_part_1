using System;

namespace Task_1_part_2
{
    /// <summary>
    /// Rectangle
    /// </summary>
    public class Rectangle: Shape
    {
        public int length { get; }

        public int width { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="length">radius</param>
        /// <param name="width">radius</param>
        public Rectangle(int length, int width)
        {
            this.length = length;
            this.width = width;
        }

        /// <summary>
        /// Area of Rectangle
        /// </summary>
        /// <returns>Area value</returns>
        public override double Area()
        {
            return length * width;
        }

        /// <summary>
        /// Perimeter of Rectangle
        /// </summary>
        /// <returns>Perimeter value</returns>
        public override double Perimeter()
        {
            return (length + width) *2;
        }

        /// <summary>
        /// Redefinition of ToString method
        /// </summary>
        /// <returns>Triangle info</returns>
        public override string ToString()
        {
            return String.Format("This is a rectangle with length={0}, width={1}", length, width);
        }

        /// <summary>
        /// Redefinition of GetHashCode method
        /// </summary>
        /// <returns>HashCode</returns>
        public override int GetHashCode()
        {
            return length + width;
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
                var comparedRectangle = (Rectangle)obj;
                return (length == comparedRectangle.length) && (width == comparedRectangle.width);
            }
        }
    }
}
