namespace ATMLibrary
{
    public class Transaction
    {
        public DateTime DateOfTransaction = DateTime.Now;
        public decimal Amount;
        public decimal BalanceBefore;
        public decimal BalanceAfter;

        public Transaction(BankAccount account, decimal amountOfTransaction)
        {
            Amount = amountOfTransaction;
            BalanceBefore = account.Balance;

            account.Balance += amountOfTransaction;
            BalanceAfter = account.Balance + amountOfTransaction;

        }
    }
}
