using ATMSimulation.Domain.Enums;

namespace ATMSimulation.Domain.Entities
{
    public class Transaction
    {
        public Guid Id { get; private set; }
        public decimal Amount { get; private set; }
        public string Description { get; private set; }
        public DateTime TransactionDate { get; private set; }
        public TransactionType TransactionType { get; private set; }
        public Guid AccountId { get; private set; }
        public Account Account { get; set; }

        // For transfer transactions
        public string? ToAccountNumber { get; private set; }
        public string? FromAccountNumber { get; private set; }

        private Transaction() { }

        // Factory method for creating a transaction

        public static Transaction CreateDeposit(Guid accountId, decimal amount)
        {
            return new Transaction
            {
                Id = Guid.NewGuid(),
                AccountId = accountId,
                Amount = amount,
                Description = "Deposit",
                TransactionDate = DateTime.UtcNow,
                TransactionType = TransactionType.Deposit
            };
        }

        public static Transaction CreateWithdrawal(Guid accountId, decimal amount)
        {
            return new Transaction
            {
                Id = Guid.NewGuid(),
                AccountId = accountId,
                Amount = amount,
                Description = "Withdrawal",
                TransactionDate = DateTime.UtcNow,
                TransactionType = TransactionType.Withdrawal
            };
        }

        public static Transaction CreateTransferTo(Guid accountId, Guid toAccountId, decimal amount, string toAccountNumber)
        {
            return new Transaction
            {
                Id = Guid.NewGuid(),
                AccountId = accountId,
                Amount = amount,
                Description = $"Transfer to {toAccountNumber}",
                TransactionDate = DateTime.UtcNow,
                TransactionType = TransactionType.TransferOut,
                ToAccountNumber = toAccountNumber,
            };
        }

        public static Transaction ResiveTransferFrom(Guid accountId, Guid fromAccountId, decimal amount, string fromAccountNumber)
        {
            return new Transaction
            {
                Id = Guid.NewGuid(),
                AccountId = accountId,
                Amount = amount,
                Description = $"Transfer from {fromAccountNumber}",
                TransactionDate = DateTime.UtcNow,
                TransactionType = TransactionType.TransferIn,
                FromAccountNumber = fromAccountNumber,
            };
        }
    }
}