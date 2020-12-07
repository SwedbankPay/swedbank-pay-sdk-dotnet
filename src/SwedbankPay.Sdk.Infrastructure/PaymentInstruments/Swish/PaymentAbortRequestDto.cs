namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    internal class PaymentAbortRequestDto
    {
        public PaymentAbortRequestDto(PaymentAbortRequest payload)
        {
            Payment = payload.Payment;
        }

        public PaymentAbortRequestDetails Payment { get; }
    }
}