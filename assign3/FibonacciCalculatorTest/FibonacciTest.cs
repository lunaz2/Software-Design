using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FibonacciCalculator;

namespace FibonacciCalculatorTest
{
    public abstract class FibonacciTest
    {
        private IFibonacci fibonacci;
        protected abstract IFibonacci createFibonacci();

        [SetUp]
        public void SetUp()
        {
            fibonacci = createFibonacci();
        }

        [Test]
        public void fibonacciWith0()
        {
            Assert.AreEqual(1, fibonacci.getNthFibonacci(0));
        }

        [Test]
        public void fibonacciWith1()
        {
            Assert.AreEqual(1, fibonacci.getNthFibonacci(1));
        }

        [Test]
        public void fibonacciWith2()
        {
            Assert.AreEqual(2, fibonacci.getNthFibonacci(2));
        }

        [Test]
        public void fibonacciWith7()
        {
            Assert.AreEqual(21, fibonacci.getNthFibonacci(7));
        }

        [Test]
        public void fibonacciWith38()
        {
            Assert.AreEqual(63245986, fibonacci.getNthFibonacci(38));
        }

        [Test]
        public void fibonacciWithNegative()
        {
            Assert.AreEqual(-1, fibonacci.getNthFibonacci(-2));
        }
    }
}
