using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToC_
{
    internal class doWhileLoop
    {
        static void Main()
        {
            int number=1;

            do
            {     
              Console.WriteLine(number);
              number++;
            } while (number < 10);
        }
    }
}
