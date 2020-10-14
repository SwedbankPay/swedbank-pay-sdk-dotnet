using SwedbankPay.Sdk.Payments.SwishPayments;
using System;
using System.Globalization;

namespace SwedbankPay.Sdk.Payments
{
    public interface ISwishPayment
    {
        public string Number { get; }
        public DateTime Created { get; }
        public DateTime Updated { get; }
        public PaymentInstrument Instrument { get; }
        public Operation Operation { get; }
        public PaymentIntent Intent { get; }
        public State State { get; }
        public CurrencyCode Currency { get; }
        public IPricesListResponse Prices { get; }
        public Amount Amount { get; }
        public Amount RemainingReversalAmount { get; set; }
        public string Description { get; }
        public string PayerReference { get; }
        public string InitiatingSystemUserAgent { get; }
        public string UserAgent { get; }
        public CultureInfo Language { get; }
        public ITransactionListResponse Transactions { get; }
        public ISaleListResponse Sales { get; }
        public IReversalsListResponse Reversals { get; }
        public IUrls Urls { get; }
        public PayeeInfo PayeeInfo { get; }
        public Uri Id { get; }
        public MetadataResponse Metadata { get; }
    }
}