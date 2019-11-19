namespace SwedbankPay.Sdk.Transactions
{
    using System;

    public class TransactionResponse
    {
        public string Id { get; protected set; }
        public DateTime Created { get; protected set; }
        public DateTime Updated { get; protected set; }
        public string Type { get; protected set; }
        public string State { get; protected set; }
        public string Number { get; protected set; }
        public long Amount { get; protected set; }
        public long VatAmount { get; protected set; }
        public string Description { get; protected set; }
        public string PayeeReference { get; protected set; }
        public bool IsOperational { get; protected set; }
    }
}
