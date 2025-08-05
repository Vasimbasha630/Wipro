using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionEx2
{
    internal class Program
    {
        static void Main(string[] args)
        {
           // abstract_class obj = new derived_class();
            Employee e = new Employeeextend();
            e.show();
            e.id();
            e.name();


        }
    }
}
