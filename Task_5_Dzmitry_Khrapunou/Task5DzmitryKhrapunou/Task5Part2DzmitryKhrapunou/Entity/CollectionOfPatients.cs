using System;
using System.Collections;
using System.Collections.Generic;

namespace Task5Part2DzmitryKhrapunou.Entity
{
    [Serializable]
    public class CollectionOfPatients<T> : ICollection<T> where T : Patient
    {
        private List<T> patients = new List<T>();

        /// <summary>
        /// Adds a patient to the collection of patients.
        /// </summary>
        /// <param name="patient"></param>
        public void Add(T patient)
        {
            patients.Add(patient);
        }

        /// <summary>
        /// Checks if the patient is contained in the collection of patients.
        /// </summary>
        /// <param name="patient"></param>
        /// <returns>True or False</returns>
        public bool Contains(T patient)
        {
            return patients.Contains(patient);
        }

        /// <summary>
        /// Deleting all patients from the collection of patients.
        /// </summary>
        public void Clear()
        {
            patients.Clear();
        }

        /// <summary>
        /// Method that copies patient collections to an array
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            patients.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Deleting the first patient found from the collection of patients.
        /// </summary>
        /// <param name="patient"></param>
        /// <returns>True or False</returns>
        public bool Remove(T patient)
        {
            return patients.Remove(patient);
        }

        public int? FindIndex(T patient)
        {
            int? index;
            index = patients.IndexOf(patient);

            return index;
        }

        /// <summary>
        /// Gets the number of items contained in the collection of patients.
        /// </summary>
        public int Count => patients.Count;

        /// <summary>
        /// Returns a value indicating whether the collection of patients is read-only.
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// The method gets enumerator.
        /// </summary>
        /// <returns>Enumerator</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return patients.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
