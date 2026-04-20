public class ChineseZodiacAnimal
{
    public static void Main()
    {
        bool isInvalidInput = false;
        int yearOfBirth = default;
        while (!isInvalidInput)
        {
            Console.WriteLine("Please enter your year of birth: ");
            var input = Console.ReadLine();
            if (!int.TryParse(input, out yearOfBirth) || yearOfBirth <= 0 || yearOfBirth > 10000)
            {
                Console.WriteLine("Invalid input. Please enter a number representing the year");
                continue;
            }
            isInvalidInput = true;
        }
        var zodiacIndex = yearOfBirth % 12;
        var zodiacName = string.Empty;
        switch (zodiacIndex)
        {
            case 0: zodiacName = "Monkey"; break;
            case 1: zodiacName = "Rooster"; break;
            case 2: zodiacName = "Dog"; break;
            case 3: zodiacName = "Pig"; break;
            case 4: zodiacName = "Rat"; break;
            case 5: zodiacName = "Ox"; break;
            case 6: zodiacName = "Tiger"; break;
            case 7: zodiacName = "Rabbit"; break;
            case 8: zodiacName = "Dragon"; break;
            case 9: zodiacName = "Snake"; break;
            case 10: zodiacName = "Horse"; break;
            case 11: zodiacName = "Goat"; break;
        }
        Console.WriteLine($"Your Chinese Zodiac animal is: {zodiacName}");
    }
}

