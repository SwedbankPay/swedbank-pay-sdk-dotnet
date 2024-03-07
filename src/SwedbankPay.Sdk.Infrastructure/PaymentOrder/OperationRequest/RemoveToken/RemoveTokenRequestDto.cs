using SwedbankPay.Sdk.PaymentOrder.OperationRequest.RemoveToken;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.OperationRequest.RemoveToken;

internal record RemoveTokenRequestDto
{
    internal RemoveTokenRequestDto(RemoveTokenRequest payload)
    {
        State = payload.State.Value;
        Comment = payload.Comment;
    }
    
    public string State { get; }
    public string Comment { get; }
}