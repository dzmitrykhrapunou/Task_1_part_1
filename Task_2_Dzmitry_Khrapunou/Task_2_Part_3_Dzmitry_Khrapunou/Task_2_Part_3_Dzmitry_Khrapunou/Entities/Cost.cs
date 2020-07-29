namespace Task2Part3DzmitryKhrapunou.Entities
{
    public class Cost
    {
        /// <summary>
        /// cost of product
        /// </summary>
        public double CostValue { get; set; }

        public Cost (double cost)
        {
            CostValue = cost;
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
                var compared = (Cost)obj;
                return this.CostValue == compared.CostValue;
            }
        }

        /// <summary>
        /// Redefinition of GetHashCode method
        /// </summary>
        /// <returns>HashCode</returns>
        public override int GetHashCode()
        {
            return (int)CostValue;
        }
    }
}
