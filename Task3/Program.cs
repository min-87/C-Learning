namespace Task3;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            BankAccount account1 = BankAccount.CreateAccount(12345, 1000);
            Console.WriteLine($"Account Number: {account1.getAccountNumber()}, Balance: {account1.getBalance()}");
            account1.Deposit(500);
            Console.WriteLine($"After deposit, Balance: {account1.getBalance()}");
            account1.Withdraw(200);
            Console.WriteLine($"After withdrawal, Balance: {account1.getBalance()}");
            // Attempt to create an account with the same number
            BankAccount account2 = BankAccount.CreateAccount(12345, 500);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
