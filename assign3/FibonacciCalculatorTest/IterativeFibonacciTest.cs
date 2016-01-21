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
    class IterativeFibonacciTest : FibonacciTest
    {
        protected override IFibonacci createFibonacci()
        {
            return new IterativeFibonacci();
        }
    }
}
