namespace SwedbankPay.Sdk.PaymentOrder.Models;

public record PayerResponse : Identifiable
{
    public Device? Device { get; }
    internal PayerResponse(PayerResponseDto dto) : base(dto.Id)
    {
        Device = dto.Device?.Map();
    }
}