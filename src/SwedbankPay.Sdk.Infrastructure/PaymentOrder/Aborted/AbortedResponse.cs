using SwedbankPay.Sdk.PaymentOrder.Aborted;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.Aborted;

internal record AbortedResponse : Identifiable, IAbortedResponse
{
    public string? AbortReason { get; }

    internal AbortedResponse(AbortedResponseDto dto) : base(dto.Id)
    {
        AbortReason = dto.AbortReason;
    }
}