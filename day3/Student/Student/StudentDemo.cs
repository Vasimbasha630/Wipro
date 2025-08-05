using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    public class StudentDemo
    {
        public int id;
        public string name;
        public double salary;

        public StudentDemo()
        {

        }

        public StudentDemo(int id, string name, double salary)
        {
            this.id = id;
            this.name = name;
            this.salary = salary;
        }
        public override string ToString()
        {
            return "student id" + id + "Student name" + name + "Student salary" + salary;
        }
    }
}
