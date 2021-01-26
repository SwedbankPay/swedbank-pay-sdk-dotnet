using System;

namespace SwedbankPay.Sdk.PaymentOrders
{
    internal class PaymentOrder : IPaymentOrder
    {
        public PaymentOrder(PaymentOrderDto paymentOrder)
        {
            Id = new Uri(paymentOrder.Id, UriKind.RelativeOrAbsolute);
            Amount = paymentOrder.Amount;
            Created = paymentOrder.Created;
            Currency = new Currency(paymentOrder.Currency);
            CurrentPayment = paymentOrder.CurrentPayment.Map();
            Description = paymentOrder.Description;
            Language = new Language(paymentOrder.Language);
            Metadata = paymentOrder.Metadata?.Map();
            Operation = paymentOrder.Operation;
            PayeeInfo = paymentOrder.PayeeInfo.Map();
            RemainingCancelAmount = paymentOrder.RemainingCancelAmount;
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
            {
                Payments = new Identifiable ( new Uri(paymentOrder.Payments.Id, UriKind.RelativeOrAbsolute) );
            }
        }

        public Uri Id { get; }
        public Amount Amount { get; }
        public DateTime Created { get; }
        public Currency Currency { get; }
        public ICurrentPaymentResponse CurrentPayment { get; }
        public string Description { get; }
        public Language Language { get; }
        public Metadata Metadata { get; }
        public string Operation { get; }
        public OrderItemListResponse OrderItems { get; }
        public IPayeeInfo PayeeInfo { get; }
        public PayerResponse Payers { get; }
        public Identifiable Payments { get; }
        public Amount RemainingCancelAmount { get; }
        public Amount RemainingCaptureAmount { get; }
        public Amount RemainingReversalAmount { get; }
        public Identifiable Settings { get; }
        public State State { get; }
        public DateTime Updated { get; }
        public IUrls Urls { get; }
        public string UserAgent { get; }
        public Amount VatAmount { get; }
    }
}