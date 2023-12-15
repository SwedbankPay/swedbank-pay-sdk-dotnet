namespace SwedbankPay.Sdk.PaymentOrder.Payer;

internal record PayerResponseDto : IdentifiableDto
{
    public DeviceDto? Device { get; init; }
    
    public PayerResponseDto(string id) : base(id)
    {
    }

    public PayerResponse Map()
    {
        return new PayerResponse(this);
    }
}