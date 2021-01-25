using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    internal class SwishPaymentDto
    {
        public long Number { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string Instrument { get; set; }
        public string Operation { get; set; }
        public string Intent { get; set; }
        public string State { get; set; }
        public string Currency { get; set; }
        public PriceListResponseDto Prices { get; set; }
        public long Amount { get; set; }
        public long RemainingReversalAmount { get; set; }
        public string Description { get; set; }
        public string PayerReference { get; set; }
        public string InitiatingSystemUserAgent { get; set; }
        public string UserAgent { get; set; }
        public string Language { get; set; }
        public TransactionListResponseDto Transactions { get; set; }
        public SaleListResponseDto Sales { get; set; }
        public ReversalListResponseDto Reversals { get; set; }
        public UrlsDto Urls { get; set; }
        public PayeeInfoDto PayeeInfo { get; set; }
        public string Id { get; set; }
        public MetadataDto Metadata { get; set; }
        public long VatAmount { get; set; }
        public long RemainingCancellationAmount { get; set; }
        public long RemainingCaptureAmount { get; set; }
        public CancellationListResponseDto Cancellations { get; set; }
        public CaptureListDto Captures { get; set; }
    }
}