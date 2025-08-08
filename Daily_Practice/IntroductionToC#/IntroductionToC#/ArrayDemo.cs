using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToC_
{
    internal class ArrayDemo
    {
        static void Main()
        {
            int[] evenNumbers = new int[3];
            evenNumbers[0] = 1;
            evenNumbers[1] = 2;
            evenNumbers[2] = 3;
           
            Console.WriteLine(evenNumbers[0]);
            Console.WriteLine(evenNumbers[1]);
            Console.WriteLine(evenNumbers[2]);
           

            //Advantage
            //Arrays are strongly typed.
            //Disadvantage
            //Arrays cannot grow in size once initialized
            //Have to rely on integral indices to store or retrieve items
            //from the array.
        }
    }
}
