using System.IO;
using System.Xml.Serialization;

namespace Task5Part1DzmitryKhrapunou.Entity
{
    public class BinaryTreeSerializer
    {
        public static void Serialize(BinaryTree<Student> tree, string path)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(BinaryTree<Student>));

            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fileStream, tree);
            }
        }

        /// <summary>
        /// Deserialize a binary tree from xml file
        /// </summary>
        /// <param name="path"> File path</param>
        /// <returns></returns>
        public static BinaryTree<Student> Deserialize(string path)
        {
            BinaryTree<Student> tree = null;

            XmlSerializer formatter = new XmlSerializer(typeof(BinaryTree<Student>));

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                tree = (BinaryTree<Student>)formatter.Deserialize(fs);
            }

            return tree;
        }
    }
}
