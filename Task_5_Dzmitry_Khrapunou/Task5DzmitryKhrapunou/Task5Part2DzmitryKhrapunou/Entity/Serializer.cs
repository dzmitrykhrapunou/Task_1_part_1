using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;

namespace Task5Part2DzmitryKhrapunou.Entity
{
    public static class Serializer<T>
    {
        /// <summary>
        /// Writes the data to the binary file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="obj"></param>
        public static void SerializeToBinary(string filePath, T obj)
        {
            File.WriteAllText(filePath, string.Empty);

            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                var binarySerializer = new BinaryFormatter();
                binarySerializer.Serialize(fileStream, obj);
            }
        }

        /// <summary>
        /// The method writes the data to the json file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="obj"></param>
        public static void SerializeToJson(string filePath, T obj)
        {
            File.WriteAllText(filePath, string.Empty);

            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                var jsonSerializer = new DataContractJsonSerializer(typeof(T));
                jsonSerializer.WriteObject(fileStream, obj);
            }
        }

        /// <summary>
        /// Writes the data to the xml file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="obj"></param>
        public static void SerializeToXml(string filePath, T obj)
        {
            File.WriteAllText(filePath, string.Empty);

            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                var xmlSerializer = new DataContractSerializer(typeof(T));
                xmlSerializer.WriteObject(fileStream, obj);
            }
        }

        /// <summary>
        /// Reads the data from the binary file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static T DeserializeFromBinary(string filePath)
        {
            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                var binarySerializer = new BinaryFormatter();
                return (T)binarySerializer.Deserialize(fileStream);
            }
        }

        /// <summary>
        /// Reads the data from the json file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static T DeserializeFromJson(string filePath)
        {
            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                var jsonSerializer = new DataContractJsonSerializer(typeof(T));
                return (T)jsonSerializer.ReadObject(fileStream);
            }
        }

        /// <summary>
        /// Reads the data from the xml file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static T DeserializeFromXml(string filePath)
        {
            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                var xmlSerializer = new DataContractSerializer(typeof(T));
                return (T)xmlSerializer.ReadObject(fileStream);
            }
        }
    }
}
