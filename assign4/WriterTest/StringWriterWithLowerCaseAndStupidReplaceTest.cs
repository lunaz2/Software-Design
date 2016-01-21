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
    public class StringWriterWithLowerCaseAndStupidReplaceTest : StringWriterTest
    {
        protected override void SetWriterOperators(BaseWriter writer)
        {
            writer.SetOperators(input => LowerCaseOperator.Transform(input), input => StupidReplaceOperator.Transform(input));
        }

        protected override string GetInput()
        {
            return "RANDOM Stupid ";
        }
        protected override string GetExpected()
        {
            return "random s***** ";
        }
    }
}
