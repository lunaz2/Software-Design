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
    public class StringWriterWithRemoveDuplicateOperatorTest : StringWriterTest
    {

        protected override void SetWriterOperators(BaseWriter writer)
        {
            writer.SetOperators(input => RemoveDuplicateOperator.Transform(input));
        }

        protected override string GetInput()
        {
            return "something random random ";
        }
        protected override string GetExpected()
        {
            return "something random ";
        }
    }
}
