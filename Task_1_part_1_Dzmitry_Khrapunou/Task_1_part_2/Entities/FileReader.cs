using System.Text;
using System.IO;
using System.Linq;

namespace Task_1_part_2.Entities
{
    /// <summary>
    /// FileReader
    /// </summary>
    public static class FileReader
    {
        /// <summary>
        /// reads txt file
        /// </summary>
        /// <returns></returns>
        public static Shape[] ReadTxt()
        {            
            string fileName = "Shape'sParam.txt";
            string path = Path.Combine(@"../../../Data/", fileName);
            var lineCount = File.ReadLines(path).Count();

            Shape[] shapes = new Shape[lineCount];
                        
            using (StreamReader reader = new StreamReader(path, Encoding.Default))
            {
                for (int i = 0; i < lineCount; i++)
                {
                    var shape = reader.ReadLine().Split('|');

                    switch (shape.FirstOrDefault())
                    {
                        case "Circle":
                            var radius = StringToNumber(shape[1]);

                            shapes[i] = radius != 0 ? new Circle(radius) : null;
                            break;

                        case "Rectangle":
                            int size1 = StringToNumber(shape[1]);
                            int size2 = StringToNumber(shape[2]);

                            shapes[i] = (size1 != 0) && (size2 != 0) ? new Rectangle(StringToNumber(shape[1]), StringToNumber(shape[2])) : null ;
                            break;

                        case "Triangle":
                            size1 = StringToNumber(shape[1]);
                            size2 = StringToNumber(shape[2]);
                            int size3 = StringToNumber(shape[3]);

                            shapes[i] = (size1 != 0) && (size1 != 0) && (size3 != 0) ? new Triangle(StringToNumber(shape[1]), StringToNumber(shape[2]), StringToNumber(shape[3])) : null;

                            break;

                        default: break;
                    }
                }
            }

            return shapes;
        }

        /// <summary>
        /// digit check
        /// </summary>
        /// <param string variable = "str"></param>
        /// <returns></returns>
        public static int StringToNumber(string str)
        {
            int num;
            bool isNumeric = int.TryParse(str, out num);

            return isNumeric ? num : 0;
        }
    }
}
