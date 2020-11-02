using System;
using System.Globalization;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public interface IPaymentOrder
    {
        public Amount Amount { get; }
        public DateTime Created { get; }
        public CurrencyCode Currency { get; }
        public ICurrentPaymentResponse CurrentPayment { get; }
        public string Description { get; }
        public CultureInfo Language { get; }
        public MetadataResponse Metadata { get; }
        public string Operation { get; }
        public OrderItems OrderItems { get; }
        public PayeeInfo PayeeInfo { get; }
        public Payer Payers { get; }
        public IdLink Payments { get; }
        public Amount RemainingCancellationAmount { get; }
        public Amount RemainingCaptureAmount { get; }
        public Amount RemainingReversalAmount { get; }
        public IdLink Settings { get; }
        public State State { get; }
        public DateTime Updated { get; }
        public IUrls Urls { get; }
        public string UserAgent { get; }
        public Amount VatAmount { get; }
        public Uri Id { get; }
    }
}