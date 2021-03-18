namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    internal class SwishPaymentRequestDto
    {
        public SwishPaymentRequestDto()
        {
        }

        public SwishPaymentRequestDto(SwishPaymentRequest paymentRequest)
        {
            Payment = new SwishPaymentRequestDetailsDto(paymentRequest.Payment);
        }

        public SwishPaymentRequestDetailsDto Payment { get; }
    }
}