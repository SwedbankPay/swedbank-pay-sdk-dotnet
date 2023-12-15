namespace SwedbankPay.Sdk.PaymentOrder.Failed;

internal record FailedResponseDto : IdentifiableDto
{
    public ProblemDto? Problem { get; init; }

    public FailedResponseDto(string id) : base(id)
    {
    }

    public FailedResponse Map()
    {
        return new FailedResponse(this);
    }
}