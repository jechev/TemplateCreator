using System;
using System.IO;
using Humanizer;

namespace TemplateCreator
{
    public class TemplateCreator
    {
        private string objectNameSingular;
        private string objectNamePlural;
        private const string repositoryText = "This is Repository Template for ";
        private const string serviceText = "Service Template for ";
        private readonly string appPath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));

        public TemplateCreator(string objectNameSingular)
        {
            this.objectNameSingular = objectNameSingular;
            this.ObjectNamePlural = objectNameSingular;
        }

        public string RepositoryPath
        {
            get { return this.appPath + "/output/Repositories/Test/"; }
        }

        public string ServicePath
        {
            get { return this.appPath + "/output/Services/"; }
        }

        public string ObjectNamePlural
        {
            get { return this.objectNamePlural; }
            set { this.objectNamePlural = value.Pluralize(); }
        }

        public void CreateSerivceTemplate()
        {
            this.CreateFolder(this.ServicePath);
            string filePath = this.ServicePath + this.objectNamePlural + "Service.txt";
            if (!File.Exists(filePath))
            {
                using (StreamWriter sw = File.CreateText(filePath))
                {
                    sw.WriteLine(serviceText + this.objectNameSingular + ", " + this.objectNamePlural + ".");
                }
                Console.WriteLine(this.ObjectNamePlural + "Service is created!");
            }
            else
            {
                Console.WriteLine(this.ObjectNamePlural + "Service exists!");
            } 
        }

        public void CreateRepositoryTemplate()
        {
            this.CreateFolder(this.RepositoryPath);
            string filePath = this.RepositoryPath + this.objectNamePlural + "Repository.cs";
            if (!File.Exists(filePath))
            {
                using (StreamWriter sw = File.CreateText(filePath))
                {
                    sw.WriteLine(repositoryText + this.objectNameSingular + ", " + this.objectNamePlural + ".");
                }
                Console.WriteLine(this.ObjectNamePlural + "Repository is created!");
            }
            else
            {
                Console.WriteLine(this.ObjectNamePlural + "Repository exists!");
            }
        }

        public void CreateRepositoryAndServiceTemplates()
        {
            this.CreateSerivceTemplate();
            this.CreateRepositoryTemplate();
        }

        private void CreateFolder(string path)
        {
            bool folderExists = Directory.Exists(path);
            if (!folderExists)
            {
                Directory.CreateDirectory(path);
            }
        }

    }
}
