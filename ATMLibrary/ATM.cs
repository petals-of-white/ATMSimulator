namespace ATMLibrary
{
    public class ATM
    {
        public event EventHandler<EventArgs>? cardInsertedEvent;
        public event EventHandler<EventArgs>? cardRemovedEvent;


        private BankAccount? selectedAccount;
        public bool InsertCard(BankAccount bankCard)
        {
            bool res = false;
            if (selectedAccount == null)
            {
                selectedAccount = bankCard;
                cardInsertedEvent?.Invoke(this, new EventArgs());//
                return true;
            }

            return res;

        }
        public decimal? GetBalance()
        {
            return selectedAccount?.Balance;
        }

        public void WithdrawMoney(decimal amountOfMoney)
        {
            selectedAccount?.WithdrawMoney(amountOfMoney);
        }
        public bool GiveCardBack()
        {
            bool res = false;
            if (selectedAccount != null)
            {
                res = true;
                selectedAccount = null;
                cardInsertedEvent?.Invoke(this, new EventArgs());//

            }
            return res;
        }


    }
}
