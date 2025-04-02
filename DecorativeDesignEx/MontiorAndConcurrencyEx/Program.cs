namespace MontiorAndConcurrencyEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount bankAccount1 = new BankAccount();
            BankAccount bankAccount2 = new BankAccount();

            Console.WriteLine("Testing single thread.");
            bankAccount1.Deposit(500);
            bankAccount1.Withdrawl(250);
            bankAccount1.Withdrawl(400);

            Console.WriteLine("Testing multi-thread.");
            bankAccount2.Deposit(500);
            Parallel.Invoke(() =>
            {
                bankAccount2.Withdrawl(250);
            });
            Parallel.Invoke(() =>
            {
                bankAccount2.Withdrawl(400);
            });
        }
    }
}
