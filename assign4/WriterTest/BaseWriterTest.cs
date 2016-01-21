using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Writer;

namespace WriterTest
{
    public abstract class BaseWriterTest
    {
        protected BaseWriter writer;

        protected abstract void SetWriterOperators(BaseWriter writer);
        protected abstract string GetInput();
        protected abstract BaseWriter GetWriter();
        protected abstract void Verify(params string[] verifyString);

        [SetUp]
        public void SetUp()
        {
            writer = GetWriter();
            SetWriterOperators(writer);
        }

        [Test]
        public void WriteToWriter()
        {
            writer.Write(GetInput());
            Verify(GetInput());
        }

        [Test]
        public void WriteAppendToWriter()
        {
            writer.Write(GetInput());
            writer.Write(GetInput());
            Verify(GetInput(), GetInput());
        }
    }
}
