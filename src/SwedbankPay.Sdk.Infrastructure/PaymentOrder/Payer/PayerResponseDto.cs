using SwedbankPay.Sdk.PaymentOrder;

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