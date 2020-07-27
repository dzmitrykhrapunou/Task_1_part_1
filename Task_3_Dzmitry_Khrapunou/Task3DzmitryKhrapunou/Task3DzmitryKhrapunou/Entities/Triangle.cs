using System;
using Task3DzmitryKhrapunou.Interfaces;

namespace Task3DzmitryKhrapunou.Entities
{
    public class Triangle : IShape
    {
        /// <summary>
        /// const LIMIT
        /// </summary>
        const double LIMIT = 1;

        public double Side { get; }

        public IMaterial Material { get; set; }

        /// <summary>
        /// Constructor for Triangle
        /// </summary>
        /// <param name="side">Triangle side</param>
        public Triangle(IMaterial material, int side)
        {
            Material = material;
            Side = side;
        }

        /// <summary>
        /// Cut Triangle from square
        /// </summary>
        /// <param name="square"></param>
        public Triangle(Square square)
        {
            this.Material = square.Material;
            Side = square.Side;
            if (Side < LIMIT)
            {
                throw new Exception("This shape can't be cut out");
            }
        }

        /// <summary>
        /// Cut Triangle from Circle
        /// </summary>
        /// <param name="circle"></param>
        public Triangle(Circle circle)
        {
            this.Material = circle.Material;
            Side = circle.Radius * Math.Sqrt(3) * 2;
            if (Side < LIMIT)
            {
                throw new Exception("This shape can't be cut out");
            }
        }

        /// <summary>
        /// Area of Triangle
        /// </summary>
        /// <returns>Area value</returns>
        public double Area()
        {
            var partPerimeter = Perimeter() / 2;

            return Math.Sqrt(partPerimeter * Math.Pow(partPerimeter - Side, 3));
        }

        /// <summary>
        /// Perimeter of Triangle
        /// </summary>
        /// <returns>Perimeter value</returns>
        public double Perimeter()
        {
            return Side * 3;
        }

        /// <summary>
        /// Redefinition of ToString method
        /// </summary>
        /// <returns>Triangle info</returns>
        public override string ToString()
        {
            dynamic currentMaterial = Convert.ChangeType(this.Material, this.Material.GetType());
            return String.Format("This is a triangle with side:{0}, material={1}, color={2}", Side, this.Material.GetType().Name, currentMaterial.Color);
        }

        /// <summary>
        /// Redefinition of GetHashCode method
        /// </summary>
        /// <returns>HashCode</returns>
        public override int GetHashCode()
        {
            return (int)Side * 3;
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

                Type currentMaterialType = this.Material.GetType();
                dynamic currentMaterial = Convert.ChangeType(this.Material, currentMaterialType);

                Type comparedMaterialType = comparedTriangle.Material.GetType();
                dynamic comparedMaterial = Convert.ChangeType(comparedTriangle.Material, currentMaterialType);

                return (Side == comparedTriangle.Side)
                    && currentMaterialType == comparedMaterialType
                    && currentMaterial.Color == comparedMaterial.Color; 
            }
        }
    }
}
