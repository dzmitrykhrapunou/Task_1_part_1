using System;
using Task2Part3DzmitryKhrapunou.Interfaces;

namespace Task2Part3DzmitryKhrapunou.Entities
{
    public class Clothes : IProductType
    {
        /// <summary>
        /// clothes type
        /// </summary>
        public string KindOfProduct { get; set; }

        public Clothes(string kindOfProduct)
        {
            KindOfProduct = kindOfProduct;
        }

        /// <summary>
        /// ClothesTypeToFoodType
        /// </summary>
        /// <param name="clothes"></param>
        public static explicit operator Food(Clothes clothesType)
        {
            return new Food(clothesType.KindOfProduct);
        }

        public override bool Equals(object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                dynamic compared = Convert.ChangeType(obj, obj.GetType());
                return this.KindOfProduct == compared.KindOfProduct;
            }
        }
        
         /// <summary>
         /// Redefinition of GetHashCode method
         /// </summary>
         /// <returns>HashCode</returns>
        public override int GetHashCode()
        {
            return KindOfProduct.GetHashCode();
        }
    }
}
