namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay;

internal class MobilePayPaymentReversalRequestDto
{
    public MobilePayPaymentReversalRequestDto(MobilePayPaymentReversalRequest payload)
    {
        Transaction = new ReversalTransactionDto(payload.Transaction);
    }

    public ReversalTransactionDto Transaction { get; }
}