using SwedbankPay.Sdk.PaymentOrder.Aborted;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.Aborted;

internal record AbortedResponseDto : IdentifiableDto
{
    public string? AbortReason { get; init; }

    public AbortedResponseDto(string id) : base(id)
    {
    }

    public IAbortedResponse Map()
    {
        return new AbortedResponse(this);
    }
}