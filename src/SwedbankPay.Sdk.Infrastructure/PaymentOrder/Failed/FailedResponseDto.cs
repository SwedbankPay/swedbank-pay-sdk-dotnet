using SwedbankPay.Sdk.PaymentOrder.Failed;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.Failed;

internal record FailedResponseDto : IdentifiableDto
{
    public ProblemDto? Problem { get; init; }

    public FailedResponseDto(string id) : base(id)
    {
    }

    public IFailedResponse Map()
    {
        return new FailedResponse(this);
    }
}