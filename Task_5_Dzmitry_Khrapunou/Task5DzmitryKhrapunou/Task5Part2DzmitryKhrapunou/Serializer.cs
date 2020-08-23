using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;

namespace Task5Part2DzmitryKhrapunou
{
    public static class Serializer<T>
    {
        /// <summary>
        /// Writes data to the binary file.
        /// </summary>
        /// <param name="filePath">Path to file</param>
        /// <param name="obj">Data to write</param>
        public static void SerializeToBinary(string filePath, T obj)
        {
            File.WriteAllText(filePath, string.Empty);

            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fileStream, obj);
            }
        }

        /// <summary>
        /// Writes data to the json file.
        /// </summary>
        /// <param name="filePath">Path to file</param>
        /// <param name="obj">Data to write</param>
        public static void SerializeToJson(string filePath, T obj)
        {
            File.WriteAllText(filePath, string.Empty);

            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                var jsonFormatter = new DataContractJsonSerializer(typeof(T));
                jsonFormatter.WriteObject(fileStream, obj);
            }
        }

        /// <summary>
        /// Writes data to the xml file.
        /// </summary>
        /// <param name="filePath">Path to file</param>
        /// <param name="obj">Data to write</param>
        public static void SerializeToXml(string filePath, T obj)
        {
            File.WriteAllText(filePath, string.Empty);

            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                var xmlFormatter = new DataContractSerializer(typeof(T));
                xmlFormatter.WriteObject(fileStream, obj);
            }
        }

        /// <summary>
        /// Reads data from the binary file.
        /// </summary>
        /// <param name="filePath">Path to file</param>
        /// <returns>Deserialized object</returns>
        public static T DeserializeFromBinary(string filePath)
        {
            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                var binaryFormatter = new BinaryFormatter();
                return (T)binaryFormatter.Deserialize(fileStream);
            }
        }

        /// <summary>
        /// Reads data from the json file.
        /// </summary>
        /// <param name="filePath">Path to file</param>
        /// <returns>Deserialized object</returns>
        public static T DeserializeFromJson(string filePath)
        {
            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                var jsonFormatter = new DataContractJsonSerializer(typeof(T));
                return (T)jsonFormatter.ReadObject(fileStream);
            }
        }

        /// <summary>
        /// Reads data from the xml file.
        /// </summary>
        /// <param name="filePath">Path to file</param>
        /// <returns>Deserialized object</returns>
        public static T DeserializeFromXml(string filePath)
        {
            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                var xmlFormatter = new DataContractSerializer(typeof(T));
                return (T)xmlFormatter.ReadObject(fileStream);
            }
        }

    }
}
