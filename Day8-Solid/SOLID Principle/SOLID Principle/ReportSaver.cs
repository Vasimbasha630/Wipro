using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Principle
{
    public class ReportSaver : IReportSaver
    {
        public void Save(string formattedReport)
        {
            // For simplicity, just output to console instead of saving to file
            Console.WriteLine("Saving Report...");
            Console.WriteLine(formattedReport);
        }
    }
}
