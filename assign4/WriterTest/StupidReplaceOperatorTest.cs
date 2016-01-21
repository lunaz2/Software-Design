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
    public class StupidReplaceOperatorTest
    {

        [Test]
        public void replaceStupid()
        {
            Assert.AreEqual("s*****!", StupidReplaceOperator.Transform("stupid!"));
        }

        [Test]
        public void replaceStupidWithUpperCaseStupid()
        {
            Assert.AreEqual("Stupid!", StupidReplaceOperator.Transform("Stupid!"));
        }

        [Test]
        public void replaceStupidWithNoStupidInString()
        {
            Assert.AreEqual("Something!", StupidReplaceOperator.Transform("Something!"));
        }
    }
}
