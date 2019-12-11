using System;

using SwedbankPay.Sdk.Transactions;

namespace SwedbankPay.Sdk.Payments
{
    public class SaleResponse
    {
        public SaleResponse(DateTime date,
                            string payerAlias,
                            string swishPaymentReference,
                            string swishStatus,
                            Uri id,
                            TransactionResponse transaction)
        {
            Date = date;
            PayerAlias = payerAlias;
            SwishPaymentReference = swishPaymentReference;
            SwishStatus = swishStatus;
            Id = id;
            Transaction = transaction;
        }


        public DateTime Date { get; }

        public Uri Id { get; }
        public string PayerAlias { get; }
        public string SwishPaymentReference { get; }
        public string SwishStatus { get; }
        public TransactionResponse Transaction { get; }
    }
}