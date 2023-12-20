using SwedbankPay.Sdk.PaymentOrder.Payer;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.Payer;

internal record PayerResponse : Identifiable, IPayerResponse
{
    public IDevice? Device { get; }
    
    internal PayerResponse(PayerResponseDto dto) : base(dto.Id)
    {
        Device = dto.Device?.Map();
    }
}