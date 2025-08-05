using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionEx1
{
    internal class Employeeextension
    {
        static void Main()
        {
            EmployeeDetails details = new EmployeeDetails();
            details.Id = 1;
            details.Name = "Vasim";
            details.Age = 24;

            EmployeeDetails details1 = new EmployeeDetails();
            details1.Id = 2;
            details1.Name = "Basha";
            details1.Age = 30;

            ArrayList arrayList = new ArrayList();
            arrayList.Add(details);
            arrayList.Add(details1);
            foreach(Object o in arrayList)
            {
                Console.WriteLine(o);
            }
                 
        }
    }
}
