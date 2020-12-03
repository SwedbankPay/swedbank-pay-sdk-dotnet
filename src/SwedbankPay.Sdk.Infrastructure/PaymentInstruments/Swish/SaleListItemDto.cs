using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    internal class SaleListItemDto
    {
        public DateTime Date { get; }
        public Uri Id { get; }
        public string PayerAlias { get; }
        public string PaymentRequestToken { get; }
        public string SwishPaymentReference { get; }
        public string SwishStatus { get; }
        public TransactionDto Transaction { get; }
    }
}