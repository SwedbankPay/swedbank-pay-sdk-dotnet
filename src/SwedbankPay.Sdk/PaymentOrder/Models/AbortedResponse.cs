namespace SwedbankPay.Sdk.PaymentOrder.Models;

public record AbortedResponse : Identifiable
{
    public string? AbortReason { get; }

    internal AbortedResponse(AbortedResponseDto dto) : base(dto.Id)
    {
        AbortReason = dto.AbortReason;
    }
}