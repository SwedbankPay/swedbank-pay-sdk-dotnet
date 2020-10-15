using SwedbankPay.Sdk.PaymentInstruments.MobilePay;
using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    public class SwishPaymentDto
    {
        public string Number { get; }
        public DateTime Created { get; }
        public DateTime Updated { get; }
        public string Instrument { get; }
        public string Operation { get; }
        public string Intent { get; }
        public string State { get; }
        public string Currency { get; }
        public PricesListResponseDto Prices { get; }
        public int Amount { get; }
        public int RemainingReversalAmount { get; set; }
        public string Description { get; }
        public string PayerReference { get; }
        public string InitiatingSystemUserAgent { get; }
        public string UserAgent { get; }
        public string Language { get; }
        public TransactionListResponseDto Transactions { get; }
        public SaleListResponseDto Sales { get; }
        public ReversalsListResponseDto Reversals { get; }
        public UrlsDto Urls { get; }
        public PayeeInfoDto PayeeInfo { get; }
        public Uri Id { get; }
        public MetadataResponse Metadata { get; }
    }
}