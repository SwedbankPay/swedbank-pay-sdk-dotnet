using SwedbankPay.Sdk.PaymentInstruments.MobilePay;
using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    public class SwishPaymentDto
    {
        public long Number { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string Instrument { get; set; }
        public string Operation { get; set; }
        public string Intent { get; set; }
        public string State { get; set; }
        public string Currency { get; set; }
        public PricesListResponseDto Prices { get; set; }
        public int Amount { get; set; }
        public int RemainingReversalAmount { get; set; }
        public string Description { get; set; }
        public string PayerReference { get; set; }
        public string InitiatingSystemUserAgent { get; set; }
        public string UserAgent { get; set; }
        public string Language { get; set; }
        public TransactionListResponseDto Transactions { get; set; }
        public SaleListResponseDto Sales { get; set; }
        public ReversalsListResponseDto Reversals { get; set; }
        public UrlsDto Urls { get; set; }
        public PayeeInfoDto PayeeInfo { get; set; }
        public Uri Id { get; set; }
        public MetadataResponse Metadata { get; set; }
    }
}