namespace SwedbankPay.Sdk.PaymentOrders
{
    using System;

    using SwedbankPay.Sdk.Payments;

    public class PaymentOrderResponse : IdLink
    {
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string Operation { get; set; }
        public State State { get; set; }
        public CurrencyCode Currency { get; set; }
        public long Amount { get; set; }
        public long VatAmount { get; set; }
        public long RemainingCaptureAmount { get; set; }
        public long RemainingCancellationAmount { get; set; }
        public long RemainingReversalAmount { get; set; }
        public string Description { get; set; }
        public string UserAgent { get; set; }
        public Language Language { get; set; }
        public Urls Urls { get; set; }
        public PayeeInfo PayeeInfo { get; set; }
        public IdLink Settings { get; set; }
        public IdLink Payments { get; set; }
        public OrderItems OrderItems { get; set; }
        public MetaDataContainer MetaData { get; set; }
        public Payer Payers { get; set; }
        public CurrentPaymentResponseContainer CurrentPayment { get; set; }
    }
}
