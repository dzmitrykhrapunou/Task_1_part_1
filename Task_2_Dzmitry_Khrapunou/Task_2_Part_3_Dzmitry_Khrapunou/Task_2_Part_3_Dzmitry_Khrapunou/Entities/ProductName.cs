namespace Task2Part3DzmitryKhrapunou.Entities
{
    public class ProductName
    {
        /// <summary>
        /// name of product
        /// </summary>
        public string Name { get; set; }

        public ProductName(string name)
        {
            Name = name;
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
                var compared = (ProductName)obj;
                return this.Name == compared.Name;
            }
        }

        /// <summary>
        /// Redefinition of GetHashCode method
        /// </summary>
        /// <returns>HashCode</returns>
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
