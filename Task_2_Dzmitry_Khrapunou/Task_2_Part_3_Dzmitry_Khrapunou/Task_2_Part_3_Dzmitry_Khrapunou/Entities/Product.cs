using System;
using Task2Part3DzmitryKhrapunou.Entities;
using Task2Part3DzmitryKhrapunou.Interfaces;

namespace Task2Part3DzmitryKhrapunou
{
    public class Product
    {
        /// <summary>
        /// type of product
        /// </summary>
        public IProductType Type { get; set; }

        /// <summary>
        /// name of product
        /// </summary>
        public ProductName Name { get; set; }

        /// <summary>
        /// cost of product
        /// </summary>
        public Cost Cost { get; }

        public Product (IProductType type, ProductName name, Cost cost)
        {
            Type = type;
            Name = name;
            Cost = cost;
        }

        /// <summary>
        /// the merger of the two products
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Product operator +(Product a, Product b)
        {
            if (a.Type.Equals(b.Type))
            {
                var newCost = (a.Cost.CostValue + b.Cost.CostValue) / 2;
                Product c = new Product(a.Type, new ProductName(a.Name.Name + " - " + b.Name.Name), new Cost(newCost));
                return c;
            }

            return a;
        }

        /// <summary>
        /// transformation cost of a product
        /// </summary>
        /// <param name="product"></param>
        public static explicit operator int(Product product)
        {
            return (int)(product.Cost.CostValue * 100);
        }

        /// <summary>
        /// output of the actual price in rubles
        /// </summary>
        /// <param name="product"></param>
        public static explicit operator double(Product product)
        {
            return product.Cost.CostValue;
        }

        /// <summary>
        /// overriding of ToString metod
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {            
            var str = String.Format(this.Type.GetType().Name.ToString() + ", " + this.Type.KindOfProduct.ToString() + ", " + this.Name.Name + ", " + this.Cost.CostValue.ToString());
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
                return this.Type.Equals(comparedProduct.Type) && this.Name.Equals(comparedProduct.Name) && this.Cost.Equals(comparedProduct.Cost);
            }
        }

        /// <summary>
        /// Redefinition of GetHashCode method
        /// </summary>
        /// <returns>HashCode</returns>
        public override int GetHashCode()
        {
            int hash = this.Name.GetHashCode() * (int)(this.Cost.CostValue * 100);

            return hash;
        }
    }
}
