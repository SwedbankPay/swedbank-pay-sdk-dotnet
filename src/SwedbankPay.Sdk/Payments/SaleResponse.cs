namespace SwedbankPay.Sdk.Payments
{
    using SwedbankPay.Sdk.Transactions;

    using System;

    public class SaleResponse
    {
        public DateTime Date { get; protected set; }
        public string PayerAlias { get; protected set; }
        public string SwishPaymentReference { get; protected set; }
        public string SwishStatus { get; protected set; }

        public string Id { get; protected set; }
        public TransactionResponse Transaction { get; protected set; }

    }
}