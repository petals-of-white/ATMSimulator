using ATMLibrary.BankAccounts;

namespace ATMLibrary.Validators
{
    internal class TransactionValidator : ITransactionValidator
    {
        public void ValidateWithdrawal(BankAccount account, decimal amountToWithdraw)
        {
            if (amountToWithdraw > account.Balance)
            {
                throw new ArgumentException("Can not withdraw more money than you have", "amountToWithdraw");
            }
        }

        public void ValidateDepositAddition(BankAccount account, decimal amount)
        {
            //Validating deposit addition
        }

    }
}
