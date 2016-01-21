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
    class FileWriterWithNoOperatorsTest : FileWriterTest
    {
        protected override void SetWriterOperators(BaseWriter writer)
        {
        }

        protected override string GetInput()
        {
            return "No Operators Test: SomeTHING really really stupid\n";
        }
    }
}
