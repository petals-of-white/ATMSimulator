using ATMLibrary.Transactions;
using ATMLibrary.Validators;

namespace ATMLibrary.BankAccounts
{
    public class BankAccount
    {

        private string pin;

        internal List<Transaction> transactions = new();
        internal TransactionValidator Validator = new TransactionValidator();
        public string AccountNumber { get; init; }
        internal string PIN { get => pin; set => pin = value; }

        internal decimal Balance = 0M;

        internal void WithdrawMoney(decimal amountToWithdraw)
        {
            try
            {
                Validator.ValidateWithdrawal(this, amountToWithdraw);
                transactions.Add(new Transaction(this, -amountToWithdraw));
            }

            catch (ArgumentException ex)
            {
                throw;
            }

        }

        internal void AddDeposit(decimal amountToDeposit)
        {
            try
            {
                Validator.ValidateDepositAddition(this, amountToDeposit);
                transactions.Add(new Transaction(this, amountToDeposit));
            }
            catch (ArgumentException ex)
            {
                throw;
            }
        }
    }
}
