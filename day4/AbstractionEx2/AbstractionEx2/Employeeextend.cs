using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionEx2
{
    internal class Employeeextend : Employee
    {
        public override void id()
        {
            Console.WriteLine("The id is 101");
        }

        public override void name()
        {
            Console.WriteLine("The name is vasim");

        }
    }
}
