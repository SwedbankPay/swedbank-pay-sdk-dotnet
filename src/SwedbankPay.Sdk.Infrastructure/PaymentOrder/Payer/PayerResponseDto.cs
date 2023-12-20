using SwedbankPay.Sdk.PaymentOrder.Payer;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.Payer;

internal record PayerResponseDto : IdentifiableDto
{
    public DeviceDto? Device { get; init; }
    
    public PayerResponseDto(string id) : base(id)
    {
    }

    public IPayerResponse Map()
    {
        return new PayerResponse(this);
    }
}