// See https://aka.ms/new-console-template for more information
using ATMLibrary;
using ATMLibrary.BankAccounts;
using ConsoleUI.Enums;
using ConsoleUI.Messages;
using ConsoleUI.Selectors;

InfoMessages.Greeting();

bool finishEverything = false;

while (finishEverything == false)
{
    InfoMessages.ShowAvailableATMS();

    int atmIndex;
    bool parseRes = int.TryParse(Console.ReadLine(), out atmIndex);

    while (parseRes == false)
    {
        InfoMessages.WrongFormat();
        parseRes = int.TryParse(Console.ReadLine(), out atmIndex);
    }
    ATM? selectedATM = ATMSelector.Select(atmIndex);

    if (selectedATM != null)
    {
        selectedATM.CardInsertedEvent += InfoMessages.CardInserted;
        selectedATM.CardRemovedEvent += InfoMessages.CardRemoved;
        selectedATM.MoneyWithdrawnEvent += InfoMessages.MoneySuccessfullyWithdrawn;
        selectedATM.PinEnteredEvent += InfoMessages.PinSuccessfullyEntered;
        selectedATM.WrongPinEvent += InfoMessages.WrongPIN;
        InfoMessages.GreetingATMMessage();

        while (!finishEverything)
        {
            InfoMessages.ShowAvailableCards();

            string selectedCardNumber = Console.ReadLine();
            BankAccount? myCard = CardSelector.Select(selectedCardNumber);

            if (myCard != null)
            {
                selectedATM.InsertCard(myCard);

                if (selectedATM.EnterPIN(InfoMessages.AskForPin()))
                {
                    while (true)
                    {
                        try
                        {
                            Operations operation = InfoMessages.AskForOperation();
                            InfoMessages.StartOperation(operation, selectedATM);

                            //selectedATM.WithdrawMoney(InfoMessages.AskForAmountToWithdraw());
                        }
                        catch (ArgumentException ex)
                        {
                            InfoMessages.NoMoney();
                        }

                        if (InfoMessages.AskToContinue() == false)
                        {
                            finishEverything = true;
                            break;
                        }
                    }



                }
                else
                {
                    selectedATM.GiveCardBack();
                    finishEverything = true;
                    break;
                }
                //InfoMessages.ShowAvailableOperations();
                //int selectedOperation = Convert.ToInt32(Console.ReadLine());
            }
            else
            {

                InfoMessages.WrongCardMessage();

                if (InfoMessages.AskToContinue() == false)
                {
                    finishEverything = true;
                    continue;
                }

            }
        }
    }

    else
    {
        if (finishEverything == true)
            break;
        if (InfoMessages.AskToContinue() == false)
        {
            break;
        }
    }
}


InfoMessages.GoodbyeMessage();
Console.ReadKey();
