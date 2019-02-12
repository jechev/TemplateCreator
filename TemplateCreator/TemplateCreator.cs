using System;
using System.IO;
using Humanizer;

namespace TemplateCreator
{
    public  class TemplateCreator
    {
        private readonly string pathForTemplates = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())) + "/output/";

        public TemplateCreator()
        {

        }

        private void CreateFolder(string path)
        {
            bool folderExists = Directory.Exists(path);
            if (!folderExists)
            {
                Directory.CreateDirectory(path);
            }
        }

        public void CreateFile(FileTemplate template)
        {
            string fullPath;
            string namePlural = template.Name.Pluralize();
            if (String.IsNullOrEmpty(template.Path))
            {
                fullPath = this.pathForTemplates + template.ComponentName.Pluralize()  + "/";
            } else
            {
                fullPath = this.pathForTemplates + template.ComponentName.Pluralize() + "/" + template.Path + "/";
            }

            string file = fullPath + namePlural + template.ComponentName + "." + template.FileExtension;
            
            this.CreateFolder(fullPath);

            if (!File.Exists(file))
            {
                using (StreamWriter sw = File.CreateText(file))
                {

                    if (String.IsNullOrEmpty(template.Content))
                    {
                        sw.WriteLine("This is " + template.ComponentName + "Template for " + template.Name + ", " + namePlural + ".");
                    }
                    else
                    {
                        sw.WriteLine(template.Content);
                    }
                }
                Console.WriteLine(namePlural + template.ComponentName + " is created!");
            }
            else
            {
                Console.WriteLine(namePlural + template.ComponentName + " exists!");
            }
        }

    }
}
