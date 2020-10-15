using System;

namespace SwedbankPay.Sdk.Payments
{
    public class TrustlyPaymentDto
    {
        public int Amount { get; }
        public DateTime Created { get; }
        public DateTime Updated { get; }
        public string Currency { get; }
        public string Description { get; }
        public Uri Id { get; }
        public string Instrument { get; }
        public string Intent { get; }
        public string Language { get; }
        public string Number { get; }
        public string Operation { get; }
        public PayeeInfoDto PayeeInfo { get; }
        public TransactionListResponseDto Transactions { get; }
        public string PayerReference { get; }
        public string InitiatingSystemUserAgent { get; }
        public PricesListResponseDto Prices { get; }
        public string State { get; }
        public UrlsDto Urls { get; }
        public string UserAgent { get; }
        public MetadataResponse Metadata { get; }
    }
}