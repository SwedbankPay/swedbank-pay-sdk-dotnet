using SwedbankPay.Sdk.PaymentOrder;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder;

internal class PaymentOrderResponse : IPaymentOrderResponse
{
    internal PaymentOrderResponse(PaymentOrderResponseDto paymentOrderResponseDto, HttpClient httpClient)
    {
        PaymentOrder = new PaymentOrder(paymentOrderResponseDto.PaymentOrder);
        Operations = new PaymentOrderOperations(paymentOrderResponseDto.Operations.Map(), httpClient);
    }

    public IPaymentOrder PaymentOrder { get; }

    public IPaymentOrderOperations Operations { get; }
}