namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.Reversed;

internal record ReversedDetailsDto
{
    public string? Msisdn { get; set; }

    public ReversedDetails Map()
    {
        return new ReversedDetails
        {
            Msisdn = Msisdn
        };
    }
}