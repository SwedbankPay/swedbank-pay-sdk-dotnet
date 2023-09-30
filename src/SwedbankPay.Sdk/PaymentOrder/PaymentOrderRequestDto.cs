namespace SwedbankPay.Sdk.PaymentOrder;

internal record PaymentOrderRequestDto
{
    internal PaymentOrderRequestDto(PaymentOrderRequest paymentOrderRequest)
    {
        PaymentOrder = new PaymentOrderDto(paymentOrderRequest);
    }

    public PaymentOrderDto PaymentOrder { get; set; }
}