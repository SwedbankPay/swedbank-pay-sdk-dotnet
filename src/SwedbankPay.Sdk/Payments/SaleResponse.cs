namespace SwedbankPay.Sdk.Payments
{
    using System;
    using SwedbankPay.Sdk.Transactions;

    public class SaleResponse
    {
        public DateTime Date { get; set; }
        public string PayerAlias { get; set; }
        public string SwishPaymentReference { get; set; }
        public string SwishStatus { get; set; }

        public string Id { get; set; }
        public TransactionResponse Transaction { get; set; }

    }
}