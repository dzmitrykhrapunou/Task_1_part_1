using System;
using Task2Part3DzmitryKhrapunou.Interfaces;

namespace Task2Part3DzmitryKhrapunou.Entities
{
    public class Food : IProductType
    {
        /// <summary>
        /// food type
        /// </summary>
        public string KindOfProduct { get; set; }

        public Food(string kindOfProduct)
        {
            KindOfProduct = kindOfProduct;
        }

        /// <summary>
        /// FoodTypeToClothes
        /// </summary>
        /// <param name="clothes"></param>
        public static explicit operator Clothes(Food foodType)
        {
            return new Clothes(foodType.KindOfProduct);
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
