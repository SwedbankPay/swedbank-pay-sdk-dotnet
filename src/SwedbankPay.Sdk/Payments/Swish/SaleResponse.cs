using SwedbankPay.Sdk.Transactions;

using System;

namespace SwedbankPay.Sdk.Payments.Swish
{
    public class SaleResponse
    {
        public SaleResponse(DateTime date, string paymentRequestToken, Uri id, TransactionResponse transaction)
        {
            Date = date;
            PaymentRequestToken = paymentRequestToken;
            Id = id;
            Transaction = transaction;
        }

        public DateTime Date { get; }
        public string PaymentRequestToken { get; }
        public Uri Id { get; }
        public TransactionResponse Transaction { get; }
    }
}
