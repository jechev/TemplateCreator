using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace TemplateCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())) + "\\templates.xml";
            string fileString = System.IO.File.ReadAllText(file);
            XmlSerializer serializer = new XmlSerializer(typeof(List<FileTemplate>), new XmlRootAttribute("FileTemplates"));
            StringReader stringReader = new StringReader(fileString);

            TemplateCreator templateCreator = new TemplateCreator();

            List<FileTemplate> fileTemplateList = (List<FileTemplate>)serializer.Deserialize(stringReader);
            foreach (var template in fileTemplateList)
            {
                templateCreator.CreateFile(template);
            }

        }
    }

}
