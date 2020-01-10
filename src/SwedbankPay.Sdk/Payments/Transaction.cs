using System;

namespace SwedbankPay.Sdk.Payments
{
    public class Transaction
    {
        public Transaction(Uri id,
                           DateTime created,
                           DateTime updated,
                           string type,
                           State state,
                           string number,
                           Amount amount,
                           Amount vatAmount,
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


        public Amount Amount { get; }
        public DateTime Created { get; }
        public string Description { get; }
        public Uri Id { get; }
        public bool IsOperational { get; }
        public string Number { get; }
        public string PayeeReference { get; }
        public State State { get; }
        public string Type { get; }
        public DateTime Updated { get; }
        public Amount VatAmount { get; }
        public OperationList Operations { get; }
    }
}