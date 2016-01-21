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
    class StringWriterWithNoOperatorsTest : StringWriterTest
    {
        protected override void SetWriterOperators(BaseWriter writer)
        {
        }

        protected override string GetInput()
        {
            return "SomeTHING really really stupid";
        }

        protected override string GetExpected()
        {
            return "SomeTHING really really stupid";
        }
    }
}
