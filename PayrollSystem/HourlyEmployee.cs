using System;
using System.Collections.Generic;
using System.Linq;

namespace PayrollSystem
{
    // 2. Погодинний співробітник
    public class HourlyEmployee : Employee
    {
        public decimal HoursWorked { get; set; }
        public decimal HourlyRate { get; set; }

        public HourlyEmployee(string name, string address, decimal hoursWorked, decimal hourlyRate)
            : base(name, address)
        {
            HoursWorked = hoursWorked;
            HourlyRate = hourlyRate;
        }

        public override decimal CalculateMonthlySalary()
        {
            return HoursWorked * HourlyRate;
        }

        public override string GetEmployeeType() => "Погодинний";
    }
}