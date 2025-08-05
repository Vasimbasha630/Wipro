using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamdaExpr1
{
    internal class LambdaExpr1
    {
        static void Main()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee {id=1,name="Vasim",basic=885220},
                new Employee { id = 2, name = "Pravika", basic = 88520 },
                new Employee { id = 3, name = "Basha", basic = 8850 },
            };
            Console.WriteLine("Employee List");
            var result1 = employees.Select(x => x);
            foreach(var v in result1)
            {
                Console.WriteLine(v);
            }
            var result2 = employees.Select(x => new { x.name, x.basic });
            Console.WriteLine("Projected Fields are");
            foreach (var v in result2)
            {
                Console.WriteLine(v);
            }

            var result3 = employees.Where(x => x.basic >= 90000);
            Console.WriteLine("Salary > 90000 records are");
            foreach (var v in result3)
            {
                Console.WriteLine(v);
            }
            var result4 = employees.Where(x => x.name.StartsWith("P"));
            foreach (var v in result4)
            {
                Console.WriteLine(v);
            }




        }

    }
}
