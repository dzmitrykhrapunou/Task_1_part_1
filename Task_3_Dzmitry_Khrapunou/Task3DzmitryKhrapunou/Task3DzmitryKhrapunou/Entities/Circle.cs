using System;
using Task3DzmitryKhrapunou.Interfaces;

namespace Task3DzmitryKhrapunou.Entities
{
    public class Circle : IShape
    {
        /// <summary>
        /// const PI
        /// </summary>
        const double Pi = 3.14;

        /// <summary>
        /// const LIMIT
        /// </summary>
        const double LIMIT = 1;

        public double Radius { get; }

        public IMaterial Material { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="radius">radius</param>
        public Circle(IMaterial material, int radius)
        {
            Material = material;
            Radius = radius;
        }  
        
        /// <summary>
        /// Cut circle from triangle
        /// </summary>
        /// <param name="triangle"></param>
        public Circle(Triangle triangle)
        {
            this.Material = triangle.Material;
            Radius = ((triangle.Side * Math.Sqrt(3)) / 6);
            if (Radius < LIMIT / 2)
            {
                throw new Exception("This shape can't be cut out");
            }
        }

        /// <summary>
        /// Cut circle from square
        /// </summary>
        /// <param name="square"></param>        
        public Circle(Square square)
        {
            this.Material = square.Material;
            Radius = square.Side * 2;
            if (Radius < LIMIT / 2)
            {
                throw new Exception("This shape can't be cut out");
            }
        }

        /// <summary>
        /// Area of Circle
        /// </summary>
        /// <returns>Area value</returns>
        public double Area()
        {
            return Pi * Math.Pow(Radius, 2);
        }

        /// <summary>
        /// Perimeter of Circle
        /// </summary>
        /// <returns>Perimeter value</returns>
        public double Perimeter()
        {
            return Pi * Radius * 2;
        }

        /// <summary>
        /// Redefinition of ToString method
        /// </summary>
        /// <returns>Circle info</returns>
        public override string ToString()
        {
            dynamic currentMaterial = Convert.ChangeType(this.Material, this.Material.GetType());
            return String.Format("This is a circle with: radius={0}, material={1}, color={2}", Radius, this.Material.GetType().Name, currentMaterial.Color);
        }

        /// <summary>
        /// Redefinition of GetHashCode method
        /// </summary>
        /// <returns>HashCode</returns>
        public override int GetHashCode()
        {
            return Radius.GetHashCode();
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
                Type currentMaterialType = this.Material.GetType();
                dynamic currentMaterial = Convert.ChangeType(this.Material, currentMaterialType);

                Type comparedMaterialType = comparedCircle.Material.GetType();
                dynamic comparedMaterial = Convert.ChangeType(comparedCircle.Material, currentMaterialType);

                return Radius == comparedCircle.Radius
                    && currentMaterialType == comparedMaterialType
                    && currentMaterial.Color == comparedMaterial.Color;
            }
        }      
    }
}
