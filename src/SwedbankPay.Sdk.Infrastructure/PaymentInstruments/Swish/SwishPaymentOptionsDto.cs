namespace SwedbankPay.Sdk.PaymentInstruments.Swish;

internal class SwishPaymentOptionsDto
{
    public SwishPaymentOptionsDto(SwishRequestData swish)
    {
        EnableEcomOnly = swish.EnableEcomOnly;
    }

    public bool EnableEcomOnly { get; set; }
}