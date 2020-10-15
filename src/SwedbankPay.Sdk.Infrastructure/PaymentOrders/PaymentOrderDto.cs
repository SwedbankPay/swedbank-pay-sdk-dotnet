using SwedbankPay.Sdk.Common;
using System;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderDto
    {
        public int Amount { get; }
        public DateTime Created { get; }
        public string Currency { get; }
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