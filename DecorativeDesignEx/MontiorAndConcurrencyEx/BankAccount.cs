using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MontiorAndConcurrencyEx
{
    public class BankAccount
    {
        public double Balance { get; set; }
        public void Deposit(double deposit)
        {
            this.Balance += deposit;
            Console.WriteLine($"Deposited ${deposit}. Current balance: ${Balance}");
        }
        public void Withdrawl(double withdrawl)
        {
            if (withdrawl > this.Balance)
            {
                Console.WriteLine($"Insufficient funds. Current balance: ${Balance}. Attempted withdrawl: ${withdrawl}.");
            }
            else
            {
                this.Balance -= withdrawl;
                Console.WriteLine($"Withdrawn ${withdrawl}. Current balance: ${Balance}");
            }
        }
    }
}
