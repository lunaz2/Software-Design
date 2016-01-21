using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Writer
{
    public static class StupidReplaceOperator
    {
        public static string Transform(string inputString)
        {
            return inputString.Replace("stupid", "s*****");
        }
    }
}
