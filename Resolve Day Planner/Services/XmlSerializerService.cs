using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using ResolveDayPlanner.Models;

namespace ResolveDayPlanner.Services
{
    class XmlSerializerService
    {
        public static void WriteToXmlFile<T>(T objectToWrite, bool append = false) where T : new()
        {
            TextWriter writer = null;
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "errand.xml");

            try
            {
                var serializer = new XmlSerializer(typeof(T));
                writer = new StreamWriter(filePath, append, Encoding.UTF8);
                serializer.Serialize(writer, objectToWrite);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

        public static T ReadFromXmlFile<T>() where T : new()
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "errand.xml");
            TextReader reader = null;
            
            try
            {
                var serializer = new XmlSerializer(typeof(T), new XmlRootAttribute("ArrayOfErrand"));
                reader = new StreamReader(filePath);
                return (T)serializer.Deserialize(reader);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }

        public static void AppendToXmlFile(Errand obj)
        {
            List<Errand> errands = ReadFromXmlFile<List<Errand>>();
            errands.Add(obj);
            WriteToXmlFile(errands);
        }
    }
}
