using SwedbankPay.Sdk.PaymentOrder;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.Payer;

internal record PayerResponse : Identifiable, IPayerResponse
{
    public IDevice? Device { get; }
    
    internal PayerResponse(PayerResponseDto dto) : base(dto.Id)
    {
        Device = dto.Device?.Map();
    }
}