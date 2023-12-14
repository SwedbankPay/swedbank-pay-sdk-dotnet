namespace SwedbankPay.Sdk.PaymentOrder.Models;

public class PayerResponse : Identifiable
{
    public Device? Device { get; }
    internal PayerResponse(PayerResponseDto dto) : base(dto.Id)
    {
        Device = dto.Device?.Map();
    }
}