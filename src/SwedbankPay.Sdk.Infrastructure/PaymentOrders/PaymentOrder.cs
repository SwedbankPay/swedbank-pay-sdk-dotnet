using System;
using System.Globalization;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrder : IPaymentOrder
    {
        public PaymentOrder(PaymentOrderDto paymentOrder)
        {
            Id = new Uri(paymentOrder.Id, UriKind.RelativeOrAbsolute);
            Amount = paymentOrder.Amount;
            Created = paymentOrder.Created;
            Currency = new CurrencyCode(paymentOrder.Currency);
            CurrentPayment = paymentOrder.CurrentPayment.Map();
            Description = paymentOrder.Description;
            Language = new CultureInfo(paymentOrder.Language);
            Metadata = paymentOrder.Metadata;
            Operation = paymentOrder.Operation;
            PayeeInfo = paymentOrder.PayeeInfo.Map();
            RemainingCancellationAmount = paymentOrder.RemainingCancellationAmount;
            RemainingCaptureAmount = paymentOrder.RemainingCaptureAmount;
            RemainingReversalAmount = paymentOrder.RemainingReversalAmount;
            Settings = paymentOrder.Settings;
            State = paymentOrder.State;
            Updated = paymentOrder.Updated;
            Urls = paymentOrder.Urls.Map();
            UserAgent = paymentOrder.UserAgent;
            VatAmount = paymentOrder.VatAmount;

            OrderItems = paymentOrder.OrderItems?.Map();
            Payers = paymentOrder.Payer?.Map();
            if (paymentOrder.Payments != null && string.IsNullOrEmpty(paymentOrder.Payments.Id))
                Payments = new IdLink() { Id = new Uri(paymentOrder.Payments.Id, UriKind.RelativeOrAbsolute) };
        }

        public Uri Id { get; }
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
    }
}