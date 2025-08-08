using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToCSharp
{
    internal class ReadInputFromConsloe
    {
        static void Main()
        {
            Console.WriteLine("Enter the user name");
            string name;
            name= Console.ReadLine();
           // Console.WriteLine("The name is"+name);
            //Another way to execute without using concate
            Console.WriteLine("The name is {0}",name);
        }
    }
}
