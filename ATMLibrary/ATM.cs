using ATMLibrary.BankAccounts;

namespace ATMLibrary
{
    public class ATM
    {
        private decimal moneyInATM;

        public string Name;
        private BankAccount? selectedAccount;
        public bool Authorized { get; private set; }
        public event EventHandler<BankAccount>? CardInsertedEvent;
        public event EventHandler<BankAccount>? CardRemovedEvent;
        public event EventHandler<BankAccount>? PinEnteredEvent;
        public event EventHandler<decimal>? MoneyWithdrawnEvent;
        public event EventHandler<BankAccount>? WrongPinEvent;


        public ATM(decimal money, string name)
        {
            this.moneyInATM = money;
            this.Name = name;
        }
        public bool InsertCard(BankAccount bankCard)
        {
            bool res = false;
            if (selectedAccount == null)
            {
                selectedAccount = bankCard;
                CardInsertedEvent?.Invoke(this, selectedAccount);//
                return true;
            }
            return res;
        }

        public bool EnterPIN(string pin)
        {
            if (pin == selectedAccount?.PIN)
            {
                Authorized = true;
                PinEnteredEvent?.Invoke(this, selectedAccount);
                return true;
            }
            else
            {
                WrongPinEvent?.Invoke(this, selectedAccount);
                GiveCardBack();
                return false;
            }
        }

        public decimal? GetBalance()
        {
            if (Authorized == true)
                return selectedAccount?.Balance;
            else return null;
        }


        public void WithdrawMoney(decimal amountToWithdraw)
        {
            try
            {
                selectedAccount?.WithdrawMoney(amountToWithdraw);
                moneyInATM -= amountToWithdraw;
                MoneyWithdrawnEvent?.Invoke(this, amountToWithdraw);

            }
            catch (ArgumentException ex)
            {
                throw;
            }
        }
        public bool GiveCardBack()
        {
            bool res = false;
            if (selectedAccount != null)
            {
                //Вихід
                Authorized = false;
                CardRemovedEvent?.Invoke(this, selectedAccount);//
                selectedAccount = null;
                res = true;
            }
            return res;
        }


    }
}
