using System;
using System.Globalization;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderResponseObject : IdLink
    {
        public PaymentOrderResponseObject(Amount amount,
                                          DateTime created,
                                          CurrencyCode currency,
                                          CurrentPaymentResponse currentPayment,
                                          string description,
                                          CultureInfo language,
                                          MetadataResponse metadata,
                                          string operation,
                                          OrderItems orderItems,
                                          PayeeInfo payeeInfo,
                                          Payer payers,
                                          IdLink payments,
                                          Amount remainingCancellationAmount,
                                          Amount remainingCaptureAmount,
                                          Amount remainingReversalAmount,
                                          IdLink settings,
                                          State state,
                                          DateTime updated,
                                          IUrls urls,
                                          string userAgent,
                                          Amount vatAmount)
        {
            Amount = amount;
            Created = created;
            Currency = currency;
            CurrentPayment = currentPayment;
            Description = description;
            Language = language;
            Metadata = metadata;
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
        public CurrentPaymentResponse CurrentPayment { get; }
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