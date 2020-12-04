namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    internal class SwishPaymentOptionsDto
    {
        public SwishPaymentOptionsDto(SwishPaymentOptions swish)
        {
            EnableEcomOnly = swish.EnableEcomOnly;
        }

        public bool EnableEcomOnly { get; set; }
    }
}