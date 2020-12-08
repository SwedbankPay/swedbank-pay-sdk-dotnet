namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    internal class MobilePayPaymentCaptureRequestDto
    {
        public MobilePayPaymentCaptureRequestDto(MobilePayPaymentCaptureRequest payload)
        {
            Transaction = new MobilePayPaymentCaptureTransactionDto(payload.Transaction);
        }

        public MobilePayPaymentCaptureTransactionDto Transaction { get; }
    }
}