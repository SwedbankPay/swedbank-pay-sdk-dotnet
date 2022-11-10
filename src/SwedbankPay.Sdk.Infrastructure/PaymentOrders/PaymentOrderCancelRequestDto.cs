namespace SwedbankPay.Sdk.PaymentOrders;

internal class PaymentOrderCancelRequestDto
{
    public PaymentOrderCancelRequestDto(PaymentOrderCancelRequest payload)
    {
        Transaction = new CancelTransactionDto(payload.Transaction);
    }

    public CancelTransactionDto Transaction { get; }
}