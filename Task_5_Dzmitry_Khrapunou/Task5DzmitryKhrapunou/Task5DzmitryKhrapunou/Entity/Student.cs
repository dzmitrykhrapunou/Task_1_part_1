using System;

namespace Task5DzmitryKhrapunou
{
    public class Student: IComparable
    {
        /// <summary>
        /// First name of student 
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of student 
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Test of student
        /// </summary>
        public Test Test { get; set; }

        public Student (string firstName, string lastName, Test test)
        {
            FirstName = firstName;
            LastName = lastName;
            Test = test;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Student () { }

        /// <summary>
        /// Compares two students
        /// </summary>
        /// <param name="obj"> An object to compare with this instance.</param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;

            Student otherStudent = obj as Student;

            if (otherStudent != null)
            {
                return FirstName.CompareTo(otherStudent.FirstName) & LastName.CompareTo(otherStudent.LastName);
            }
            else
            {
                throw new ArgumentException("Object is not a Student");
            }
        }
    }
}
