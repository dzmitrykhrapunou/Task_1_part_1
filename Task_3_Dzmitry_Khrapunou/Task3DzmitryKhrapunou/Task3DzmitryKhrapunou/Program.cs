using System;
using Task3DzmitryKhrapunou.Data;
using Task3DzmitryKhrapunou.Entities;
using Task3DzmitryKhrapunou.WorkWithFile;
using System.IO;

namespace Task3DzmitryKhrapunou
{
    class Program
    {        
        static void Main(string[] args)
        {
            string pathToRead = Path.Combine(@"..\..\..\Data\", "Shapes.xml");

            string pathToWrite1 = Path.Combine(@"..\..\..\Data\", "NewShapes.xml");
            string pathToWrite2 = Path.Combine(@"..\..\..\Data\", "MadeFromPaper.xml");
            string pathToWrite3 = Path.Combine(@"..\..\..\Data\", "MadeFromFilm.xml");

            var box = new Box();
            var bc = new FileReader();

            bc.ReadFile(pathToRead, ReaderType.stream, box.Shapes);
            var circles = box.ExtractAllCircles();
            var papers = box.ExtractAllPaperShapes();
            var films = box.ExtractAllFilmShapes();

            bc.WriteToFiles(pathToWrite1, ReaderType.stream, circles.ToArray());
            bc.WriteToFiles(pathToWrite2, ReaderType.stream, papers.ToArray());
            bc.WriteToFiles(pathToWrite3, ReaderType.stream, films.ToArray());
            Console.ReadKey();
        }
    }
}
