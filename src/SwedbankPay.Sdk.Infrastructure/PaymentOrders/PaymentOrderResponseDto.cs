using SwedbankPay.Sdk.Payments;
using System;
using System.Globalization;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderResponseDto
    {
        public int Amount { get; }
        public DateTime Created { get; }
        public CurrencyCode Currency { get; }
        public CurrentPaymentResponseDto CurrentPayment { get; }
        public string Description { get; }
        public string Language { get; }
        public MetadataResponse Metadata { get; }
        public string Operation { get; }
        public OrderItemsDto OrderItems { get; }
        public PayeeInfoDto PayeeInfo { get; }
        public PayerDtp Payers { get; }
        public IdLink Payments { get; }
        public int RemainingCancellationAmount { get; }
        public int RemainingCaptureAmount { get; }
        public int RemainingReversalAmount { get; }
        public IdLink Settings { get; }
        public string State { get; }
        public DateTime Updated { get; }
        public UrlsDto Urls { get; }
        public string UserAgent { get; }
        public int VatAmount { get; }
    }
}