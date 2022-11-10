namespace SwedbankPay.Sdk.PaymentInstruments.Vipps;

internal class VippsPaymentCancelRequestDto
{
    public VippsPaymentCancelRequestDto(VippsPaymentCancelRequest payload)
    {
        Transaction = new CancelTransactionDto(payload.Transaction);
    }

    public CancelTransactionDto Transaction { get; }
}