namespace ATMLibrary
{
    public interface ITransaction
    {
        DateTime DateOfTransaction { get; set ; }
        decimal Amount { get; set; }
        decimal BalanceBefore { get; set; }
        decimal BalanceAfter { get; set; }
    }
}
