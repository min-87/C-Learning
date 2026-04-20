using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        Console.Title = "Калькулятор об'єму та площі поверхні кулі";
        Console.WriteLine("=== Калькулятор об'єму та площі поверхні кулі ===\n");

        var color = Console.ForegroundColor;

        while (true)
        {
            Console.WriteLine("Оберіть, що потрібно обчислити:");
            Console.WriteLine("1 - Об'єм кулі (V = 4/3 * π * r³)");
            Console.WriteLine("2 - Площа поверхні кулі (S = 4 * π * r²)");
            Console.WriteLine("0 - Вийти з програми");
            Console.Write("\nВаш вибір: ");

            Console.ForegroundColor = ConsoleColor.Green;
            string choiceInput = Console.ReadLine()?.Trim();
            Console.ForegroundColor = color;

            if (choiceInput == "0")
            {
                Console.WriteLine("Дякую за використання програми! До побачення.");
                break;
            }

            if (choiceInput != "1" && choiceInput != "2")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Помилка: Введіть 1, 2 або 0.\n");
                Console.ForegroundColor = color;
                continue;
            }

            // Введення радіуса з перевіркою
            double radius = GetValidRadius();

            if (radius <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Радіус повинен бути додатним числом. Спробуйте ще раз.\n");
                Console.ForegroundColor = color;
                continue;
            }

            double result;
            string operationName;

            if (choiceInput == "1")
            {
                // Об'єм кулі: V = 4/3 * π * r³
                result = (4.0 / 3.0) * Math.PI * Math.Pow(radius, 3);
                operationName = "Об'єм кулі";
            }
            else
            {
                // Площа поверхні кулі: S = 4 * π * r²
                result = 4 * Math.PI * Math.Pow(radius, 2);
                operationName = "Площа поверхні кулі";
            }

            Console.WriteLine($"\nРезультат:");
            Console.WriteLine($"{operationName} при радіусі r = {radius:F4} становить:");
            Console.WriteLine($"{result:F6} одиниць³ (або одиниць² для площі)");
            Console.WriteLine($"Округлено: {result:F2}\n");

            Console.WriteLine("Натисніть будь-яку клавішу для нового розрахунку...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    /// <summary>
    /// Запитує радіус у користувача з повною перевіркою коректності введення
    /// </summary>
    static double GetValidRadius()
    {
        while (true)
        {
            Console.Write("Введіть радіус кулі (r > 0): ");

            Console.ForegroundColor = ConsoleColor.Green;
            string input = Console.ReadLine()?.Trim();
            Console.ForegroundColor = ConsoleColor.White;

            // Спроба перетворити рядок у число
            if (double.TryParse(input, out double radius))
            {
                if (radius > 0)
                {
                    return radius; // Успішне введення
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Помилка: Радіус має бути додатним числом (> 0).");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Помилка: Введено некоректне число. Використовуйте кому або крапку для десяткових.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Приклад правильного введення: 5,25 або 5.25");
            }
            Console.WriteLine("Спробуйте ще раз.\n");
        }
    }
}

