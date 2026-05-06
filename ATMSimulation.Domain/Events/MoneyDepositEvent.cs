namespace ATMSimulation.Domain.Events;
public class MoneyDepositEvent(Guid accountId, decimal amount)
{
    public Guid AccountId { get; set; } = accountId;
    public decimal Amount { get; set; } = amount;
}