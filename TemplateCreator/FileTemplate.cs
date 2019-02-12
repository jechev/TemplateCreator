using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateCreator
{
    public class FileTemplate
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public string ComponentName { get; set; }

        public string FileExtension { get; set; }

        public string Content { get; set; }
    }
}
