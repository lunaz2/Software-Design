using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FibonacciCalculator;
using System.Diagnostics;


namespace FibonacciCalculatorTest
{
    class MemoizedRecursiveFibonacciTest : FibonacciTest
    {
        protected override IFibonacci createFibonacci()
        {
            return new MemoizedRecursiveFibonacci();
        }

        protected long getTime(IFibonacci fibonacci, int number)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            fibonacci.getNthFibonacci(number);
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        [Test]
        public void memoizedVersionIsFasterThanRecursiveVersionByAtLeastOneOrderOfMagnitude()
        {
          Assert.IsTrue(getTime(new RecursiveFibonacci(), 40) > getTime(new MemoizedRecursiveFibonacci(), 40) * 10);
        }
    }
}
