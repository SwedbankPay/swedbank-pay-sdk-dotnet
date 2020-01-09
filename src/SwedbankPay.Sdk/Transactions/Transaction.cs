using System;

namespace SwedbankPay.Sdk.Transactions
{
    public class Transaction
    {
        public Transaction(string id,
                                   DateTime created,
                                   DateTime updated,
                                   string type,
                                   State state,
                                   string number,
                                   long amount,
                                   long vatAmount,
                                   string description,
                                   string payeeReference,
                                   bool isOperational,
                                   OperationList operations)
        {
            Id = id;
            Created = created;
            Updated = updated;
            Type = type;
            State = state;
            Number = number;
            Amount = amount;
            VatAmount = vatAmount;
            Description = description;
            PayeeReference = payeeReference;
            IsOperational = isOperational;
            Operations = operations;
        }


        public long Amount { get; }
        public DateTime Created { get; }
        public string Description { get; }
        public string Id { get; }
        public bool IsOperational { get; }
        public string Number { get; }
        public string PayeeReference { get; }
        public State State { get; }
        public string Type { get; }
        public DateTime Updated { get; }
        public long VatAmount { get; }
        public OperationList Operations { get; }
    }
}