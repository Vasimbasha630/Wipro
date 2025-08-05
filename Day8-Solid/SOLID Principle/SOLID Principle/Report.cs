using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Principle
{
    public abstract class Report:IReportContentGenerator
    {
        public abstract string GenerateContent();
    }
}
