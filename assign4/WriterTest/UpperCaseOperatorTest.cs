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
    public class UpperCaseOperatorTest
    {
        [Test]
        public void ConvertStringToUpperCase()
        {
            Assert.AreEqual("RANDOM!", UpperCaseOperator.Transform("random!"));
        }
    }
}
