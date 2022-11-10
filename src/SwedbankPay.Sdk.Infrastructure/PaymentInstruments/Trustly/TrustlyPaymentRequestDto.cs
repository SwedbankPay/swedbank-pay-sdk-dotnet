namespace SwedbankPay.Sdk.PaymentInstruments.Trustly;

internal class TrustlyPaymentRequestDto
{
    public TrustlyPaymentRequestDto(TrustlyPaymentRequest paymentRequest)
    {
        Payment = new TrustlyPaymentDetailsDto(paymentRequest.Payment);
    }

    public TrustlyPaymentDetailsDto Payment { get; set; }
}