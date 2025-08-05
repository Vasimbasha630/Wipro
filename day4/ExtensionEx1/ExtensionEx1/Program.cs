using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionEx1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculation ca = new Calculation();
            Console.WriteLine(ca.Sum(12,5));
            Console.WriteLine(ca.Sub(12, 5));
            Console.WriteLine(ca.mul(12,5));

        }
    }
}
