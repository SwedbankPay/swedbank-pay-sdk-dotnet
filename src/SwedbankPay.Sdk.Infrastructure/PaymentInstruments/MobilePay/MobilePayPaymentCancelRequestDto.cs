namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay;

internal class MobilePayPaymentCancelRequestDto
{
    public MobilePayPaymentCancelRequestDto(MobilePayPaymentCancelRequest payload)
    {
        Transaction = new CancelTransactionDto(payload.Transaction);
    }

    public CancelTransactionDto Transaction { get; }
}