using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Principle
{
    public class PdfFormatter:IReportFormatter
    {
        public string Format(string content)
        {
            return $"*** PDF FORMAT ***\n{content}\n*** End PDF ***";
        }
    }
}
