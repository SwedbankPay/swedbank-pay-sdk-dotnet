namespace SwedbankPay.Sdk.PaymentOrders
{
    internal class PaymentOrderRequestDto
    {
        public PaymentOrderRequestDto(PaymentOrderRequest paymentOrderRequest)
        {
            PaymentOrder = new PaymentOrderRequestDetailsDto(paymentOrderRequest.PaymentOrder);
        }

        public PaymentOrderRequestDetailsDto PaymentOrder { get; }
    }
}