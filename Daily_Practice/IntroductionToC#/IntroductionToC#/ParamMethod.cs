using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToC_
{
    internal class ParamMethod
    {
        public static void Param(params int[] Numbers)
        {
            Console.WriteLine(Numbers.Length);
            foreach (int i in Numbers)
            {
                {
                    Console.WriteLine(i);
                }
            }
        }
       static void Main()
       {
            int[] Numbers = new int[3];
            Numbers[0] = 1;
            Numbers[1] = 2;
            Numbers[2] = 3;
            Param();
            Param(Numbers);
       }
    }
}
