using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Principle
{
    public class ExcelFormatter : IReportFormatter

    {
        public string Format(string content)
        {
            return $"*** EXCEL FORMAT ***\n{content}\n*** End EXCEL ***";
        }
    }
}
