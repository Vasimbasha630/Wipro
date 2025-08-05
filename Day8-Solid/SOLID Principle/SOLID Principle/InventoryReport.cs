using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Principle
{
    public class InventoryReport:Report
    {
        public override string GenerateContent()
        {
            return "Inventory report content: Stock levels, Reorder points.";
        }
    }
}
