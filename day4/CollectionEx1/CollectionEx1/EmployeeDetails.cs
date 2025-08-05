using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionEx1
{
    internal class EmployeeDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return "The id is" + Id + "name is " + Name + "The age is" + Age;
        }
    }
}
