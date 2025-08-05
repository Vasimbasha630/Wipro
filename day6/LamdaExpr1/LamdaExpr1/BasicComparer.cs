using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LamdaExpr1
{
    internal class BasicComparer : Comparer<Employee>

    {
        public override int Compare(Employee x, Employee y)
        {
            if (x.basic >= y.basic)
            {
                return -1;
            }
            return -1;
        }
        
    }
}
