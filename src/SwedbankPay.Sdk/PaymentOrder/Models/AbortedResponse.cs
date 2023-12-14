namespace SwedbankPay.Sdk.PaymentOrder.Models;

public class AbortedResponse : Identifiable
{
    public string? AbortReason { get; }

    internal AbortedResponse(AbortedResponseDto dto) : base(dto.Id)
    {
        AbortReason = dto.AbortReason;
    }
}