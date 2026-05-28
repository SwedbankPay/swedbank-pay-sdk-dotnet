using System.Net;

using SwedbankPay.Sdk.PaymentOrder;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder;

internal class PaymentOrderResponse : IPaymentOrderResponse
{
    internal PaymentOrderResponse(PaymentOrderResponseDto paymentOrderResponseDto, HttpClient httpClient, HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        PaymentOrder = new PaymentOrder(paymentOrderResponseDto.PaymentOrder);
        Operations = new PaymentOrderOperations(paymentOrderResponseDto.Operations.Map(), httpClient);
        IsPending = statusCode == HttpStatusCode.Accepted;
    }

    public IPaymentOrder PaymentOrder { get; }

    public IPaymentOrderOperations Operations { get; }

    public bool IsPending { get; }
}
