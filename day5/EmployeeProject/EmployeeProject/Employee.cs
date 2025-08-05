using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProject
{
    [Serializable]
    public class Employee
    {
        public int Empno { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }

        public string Dept { get; set; }
        public string Desig { get; set; }
        public double Basic { get; set; }

        public Employee() { }

        public Employee(int empno, string name, string gender, string dept, string design, double basic)
        {
            Empno = empno;
            Name = name;
            Gender = gender;
            Dept = dept;
            Desig = design;
            Basic = basic;
        }
        public override string ToString()
        {
            return "Employee No" + Empno +
                   "Emp Name" + Name +
                   "Emp Gender" + Gender +
                   "Emp Dept" + Dept +
                   "Emp Design" + Desig +
                   "Emp Basic" + Basic;
        }
    }
}
