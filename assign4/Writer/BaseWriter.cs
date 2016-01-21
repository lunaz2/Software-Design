using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Writer
{
    public abstract class BaseWriter
    {
        private List<Func<string, string>> transformers = new List<Func<string, string>>();

        public void SetOperators(params Func<string, string>[] theTransfrormers)
        {
            transformers = theTransfrormers.ToList();
        }

        public string Transform(string input)
        {
            return transformers.Aggregate(input.ToString(), (newString, transformer) => transformer.Invoke(newString.ToString()));
        }

        public abstract void Write(string input);
        public abstract string GetWriterString();
    }
}
