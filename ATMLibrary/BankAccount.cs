namespace ATMLibrary
{
    public class BankAccount
    {
        public string AccountNumber { get; init; }
        internal List<Transaction> transactions = new();
        internal string pin;
        internal decimal Balance = 0M;

        internal void WithdrawMoney(decimal amountToWithdraw)
        {
            if (amountToWithdraw > Balance)
            {
                throw new ArgumentException("Can not withdraw more than you have");

            }

            Transaction transaction = new(this, -amountToWithdraw);
            transactions.Add(transaction);

        }
        internal void AddDeposit(decimal amountToDeposit)
        {
            Transaction transaction = new(this, amountToDeposit);
            transactions.Add(transaction);
        }
    }
}
