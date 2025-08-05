using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticMethodEx
{
    internal class Data
    {
        public void show()
        {
            Console.WriteLine("Show method from Data");
        }
        public static void Dispaly()
        {
            Console.WriteLine("Display Method from Class Data");

        }
        static void Main(string[] args)
        {
            Data data = new Data();
            data.show();
            Data.Dispaly();

        }
    }
}
