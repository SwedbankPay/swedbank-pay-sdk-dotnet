namespace SwedbankPay.Sdk.PaymentOrder.Models;

public class FailedResponse : Identifiable
{
    public Problem? Problem { get; }

    internal FailedResponse(FailedResponseDto dto) : base(dto.Id)
    {
        Problem = dto.Problem?.Map();
    }
}