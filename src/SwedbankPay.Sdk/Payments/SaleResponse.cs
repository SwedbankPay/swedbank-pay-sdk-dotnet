namespace SwedbankPay.Sdk.Payments
{
    using SwedbankPay.Sdk.Transactions;

    using System;

    public class SaleResponse
    {
        public DateTime Date { get; }
        public string PayerAlias { get; }
        public string SwishPaymentReference { get; }
        public string SwishStatus { get; }

        public string Id { get; }
        public TransactionResponse Transaction { get; }


        public SaleResponse(DateTime date,
                            string payerAlias,
                            string swishPaymentReference,
                            string swishStatus,
                            string id,
                            TransactionResponse transaction)
        {
            Date = date;
            PayerAlias = payerAlias;
            SwishPaymentReference = swishPaymentReference;
            SwishStatus = swishStatus;
            Id = id;
            Transaction = transaction;
        }
    }
}