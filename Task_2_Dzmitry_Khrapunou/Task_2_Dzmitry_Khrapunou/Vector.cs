using System;

namespace Task_2_Part_1_Dzmitry_Khrapunou
{
    public class Vector
    {
        /// <summary>
        /// Vector name
        /// </summary>
        public string name { get; }

        /// <summary>
        /// Сoordinate x
        /// </summary>
        public int x { get; }

        /// <summary>
        /// Сoordinate y
        /// </summary>
        public int y { get; }

        /// <summary>
        /// Сoordinate z
        /// </summary>
        public int z { get; }


        /// <summary>
        /// Create a constructor to initialize vector components.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Vector(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// Metod returns a new vector (summ of two vectors).
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

        /// <summary>
        /// Metod returns a new vector (subtraction of two vectors).
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

        /// <summary>
        /// Metod returns a new vector (scalar multiplication).
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="scalar"></param>
        /// <returns></returns>
        public static Vector operator *(Vector v1, int scalar)
        {
            return new Vector(v1.x * scalar, v1.y * scalar, v1.z * scalar);
        }

        /// <summary>
        /// Metod returns scalar composition.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static int ScalarСomposition(Vector v1, Vector v2)
        {
            return (v1.x * v2.x + v1.y * v2.y + v1.z * v2.z);
        }

        /// <summary>
        /// Metod returns vector composition.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static int VectorСomposition(Vector v1, Vector v2)
        {
            return ((v1.y * v2.z - v1.z * v2.y) + (v1.z * v2.x - v1.x * v2.z) + (v1.x * v2.y - v1.y * v2.x));
        }

        /// <summary>
        /// Metod returns module of the vector.
        /// </summary>
        /// <param name="v1"></param>
        /// <returns></returns>
        public static double ModulVector(Vector v1)
        {
            return (Math.Sqrt(v1.x * v1.x + v1.y * v1.y + v1.z * v1.z));
        }

        /// <summary>
        /// overriding of ToString metod.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "(" + x + ", " + y + ", " + z + ")";
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
                var comparedVector = (Vector)obj;
                return (x == comparedVector.x) && (y == comparedVector.y) && (z == comparedVector.z);
            }
        }

        /// <summary>
        /// Redefinition of GetHashCode method
        /// </summary>
        /// <returns>HashCode</returns>
        public override int GetHashCode()
        {
            int hash = 23;
           
                hash = hash * 187739 + x.GetHashCode();
                hash = hash * 187739 + y.GetHashCode();
                hash = hash * 187739 + z.GetHashCode();
            
            return hash;
        }
    
    }
}
