using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticEx2
{
    internal class Program
    {
        static int count;
        public void Incremanet()
        {
            count++;
        }
        public void show()
        {
            Console.WriteLine("Count is"+count);
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Incremanet();
            p.show();

        }
    }
}
