using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FibonacciCalculator;

namespace FibonacciCalculatorTest
{
    [TestFixture]
    public class RecursiveFibonacciTest : FibonacciTest
    {
        protected override IFibonacci createFibonacci()
        {
           return new RecursiveFibonacci();
        }

        public class RecursiveTester : RecursiveFibonacci
        {
            public int Call { get; set; }

            public override int getNthFibonacci(int number)
            {
                Call++;
                return base.getNthFibonacci(number);
            }
        }

        [Test]
        public void getNthFibonacciIsCalled5TimesWith3()
        {
            var recursiveTester = new RecursiveTester();
            recursiveTester.getNthFibonacci(3);
            Assert.AreEqual(5, recursiveTester.Call);
            
        }
    }
}
