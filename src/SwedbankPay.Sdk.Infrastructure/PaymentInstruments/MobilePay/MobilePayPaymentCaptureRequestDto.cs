namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    internal class MobilePayPaymentCaptureRequestDto
    {
        public MobilePayPaymentCaptureRequestDto(MobilePayPaymentCaptureRequest payload)
        {
            Transaction = new CaptureTransactionDto(payload.Transaction);
        }

        public CaptureTransactionDto Transaction { get; }
    }
}