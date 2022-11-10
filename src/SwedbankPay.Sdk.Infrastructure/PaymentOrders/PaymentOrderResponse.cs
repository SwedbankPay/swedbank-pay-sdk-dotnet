
using System.Net.Http;

namespace SwedbankPay.Sdk.PaymentOrders;

internal class PaymentOrderResponse : IPaymentOrderResponse
{
    public PaymentOrderResponse(PaymentOrderResponseDto paymentOrder, HttpClient httpClient)
    {
        Operations = new PaymentOrderOperations(paymentOrder.Operations.Map(), httpClient);
        PaymentOrder = new PaymentOrder(paymentOrder.PaymentOrder);
    }

    public IPaymentOrderOperations Operations { get; }

    public IPaymentOrder PaymentOrder { get; }
}