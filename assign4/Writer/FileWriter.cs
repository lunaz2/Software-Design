using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Writer
{
    public class FileWriter : BaseWriter
    {
        private string filePath;

        public FileWriter(string theFilePath)
        {
            filePath = theFilePath;
        }

        public override void Write(string input)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.Write(base.Transform(input));
            } 
        }

        public override string GetWriterString() { return null; }
    }
}
