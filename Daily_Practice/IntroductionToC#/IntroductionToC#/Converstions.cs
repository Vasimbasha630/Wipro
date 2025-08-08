using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToC_
{
    internal class Converstions
    {
        static void Main()
        {


            //Implicit Casting(automatically)
            //char-->int-->long-->float-->double
            int i = 100;
            float f = i;
            Console.WriteLine(f);

            //Explicit Casting(manually)
            //double-->float-->long-->int-->char
            float f1 = 223.8f;
            int i1 = (int)f1;
            //int i1=Convert.ToInt32(i1);
            Console.WriteLine(i1);
            string s = "100";
            int j = int.Parse(s);
            Console.WriteLine(j);

        }
    }

}
