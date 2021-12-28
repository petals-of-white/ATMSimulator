namespace ATMLibrary.Transactions
{
    internal interface ITransaction
    {
        DateTime DateOfTransaction { get; init; }
        decimal Amount { get; init; }
        decimal BalanceBefore { get; init; }
        decimal BalanceAfter { get; init; }
    }
}
