using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticClassEx
{
    static class Program
    {
        public static void show()
        {
            Console.WriteLine("Show Method fro program class");
        }
        public static void Trainer()
        {
            Console.WriteLine("This is Dot net training");
        }
        static void Main(string[] args)
        {
            Program.Trainer();
            Program.show();


        }
    }
}