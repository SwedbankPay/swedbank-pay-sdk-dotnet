using System;

namespace SwedbankPay.Sdk.Payments.Swish
{
    public class SaleResponse
    {
        public SaleResponse(Uri payment, Sale sale)
        {
            Payment = payment;
            Sale = sale;
        }

        public Uri Payment { get; }
        public Sale Sale { get; }
    }

    public class Sale
    {
        public Sale(DateTime date, string paymentRequestToken, Uri id, Transaction transaction)
        {
            Date = date;
            PaymentRequestToken = paymentRequestToken;
            Id = id;
            Transaction = transaction;
        }

        public DateTime Date { get; }
        public string PaymentRequestToken { get; }
        public Uri Id { get; }
        public Transaction Transaction { get; }
    }
}
