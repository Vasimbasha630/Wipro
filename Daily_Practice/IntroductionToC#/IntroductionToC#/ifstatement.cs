using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToC_
{
    internal class ifstatement
    {
        static void Main()
        {
            Console.WriteLine("Enter the user number");
            int i;
            i = Convert.ToInt32(Console.ReadLine());
            if(i>18)
            {
                Console.WriteLine("Elligible for vote and his age is above 18" +i);
            }
            else
            {
                Console.WriteLine("not elligible");
            }
        }
    }
}
