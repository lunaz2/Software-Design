using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Writer
{
    public class StringWriter : BaseWriter
    {
        private StringBuilder writerString = new StringBuilder();

        public override string GetWriterString()
        {
            return writerString.ToString();
        }

        public override void Write(string input)
        {
            writerString.Append(base.Transform(input));
        }

    }
}
