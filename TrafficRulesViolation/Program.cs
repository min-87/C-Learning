public class TrafficRulesViolation
{
    public static void Main()
    {
        const float time = 0.5f;
        float distance = default;
        bool isInvalidInput = false;
        while (!isInvalidInput)
        {
            Console.WriteLine("Enter the number of miles driven:");
            var input = Console.ReadLine();
            if (!float.TryParse(input, out distance) || distance <= 0)
            {
                Console.WriteLine("Invalid input. Please enter the correct value.");
                continue;
            }
            isInvalidInput = true;
        }
        var velocity = distance / time;
        if (velocity > 45)
        {
            Console.WriteLine($"Velocity: {velocity} miles per hour. The driver violated the traffic rules.");
        }
        else
        {
            Console.WriteLine($"Velocity: {velocity} miles per hour. The driver did not violate the traffic rules.");
        }
    }
}

