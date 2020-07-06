using System;

namespace SwedbankPay.Sdk.Payments.TrustlyPayments
{
    public class TrustlyPaymentSaleResponse
    {
        public TrustlyPaymentSaleResponse(Uri payment, Sale sale)
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
        public Uri Id { get; }
        public string PaymentRequestToken { get; }
        public Transaction Transaction { get; }
    }
}
