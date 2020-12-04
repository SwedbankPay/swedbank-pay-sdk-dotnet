using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    internal class PaymentOrderRequestDetailsDto
    {
        public PaymentOrderRequestDetailsDto(PaymentOrderRequestDetails paymentOrder)
        {
            Amount = paymentOrder.Amount.InLowestMonetaryUnit;
            Currency = paymentOrder.Currency.ToString();
            Description = paymentOrder.Description;
            GenerateRecurrenceToken = paymentOrder.GenerateRecurrenceToken;
            Items = new List<ItemDto>();
            foreach (var item in paymentOrder.Items)
            {
                Items.Add(new ItemDto(item));
            }
            Language = paymentOrder.Language.ToString();
            Operation = paymentOrder.Operation.Value;
            OrderItems = new List<OrderItemDto>();
            foreach (var item in paymentOrder.OrderItems)
            {
                OrderItems.Add(new OrderItemDto(item));
            }
            PayeeInfo = new PayeeInfoDto(paymentOrder.PayeeInfo);
            Payer = new PayerDto(paymentOrder.Payer);
            RiskIndicator = new RiskIndicatorDto(paymentOrder.RiskIndicator);
            Urls = new UrlsDto(paymentOrder.Urls);
            UserAgent = paymentOrder.UserAgent;
            VatAmount = paymentOrder.VatAmount.InLowestMonetaryUnit;
            DisablePaymentMenu = paymentOrder.DisablePaymentMenu;
            Metadata = paymentOrder.Metadata;
        }

        public long Amount { get; }

        public string Currency { get; }

        public string Description { get; }

        public bool GenerateRecurrenceToken { get; }

        public List<ItemDto> Items { get; }

        public string Language { get; }

        public string Operation { get; }

        public List<OrderItemDto> OrderItems { get; }

        public PayeeInfoDto PayeeInfo { get; }

        public PayerDto Payer { get; }

        public RiskIndicatorDto RiskIndicator { get; }

        public UrlsDto Urls { get; }

        public string UserAgent { get; }

        public long VatAmount { get; }

        public bool? DisablePaymentMenu { get; }

        public Dictionary<string, object> Metadata { get; }
    }
}