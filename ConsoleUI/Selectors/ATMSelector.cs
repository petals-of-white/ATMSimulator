using ATMLibrary;
using ATMLibrary.SampleData;

namespace ConsoleUI.Selectors
{
    internal static class ATMSelector
    {

        internal static List<ATM> ATMs = SampleDataCreator.SampleATMS();

        public static ATM? Select(int atmNumber)
        {
            ATM? selectedATM = ATMs [atmNumber - 1];
            return selectedATM;
        }
    }
}
