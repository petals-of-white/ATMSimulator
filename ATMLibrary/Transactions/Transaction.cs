using ATMLibrary.BankAccounts;

namespace ATMLibrary.Transactions
{
    public class Transaction : ITransaction
    {
        //public DateTime DateOfTransaction = DateTime.Now;
        //public decimal Amount;
        //public decimal BalanceBefore;
        //public decimal BalanceAfter;

        public Transaction(BankAccount account, decimal amountOfTransaction)
        {
            Amount = amountOfTransaction;
            BalanceBefore = account.Balance;

            account.Balance += amountOfTransaction;
            BalanceAfter = account.Balance + amountOfTransaction;

        }

        public DateTime DateOfTransaction { get; init; }
        public decimal Amount { get; init; }
        public decimal BalanceBefore { get; init; }
        public decimal BalanceAfter { get; init; }
    }
}
