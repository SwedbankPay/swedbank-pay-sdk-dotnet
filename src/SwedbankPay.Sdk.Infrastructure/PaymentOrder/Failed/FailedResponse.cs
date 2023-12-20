using SwedbankPay.Sdk.PaymentOrder.Failed;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.Failed;

internal record FailedResponse : Identifiable, IFailedResponse
{
    public IProblem? Problem { get; }

    internal FailedResponse(FailedResponseDto dto) : base(dto.Id)
    {
        Problem = dto.Problem?.Map();
    }
}