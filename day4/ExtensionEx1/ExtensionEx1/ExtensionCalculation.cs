using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionEx1
{
    internal static class ExtensionCalculation
    {
        public static int mul(this Calculation cal, int a, int b)
        {
            return a * b;
        }
    }
}
