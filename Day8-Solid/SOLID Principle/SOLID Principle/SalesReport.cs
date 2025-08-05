using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Principle
{
    public class SalesReport:Report
    {
        public override string GenerateContent()
        {
            return "Sales report content: Total sales, Revenue, Profit.";
        }

    }
}
