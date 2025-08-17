using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToC_
{
    internal class forandforeachdemo
    {
        static void Main()
        {
            Console.WriteLine("Enter the a value");
            int a;
            a=Convert.ToInt32(Console.ReadLine());
            for(int i=0;i<a;i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
