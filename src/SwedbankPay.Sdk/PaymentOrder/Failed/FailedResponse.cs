namespace SwedbankPay.Sdk.PaymentOrder.Failed;

public record FailedResponse : Identifiable
{
    public Problem? Problem { get; }

    internal FailedResponse(FailedResponseDto dto) : base(dto.Id)
    {
        Problem = dto.Problem?.Map();
    }
}