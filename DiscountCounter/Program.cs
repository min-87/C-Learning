public class DiscountCounter
{
    public static void Main()
    {
        double purchasePrice = default;
        bool isValidInput = false;
        while (!isValidInput)
        {
            Console.Write("Enter the cost of the purchase: ");
            var input = Console.ReadLine();
            if (!double.TryParse(input, out purchasePrice) || purchasePrice <= 0)
            {
                Console.WriteLine("Invalid input. Please enter the correct value.");
                continue;
            }
            isValidInput = true;
        }
        if (purchasePrice < 100)
        {
            var priceWithDiscount = purchasePrice - 0.05 * purchasePrice;
            Console.WriteLine($"Your discount is 5%, the amount to be paid is {priceWithDiscount}");
        }
        else if (purchasePrice >= 100 && purchasePrice < 200)
        {
            var priceWithDiscount = purchasePrice - 0.1 * purchasePrice;
            Console.WriteLine($"Your discount is 10%, the amount to be paid is {priceWithDiscount}");
        }
        else if (purchasePrice >= 200)
        {
            var priceWithDiscount = purchasePrice - 0.15 * purchasePrice;
            Console.WriteLine($"Your discount is 15%, the amount to be paid is {priceWithDiscount}");
        }
    }
}


