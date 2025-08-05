using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Principle
{
    class Program
    {
        static void Main(string[] args)
        {
            Report salesReport = new SalesReport();
            IReportFormatter pdfFormatter = new PdfFormatter();
            var generator = new ReportGenerator(salesReport, pdfFormatter);
            IReportSaver saver = new ReportSaver();

            var reportService = new ReportService(generator, saver);
            reportService.GenerateAndSaveReport();

            Console.WriteLine("\n-----\n");

            // Create Inventory report with Excel format
            Report inventoryReport = new InventoryReport();
            IReportFormatter excelFormatter = new ExcelFormatter();
            generator = new ReportGenerator(inventoryReport, excelFormatter);

            reportService = new ReportService(generator, saver);
            reportService.GenerateAndSaveReport();
        }
    }
}
