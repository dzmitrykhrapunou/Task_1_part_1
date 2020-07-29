namespace Task2Part3DzmitryKhrapunou.Interfaces
{
    public interface IProductType
    {
        /// <summary>
        /// Kind Of Product
        /// </summary>
        public string KindOfProduct { get; set; }

        /// <summary>
        /// Redefinition of Equals method
        /// </summary>
        /// <returns>HashCode</returns>
        public bool Equals(object obj);

        /// <summary>
        /// Redefinition of GetHashCode method
        /// </summary>
        /// <returns>HashCode</returns>
        public int GetHashCode();
    }
}
