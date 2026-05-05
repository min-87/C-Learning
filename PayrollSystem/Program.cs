using System;
using System.Collections.Generic;
using System.Linq;

namespace PayrollSystem
{

    public class Program
    {
        private static List<Employee> employees = new List<Employee>();

        static void Main(string[] args)
        {
            // User Story 1: Додавання співробітників
            AddEmployee("штатний", "Іван Петренко", "Київ, вул. Хрещатик 1", 45000m, 1.1m);
            AddEmployee("погодинний", "Олена Сидоренко", "Львів, пр. Свободи 5", 160m, 320m);
            AddEmployee("контрактний", "ТОВ 'Рішення'", "Одеса, вул. Дерибасівська 10", 120000m, 6);

            // Додаткові приклади
            AddEmployee("штатний", "Марія Коваленко", "Харків", 38000m, 0.95m);
            AddEmployee("погодинний", "Андрій Шевченко", "Дніпро", 140m, 280m);

            // User Story 2 + 3: Розрахунок та звіт
            GeneratePayrollReport();

            Console.WriteLine("\nНатисніть будь-яку клавішу для завершення...");
            Console.ReadKey();
        }

        // 6. Додавання співробітника за типом
        public static void AddEmployee(string type, string name, string address, params object[] parameters)
        {
            Employee employee = null;

            switch (type.ToLower())
            {
                case "salaried":
                case "штатний":
                    if (parameters.Length >= 2)
                    {
                        employee = new SalariedEmployee(
                            name,
                            address,
                            (decimal)parameters[0],
                            (decimal)parameters[1]
                        );
                    }
                    break;

                case "hourly":
                case "погодинний":
                    if (parameters.Length >= 2)
                    {
                        employee = new HourlyEmployee(
                            name,
                            address,
                            (decimal)parameters[0],
                            (decimal)parameters[1]
                        );
                    }
                    break;

                case "contract":
                case "контрактний":
                    if (parameters.Length >= 2)
                    {
                        employee = new ContractEmployee(
                            name,
                            address,
                            (decimal)parameters[0],
                            (int)parameters[1]
                        );
                    }
                    break;

                default:
                    throw new ArgumentException($"Невідомий тип працівника: {type}");
            }

            if (employee != null)
            {
                employees.Add(employee);
                Console.WriteLine($"✓ Додано {employee.GetEmployeeType()} працівника: {name}");
            }
        }
        // 7. Розрахунок зарплати (поліморфізм)
        public static decimal CalculateSalary(Employee employee)
        {
            return employee.CalculateMonthlySalary();
        }
        // 8. Звіт про заробітну плату
        public static void GeneratePayrollReport()
        {
            Console.WriteLine("\n" + new string('=', 80));
            Console.WriteLine("ЗВІТ ПРО ЗАРОБІТНУ ПЛАТУ ЗА МІСЯЦЬ");
            Console.WriteLine(new string('=', 80));
            Console.WriteLine($"{"Ім'я",-25} {"Тип",-15} {"Зарплата",-12} {"Податок",-12} {"На руки",-12}");
            Console.WriteLine(new string('-', 80));

            decimal totalSalary = 0;
            decimal totalTax = 0;

            foreach (var emp in employees)
            {
                decimal salary = CalculateSalary(emp);
                decimal taxRate = emp is ContractEmployee ? 0.10m : 0.20m;
                decimal tax = salary * taxRate;
                decimal netSalary = salary - tax;

                Console.WriteLine($"{emp.Name,-25} {emp.GetEmployeeType(),-15} {salary,12:C2} {tax,12:C2} {netSalary,12:C2}");

                totalSalary += salary;
                totalTax += tax;
            }

            Console.WriteLine(new string('-', 80));
            Console.WriteLine($"{"Всього",-40} {totalSalary,12:C2} {totalTax,12:C2} {(totalSalary - totalTax),12:C2}");
            Console.WriteLine(new string('=', 80));
        }
        public List<Employee> GetEmployees() => employees;


    }

}

