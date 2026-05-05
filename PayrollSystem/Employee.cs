using System;
using System.Collections.Generic;
using System.Linq;

namespace PayrollSystem
{
    // Базовий клас
    public abstract class Employee
    {
        public string Name { get; set; }
        public string Address { get; set; }

        protected Employee(string name, string address)
        {
            Name = name;
            Address = address;
        }

        // Поліморфний метод
        public abstract decimal CalculateMonthlySalary();

        // Допоміжний метод для звіту
        public abstract string GetEmployeeType();
    }
}