using ATMLibrary.BankAccounts;

namespace ATMLibrary
{
    public class ATM
    {
        private decimal moneyInATM = 10000;
        private BankAccount? selectedAccount;
        public bool Authorized { get; private set; }
        public event EventHandler<EventArgs>? CardInsertedEvent;
        public event EventHandler<EventArgs>? CardRemovedEvent;
        public event EventHandler<EventArgs>? PinEnteredEvent;
        public event EventHandler<EventArgs>? MoneyWithdrawnEvent;


        public bool InsertCard(BankAccount bankCard)
        {
            bool res = false;
            if (selectedAccount == null)
            {
                selectedAccount = bankCard;
                CardInsertedEvent?.Invoke(this, new EventArgs());//
                return true;
            }
            return res;
        }

        public bool EnterPIN(string pin)
        {
            if (pin == selectedAccount?.PIN)
            {
                Authorized = true;
                PinEnteredEvent?.Invoke(this, new EventArgs());
                return true;
            }
            else
            {
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
                moneyInATM -=amountToWithdraw;
                MoneyWithdrawnEvent?.Invoke(this, new EventArgs());

            }
            catch (ArgumentException ex)
            {
                
            }
        }
        public bool GiveCardBack()
        {
            bool res = false;
            if (selectedAccount != null)
            {
                //Вихід
                Authorized = false;
                selectedAccount = null;

                res = true;

                CardRemovedEvent?.Invoke(this, new EventArgs());//

            }
            return res;
        }


    }
}
