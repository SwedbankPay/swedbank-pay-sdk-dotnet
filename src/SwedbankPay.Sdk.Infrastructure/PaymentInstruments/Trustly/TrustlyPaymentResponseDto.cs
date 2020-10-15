using System;
using System.Globalization;

namespace SwedbankPay.Sdk.Payments
{
    public class TrustlyPaymentResponseDto
    {
        public int Amount { get; }
        public DateTime Created { get; }
        public DateTime Updated { get; }
        public CurrencyCode Currency { get; }
        public string Description { get; }
        public Uri Id { get; }
        public PaymentInstrument Instrument { get; }
        public PaymentIntent Intent { get; }
        public CultureInfo Language { get; }
        public string Number { get; }
        public string Operation { get; }
        public PayeeInfoDto PayeeInfo { get; }
        public ITransactionListResponse Transactions { get; }
        public string PayerReference { get; }
        public string InitiatingSystemUserAgent { get; }
        public PricesListResponseDto Prices { get; }
        public string State { get; }
        public UrlsDto Urls { get; }
        public string UserAgent { get; }
        public MetadataResponse Metadata { get; }
    }
}