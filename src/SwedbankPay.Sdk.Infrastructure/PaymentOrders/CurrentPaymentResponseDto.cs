using SwedbankPay.Sdk.Common;
using SwedbankPay.Sdk.PaymentInstruments;
using System;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class CurrentPaymentResponseDto
    {
        public Uri PaymentOrder { get; }
        public string MenuElementName { get; }
        public PaymentResponseDto Payment { get; }

        internal ICurrentPaymentResponse Map()
        {
            var payment = new CurrentPaymentResponseObject(Payment)
            return new CurrentPaymentResponse(PaymentOrder, MenuElementName, Payment);
        }
    }

    public class PaymentResponseDto
    {
        public string Number { get; }
        public string Instrument { get; }
        public DateTime Created { get; }
        public DateTime Updated { get; }
        public int Amount { get; }
        public TransactionListResponseDto Authorizations { get; }
        public TransactionListResponseDto Cancellations { get; }
        public TransactionListResponseDto Captures { get; }
        public string Currency { get; }
        public string Description { get; }
        public string Intent { get; }
        public string Language { get; }
        public string Operation { get; }
        public PayeeInfoDto PayeeInfo { get; }
        public string PayerReference { get; }
        public string PaymentToken { get; }
        public PricesListResponseDto Prices { get; }
        public TransactionListResponseDto Reversals { get; }
        public string State { get; }
        public TransactionListResponseDto Transactions { get; }
        public IdLink Urls { get; }
        public string UserAgent { get; }
        public TransactionListResponseDto Sales { get; }
    }
}