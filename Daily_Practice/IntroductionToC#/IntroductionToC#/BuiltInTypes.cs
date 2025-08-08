using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToC_
{
    internal class BuiltInTypes
    {
        static void Main()
        {
            bool name = true;
            Console.WriteLine(name);

            //The built-in data types are the
            //int,float,bool,short,long,double,char
            int i = 12;
            Console.WriteLine("The value is"+i);
            float f = 20.2f;
            Console.WriteLine("The float value is"+f);
            double d = 20.2;
            Console.WriteLine("The double value is" + d);

            char c = 'a';
            Console.WriteLine("The char value is"+c);
        }
    }
}
