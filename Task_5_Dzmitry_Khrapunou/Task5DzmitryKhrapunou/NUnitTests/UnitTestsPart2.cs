using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

            patients = new CollectionOfPatients<Patient>(new List<Patient>
            {
                new Patient("FirstName1", "LastName1", doctor[0]),
                new Patient("FirstName2", "FirstName2", doctor[1])
            });

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

            patients = new CollectionOfPatients<Patient>(new List<Patient>
            {
                new Patient("FirstName1", "LastName1", doctor[0]),
                new Patient("FirstName2", "FirstName2", doctor[1]),
                new Patient("FirstName3", "LastName3", doctor[2])
            });

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

            patients = new CollectionOfPatients<Patient>(new List<Patient>
            {
                new Patient("FirstName1", "LastName1", doctor[0]),
                new Patient("FirstName2", "FirstName2", doctor[1]),
                new Patient("FirstName3", "LastName3", doctor[2])
            });

            patients.Clear();

            Assert.IsEmpty(patients);            
        }

        [Test]
        public void CopyTo_CopyToSomePatient_NewPatient()
        {
            Random random = new Random();
            var doctor = AddNewPatientsWithDoctor(random);
            var newPatients = new Patient[3];

            patients = new CollectionOfPatients<Patient>(new List<Patient>
            {
                new Patient("FirstName1", "LastName1", doctor[0]),
                new Patient("FirstName2", "FirstName2", doctor[1]),
                new Patient("FirstName3", "LastName3", doctor[2])
            });

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

            patients = new CollectionOfPatients<Patient>(new List<Patient>
            {
                new Patient("FirstName1", "LastName1", doctor[0]),
                new Patient("FirstName2", "FirstName2", doctor[1]),
                new Patient("FirstName3", "LastName3", doctor[2])
            });

            var patient1 = new Patient("FirstName2", "FirstName2", doctor[1]);
            var patient2 = new Patient("FirstName4", "FirstName4", doctor[3]);

            Assert.IsFalse(patients.Remove(patient2));
            Assert.IsTrue(patients.Remove(patient1));

        }

        [Test]
        public void Serialize_SerializeCollectionOfPatientsToBinaryFile_NewBinaryFile()
        {
            var binaryCollectionOfPatientsPath = @"..\..\..\..\..\Task5DzmitryKhrapunou\Task5Part2DzmitryKhrapunou\Data\BinaryCollectionOfPatients.dat";
            var binaryPatientPath = @"..\..\..\..\..\Task5DzmitryKhrapunou\Task5Part2DzmitryKhrapunou\Data\BinaryPatient.dat";
           
            Random random = new Random();
            var doctor = AddNewPatientsWithDoctor(random);
           
            patients = new CollectionOfPatients<Patient>(new List<Patient>
            {
                new Patient("FirstName1", "LastName1", doctor[0]),
                new Patient("FirstName2", "FirstName2", doctor[1]),
                new Patient("FirstName3", "LastName3", doctor[2])
            });

            Serializer<CollectionOfPatients<Patient>>.SerializeToBinary(binaryCollectionOfPatientsPath, patients);
            Serializer<Patient>.SerializeToBinary(binaryPatientPath, patients.ElementAt(0));
            var fileInfoCollectionOfPatients = new FileInfo(binaryCollectionOfPatientsPath);
            var fileInfoPatient = new FileInfo(binaryPatientPath);
            Assert.IsTrue(fileInfoCollectionOfPatients.Length > 0);
            Assert.IsTrue(fileInfoPatient.Length > 0);
        }

        [Test]
        public void Serialize_SerializeCollectionOfPatientsToXmlFile_NewXmlFile()
        {
            var xmlCollectionOfPatientsPath = @"..\..\..\..\..\Task5DzmitryKhrapunou\Task5Part2DzmitryKhrapunou\Data\XmlCollectionOfPatients.xml";
            var xmlPatientPath = @"..\..\..\..\..\Task5DzmitryKhrapunou\Task5Part2DzmitryKhrapunou\Data\XmlPatient.xml";

            Random random = new Random();
            var doctor = AddNewPatientsWithDoctor(random);

            patients = new CollectionOfPatients<Patient>(new List<Patient>
            {
                new Patient("FirstName1", "LastName1", doctor[0]),
                new Patient("FirstName2", "FirstName2", doctor[1]),
                new Patient("FirstName3", "LastName3", doctor[2])
            });

            Serializer<CollectionOfPatients<Patient>>.SerializeToXml(xmlCollectionOfPatientsPath, patients);
            Serializer<Patient>.SerializeToXml(xmlPatientPath, patients.ElementAt(1));
            var fileInfoCollectionOfPatients = new FileInfo(xmlCollectionOfPatientsPath);
            var fileInfoPatient = new FileInfo(xmlPatientPath);
            Assert.IsTrue(fileInfoCollectionOfPatients.Length > 0);
            Assert.IsTrue(fileInfoPatient.Length > 0);
        }

        [Test]
        public void Serialize_SerializeCollectionOfPatientsToJsonFile_NewJsonFile()
        {
            var jsonCollectionOfPatientsPath = @"..\..\..\..\..\Task5DzmitryKhrapunou\Task5Part2DzmitryKhrapunou\Data\JsonCollectionOfPatients.json";
            var jsonPatientPath = @"..\..\..\..\..\Task5DzmitryKhrapunou\Task5Part2DzmitryKhrapunou\Data\JsonPatient.json";

            Random random = new Random();
            var doctor = AddNewPatientsWithDoctor(random);

            patients = new CollectionOfPatients<Patient>(new List<Patient>
            {
                new Patient("FirstName1", "LastName1", doctor[0]),
                new Patient("FirstName2", "FirstName2", doctor[1]),
                new Patient("FirstName3", "LastName3", doctor[2])
            });

            Serializer<CollectionOfPatients<Patient>>.SerializeToJson(jsonCollectionOfPatientsPath, patients);
            Serializer<Patient>.SerializeToJson(jsonPatientPath, patients.ElementAt(2));
            var fileInfoCollectionOfPatients = new FileInfo(jsonCollectionOfPatientsPath);
            var fileInfoPatient = new FileInfo(jsonPatientPath);
            Assert.IsTrue(fileInfoCollectionOfPatients.Length > 0);
            Assert.IsTrue(fileInfoPatient.Length > 0);
        }

        [Test]
        public void Test_DeserializeCollectionAndObjectFromBinaryFile()
        {
            var binaryCollectionOfPatientsPath = @"..\..\..\..\..\Task5DzmitryKhrapunou\Task5Part2DzmitryKhrapunou\Data\BinaryCollectionOfPatients.dat";
            var binaryPatientPath = @"..\..\..\..\..\Task5DzmitryKhrapunou\Task5Part2DzmitryKhrapunou\Data\BinaryPatient.dat";

            Serialize_SerializeCollectionOfPatientsToBinaryFile_NewBinaryFile();
            
            CollectionOfPatients<Patient> resultCollectionOfPatients = Serializer<CollectionOfPatients<Patient>>.DeserializeFromBinary(binaryCollectionOfPatientsPath);
            Patient result = Serializer<Patient>.DeserializeFromBinary(binaryPatientPath);
            Assert.AreEqual(resultCollectionOfPatients, patients);
            Assert.AreEqual(result, patients.ElementAt(0));
        }

        [Test]
        public void Test_DeserializeCollectionAndObjectFromXmlFile()
        {
            var xmlCollectionOfPatientsPath = @"..\..\..\..\..\Task5DzmitryKhrapunou\Task5Part2DzmitryKhrapunou\Data\XmlCollectionOfPatients.xml";
            var xmlPatientPath = @"..\..\..\..\..\Task5DzmitryKhrapunou\Task5Part2DzmitryKhrapunou\Data\XmlPatient.xml";

            Serialize_SerializeCollectionOfPatientsToXmlFile_NewXmlFile();

            CollectionOfPatients<Patient> resultCollectionOfPatients = Serializer<CollectionOfPatients<Patient>>.DeserializeFromXml(xmlCollectionOfPatientsPath);
            Patient result = Serializer<Patient>.DeserializeFromXml(xmlPatientPath);
            Assert.AreEqual(resultCollectionOfPatients, patients);
            Assert.AreEqual(result, patients.ElementAt(1));
        }

        [Test]
        public void Test_DeserializeCollectionAndObjectFromJsonFile()
        {
            var jsonCollectionOfPatientsPath = @"..\..\..\..\..\Task5DzmitryKhrapunou\Task5Part2DzmitryKhrapunou\Data\JsonCollectionOfPatients.json";
            var jsonPatientPath = @"..\..\..\..\..\Task5DzmitryKhrapunou\Task5Part2DzmitryKhrapunou\Data\JsonPatient.json";

            Serialize_SerializeCollectionOfPatientsToJsonFile_NewJsonFile();

            CollectionOfPatients<Patient> resultCollectionOfPatients = Serializer<CollectionOfPatients<Patient>>.DeserializeFromJson(jsonCollectionOfPatientsPath);
            Patient result = Serializer<Patient>.DeserializeFromJson(jsonPatientPath);
            Assert.AreEqual(resultCollectionOfPatients, patients);
            Assert.AreEqual(result, patients.ElementAt(2));
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