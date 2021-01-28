namespace SwedbankPay.Sdk.PaymentOrders
{
    internal class PaymentOrderReversalRequestDto
    {
        public PaymentOrderReversalRequestDto(PaymentOrderReversalRequest payload)
        {
            Transaction = new PaymentOrderReversalTransactionDto(payload.Transaction);
        }

        public PaymentOrderReversalTransactionDto Transaction { get; }
    }
}