using ATMLibrary.BankAccounts;

namespace ATMLibrary.Validators
{
    internal interface ITransactionValidator
    {
        void ValidateDepositAddition(BankAccount account, decimal amount);
        void ValidateWithdrawal(BankAccount account, decimal amountToWithdraw);
    }
}