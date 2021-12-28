using ATMLibrary.BankAccounts;
using ATMLibrary.SampleData;

namespace ConsoleUI.Selectors
{
    internal static class CardSelector
    {

        internal static List<BankAccount> BankAccounts = SampleDataCreator.SampleAccounts();

        public static BankAccount? Select(string accoutNumber)
        {
            BankAccount? selectedCard = BankAccounts.Find(x => x.AccountNumber == accoutNumber);
            return selectedCard;
        }
    }
}
