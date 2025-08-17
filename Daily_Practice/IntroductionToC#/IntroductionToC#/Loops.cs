using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToC_
{
    internal class Loops
    {
        //While loop checks the condition first
        //If the condition is true, statements with in the loop are executed
        //This process is repeated as long as the condition evalutates to true.
        static void Main()
        {
            Console.WriteLine("enter the target number");
            int i = Convert.ToInt32(Console.ReadLine());
            int start = 0;
            while(start<=i)
            {
                Console.WriteLine(start);
                start++;
            }

        }
    }
}
