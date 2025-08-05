using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircketEx
{
    internal class Program
    {
        static int score;
        public void Increment(int x)
        {
            score++;
        }

        static void Main(string[] args)
        {
            {
                Program fb = new Program();
                Program sb = new Program();
                Program ext = new Program();

                fb.Increment(14);
                sb.Increment(9);
                ext.Increment(11);

                Console.WriteLine("Total Score  " + Program.score);
            }
        }
    }
}
