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
    public class FileWriterWithLowerCaseAndStupidReplaceTest : FileWriterTest
    {
        protected override void SetWriterOperators(BaseWriter writer)
        {
            writer.SetOperators(input => LowerCaseOperator.Transform(input), input => StupidReplaceOperator.Transform(input));
        }

        protected override string GetInput()
        {
            return "Multiple Operations Test - Lower and Stupid: SOMETHING stupid \n";
        }
    }
}
