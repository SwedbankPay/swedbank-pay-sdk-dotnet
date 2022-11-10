namespace SwedbankPay.Sdk.PaymentInstruments.Vipps;

internal class VippsPaymentReversalRequestDto
{
    public VippsPaymentReversalRequestDto(VippsPaymentReversalRequest payload)
    {
        Transaction = new ReversalTransactionDto(payload.Transaction);
    }

    public ReversalTransactionDto Transaction { get; }
}