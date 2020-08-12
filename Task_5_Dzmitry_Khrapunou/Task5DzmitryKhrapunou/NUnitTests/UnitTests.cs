using NUnit.Framework;
using System;
using Task5DzmitryKhrapunou;
using Task5DzmitryKhrapunou.Data;
using Task5DzmitryKhrapunou.Entity;

namespace NUnitTests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void AddAndRemove_AddNewStudentsWithTestsAndRemoveSomeStudent_NewStudent()
        {
            Random random = new Random();
            var math = AddNewStudentsWithtests(random);

            var s1 = new Student("FirstName1", "LastName1", math[0]);
            var s2 = new Student("FirstName2", "LastName2", math[1]);
            var s3 = new Student("FirstName3", "LastName3", math[2]);
            var s4 = new Student("FirstName4", "LastName4", math[3]);
            var s5 = new Student("FirstName5", "LastName5", math[4]);
            var s6 = new Student("FirstName6", "LastName6", math[5]);
            var s7 = new Student("FirstName7", "LastName7", math[6]);
                        
            var tree = new BinaryTree<Student>();

            tree.Add(s1);
            tree.Add(s2);
            tree.Add(s3);
            tree.Add(s4);
            tree.Add(s5);
            tree.Add(s6);
            tree.Add(s7);

            BinaryTreeSerializer.Serialize(tree, "BinaryTree.xml");

            tree.Remove(s4);

            BinaryTreeSerializer.Deserialize("BinaryTree.xml");
        }

        /// <summary>
        /// Tree Balance Testing
        /// </summary>
        [Test]
        public void TestBalancing()
        {
            BinaryTree<int> tree = new BinaryTree<int>();

            tree.Add(6);
            tree.Add(5);
            tree.Add(4);
            tree.Add(8);
            tree.Add(9);
            tree.Add(10);
            tree.Add(20);

            /*   Before
             *     6
             *   5   8
             * 4       9
             *          10           
             */

            tree.BalanceTree();

            /*     After
             *      8
             *     6  9
             *    5    10
             *  4        20
             *
            */

            var node6 = tree.Search(6);
            var node5 = tree.Search(5);
            var node4 = tree.Search(4);
            var node8 = tree.Search(8);
            var node9 = tree.Search(9);
            var node10 = tree.Search(10);
            var node20 = tree.Search(20);

            Assert.IsTrue(node5.RightNode == null && node5.LeftNode == node4 &&
                          node8.RightNode == node9 && node8.LeftNode == node6 &&
                          node10.RightNode == node20 && node10.LeftNode == null &&
                          node4.RightNode == null && node4.LeftNode == null &&
                          node6.RightNode == null && node6.LeftNode == node5);
        }

        public Test[] AddNewStudentsWithtests(Random random)
        {
            var math = new Test[7];

            int count = 7;

            for (int i = 0; i < count; i++)
            {
                var testName = (TestName)random.Next(0, 3);
                var dateTest = new DateTime(2020, random.Next(1, 12), random.Next(1, 29));
                var testMark = random.Next(0, 10) + random.NextDouble();
                var test = new Test(testName, dateTest, testMark);
                math[i] = test;
            }

            return math;
        }

    }
}