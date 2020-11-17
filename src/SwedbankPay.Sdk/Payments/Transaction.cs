using System;

namespace SwedbankPay.Sdk.Payments
{
    public class Transaction
    {
        public Transaction(Uri id,
                           DateTime created,
                           DateTime updated,
                           TransactionType type,
                           State state,
                           string number,
                           Amount amount,
                           Amount vatAmount,
                           string description,
                           string payeeReference,
                           bool isOperational,
                           ProblemResponse problem,
                           OperationList operations,
                           string activity)
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
            Problem = problem;
            Operations = operations;
            Activity = activity;
        }


        public Amount Amount { get; }
        public DateTime Created { get; }
        public string Description { get; }
        public Uri Id { get; }
        public bool IsOperational { get; }
        public string Number { get; }
        public OperationList Operations { get; }
        public string PayeeReference { get; }
        public ProblemResponse Problem { get; }
        public State State { get; }
        public TransactionType Type { get; }
        public DateTime Updated { get; }
        public Amount VatAmount { get; }
        public string Activity { get; }
    }
}