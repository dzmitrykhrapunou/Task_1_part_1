using System;
using Task3DzmitryKhrapunou.Interfaces;

namespace Task3DzmitryKhrapunou.Entities
{
    public class Square : IShape
    {
        /// <summary>
        /// const LIMIT
        /// </summary>
        const double LIMIT = 1;

        public double Side { get; }

        public IMaterial Material { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Side">Side</param>        
        public Square(IMaterial material, int side)
        {
            Material = material;
            Side = side;            
        }

        /// <summary>
        /// Cut Square from triangle
        /// </summary>
        /// <param name="triangle"></param>
        public Square(Triangle triangle)
        {
            this.Material = triangle.Material;
            Side = (triangle.Side * Math.Sqrt(3) * (2 - Math.Sqrt(3)));
            if (Side < LIMIT)
            {
                throw new Exception("This shape can't be cut out");
            }
        }

        /// <summary>
        /// Cut Square from Circle
        /// </summary>
        /// <param name="circle"></param>
        public Square(Circle circle)
        {
            this.Material = circle.Material;
            Side = (2* circle.Radius) / Math.Sqrt(2);
            if (Side < LIMIT)
            {
                throw new Exception("This shape can't be cut out");
            }
        }

        /// <summary>
        /// Area of Square
        /// </summary>
        /// <returns>Area value</returns>
        public double Area()
        {
            return Math.Pow(Side, 2);
        }

        /// <summary>
        /// Perimeter of Square
        /// </summary>
        /// <returns>Perimeter value</returns>
        public double Perimeter()
        {
            return Side * 4;
        }

        /// <summary>
        /// Redefinition of ToString method
        /// </summary>
        /// <returns>Triangle info</returns>
        public override string ToString()
        {
            dynamic currentMaterial = Convert.ChangeType(this.Material, this.Material.GetType());
            return String.Format("This is a square with Side={0}, material={1}, color={2}", Side, this.Material.GetType().Name, currentMaterial.Color);
        }

        /// <summary>
        /// Redefinition of GetHashCode method
        /// </summary>
        /// <returns>HashCode</returns>
        public override int GetHashCode()
        {
            return (int)Side;
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
                var comparedSquare = (Square)obj;

                Type currentMaterialType = this.Material.GetType();
                dynamic currentMaterial = Convert.ChangeType(this.Material, currentMaterialType);

                Type comparedMaterialType = comparedSquare.Material.GetType();
                dynamic comparedMaterial = Convert.ChangeType(comparedSquare.Material, currentMaterialType);

                return (Side == comparedSquare.Side)
                    && currentMaterialType == comparedMaterialType
                    && currentMaterial.Color == comparedMaterial.Color; 
            }
        }
    }
}
