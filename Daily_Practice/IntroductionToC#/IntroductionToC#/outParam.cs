using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToC_
{
    internal class outParam
    {
        public static void Cal(int x, int y, out int sum,out int pro)
        {
            sum = x + y;
            pro = x * y;
        }
        static void Main()
        {
            int sum = 0;
            int pro = 0;
            Cal(10, 20,out sum, out pro);
            Console.WriteLine("The sum = {0} && product = {1}", sum,pro);
        }
    }
}
