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
    public class LowerCaseOperatorTest
    {
        [Test]
        public void ConvertStringToLowerCase()
        {
            Assert.AreEqual("random!", LowerCaseOperator.Transform("RanDom!"));
        }
    }
}
