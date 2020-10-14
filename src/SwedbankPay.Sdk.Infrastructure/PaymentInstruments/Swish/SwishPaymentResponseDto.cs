using SwedbankPay.Sdk.Payments.SwishPayments;
using System;
using System.Globalization;

namespace SwedbankPay.Sdk.Payments
{
    public class SwishPaymentResponseDto
    {
        public string Number { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string Instrument { get; set; }
        public string Operation { get; set; }
        public string Intent { get; set; }
        public string State { get; set; }
        public CurrencyCode Currency { get; set; }
        public PricesListResponseDto Prices { get; set; }
        public int Amount { get; set; }
        public int RemainingReversalAmount { get; set; }
        public string Description { get; set; }
        public string PayerReference { get; set; }
        public string InitiatingSystemUserAgent { get; set; }
        public string UserAgent { get; set; }
        public CultureInfo Language { get; set; }
        public TransactionListResponseDto Transactions { get; set; }
        public SaleListResponseDto Sales { get; set; }
        public ReversalsListResponseDto Reversals { get; set; }
        public UrlsDto Urls { get; set; }
        public PayeeInfoDto PayeeInfo { get; set; }
        public Uri Id { get; set; }
        public MetadataResponse Metadata { get; set; }
    }
}