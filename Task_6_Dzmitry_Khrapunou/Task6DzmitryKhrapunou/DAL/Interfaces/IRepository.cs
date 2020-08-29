using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IRepository<T>
        where T : class
    {
        /// <summary>
        /// Gets all entities of type T
        /// </summary>
        /// <returns>Collection of type T</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Gets entity by id
        /// </summary>
        /// <param name="id">Id of entity</param>
        /// <returns>Entity with type T</returns>
        T GetById(int id);

        /// <summary>
        /// Adds a new entity
        /// </summary>
        /// <param name="item">Entity with type T</param>
        void Create(T item);

        /// <summary>
        /// Updates Entity
        /// </summary>
        /// <param name="item">Entity with type T</param>
        void Update(T item);

        /// <summary>
        /// Deletes entity by id
        /// </summary>
        /// <param name="id">Id of entity</param>
        void Delete(int id);
    }
}
