using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using Task3DzmitryKhrapunou.Data;
using Task3DzmitryKhrapunou.Entities;
using Task3DzmitryKhrapunou.Interfaces;

namespace Task3DzmitryKhrapunou.WorkWithFile
{
    public class FileReader : IDisposable
    {        
        private StreamReader streamReader = null;
        private XmlTextReader xmlReader = null;
        private StreamWriter streamWriter = null;
        private XmlTextWriter xmlWriter = null;
        private bool disposedValue = false;

        /// <summary>
        /// Rreading from a file in two methods
        /// </summary>
        public void ReadFile(string fileNameToRead, ReaderType type, IShape[] box)
        {
            if (disposedValue)
            {
                throw new ObjectDisposedException(fileNameToRead);
            }

            using (streamReader = File.OpenText(fileNameToRead))
            {
                List<string> temp = new List<string>();
                if (type == ReaderType.stream)
                {
                    string pattern = @"(?<=\>)(.*)(?=\<)";
                    string input = null;
                    var boxIndex = 0;
                    while ((input = streamReader.ReadLine()) != null)
                    {
                        foreach (Match match in Regex.Matches(input, pattern))
                        {
                            temp.Add(match.Value);
                        }
                        if (temp.Count == 4)
                        {                            
                            switch (temp[0])
                            {
                                case "Circle":
                                    if (temp[1] == "Film")
                                    {
                                        box[boxIndex] = new Circle(new Film(), int.Parse(temp[3]));
                                        boxIndex++;
                                        break;
                                    }

                                    if (temp[1] == "Paper")
                                    {
                                        box[boxIndex] = new Circle(temp[2] == Color.White.ToString() ? new Paper() : new Paper((Color)Enum.Parse(typeof(Color), temp[2])), int.Parse(temp[3]));
                                        boxIndex++;
                                        break;
                                    }

                                    else                                    
                                        throw new Exception("Incorrect data");
                                        
                                case "Triangle":
                                    if (temp[1] == "Film")
                                    {
                                        box[boxIndex] = new Triangle(new Film(), int.Parse(temp[3]));
                                        boxIndex++;
                                        break;
                                    }

                                    if (temp[1] == "Paper")
                                    {
                                        box[boxIndex] = new Triangle(temp[2] == Color.White.ToString() ? new Paper() : new Paper((Color)Enum.Parse(typeof(Color), temp[2])), int.Parse(temp[3]));
                                        boxIndex++;
                                        break;
                                    }

                                    else
                                        throw new Exception("Incorrect data");

                                case "Square":
                                    if (temp[1] == "Film")
                                    {
                                        box[boxIndex] = new Square(new Film(), int.Parse(temp[3]));
                                        boxIndex++;
                                        break;
                                    }

                                    if (temp[1] == "Paper")
                                    {
                                        box[boxIndex] = new Square(temp[2] == Color.White.ToString() ? new Paper() : new Paper((Color)Enum.Parse(typeof(Color), temp[2])), int.Parse(temp[3]));
                                        boxIndex++;
                                        break;
                                    }

                                    else
                                        throw new Exception("Incorrect data");
                                default:
                                    throw new Exception("Incorrect data");                                    
                            }
                            
                            temp.Clear();
                        }
                    }
                }
                else
                {
                    using (xmlReader = new XmlTextReader(fileNameToRead))
                    {
                        var boxIndex = 0;
                        Console.WriteLine("Welcome to XMLReader!");
                        while (xmlReader.Read())
                        {
                            switch (xmlReader.NodeType)
                            {
                                case XmlNodeType.Text:
                                    temp.Add(xmlReader.Value);
                                    break;
                            }
                            if (temp.Count == 4)
                            {
                                switch (temp[0])
                                {
                                    case "Circle":
                                        if (temp[1] == "Film")
                                        {
                                            box[boxIndex] = new Circle(new Film(), int.Parse(temp[3]));
                                            boxIndex++;
                                            break;
                                        }

                                        if (temp[1] == "Paper")
                                        {
                                            box[boxIndex] = new Circle(temp[2] == Color.White.ToString() ? new Paper() : new Paper((Color)Enum.Parse(typeof(Color), temp[2])), int.Parse(temp[3]));
                                            boxIndex++;
                                            break;
                                        }

                                        else
                                            throw new Exception("Incorrect data");

                                    case "Triangle":
                                        if (temp[1] == "Film")
                                        {
                                            box[boxIndex] = new Triangle(new Film(), int.Parse(temp[3]));
                                            boxIndex++;
                                            break;
                                        }

                                        if (temp[1] == "Paper")
                                        {
                                            box[boxIndex] = new Triangle(temp[2] == Color.White.ToString() ? new Paper() : new Paper((Color)Enum.Parse(typeof(Color), temp[2])), int.Parse(temp[3]));
                                            boxIndex++;
                                            break;
                                        }

                                        else
                                            throw new Exception("Incorrect data");

                                    case "Square":
                                        if (temp[1] == "Film")
                                        {
                                            box[boxIndex] = new Square(new Film(), int.Parse(temp[3]));
                                            boxIndex++;
                                            break;
                                        }

                                        if (temp[1] == "Paper")
                                        {
                                            box[boxIndex] = new Square(temp[2] == Color.White.ToString() ? new Paper() : new Paper((Color)Enum.Parse(typeof(Color), temp[2])), int.Parse(temp[3]));
                                            boxIndex++;
                                            break;
                                        }

                                        else
                                            throw new Exception("Incorrect data");
                                    default:
                                        throw new Exception("Incorrect data");
                                }

                                temp.Clear();
                            }
                        }
                    }
                }
            }
        }

        public void WriteToFiles(string fileName, ReaderType wType, IShape[] mas)
        {
            if (disposedValue)
            {
                throw new ObjectDisposedException(fileName);
            }
            using (streamWriter = File.CreateText(fileName))
            {
                if (wType == ReaderType.xml)
                {
                    using (xmlWriter = new XmlTextWriter(streamWriter))
                    {
                        xmlWriter.WriteStartDocument();
                        xmlWriter.WriteStartElement("CATALOG");
                        xmlWriter.WriteWhitespace("\n");
                        foreach (IShape val in mas)
                        {
                            var type = val.GetType();
                            dynamic newVal = Convert.ChangeType(val, type);
                            xmlWriter.WriteStartElement("SHAPE");
                            xmlWriter.WriteElementString("TYPE", newVal.Type);
                            xmlWriter.WriteElementString("MATERIAL", newVal.Material.ToString());
                            xmlWriter.WriteElementString("COLOR", newVal.Color);
                            if (newVal.GetType() is Circle)
                                xmlWriter.WriteElementString("RADIUS", newVal.Radius);

                            xmlWriter.WriteElementString("SIDE", newVal.Side);
                            xmlWriter.WriteEndElement();
                            xmlWriter.WriteWhitespace("\n");
                        }
                        xmlWriter.WriteEndElement();
                        xmlWriter.WriteEndDocument();
                    }
                }
                else
                {
                    streamWriter.WriteLine("<CATALOG>");
                    foreach (IShape val in mas)
                    {
                        var type = val.GetType();
                        dynamic newVal = Convert.ChangeType(val, type);
                        streamWriter.Write(new string(' ', 2));
                        streamWriter.WriteLine("<SHAPE>");
                        streamWriter.WriteLine("\t" + "<TYPE>" + newVal.GetType().Name + "</TYPE>");
                        streamWriter.WriteLine("\t" + "<MATERIAL>" + newVal.Material.GetType().Name + "</MATERIAL>");
                        streamWriter.WriteLine("\t" + "<COLOR>" + newVal.Material.Color + "</COLOR>");
                        if (newVal is Circle)
                            streamWriter.WriteLine("\t" + "<RADIUS>" + newVal.Radius + "</RADIUS>");
                        else
                            streamWriter.WriteLine("\t" + "<SIDE>" + newVal.Side + "</SIDE>");
                        streamWriter.Write(new string(' ', 2));
                        streamWriter.WriteLine("</SHAPE>");
                    }
                    streamWriter.WriteLine("</CATALOG>");
                }
            }
        }

        /// <summary>
        /// Implementation of the Dispose pattern
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Memory clearing
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {                
                if (xmlReader != null)
                {
                    xmlReader.Close();
                    xmlReader = null;
                }
                if (streamReader != null)
                {                    
                    streamReader.Close();
                    streamReader = null;
                }
                if (xmlWriter != null)
                {
                    xmlWriter.Close();
                    xmlWriter = null;
                }
                if (streamWriter != null)
                {
                    streamWriter.Close();
                    streamWriter = null;
                }

                disposedValue = true;
            }
        }

        ~FileReader()
        {
            Dispose(false);
        }
    }
}
