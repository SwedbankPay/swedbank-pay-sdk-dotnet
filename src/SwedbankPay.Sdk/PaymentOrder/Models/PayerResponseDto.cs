namespace SwedbankPay.Sdk.PaymentOrder.Models;

internal record PayerResponseDto : IdentifiableDto
{
    public DeviceDto? Device { get; set; }
    
    public PayerResponseDto(string id) : base(id)
    {
    }

    public PayerResponse Map()
    {
        return new PayerResponse(this);
    }
}