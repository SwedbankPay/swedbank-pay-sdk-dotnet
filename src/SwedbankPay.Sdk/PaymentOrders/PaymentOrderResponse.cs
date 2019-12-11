using System;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderResponse : IdLink
    {
        public Amount Amount { get; set; }
        public DateTime Created { get; set; }
        public CurrencyCode Currency { get; set; }
        public CurrentPaymentResponseContainer CurrentPayment { get; set; }
        public string Description { get; set; }
        public Language Language { get; set; }
        public MetaDataContainer MetaData { get; set; }
        public string Operation { get; set; }
        public OrderItems OrderItems { get; set; }
        public PayeeInfo PayeeInfo { get; set; }
        public Payer Payers { get; set; }
        public IdLink Payments { get; set; }
        public Amount RemainingCancellationAmount { get; set; }
        public Amount RemainingCaptureAmount { get; set; }
        public Amount RemainingReversalAmount { get; set; }
        public IdLink Settings { get; set; }
        public State State { get; set; }
        public DateTime Updated { get; set; }
        public Urls Urls { get; set; }
        public string UserAgent { get; set; }
        public Amount VatAmount { get; set; }
    }
}