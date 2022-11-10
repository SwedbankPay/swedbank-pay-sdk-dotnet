namespace SwedbankPay.Sdk.PaymentInstruments.Vipps;

internal class VippsPaymentRequestDto
{
    public VippsPaymentRequestDto()
    {
    }

    public VippsPaymentRequestDto(VippsPaymentRequest paymentRequest)
    {
        Payment = new VippsPaymentRequestDetailsDto(paymentRequest.Payment);
    }

    public VippsPaymentRequestDetailsDto Payment { get; set; }
}