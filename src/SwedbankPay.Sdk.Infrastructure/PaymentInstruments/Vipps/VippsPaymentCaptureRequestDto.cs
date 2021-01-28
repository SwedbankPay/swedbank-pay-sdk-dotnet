namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    internal class VippsPaymentCaptureRequestDto
    {
        public VippsPaymentCaptureRequestDto(VippsPaymentCaptureRequest payload)
        {
            Transaction = new CaptureTransactionDto(payload.Transaction);
        }

        public CaptureTransactionDto Transaction { get; }
    }
}