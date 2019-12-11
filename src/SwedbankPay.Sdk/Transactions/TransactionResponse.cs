using System;

using Newtonsoft.Json;

namespace SwedbankPay.Sdk.Transactions
{
    public class TransactionResponse
    {
        public TransactionResponse()
        {
        }


        [JsonConstructor]
        public TransactionResponse(string id,
                                   DateTime created,
                                   DateTime updated,
                                   string type,
                                   State state,
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
    }
}