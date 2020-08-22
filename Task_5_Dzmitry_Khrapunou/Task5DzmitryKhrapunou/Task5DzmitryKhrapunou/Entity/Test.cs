using System;
using Task5Part1DzmitryKhrapunou.Data;

namespace Task5Part1DzmitryKhrapunou
{
    public class Test
    {
        /// <summary>
        /// Name of test
        /// </summary>
        public TestName TestName { get; set; }

        /// <summary>
        /// Date of test completion
        /// </summary>
        public DateTime DateTest { get; set; }

        /// <summary>
        /// Mark of test
        /// </summary>
        public int TestMark { get; set; }

        public Test (TestName testName, DateTime dateTest, double testMark)
        {           
            TestName = testName;
            DateTest = dateTest;
            if (testMark >= 0 && testMark < 11)
            {
                TestMark = (int)testMark;
            }
            else
            {
                throw new Exception("Invalid value of the test mark.");
            }           
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Test () { }
    }
}
