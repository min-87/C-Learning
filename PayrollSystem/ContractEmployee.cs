using System;
using System.Collections.Generic;
using System.Linq;

namespace PayrollSystem
{
    // 3. Контрактник
    public class ContractEmployee : Employee
    {
        public decimal ContractValue { get; set; }
        public int DurationMonths { get; set; }

        public ContractEmployee(string name, string address, decimal contractValue, int durationMonths)
            : base(name, address)
        {
            ContractValue = contractValue;
            DurationMonths = durationMonths;
        }

        public override decimal CalculateMonthlySalary()
        {
            if (DurationMonths <= 0) return 0;
            return ContractValue / DurationMonths;
        }

        public override string GetEmployeeType() => "Контрактний";
    }
}
