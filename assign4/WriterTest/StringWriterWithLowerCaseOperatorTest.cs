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
    public class StringWriterWithLowerCaseOperatorTest : StringWriterTest
    {
        protected override void SetWriterOperators(BaseWriter writer)
        {
            writer.SetOperators(input => LowerCaseOperator.Transform(input));
        }

        protected override string GetInput()
        {
            return "RANDOM ";
        }
        protected override string GetExpected()
        {
            return "random ";
        }
    }
}
