using SwedbankPay.Sdk.PaymentOrder;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder;

internal record PaymentOrderRequestDto
{
    internal PaymentOrderRequestDto(PaymentOrderRequest paymentOrderRequest)
    {
        PaymentOrder = new PaymentOrderDto(paymentOrderRequest);
    }

    public PaymentOrderDto PaymentOrder { get; }
}