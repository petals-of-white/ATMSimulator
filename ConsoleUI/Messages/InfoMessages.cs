using ATMLibrary;
using ATMLibrary.BankAccounts;
using ConsoleUI.Enums;
using ConsoleUI.Selectors;

namespace ConsoleUI.Messages
{
    internal static class InfoMessages
    {
        internal static void ShowAvailableATMS()
        {
            Console.WriteLine("Оберіть один із банкматів нижче (введіть порядковий номер)");
            foreach (var ATM in ATMSelector.ATMs)
            {
                Console.WriteLine($"{ATMSelector.ATMs.IndexOf(ATM) + 1}. {ATM.Name}");
            }

            Console.WriteLine();
        }
        internal static void Greeting()
        {
            Console.WriteLine($"Вітання!");
        }
        internal static void CardRemoved(object? sender, BankAccount e)
        {
            Console.WriteLine("Картку успішно витягнуто");

        }
        internal static void PinSuccessfullyEntered(object? sender, BankAccount e)
        {
            Console.WriteLine("ПІН-код уведено правильно");
        }
        internal static void MoneySuccessfullyWithdrawn(object? sender, decimal e)
        {
            Console.WriteLine($"Успішно знято {e} гривень");

        }
        internal static void CardInserted(object? sender, BankAccount account)
        {

            Console.WriteLine("Картку успішно вставлено");
        }
        internal static void GreetingATMMessage()
        {
            Console.WriteLine($"Вас вітає банкомат! Уставте картку, щоб продовжити...");
        }
        internal static void GoodbyeMessage()
        {
            Console.WriteLine("Дякуємо за візит. На все добре");
        }
        internal static string? AskForPin()
        {
            Console.Write("Уведіть PIN: ");
            return Console.ReadLine();
        }
        internal static void StartOperation(Operations operation, ATM atm)
        {
            switch (operation)
            {
                case Operations.Withdraw:
                    StartWithdrawing(atm);
                    break;
                case Operations.BalanceToScreen:
                    StartBalance(atm);
                    break;
            }
        }
        internal static void StartBalance(ATM atm)
        {
            Console.WriteLine($"Ваш баланс: {atm.GetBalance()}");
        }
        internal static void StartWithdrawing(ATM atm)
        {
            Console.WriteLine("Скільки грошей бажаєте зняти?: ");
            decimal amountToWithdraw;

            bool parseRes = decimal.TryParse(Console.ReadLine(), out amountToWithdraw);

            while (parseRes == false)
            {
                WrongFormat();
                parseRes = decimal.TryParse(Console.ReadLine(), out amountToWithdraw);
            }

            atm.WithdrawMoney(amountToWithdraw);
            //return amountToWithdraw;
        }
        internal static Operations AskForOperation()
        {
            Operations operation;
            Console.WriteLine("Оберіть, що хочете зробити:\n1. Зняти готівку\n" +
                "2. Баланс на екран");
            bool parseResult = Enum.TryParse(Console.ReadLine(), out operation);

            while (parseResult == false)
            {
                WrongFormat();
                parseResult = Enum.TryParse(Console.ReadLine(), out operation);

            }
            return operation;


        }
        internal static decimal AskForAmountToWithdraw()
        {
            Console.WriteLine("Скільки грошей бажаєте зняти?: ");
            decimal amounToWithdraw;

            bool parseRes = decimal.TryParse(Console.ReadLine(), out amounToWithdraw);

            while (parseRes == false)
            {
                WrongFormat();
                parseRes = decimal.TryParse(Console.ReadLine(), out amounToWithdraw);
            }

            return amounToWithdraw;
        }
        internal static void ShowAvailableOperations()
        {
            Console.WriteLine("Оберіть, що хочете зробити:\n1. Зняти готівку\n" +
                "3. Баланс на екран");
        }
        internal static void WrongPIN(object? sender, BankAccount e)
        {
            Console.WriteLine("Неправильний PIN!");
        }
        internal static void WrongCardMessage()
        {
            Console.WriteLine("Картка не існує!");
        }
        internal static void ShowAvailableCards()
        {
            Console.WriteLine($"(Оберіть одну з карток, введіть номер :)");

            foreach (var account in CardSelector.BankAccounts)
            {
                Console.WriteLine(account.AccountNumber);
            }
            Console.WriteLine();

        }
        internal static bool AskToContinue()
        {
            Console.WriteLine("Продовжити операції чи завершити роботу? (y / n)");

            switch (Console.ReadLine())
            {
                case "y":
                    return true;
                case "n":
                    return false;
                default:
                    return false;
            }
        }
        internal static void NoMoney()
        {
            Console.WriteLine("Недостатьно грошей на рахунку.");

        }
        internal static void WrongFormat()
        {
            Console.WriteLine("Неправильний формат даних, спробуйте знову: ");
        }

    }
}
