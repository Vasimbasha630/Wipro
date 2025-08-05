using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProject
{
    public class EmployeeDao
    {
        static List<Employee> list;

        static EmployeeDao()
        {
            list = new List<Employee>()
            {
                new Employee{Id=1,Name="Vasim",Basic=8888},
                new Employee{Id=2,Name="Basha",Basic=8889},

            };
        }
        public List<Employee> ShowEmployee()
        {
            return list;
        }

        public Employee SearchEmployee(int id)
        {
            Employee e = null;
            foreach (Employee employee in list)
            {
                if (employee.Id == id)
                {
                    {
                        e = employee;
                    }

                }                



            }
            return e;



        }
    }

}
