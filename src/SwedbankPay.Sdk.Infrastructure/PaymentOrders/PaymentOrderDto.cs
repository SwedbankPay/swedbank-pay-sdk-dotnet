using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    internal class PaymentOrderDto
    {
        public string Id { get; set; }
        public int Amount { get; set; }
        public DateTime Created { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public MetadataResponse Metadata { get; set; }
        public string Operation { get; set; }
        public OrderItemsDto OrderItems { get; set; }
        public int RemainingCancelAmount { get; set; }
        public int RemainingCaptureAmount { get; set; }
        public int RemainingReversalAmount { get; set; }
        public Identifiable Settings { get; set; }
        public string State { get; set; }
        public DateTime Updated { get; set; }
        public UrlsDto Urls { get; set; }
        public string UserAgent { get; set; }
        public int VatAmount { get; set; }
        public string InitiatingSystemUserAgent { get; set; }
        public PaymentOrderPayeeInfoDto PayeeInfo { get; set; }
        public PayerDto Payer { get; set; }
        public PaymentOrderPaymentsDto Payments { get; set; }
        public PaymentOrderCurrentPaymentDto CurrentPayment { get; set; }
        public List<ItemDto> Items { get; set; }
    }
}