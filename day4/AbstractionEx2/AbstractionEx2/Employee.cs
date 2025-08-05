using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionEx2
{
    internal abstract class Employee
    {
        public void show()
        {
            Console.WriteLine("The Employee name is vasim");
        }

        public abstract void id();
        public abstract void name();
    }
}
