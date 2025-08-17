using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToC_
{
    internal class MethodParam2
    {
        public static void Sim(ref int j)
        {
            j = 101;

        }
        
        public static void Main()
        {
            int i = 0;
            
            MethodParam2.Sim(ref i);
            Console.WriteLine(i);

        }
    }
}
