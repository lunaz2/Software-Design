using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Writer;

namespace WriterTest
{
    [TestFixture]
    public abstract class StringWriterTest : BaseWriterTest
    {
        protected override BaseWriter GetWriter()
        {
            return new StringWriter();
        }

        protected abstract string GetExpected();

        protected override void Verify(params string[] verifyString)
        {
            string expected = GetExpected();
            if (verifyString.Count() > 1) expected += GetExpected();

            Assert.AreEqual(expected, writer.GetWriterString());
        }   
    }
}
