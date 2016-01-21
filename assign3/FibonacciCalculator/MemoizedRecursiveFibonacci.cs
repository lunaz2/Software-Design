using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciCalculator
{
    public class MemoizedRecursiveFibonacci : RecursiveFibonacci
    {
        private Dictionary<int, int> memoizedFibonnaciValues = new Dictionary<int, int>();
        
        public override int getNthFibonacci(int number)
        {
            if(!memoizedFibonnaciValues.ContainsKey(number))
                memoizedFibonnaciValues.Add(number, base.getNthFibonacci(number));
            return memoizedFibonnaciValues[number];
        }
    }
}
