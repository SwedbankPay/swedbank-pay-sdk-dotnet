using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    public interface ISwishSaleListItem
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