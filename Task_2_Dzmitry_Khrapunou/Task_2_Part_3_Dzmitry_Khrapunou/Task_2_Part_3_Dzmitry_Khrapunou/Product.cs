using System;

namespace Task2Part3DzmitryKhrapunou
{
    public class Product
    {
        /// <summary>
        /// type of product
        /// </summary>
        public ProductType Type { get; set; }

        /// <summary>
        /// name of product
        /// </summary>
        public String Name { get; }

        /// <summary>
        /// cost of product
        /// </summary>
        public Double Cost { get; }


        public Product (ProductType type, string name, double cost)
        {
            this.Type = type;
            this.Name = name;
            this.Cost = cost;
        }

        /// <summary>
        /// the merger of the two products
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Product operator +(Product a, Product b)
        {
            if (a.Type == b.Type)
            {
                var newCost = (a.Cost + b.Cost) / 2;
                Product c = new Product(a.Type, a.Name + " - " + b.Name, newCost);
                return c;
            }

            return a;
        }

        /// <summary>
        /// changing the product type
        /// </summary>
        /// <param name="newType"></param>
        /// <returns></returns>
        public Product ChangeType(ProductType newType)
        {
            this.Type = newType;

            return this;
        }

        /// <summary>
        /// transformation cost of a product
        /// </summary>
        /// <param name="product"></param>
        public static explicit operator int(Product product)
        {
            return (int)(product.Cost * 100);
        }

        /// <summary>
        /// output of the actual price in rubles
        /// </summary>
        /// <param name="product"></param>
        public static explicit operator double(Product product)
        {
            return product.Cost;
        }

        /// <summary>
        /// overriding of ToString metod
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {            
            var str = String.Format(this.Type.ToString() + ", " + this.Name + ", " + this.Cost.ToString());
            return str;
        }

        /// <summary>
        /// Redefinition of Equals method
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                var comparedProduct = (Product)obj;
                return this.Type == comparedProduct.Type && this.Name == comparedProduct.Name && this.Cost == comparedProduct.Cost;
            }
        }

        /// <summary>
        /// Redefinition of GetHashCode method
        /// </summary>
        /// <returns>HashCode</returns>
        public override int GetHashCode()
        {
            int hash = this.Name.GetHashCode() * (int)(this.Cost * 100);

            return hash;
        }
    }
}
