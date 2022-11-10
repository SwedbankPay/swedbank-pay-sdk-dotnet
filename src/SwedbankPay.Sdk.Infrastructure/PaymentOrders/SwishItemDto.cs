namespace SwedbankPay.Sdk.PaymentOrders;

internal class SwishItemDto
{
    public SwishItemDto(Swish swish)
    {
        if(swish == null)
        {
            return;
        }

        EnableEcomOnly = swish.EnableEcomOnly;
    }

    public bool EnableEcomOnly { get; set; }
}