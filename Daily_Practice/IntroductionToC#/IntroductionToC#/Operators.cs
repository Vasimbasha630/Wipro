using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToC_
{
    //Assignment Operator =
    //Airthemetic Operator +,-,*,/,%
    //Comparision Operator ==,!=,>,>=,<,<=
    //Conditional Operator &&, ||
    //Ternary operator ?:
    //Null coalescing Operator ??

    internal class Operators
    {
        static void Main()
        {
            int i = 10;
            int j = 20;
            int result = i + j;
            Console.WriteLine("The value of two numbers is" + result);
            string a = "Vasim";
            string b = "Vasim";
            if (a == b)
            {
                Console.WriteLine("The values are two same");
            }
            else
            {
                Console.WriteLine("Not");
            }
        }

    }
}
