using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    internal class InvoicePaymentDto
    {
        public long Amount { get; set; }
        public long VatAmount { get; set; }
        public long RemainingCaptureAmount { get; set; }
        public long RemainingCancellationAmount { get; set; }
        public long RemainingReversalAmount { get; set; }
        public InvoicePaymentAuthorizationListDto Authorizations { get; set; }
        public CancellationListResponseDto Cancellations { get; set; }
        public CaptureListResponseDto Captures { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
        public Uri Id { get; set; }
        public string Instrument { get; set; }
        public string Intent { get; set; }
        public string Language { get; set; }
        public long Number { get; set; }
        public string Operation { get; set; }
        public PayeeInfoDto PayeeInfo { get; set; }
        public string PayerReference { get; set; }
        public string InitiatingSystemUserAgent { get; set; }
        public PricesDto Prices { get; set; }
        public ReversalListResponseDto Reversals { get; set; }
        public string State { get; set; }
        public TransactionListResponseDto Transactions { get; set; }
        public UrlsDto Urls { get; set; }
        public string UserAgent { get; set; }
        public MetadataDto Metadata { get; set; }
    }
}