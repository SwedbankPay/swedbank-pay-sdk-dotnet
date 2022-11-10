using System;

namespace SwedbankPay.Sdk.PaymentOrders;

internal class PaymentOrderPaymentListDto
{
    public string Id { get; set; }
    public string Instrument { get; set; }
    public DateTime Created { get; set; }
}