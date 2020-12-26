using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace XMLHelper
{
    public static class XMLHelpper
    {
        public static void WriteXML<T>(string path, object data)
        {
            Stream fs = null;
            XmlWriter writer = null;
            try
            {
                string dirPath = Path.GetDirectoryName(path);
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                }

                XmlSerializer serializer = new XmlSerializer(typeof(T));

                // Create an XmlTextWriter using a FileStream.
                fs = new FileStream(path, FileMode.Create);
                writer = XmlWriter.Create(fs, new XmlWriterSettings { Indent = true });

                // Serialize using the XmlTextWriter.
                serializer.Serialize(writer, data);
                writer.Close();
                fs.Close();
            }
            finally
            {
                if(writer != null)
                {
                    writer.Close();
                }
                if (fs != null)
                {
                    fs.Close();
                }
            }           
        }

        public static T ReadXML<T>(string path)
        {
            if (!File.Exists(path))
            {
                return default;
            }

            try
            {
                // Create an instance of the XmlSerializer specifying type and namespace.
                XmlSerializer serializer = new XmlSerializer(typeof(T));

                // A FileStream is needed to read the XML document.
                FileStream fs = new FileStream(path, FileMode.Open);
                XmlReader reader = XmlReader.Create(fs);

                // Use the Deserialize method to restore the object's state.
                T result = (T)serializer.Deserialize(reader);
                reader.Close();
                fs.Close();

                return result;
            }
            catch
            {
                return default;
            }
        }
    }
}
