using SwedbankPay.Sdk.PaymentInstruments;

namespace SwedbankPay.Sdk;

internal class PaymentAbortRequestDto
{
    public PaymentAbortRequestDto(PaymentAbortRequest payload)
    {
        Payment = payload.Payment;
    }

    public PaymentAbortRequestDetails Payment { get; }
}