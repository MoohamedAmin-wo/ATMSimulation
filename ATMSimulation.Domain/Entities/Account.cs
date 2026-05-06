using ATMSimulation.Domain.Common;
using ATMSimulation.Domain.Enums;
using ATMSimulation.Domain.Events;

namespace ATMSimulation.Domain.Entities
{
    public class Account : EventBase
    {
        public Guid Id { get; set; }
        public AccountType AccountType { get; set; }
        public bool IsActive { get; set; }
        public decimal Balance { get; private set; }

        public Guid CustomerId { get;  set; }
        public Customer Customer { get; set; }
        public Guid CardId { get; set; }
        public Card Card { get; set; }


        public Account() {}
        public Account(decimal initialBalance)
        {
            if(initialBalance < 0)
                throw new ArgumentException("balance can't be negative !");
            Balance = initialBalance;
        }

        public string AccountNumber { get;private set; }

        private readonly List<Transaction> _transactions = new();
        public virtual IReadOnlyCollection<Transaction> Transactions => _transactions.AsReadOnly();



        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                return;
            Balance += amount;

            _transactions.Add(Transaction.CreateDeposit(Id , amount));

            AddDomainEvent(new MoneyDepositEvent(Id, amount));
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0 || amount > Balance) throw new Exception("Invalid withdrawal attemp !");
            Balance -= amount;

            _transactions.Add(Transaction.CreateWithdrawal(Id , amount));

            AddDomainEvent(new MoneyWithdrawalEvent(Id, amount));
        }

        public void TransferTo(Account toAccount, decimal amount)
        {
            if (toAccount == null) throw new ArgumentNullException(nameof(toAccount));
            if (amount <= 0 || amount > Balance) throw new Exception("Invalid transfer attemp !");
            Balance -= amount;
            toAccount.Balance += amount;
            _transactions.Add(Transaction.CreateTransferTo(Id , toAccount.Id, amount, toAccount.AccountNumber));
        }
    }
}
