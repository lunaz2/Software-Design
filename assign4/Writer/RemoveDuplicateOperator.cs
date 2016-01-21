using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Writer
{
    public static class RemoveDuplicateOperator
    {
        public static string Transform(string inputString)
        {
            return string.Join(" ", inputString.Split(' ').Distinct());
        }
    }
}
