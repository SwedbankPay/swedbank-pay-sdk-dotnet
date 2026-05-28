using System.Net;

using SwedbankPay.Sdk.PaymentOrder;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder;

internal class PaymentOrderResponse : IPaymentOrderResponse
{
    internal PaymentOrderResponse(PaymentOrderResponseDto paymentOrderResponseDto, HttpClient httpClient)
        : this(paymentOrderResponseDto, httpClient, HttpStatusCode.OK)
    {
    }

    internal PaymentOrderResponse(PaymentOrderResponseDto paymentOrderResponseDto, HttpClient httpClient, HttpStatusCode statusCode)
    {
        PaymentOrder = new PaymentOrder(paymentOrderResponseDto.PaymentOrder);
        Operations = new PaymentOrderOperations(paymentOrderResponseDto.Operations.Map(), httpClient);
        StatusCode = statusCode;
    }

    public IPaymentOrder PaymentOrder { get; }

    public IPaymentOrderOperations Operations { get; }

    public HttpStatusCode StatusCode { get; }
}
