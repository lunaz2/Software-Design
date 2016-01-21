using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciCalculator
{
    public class IterativeFibonacci : IFibonacci
    {
        public int getNthFibonacci(int number)
        {
            if (number < 0) return -1;
            if (number < 2) return 1;
            return Enumerable.Range(2, number - 1).Select(index => Tuple.Create(1, 1))
                   .Aggregate(Tuple.Create(1, 1), (series, ignore) => Tuple.Create(series.Item2, series.Item2 + series.Item1))
                   .Item2;
        }

    }
}
