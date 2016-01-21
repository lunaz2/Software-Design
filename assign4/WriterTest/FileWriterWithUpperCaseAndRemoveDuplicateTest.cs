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
    public class FileWriterWithUpperCaseAndRemoveDuplicateTest : FileWriterTest
    {
        protected override void SetWriterOperators(BaseWriter writer)
        {
            writer.SetOperators(input => UpperCaseOperator.Transform(input), input => RemoveDuplicateOperator.Transform(input));
        }

        protected override string GetInput()
        {
            return "Multiple Operations Test - Upper and Duplicate: SOMETHING stupid stupid \n";
        }
    }
}
