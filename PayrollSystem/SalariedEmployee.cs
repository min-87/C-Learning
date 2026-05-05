using System;
using System.Collections.Generic;
using System.Linq;

namespace PayrollSystem
{
    public class SalariedEmployee : Employee
    {
        public decimal MonthlySalary { get; set; }
        public decimal LoadFactor { get; set; } // коефіцієнт завантаженості

        public SalariedEmployee(string name, string address, decimal monthlySalary, decimal loadFactor)
            : base(name, address)
        {
            MonthlySalary = monthlySalary;
            LoadFactor = loadFactor;
        }

        public override decimal CalculateMonthlySalary()
        {
            return MonthlySalary * LoadFactor;
        }

        public override string GetEmployeeType() => "Штатний";
    }

}
