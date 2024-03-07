using SwedbankPay.Sdk.PaymentOrder.Payer;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.Payer;

internal record PayerResponseDto : IdentifiableDto
{
    public DeviceDto? Device { get; init; }
    public string? Reference { get; init; }
    public string? Name { get; init; }
    public string? Email { get; init; }
    public string? Msisdn { get; init; }
    public Dictionary<string, string>? HashedFields { get; init; }
    
    public PayerResponseDto(string id) : base(id)
    {
    }

    public IPayerResponse Map()
    {
        return new PayerResponse(this);
    }
}