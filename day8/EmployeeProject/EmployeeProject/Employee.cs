using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProject
{
    public class Employee
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public double Basic {  get; set; }

        public Employee() { }

        public Employee(int id, string name, double basic)
        {
            Id = id;
            Name = name;
            Basic = basic;
        }
        public override string ToString()
        {
            return "Id " + Id + " Name " + Name + " Basic " + Basic;
        }
    }
}
