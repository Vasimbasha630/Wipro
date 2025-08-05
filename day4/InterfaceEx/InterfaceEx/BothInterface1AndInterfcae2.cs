using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceEx
{
    internal class BothInterface1AndInterfcae2 : Interface1, Interface2
    {
        public void display()
        {
            Console.WriteLine("This is Display method");
        }

        public void show()
        {
            Console.WriteLine("This is Show Method");
        }
    }
}
