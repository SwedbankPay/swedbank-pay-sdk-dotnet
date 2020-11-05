using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    public class SiwshPaymentSale : ISiwshPaymentSale
    {
        public SiwshPaymentSale(DateTime created, DateTime updated, string paymentRequestToken, Uri id, ITransaction transaction)
        {
            Created = created;
            Updated = updated;
            PaymentRequestToken = paymentRequestToken;
            Id = id;
            Transaction = transaction;
        }


        public DateTime Created { get; }
        public DateTime Updated { get; }
        public Uri Id { get; }
        public string PaymentRequestToken { get; }
        public ITransaction Transaction { get; }
    }
}