using SwedbankPay.Sdk.Common;
using SwedbankPay.Sdk.PaymentInstruments;
using System;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentResponseDto
    {
        public string Number { get; set; }
        public string Instrument { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public int Amount { get; set; }
        public AuthorizationTransactionResponseDto Authorizations { get; set; }
        public CancellationTransactionResponseDto Cancellations { get; set; }
        public CaptureTransactionResponseDto Captures { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
        public string Intent { get; set; }
        public string Language { get; set; }
        public string Operation { get; set; }
        public PayeeInfoDto PayeeInfo { get; set; }
        public string PayerReference { get; set; }
        public string PaymentToken { get; set; }
        public PricesListResponseDto Prices { get; set; }
        public ReversalTransactionListResponseDto Reversals { get; set; }
        public string State { get; set; }
        public TransactionListResponseDto Transactions { get; set; }
        public IdLink Urls { get; set; }
        public string UserAgent { get; set; }
        public SalesTransactionListResponseDto Sales { get; set; }
        public string Id { get; set; }
        public int RemainingReversalAmount { get; set; }
        public IdLink Metadata { get; set; }
    }
}