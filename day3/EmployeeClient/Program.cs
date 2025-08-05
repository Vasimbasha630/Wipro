using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee;

namespace EmployeeClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeDemo demo = new EmployeeDemo();

            demo.id = 10;
            demo.name = "Vasim";
            Console.WriteLine(demo.id);
            Console.WriteLine(demo.name);
        }
    }
}
