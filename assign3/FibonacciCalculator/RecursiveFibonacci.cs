using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciCalculator
{
    public class RecursiveFibonacci : IFibonacci
    {
        public virtual int getNthFibonacci(int number)
        {
            if (number < 0) return -1;
            if (number < 2) return 1;
            return getNthFibonacci(number - 1) + getNthFibonacci(number - 2);
        }
    }
}
