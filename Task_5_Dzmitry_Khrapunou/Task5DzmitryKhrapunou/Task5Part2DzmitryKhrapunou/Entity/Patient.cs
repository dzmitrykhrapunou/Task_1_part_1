using System;
using System.Runtime.Serialization;
using Task5Part2DzmitryKhrapunou.Data;

namespace Task5Part2DzmitryKhrapunou
{
    [Serializable]
    [DataContract]
    public class Patient
    {
        /// <summary>
        /// First name of patient 
        /// </summary>
        [DataMember]
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of patient 
        /// </summary>
        [DataMember]
        public string LastName { get; set; }

        /// <summary>
        /// To the doctor
        /// </summary>
        [DataMember]
        public Doctor Doctor { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Patient() { }

        public Patient (string firstName, string lastName, Doctor doctor)
        {
            FirstName = firstName;
            LastName = lastName;
            Doctor = doctor;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            var patient = (Patient)obj;

            return (patient.FirstName == this.FirstName) && (patient.LastName == this.LastName) && (patient.Doctor == this.Doctor);
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode() ^ LastName.GetHashCode() ^ Doctor.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format($"FirstName: {this.FirstName}\n" + $"LastName: {this.LastName}\n" + $"To the doctor: {this.Doctor}\n");
        }
    }
}
