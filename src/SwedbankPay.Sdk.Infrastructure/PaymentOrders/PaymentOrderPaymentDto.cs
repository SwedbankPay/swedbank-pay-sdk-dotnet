using SwedbankPay.Sdk.PaymentInstruments;
using System;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderPaymentDto
    {
        public string CorporationId { get; set; }
        public string Id { get; set; }
        public long Number { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string Instrument { get; set; }
        public string Operation { get; set; }
        public string Intent { get; set; }
        public string State { get; set; }
        public string Currency { get; set; }
        public PricesDto Prices { get; set; }
        public int Amount { get; set; }
        public int RemainingReversalAmount { get; set; }
        public string Description { get; set; }
        public string UserAgent { get; set; }
        public string Language { get; set; }
        public PaymentOrderTransactions Transactions { get; set; }
        public PaymentOrderAuthorizations Authorizations { get; set; }
        public PaymentOrderCaptures Captures { get; set; }
        public UrlsDto Urls { get; set; }
        public PaymentOrderPayeeInfoDto PayeeInfo { get; set; }
        public MetadataDto Metadata { get; set; }
    }
}