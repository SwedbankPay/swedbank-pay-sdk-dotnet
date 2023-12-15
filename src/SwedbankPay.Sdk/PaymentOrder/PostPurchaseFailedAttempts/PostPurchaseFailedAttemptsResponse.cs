namespace SwedbankPay.Sdk.PaymentOrder.PostPurchaseFailedAttempts;

public record PostPurchaseFailedAttemptsResponse : Identifiable
{
    internal PostPurchaseFailedAttemptsResponse(PostPurchaseFailedAttemptsResponseDto dto) : base(dto.Id)
    {
    }
}