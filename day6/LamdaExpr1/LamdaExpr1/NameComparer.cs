using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamdaExpr1
{
    internal class NameComparer : Comparer<Employee>
    {
        public override int Compare(Employee x, Employee y)
        {
            return x.name.CompareTo(y.name);
        }
    }
}
