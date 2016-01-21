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
    public class StringWriterWithUpperCaseOperatorTest : StringWriterTest
    {
        protected override void SetWriterOperators(BaseWriter writer)
        {
            writer.SetOperators(input => UpperCaseOperator.Transform(input));
        }

        protected override string GetInput()
        {
            return "random ";
        }
        protected override string GetExpected()
        {
            return "RANDOM ";
        }
    }
}
