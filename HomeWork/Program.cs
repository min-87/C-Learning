using System.ComponentModel.Design;

short[] numbers = new short[10];
Random random = new Random();

for (byte i = 0; i < numbers.Length; i++)
{
    numbers[i] = Convert.ToInt16(random.Next(-50, 50));
    Console.WriteLine($"El: {numbers[i]}");
}
Console.WriteLine("Enter you want to find in numbers (positive/negative): ");
Console.WriteLine("If you want to find index positive element enter True, otherwise enter False");

string userInput = Console.ReadLine();
if (userInput != null)
{
    FindIndexFirstPositiveOrNegativeElemInNumbers(numbers, userInput);
}
else
{
    Console.WriteLine("No input provided.");
}

void FindIndexFirstPositiveOrNegativeElemInNumbers(short[] numbers, string userInput = "True")
{
    if (userInput.Equals("False", StringComparison.OrdinalIgnoreCase))
    {
        for (byte i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] < 0)
            {
                Console.WriteLine($"Index of first negative element: {i}");
                return;
            }
        }
        Console.WriteLine("No negative element found.");
    }
    else
    {
        for (byte i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] >= 0)
            {
                Console.WriteLine($"Index of first positive element: {i}");
                return;
            }
        }
        Console.WriteLine("No positive element found.");
    }
}
