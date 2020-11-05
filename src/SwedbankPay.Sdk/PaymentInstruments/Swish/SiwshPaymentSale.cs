using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    public class SiwshPaymentSale : ISiwshPaymentSale
    {
        public SiwshPaymentSale(DateTime date, string paymentRequestToken, Uri id, ITransaction transaction)
        {
            Date = date;
            PaymentRequestToken = paymentRequestToken;
            Id = id;
            Transaction = transaction;
        }


        public DateTime Date { get; }
        public Uri Id { get; }
        public string PaymentRequestToken { get; }
        public ITransaction Transaction { get; }
    }
}