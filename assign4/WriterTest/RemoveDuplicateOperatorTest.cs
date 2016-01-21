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
    public class RemoveDuplicateOperatorTest
    {
        [Test]
        public void RemoveDuplicate()
        {
            Assert.AreEqual("Something really random!", RemoveDuplicateOperator.Transform("Something really really random!"));
        }

        [Test]
        public void RemoveDuplicateWithNoDuplication()
        {
            Assert.AreEqual("Something really random!", RemoveDuplicateOperator.Transform("Something really random!"));
        }
    }
}
