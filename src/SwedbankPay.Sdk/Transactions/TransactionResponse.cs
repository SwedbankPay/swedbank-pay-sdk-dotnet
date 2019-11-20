namespace SwedbankPay.Sdk.Transactions
{
    using System;

    public class TransactionResponse
    {
        public string Id { get; }
        public DateTime Created { get; }
        public DateTime Updated { get; }
        public string Type { get; }
        public string State { get; }
        public string Number { get; }
        public long Amount { get; }
        public long VatAmount { get; }
        public string Description { get; }
        public string PayeeReference { get; }
        public bool IsOperational { get; }


        public TransactionResponse(string id,
                                   DateTime created,
                                   DateTime updated,
                                   string type,
                                   string state,
                                   string number,
                                   long amount,
                                   long vatAmount,
                                   string description,
                                   string payeeReference,
                                   bool isOperational)
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
        }
    }
}
