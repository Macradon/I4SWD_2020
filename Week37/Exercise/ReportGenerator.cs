using System;
using System.Collections.Generic;

namespace ReportGenerator
{
    public enum ReportOutputFormatType
    {
        NameFirst,
        SalaryFirst
    }

    internal class ReportGenerator
    {
        private ReportCompiler _reportCompiler;
        private ReportOutputFormatType _currentOutputFormat;

        public ReportGenerator(ReportCompiler reportCompiler)
        {
            _currentOutputFormat = ReportOutputFormatType.NameFirst;
            _reportCompiler = reportCompiler;
        }

        public void SetOutputFormat(ReportOutputFormatType format)
        {
            _currentOutputFormat = format;
        }

        public void GenerateReport()
        {
            _reportCompiler.CompileReport(_currentOutputFormat);
        }
    }
}