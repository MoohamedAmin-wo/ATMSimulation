namespace ATMSimulation.Domain.Events;

public class MoneyWithdrawalEvent(Guid accountId, decimal amount)
{
    public Guid AccountId { get; set; } = accountId;
    public decimal Amount { get; set; } = amount;
}