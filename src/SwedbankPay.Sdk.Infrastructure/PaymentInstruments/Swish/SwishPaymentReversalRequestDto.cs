namespace SwedbankPay.Sdk.PaymentInstruments.Swish;

internal class SwishPaymentReversalRequestDto
{
    public SwishPaymentReversalRequestDto(SwishPaymentReversalRequest payload)
    {
        Transaction = new SwishPaymentReversalTransactionDto(payload.Transaction);
    }

    public SwishPaymentReversalTransactionDto Transaction { get; }
}