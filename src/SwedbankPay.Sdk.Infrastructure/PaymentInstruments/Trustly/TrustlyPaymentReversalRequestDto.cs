namespace SwedbankPay.Sdk.PaymentInstruments.Trustly;

internal class TrustlyPaymentReversalRequestDto
{
    public TrustlyPaymentReversalRequestDto(TrustlyPaymentReversalRequest payload)
    {
        Transaction = new ReversalTransactionDto(payload.Transaction);
    }

    public ReversalTransactionDto Transaction { get; }
}