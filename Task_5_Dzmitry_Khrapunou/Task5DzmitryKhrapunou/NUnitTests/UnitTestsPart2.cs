using NUnit.Framework;
using System;
using System.Collections.Generic;
using Task5Part2DzmitryKhrapunou;
using Task5Part2DzmitryKhrapunou.Data;
using Task5Part2DzmitryKhrapunou.Entity;

namespace UnitTestsPart2
{
    [TestFixture]
    public class Test 
    {
        private CollectionOfPatients<Patient> patients;
        
        [Test]
        public void Add_AddNewPatients_NewPatient()
        {
            Random random = new Random();
            var doctor = AddNewPatientsWithDoctor(random);

            patients = new CollectionOfPatients<Patient>()
            {
                new Patient("FirstName1", "LastName1", doctor[0]),
                new Patient("FirstName2", "FirstName2", doctor[1])
            };

            var patient1 = new Patient("FirstName3", "LastName3", doctor[2]);
            var patient2 = new Patient("FirstName4", "FirstName4", doctor[3]);
            patients.Add(patient1);
            patients.Add(patient2);

            Assert.AreNotEqual(patients.FindIndex(patient2), null);
        }

        [Test]
        public void Contains_ChecksSomePatient_ChecksPatient()
        {
            Random random = new Random();
            var doctor = AddNewPatientsWithDoctor(random);

            patients = new CollectionOfPatients<Patient>()
            {
                new Patient("FirstName1", "LastName1", doctor[0]),
                new Patient("FirstName2", "FirstName2", doctor[1]),
                new Patient("FirstName3", "LastName3", doctor[2])
            };

            var patient1 = new Patient("FirstName2", "FirstName2", doctor[1]);
            var patient2 = new Patient("FirstName4", "FirstName4", doctor[3]);
            
            Assert.IsFalse(patients.Contains(patient2));
            Assert.IsTrue(patients.Contains(patient1));            
        }

        [Test]
        public void Clear_ClearCollectionOfPatients_Empty()
        {
            Random random = new Random();
            var doctor = AddNewPatientsWithDoctor(random);

            patients = new CollectionOfPatients<Patient>()
            {
                new Patient("FirstName1", "LastName1", doctor[0]),
                new Patient("FirstName2", "FirstName2", doctor[1]),
                new Patient("FirstName3", "LastName3", doctor[2])
            };

            patients.Clear();

            Assert.IsEmpty(patients);            
        }

        [Test]
        public void CopyTo_CopyToSomePatient_NewPatient()
        {
            Random random = new Random();
            var doctor = AddNewPatientsWithDoctor(random);
            var newPatients = new Patient[3];

            patients = new CollectionOfPatients<Patient>()
            {
                new Patient("FirstName1", "LastName1", doctor[0]),
                new Patient("FirstName2", "FirstName2", doctor[1]),
                new Patient("FirstName3", "LastName3", doctor[2])
            };

            var ExpectedPatients = new Patient[]
            {
                new Patient("FirstName1", "LastName1", doctor[0]),
                new Patient("FirstName2", "FirstName2", doctor[1]),
                new Patient("FirstName3", "LastName3", doctor[2])
            };

            patients.CopyTo(newPatients, 0);
                        
            Assert.AreEqual(newPatients, ExpectedPatients);                       
        }

        [Test]
        public void Remove_RemoveSomePatient_NewPatient()
        {
            Random random = new Random();
            var doctor = AddNewPatientsWithDoctor(random);

            patients = new CollectionOfPatients<Patient>()
            {
                new Patient("FirstName1", "LastName1", doctor[0]),
                new Patient("FirstName2", "FirstName2", doctor[1]),
                new Patient("FirstName3", "LastName3", doctor[2])
            };

            var patient1 = new Patient("FirstName2", "FirstName2", doctor[1]);
            var patient2 = new Patient("FirstName4", "FirstName4", doctor[3]);

            Assert.IsFalse(patients.Remove(patient2));
            Assert.IsTrue(patients.Remove(patient1));

        }

        public Doctor[] AddNewPatientsWithDoctor(Random random)
        {
            var doctor = new Doctor[4];

            int count = 4;

            for (int i = 0; i < count; i++)
            {
                var doc = (Doctor)random.Next(0, 3);

                doctor[i] = doc;
            }

            return doctor;
        }
    }
}