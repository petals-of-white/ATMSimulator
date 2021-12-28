using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMLibrary.BankAccounts;

namespace ATMLibrary.Validators
{
    internal class TransactionValidator
    {
        internal void ValidateWithdrawal(BankAccount account, decimal amountToWithdraw)
        {
            if (amountToWithdraw > account.Balance)
            {
                throw new ArgumentException("Can not withdraw more money than you have", "amountToWithdraw");
            }
        }

        internal void ValidateDepositAddition(BankAccount account, decimal amount)
        {
            //Validating deposit addition
        }

    }
}
