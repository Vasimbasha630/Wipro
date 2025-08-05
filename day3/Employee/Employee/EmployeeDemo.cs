using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    public class EmployeeDemo
    {
        public int id;
        public string name;

        public EmployeeDemo() { }

        public EmployeeDemo(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public override string ToString()
        {
            return "The id is"+ id + "The name"+name;
        }

    }
}
