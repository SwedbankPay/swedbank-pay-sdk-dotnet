namespace SwedbankPay.Sdk.PaymentOrders
{
    internal class PaymentOrderCaptureRequestDto
    {
        public PaymentOrderCaptureRequestDto(PaymentOrderCaptureRequest payload)
        {
            Transaction = new PaymentOrderCaptureTransactionDto(payload.Transaction);
        }

        public PaymentOrderCaptureTransactionDto Transaction { get; }
    }
}