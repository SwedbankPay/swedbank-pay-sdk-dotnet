namespace SwedbankPay.Sdk.PaymentOrders
{
    internal class PaymentOrderUpdateRequestDto
    {
        public PaymentOrderUpdateRequestDto(PaymentOrderUpdateRequest payload)
        {
            PaymentOrder = new PaymentOrderUpdateRequestDetailsDto(payload.PaymentOrder);
        }

        public PaymentOrderUpdateRequestDetailsDto PaymentOrder { get; }
    }
}