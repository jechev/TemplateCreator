using System;


namespace TemplateCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "STOP")
            {
                input = char.ToUpper(input[0]) + input.Substring(1);
                TemplateCreator template = new TemplateCreator(input);
                template.CreateRepositoryAndServiceTemplates();

                input = Console.ReadLine();
            }
        }
    }
}
