using System;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderResponse : IdLink
    {
        public PaymentOrderResponse(Amount amount, DateTime created, CurrencyCode currency, CurrentPaymentResponseContainer currentPayment, string description, Language language, MetaDataContainer metaData, string operation, OrderItems orderItems, PayeeInfo payeeInfo, Payer payers, IdLink payments, Amount remainingCancellationAmount, Amount remainingCaptureAmount, Amount remainingReversalAmount, IdLink settings, State state, DateTime updated, Urls urls, string userAgent, Amount vatAmount)
        {
            Amount = amount;
            Created = created;
            Currency = currency;
            CurrentPayment = currentPayment;
            Description = description;
            Language = language;
            MetaData = metaData;
            Operation = operation;
            OrderItems = orderItems;
            PayeeInfo = payeeInfo;
            Payers = payers;
            Payments = payments;
            RemainingCancellationAmount = remainingCancellationAmount;
            RemainingCaptureAmount = remainingCaptureAmount;
            RemainingReversalAmount = remainingReversalAmount;
            Settings = settings;
            State = state;
            Updated = updated;
            Urls = urls;
            UserAgent = userAgent;
            VatAmount = vatAmount;
        }

        public Amount Amount { get; }
        public DateTime Created { get; }
        public CurrencyCode Currency { get; }
        public CurrentPaymentResponseContainer CurrentPayment { get; }
        public string Description { get; }
        public Language Language { get; }
        public MetaDataContainer MetaData { get; }
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
        public Urls Urls { get; }
        public string UserAgent { get; }
        public Amount VatAmount { get; }
    }
}