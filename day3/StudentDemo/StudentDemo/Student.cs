using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace StudentDemo
{
    public class Student
    {
        public int id;
        public string name;
        public double salary;

        public Student() { }

        public Student(int id, string name, double salary)
        {
            this.id = id;
            this.name = name;
            this.salary = salary;            
        }
        public override string ToString()
        {
            return "sid"+id+"name"+name+"salary"+salary;
        }
    }
}
