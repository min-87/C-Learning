class Program
{
    static void Main(string[] args)
    {
        Console.Title = "Калькулятор трикутної піраміди";
        Console.WriteLine("=== Калькулятор трикутної піраміди ===\n");

        var color = Console.ForegroundColor;

        while (true)
        {
            Console.WriteLine("Оберіть, що потрібно обчислити:");
            Console.WriteLine("1 - Об'єм піраміди");
            Console.WriteLine("2 - Площа поверхні піраміди");
            Console.WriteLine("0 - Вийти з програми");

            Console.ForegroundColor = ConsoleColor.Green;
            string choice = Console.ReadLine()?.Trim();
            Console.ForegroundColor = color;

            if (choice == "0")
            {
                Console.WriteLine("Дякую за використання програми! До побачення.");
                break;
            }

            if (choice != "1" && choice != "2")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Помилка: Введіть 1, 2 або 0.\n");
                Console.ForegroundColor = color;
                continue;
            }

            try
            {
                // Введення параметрів основи (трикутник)
                Console.WriteLine("\nВведіть параметри трикутної основи:");

                double a = ReadPositiveDouble("Довжина першої сторони основи (a): ");
                double b = ReadPositiveDouble("Довжина другої сторони основи (b): ");
                double c = ReadPositiveDouble("Довжина третьої сторони основи (c): ");

                // Перевірка нерівності трикутника
                if (!IsValidTriangle(a, b, c))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Помилка: Сторони не утворюють трикутник (порушено нерівність трикутника)!\n");
                    Console.ForegroundColor = color;
                    continue;
                }

                double height = ReadPositiveDouble("Висота піраміди (h): ");

                if (choice == "1")
                {
                    // Обчислення об'єму
                    double volume = CalculateVolume(a, b, c, height);
                    Console.WriteLine($"\nОб'єм піраміди: {volume:F4} куб. одиниць");
                }
                else if (choice == "2")
                {
                    // Для площі поверхні потрібні довжини бічних ребер або апофем, 
                    // але для спрощення розрахуємо площу бічних граней через висоту та основу
                    // Тут використовуємо спрощений підхід: площа основи + площі трьох бічних трикутників

                    double baseArea = CalculateTriangleArea(a, b, c);
                    double lateralArea = CalculateLateralSurfaceArea(a, b, c, height);

                    double totalSurfaceArea = baseArea + lateralArea;

                    Console.WriteLine($"\nПлоща основи: {baseArea:F4}");
                    Console.WriteLine($"Площа бічної поверхні: {lateralArea:F4}");
                    Console.WriteLine($"Загальна площа поверхні: {totalSurfaceArea:F4} кв. одиниць");
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Сталася помилка: {ex.Message}");
                Console.ForegroundColor = color;
            }

            Console.WriteLine("Натисніть будь-яку клавішу для нового розрахунку...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    // Читання додатного числа з перевіркою
    static double ReadPositiveDouble(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);

            Console.ForegroundColor = ConsoleColor.Green;
            string input = Console.ReadLine()?.Trim();
            Console.ForegroundColor = ConsoleColor.White;

            if (double.TryParse(input, out double value) && value > 0)
            {
                return value;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Помилка: Введіть додатне число!");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    // Перевірка, чи утворюють сторони трикутник
    static bool IsValidTriangle(double a, double b, double c)
    {
        return a + b > c && a + c > b && b + c > a;
    }

    // Обчислення площі трикутника за формулою Герона
    static double CalculateTriangleArea(double a, double b, double c)
    {
        double s = (a + b + c) / 2;
        return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
    }

    // Об'єм піраміди: V = (1/3) * S_осн * h
    static double CalculateVolume(double a, double b, double c, double h)
    {
        double baseArea = CalculateTriangleArea(a, b, c);
        return (1.0 / 3) * baseArea * h;
    }

    // Площа бічної поверхні (спрощений розрахунок через висоту піраміди)
    // Знаходимо відстань від центра основи до середини кожної сторони та використовуємо її як "апофему"
    static double CalculateLateralSurfaceArea(double a, double b, double c, double h)
    {
        double baseArea = CalculateTriangleArea(a, b, c);

        // Знаходимо радіус вписаного кола в основу (r)
        double semiPerimeter = (a + b + c) / 2;
        double r = baseArea / semiPerimeter;

        // Площа бічної поверхні ≈ периметр основи * (довжина апофеми)/2
        // Довжина апофеми = sqrt(h² + r²)
        double apothem = Math.Sqrt(h * h + r * r);
        double perimeter = a + b + c;

        return (perimeter * apothem) / 2;
    }
}


