class Program
{
    static void Main(string[] args)
    {
        Console.Title = "Калькулятор об'єму та площі поверхні паралелепіпеда";
        Console.WriteLine("=== Калькулятор об'єму та площі поверхні паралелепіпеда ===\n");

        var color = Console.ForegroundColor;

        while (true)
        {
            Console.WriteLine("Оберіть, що потрібно обчислити:");
            Console.WriteLine("1 - Об'єм паралелепіпеда (V = a × b × c)");
            Console.WriteLine("2 - Площа поверхні паралелепіпеда (S = 2(ab + bc + ca))");
            Console.WriteLine("0 - Вийти з програми");
            Console.Write("\nВаш вибір: ");

            Console.ForegroundColor = ConsoleColor.Green;
            string choice = Console.ReadLine()?.Trim();
            Console.ForegroundColor = color;

            if (choice == "0")
            {
                Console.WriteLine("\nДякую за використання програми! До побачення.");
                break;
            }

            if (choice != "1" && choice != "2")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Помилка: Введіть лише 1, 2 або 0.\n");
                Console.ForegroundColor = color;
                continue;
            }

            // Введення трьох ребер (a, b, c)
            Console.WriteLine("\nВведіть розміри паралелепіпеда:");
            double a = GetValidPositiveNumber("Довжина a");
            double b = GetValidPositiveNumber("Ширина b");
            double c = GetValidPositiveNumber("Висота c");

            double result;
            string operationName;

            if (choice == "1")
            {
                // Об'єм: V = a * b * c
                result = a * b * c;
                operationName = "Об'єм паралелепіпеда";
            }
            else
            {
                // Площа поверхні: S = 2(ab + bc + ca)
                result = 2 * (a * b + b * c + c * a);
                operationName = "Площа поверхні паралелепіпеда";
            }

            Console.WriteLine("\n" + new string('=', 50));
            Console.WriteLine($"Результат:");
            Console.WriteLine($"{operationName}");
            Console.WriteLine($"a = {a:F4}, b = {b:F4}, c = {c:F4}");
            Console.WriteLine($"Результат = {result:F6}");
            Console.WriteLine($"Округлено = {result:F2}");
            Console.WriteLine(new string('=', 50));

            Console.WriteLine("\nНатисніть будь-яку клавішу для нового розрахунку...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    /// <summary>
    /// Запитує у користувача додатне число з надійною перевіркою введення
    /// </summary>
    static double GetValidPositiveNumber(string parameterName)
    {
        while (true)
        {
            Console.Write($"{parameterName} (> 0): ");

            Console.ForegroundColor = ConsoleColor.Green;
            string input = Console.ReadLine()?.Trim();
            Console.ForegroundColor = ConsoleColor.White;

            if (string.IsNullOrEmpty(input))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Помилка: Поле не може бути порожнім.");
                continue;
            }

            if (double.TryParse(input, out double value))
            {
                if (value > 0)
                {
                    return value; // Успішне введення
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Помилка: Значення має бути додатним числом (> 0).");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Помилка: Введено некоректне число!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Використовуйте кому (,) або крапку (.) для десяткових чисел.");
                Console.WriteLine("Приклад: 5,25   або   12.75");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Спробуйте ще раз.\n");
        }
    }
}

