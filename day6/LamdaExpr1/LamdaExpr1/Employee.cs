using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamdaExpr1
{
    internal class Employee : IComparable<Employee>
    {
        public int id {  get; set; }
        public string name { get; set; }
        public double basic {  get; set; }


        public int CompareTo(Employee employee)
        {
            if(id>=employee.id)
            {
                return 1;
            }
            return -1;
           
        }

        public override string ToString()
        {
            return "Employee Numbwe" + id
                + "Employee Name" + name
                + "Employee Basics" + basic;
        }
    }
}
