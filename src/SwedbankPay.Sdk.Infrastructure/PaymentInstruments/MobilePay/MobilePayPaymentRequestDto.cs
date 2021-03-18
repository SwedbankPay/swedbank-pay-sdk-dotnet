namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    internal class MobilePayPaymentRequestDto
    {
        public MobilePayPaymentRequestDto(MobilePayPaymentRequest paymentRequest)
        {
            Payment = new MobilePayPaymentDetailsDto(paymentRequest.Payment);
            MobilePay = new MobilePayPaymentRequestDetailsDto(paymentRequest.MobilePay);
        }

        public MobilePayPaymentDetailsDto Payment { get; set; }

        public MobilePayPaymentRequestDetailsDto MobilePay { get; set; }
    }
}