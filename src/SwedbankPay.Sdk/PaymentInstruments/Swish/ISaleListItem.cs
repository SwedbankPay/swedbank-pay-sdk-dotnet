using System;

namespace SwedbankPay.Sdk.Payments.SwishPayments
{
    public interface ISaleListItem
    {
        public DateTime Date { get; }
        public Uri Id { get; }
        public string PayerAlias { get; }
        public string PaymentRequestToken { get; }
        public string SwishPaymentReference { get; }
        public string SwishStatus { get; }
        public ITransaction Transaction { get; }
    }
}