using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Principle
{
    public class ReportGenerator
    {
        public interface IReportContentGenerator
        {
            string GenerateContent();
        }

        public interface IReportFormatter
        {
            string Format(string content);
        }

        private readonly IReportContentGenerator _report;
        private readonly IReportFormatter _formatter;
        private Report salesReport;
        private SOLID_Principle.IReportFormatter pdfFormatter;

        public ReportGenerator(IReportContentGenerator report, IReportFormatter formatter)
        {
            _report = report;
            _formatter = formatter;
        }

        public ReportGenerator(Report salesReport, SOLID_Principle.IReportFormatter pdfFormatter)
        {
            this.salesReport = salesReport;
            this.pdfFormatter = pdfFormatter;
        }

        public string Generate()
        {
            var content = _report.GenerateContent();
            return _formatter.Format(content);
        }
    }
}
