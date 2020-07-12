using System;

namespace Task_1_part_2
{
    /// <summary>
    /// Triangle
    /// </summary>
    public class Triangle: Shape
    {
        public int side1 { get; }
        public int side2 { get; }
        public int side3 { get; }

        /// <summary>
        /// Constructor for Triangle
        /// </summary>
        /// <param name="side1">side1</param>
        /// <param name="side2">side2</param>
        /// <param name="side3">side3</param>
        public Triangle (int side1, int side2, int side3)
        {
            this.side1 = side1;
            this.side2 = side2;
            this.side3 = side3;
        }
        /// <summary>
        /// Area of Triangle
        /// </summary>
        /// <returns>Area value</returns>
        public override double Area()
        {
            var partPerimeter = Perimeter() / 2;
            
            return Math.Sqrt(partPerimeter * (partPerimeter - side1) * (partPerimeter - side2) * (partPerimeter - side3));
        }

        /// <summary>
        /// Perimeter of Triangle
        /// </summary>
        /// <returns>Perimeter value</returns>
        public override double Perimeter()
        {
            return side1 + side2 + side3;
        }

        /// <summary>
        /// Redefinition of ToString method
        /// </summary>
        /// <returns>Triangle info</returns>
        public override string ToString()
        {
            return String.Format("This is a triangle with sides:{0}, {1}, {2}", side1, side2, side3);
        }

        /// <summary>
        /// Redefinition of GetHashCode method
        /// </summary>
        /// <returns>HashCode</returns>
        public override int GetHashCode()
        {
            return side1 + side2 + side3;
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
                var comparedTriangle = (Triangle)obj;
                return (side1 == comparedTriangle.side1) && (side2 == comparedTriangle.side2) && (side3 == comparedTriangle.side3);
            }
        }
    }
}

