using System;
using System.Collections.Generic;

namespace ReportGenerator
{
    internal class ReportCompiler
    {
        private readonly EmployeeDB _employeeDb;
        public ReportCompiler(EmployeeDB employeeDb)
        {
            if (employeeDb == null) throw new ArgumentNullException("employeeDb");
            _employeeDb = employeeDb;
        }
        public void CompileReport(ReportOutputFormatType reportFormat)
        {
            var employees = new List<Employee>();
            Employee employee;

            _employeeDb.Reset();

            // Get all employees
            while ((employee = _employeeDb.GetNextEmployee()) != null)
            {
                employees.Add(employee);
            }

            // All employees collected - let's output them
            switch (reportFormat)
            {
                case ReportOutputFormatType.NameFirst:
                    Console.WriteLine("Name-first report");
                    foreach (var e in employees)
                    {
                        Console.WriteLine("------------------");
                        Console.WriteLine("Name: {0}", e.Name);
                        Console.WriteLine("Salary: {0}", e.Salary);
                        Console.WriteLine("------------------");
                    }
                    break;

                case ReportOutputFormatType.SalaryFirst:
                    Console.WriteLine("Salary-first report");
                    foreach (var e in employees)
                    {
                        Console.WriteLine("------------------");
                        Console.WriteLine("Salary: {0}", e.Salary);
                        Console.WriteLine("Name: {0}", e.Name);
                        Console.WriteLine("------------------");
                    }
                    break;
            }
        }
    }
}