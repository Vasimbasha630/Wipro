using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LamdaExpr1
{
    internal class EmployeeSort
    {
        static void Main()
        {
            List<Employee> list = new List<Employee>
            {
                new Employee{id=12,name="Rajesh",basic=88323},
                new Employee{id=2,name="Venkata",basic=91133},
                new Employee{id=33,name="Uday",basic=80022},
                new Employee{id=14,name="Pallavi",basic=90321},
                new Employee{id=25,name="Pralavi",basic=78822},
                new Employee{id=6,name="Anusha",basic=78823},
            };
            list.Sort();
            Console.WriteLine("Sorted data(default w.r.t Employee no)");
            list.Sort();
            Console.WriteLine("Sorted Data (default w.r.t. Empno)  ");
            var result1 = list.Select(x => x);
            foreach (var v in result1)
            {
                Console.WriteLine(v);
            }

            Console.WriteLine("Sort by Name-wise  ");
            list.Sort(new NameComparer());
            var result2 = list.Select(x => x);
            foreach (var v in result2)
            {
                Console.WriteLine(v);
            }
            Console.WriteLine("Sort By Basic-Wise ");
            list.Sort(new BasicComparer());
            foreach (var v in list)
            {
                Console.WriteLine(v);
            }
        }
    }

}
