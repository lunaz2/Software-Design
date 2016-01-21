using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Writer;
using Rhino.Mocks;

namespace WriterTest
{
    [TestFixture]
    public abstract class FileWriterTest : BaseWriterTest
    {
        protected override BaseWriter GetWriter()
        {
            return MockRepository.GenerateStub<FileWriter>("text.txt");
        }

        protected override void Verify(params string[] verifyString)
        {
            writer.AssertWasCalled(s => s.Write(Arg<string>.Is.Anything), options => options.Repeat.Times(verifyString.Count()));
        }
    }
}
