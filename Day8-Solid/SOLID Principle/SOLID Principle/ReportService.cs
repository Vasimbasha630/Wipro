using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Principle
{
    public class ReportService
    {
        private readonly ReportGenerator _generator;
        private readonly IReportSaver _saver;

        public interface IReportSaver
        {
            void Save(string report);
        }

        // Dummy ReportGenerator class for example
        public class ReportGenerator
        {
            public string Generate()
            {
                return "Sample Report Content";
            }
        }

        internal interface IReportSaver
        {
            void Save(string report);
        }

        public ReportService(ReportGenerator generator, IReportSaver saver)
        {
            _generator = generator;
            _saver = saver;
        }

        public ReportService(ReportGenerator generator, IReportSaver saver)
        {
            _generator = generator ?? throw new ArgumentNullException(nameof(generator));
            _saver = saver ?? throw new ArgumentNullException(nameof(saver));
        }
        public void GenerateAndSaveReport()
        {
            string report = _generator.Generate();
            _saver.Save(report);
        }
    }
}
