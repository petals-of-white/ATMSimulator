using ATMLibrary.BankAccounts;

namespace ATMLibrary.SampleData
{
    public static class SampleDataCreator
    {
        public static List<BankAccount> SampleAccounts()
        {
            List<BankAccount> accounts = new();
            accounts.Add(new BankAccount { AccountNumber = "123456789", Balance = 100M, PIN = "1234" });
            accounts.Add(new BankAccount { AccountNumber = "987654321", Balance = 500M, PIN = "4321" });
            accounts.Add(new BankAccount { AccountNumber = "133722899", Balance = 1337M, PIN = "1337" });

            return accounts;
        }

        public static List<ATM> SampleATMS()
        {
            List<ATM> ATMS = new();
            ATMS.Add(new ATM(50000m, "SuperBank"));
            ATMS.Add(new ATM(3000m, "Speedwagon Foundaiton"));
            ATMS.Add(new ATM(2000m, "QMoney"));
            return ATMS;
        }
    }
}
