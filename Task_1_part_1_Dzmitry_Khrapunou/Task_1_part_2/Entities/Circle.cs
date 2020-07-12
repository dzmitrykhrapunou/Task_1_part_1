using System;

namespace Task_1_part_2
{
    public class Circle : Shape
    {
        /// <summary>
        /// const PI
        /// </summary>
        const double Pi = 3.14;
        public int radius { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="radius">radius</param>
        public Circle(int radius)
        {
            this.radius = radius;
        }

        /// <summary>
        /// Area of Circle
        /// </summary>
        /// <returns>Area value</returns>
        public override double Area()
        {
            return Pi * Math.Pow(radius, 2);
        }

        /// <summary>
        /// Perimeter of Circle
        /// </summary>
        /// <returns>Perimeter value</returns>
        public override double Perimeter()
        {
            return Pi * radius * 2;
        }

        /// <summary>
        /// Redefinition of ToString method
        /// </summary>
        /// <returns>Circle info</returns>
        public override string ToString()
        {
            return String.Format("This is a circle with radius={0}", radius);
        }

        /// <summary>
        /// Redefinition of GetHashCode method
        /// </summary>
        /// <returns>HashCode</returns>
        public override int GetHashCode()
        {
            return radius.GetHashCode();
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
                var comparedCircle = (Circle)obj;
                return radius == comparedCircle.radius;
            }
        }
    }
}
